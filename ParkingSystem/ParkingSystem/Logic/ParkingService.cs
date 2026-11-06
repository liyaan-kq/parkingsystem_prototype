using System;
using System.Collections.Generic;
using System.Data;
using ParkingSystem.Helpers;
using red_framework;

namespace ParkingSystem.Logic
{
    public static class ParkingService
    {
        private const string ActiveSelect =
            "SELECT t.TransactionID, t.VehicleID, v.PlateNumber, v.VehicleType, v.OwnerName, " +
            "       t.SlotID, s.SlotNumber, t.EntryTime " +
            "FROM ParkingTransactions t " +
            "JOIN Vehicles v ON v.VehicleID = t.VehicleID " +
            "JOIN ParkingSlots s ON s.SlotID = t.SlotID " +
            "WHERE t.Status = 'Parked' ";

        public static List<VehicleInfo> GetVehicles()
        {
            return AppDb.Instance.QueryList<VehicleInfo>(
                "SELECT VehicleID, PlateNumber, VehicleType, OwnerName FROM Vehicles ORDER BY PlateNumber");
        }

        public static List<ActiveParking> GetActiveList()
        {
            return AppDb.Instance.QueryList<ActiveParking>(ActiveSelect + "ORDER BY t.EntryTime");
        }

        public static OperationResult ParkVehicle(string plate, string vehicleType, string ownerName, int slotId, DateTime entryTime)
        {
            IDatabase db = AppDb.Instance;
            string key = Validator.PlateKey(plate);
            OperationResult result = null;

            db.ExecuteTransaction(tran =>
            {
                ActiveParking active = db.QuerySingle<ActiveParking>(ActiveSelect + "AND v.PlateKey = @PlateKey", new { PlateKey = key });
                if (active != null)
                {
                    result = OperationResult.Fail(active.PlateNumber + " is already parked at " + active.SlotNumber + ". Process its exit first.");
                    return false;
                }

                DataTable slot = db.TableData(
                    "SELECT SlotNumber, Status FROM ParkingSlots WITH (UPDLOCK) WHERE SlotID = @SlotID",
                    new { SlotID = slotId });
                if (slot.Rows.Count == 0 || (string)slot.Rows[0]["Status"] != "Available")
                {
                    string number = slot.Rows.Count == 0 ? "" : slot.Rows[0]["SlotNumber"] + " ";
                    result = OperationResult.Fail("Slot " + number + "is no longer available. Please choose another slot.");
                    return false;
                }
                string slotNumber = (string)slot.Rows[0]["SlotNumber"];

                object existingId = db.Scalar("SELECT VehicleID FROM Vehicles WHERE PlateKey = @PlateKey", new { PlateKey = key });
                int vehicleId;
                if (existingId == null)
                {
                    vehicleId = Convert.ToInt32(db.Scalar(
                        "INSERT INTO Vehicles (PlateNumber, VehicleType, OwnerName) VALUES (@PlateNumber, @VehicleType, @OwnerName); " +
                        "SELECT CAST(SCOPE_IDENTITY() AS INT);",
                        new { PlateNumber = plate, VehicleType = vehicleType, OwnerName = ownerName }));
                }
                else
                {
                    vehicleId = Convert.ToInt32(existingId);
                    db.Update("Vehicles", new { VehicleID = vehicleId, VehicleType = vehicleType, OwnerName = ownerName }, "VehicleID");
                }

                db.Save("ParkingTransactions", new
                {
                    VehicleID = vehicleId,
                    SlotID = slotId,
                    EntryTime = entryTime,
                    Status = "Parked",
                    UpdatedAt = entryTime
                });
                db.Update("ParkingSlots", new { SlotID = slotId, Status = "Occupied", UpdatedAt = entryTime }, "SlotID");

                result = OperationResult.Ok(plate + " parked at " + slotNumber + " (" + entryTime.ToString("hh:mm tt") + ").");
                return true;
            });
            return result;
        }

        public static OperationResult<StubInfo> CompleteExit(ActiveParking parking, DateTime exitTime, int durationMinutes, decimal fee)
        {
            IDatabase db = AppDb.Instance;
            OperationResult<StubInfo> result = null;

            db.ExecuteTransaction(tran =>
            {
                int affected = db.CUD(
                    "UPDATE ParkingTransactions SET ExitTime = @ExitTime, DurationMinutes = @DurationMinutes, Fee = @Fee, " +
                    "       Status = 'Completed', UpdatedAt = @ExitTime " +
                    "WHERE TransactionID = @TransactionID AND Status = 'Parked'",
                    new { ExitTime = exitTime, DurationMinutes = durationMinutes, Fee = fee, parking.TransactionID });
                if (affected == 0)
                {
                    object status = db.Scalar("SELECT Status FROM ParkingTransactions WHERE TransactionID = @TransactionID",
                                              new { parking.TransactionID });
                    result = OperationResult<StubInfo>.Fail(status == null
                        ? "This parking record was deleted, so it can't be paid. The list has been refreshed."
                        : "This parking record was already paid. The list has been refreshed.");
                    return false;
                }

                db.Update("ParkingSlots", new { parking.SlotID, Status = "Available", UpdatedAt = exitTime }, "SlotID");

                string stubNo = Convert.ToString(db.Scalar(
                    "INSERT INTO CardStubs (TransactionID, IssuedAt) VALUES (@TransactionID, @IssuedAt); " +
                    "SELECT StubNo FROM CardStubs WHERE StubID = SCOPE_IDENTITY();",
                    new { parking.TransactionID, IssuedAt = exitTime }));

                StubInfo stub = new StubInfo
                {
                    StubNo = stubNo,
                    PlateNumber = parking.PlateNumber,
                    VehicleType = parking.VehicleType,
                    OwnerName = parking.OwnerName,
                    SlotNumber = parking.SlotNumber,
                    EntryTime = parking.EntryTime,
                    ExitTime = exitTime,
                    DurationMinutes = durationMinutes,
                    Fee = fee,
                    IssuedAt = exitTime
                };
                result = OperationResult<StubInfo>.Ok(
                    "Paid " + FeeCalculator.FormatMoney(fee) + " for " + parking.PlateNumber + ". Stub No. " + stubNo +
                    " issued. " + parking.SlotNumber + " is now free.", stub);
                return true;
            });
            return result;
        }
    }
}
