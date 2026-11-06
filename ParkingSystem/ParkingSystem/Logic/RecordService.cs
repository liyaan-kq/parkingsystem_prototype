using System;
using System.Data;
using ParkingSystem.Helpers;
using red_framework;

namespace ParkingSystem.Logic
{
    public static class RecordService
    {
        private const string DetailsSelect =
            "SELECT t.TransactionID, t.VehicleID, v.PlateNumber, v.VehicleType, v.OwnerName, t.SlotID, s.SlotNumber, " +
            "       t.EntryTime, t.ExitTime, t.DurationMinutes, t.Fee, t.Status, t.UpdatedAt, c.StubNo " +
            "FROM ParkingTransactions t " +
            "JOIN Vehicles v ON v.VehicleID = t.VehicleID " +
            "JOIN ParkingSlots s ON s.SlotID = t.SlotID " +
            "LEFT JOIN CardStubs c ON c.TransactionID = t.TransactionID " +
            "WHERE t.TransactionID = @TransactionID";

        public static RecordDetails GetRecord(int transactionId)
        {
            return AppDb.Instance.QuerySingle<RecordDetails>(DetailsSelect, new { TransactionID = transactionId });
        }

        public static OperationResult UpdateRecord(int transactionId, string plate, string vehicleType, string ownerName, int slotId)
        {
            IDatabase db = AppDb.Instance;
            OperationResult result = null;

            db.ExecuteTransaction(tran =>
            {
                RecordDetails record = db.QuerySingle<RecordDetails>(DetailsSelect, new { TransactionID = transactionId });
                if (record == null)
                {
                    result = OperationResult.Fail("This record no longer exists. It may have been deleted.");
                    return false;
                }

                object otherVehicle = db.Scalar(
                    "SELECT VehicleID FROM Vehicles WHERE PlateKey = @PlateKey AND VehicleID <> @VehicleID",
                    new { PlateKey = Validator.PlateKey(plate), record.VehicleID });
                if (otherVehicle != null)
                {
                    result = OperationResult.Fail("Plate number " + plate + " is already registered to another vehicle.");
                    return false;
                }

                DateTime now = DateTime.Now;
                bool vehicleChanged = plate != record.PlateNumber || vehicleType != record.VehicleType || ownerName != record.OwnerName;
                if (vehicleChanged)
                {
                    db.Update("Vehicles", new
                    {
                        record.VehicleID,
                        PlateNumber = plate,
                        VehicleType = vehicleType,
                        OwnerName = ownerName
                    }, "VehicleID");
                    db.CUD("UPDATE ParkingTransactions SET UpdatedAt = @Now WHERE VehicleID = @VehicleID",
                           new { Now = now, record.VehicleID });
                }

                string moveNote = "";
                if (slotId != record.SlotID)
                {
                    if (!record.IsParked)
                    {
                        result = OperationResult.Fail("The slot of a completed record cannot be changed.");
                        return false;
                    }

                    DataTable newSlot = db.TableData(
                        "SELECT SlotNumber, Status FROM ParkingSlots WITH (UPDLOCK) WHERE SlotID = @SlotID",
                        new { SlotID = slotId });
                    if (newSlot.Rows.Count == 0 || (string)newSlot.Rows[0]["Status"] != "Available")
                    {
                        result = OperationResult.Fail("The selected slot is no longer available. Please choose another slot.");
                        return false;
                    }

                    db.Update("ParkingTransactions", new { TransactionID = transactionId, SlotID = slotId, UpdatedAt = now }, "TransactionID");
                    db.Update("ParkingSlots", new { record.SlotID, Status = "Available", UpdatedAt = now }, "SlotID");
                    db.Update("ParkingSlots", new { SlotID = slotId, Status = "Occupied", UpdatedAt = now }, "SlotID");
                    moveNote = " Moved from " + record.SlotNumber + " to " + newSlot.Rows[0]["SlotNumber"] + ".";
                }

                result = OperationResult.Ok("Record No. " + transactionId + " updated." + moveNote);
                return true;
            });
            return result;
        }

        public static OperationResult DeleteRecord(int transactionId)
        {
            IDatabase db = AppDb.Instance;
            OperationResult result = null;

            db.ExecuteTransaction(tran =>
            {
                RecordDetails record = db.QuerySingle<RecordDetails>(DetailsSelect, new { TransactionID = transactionId });
                if (record == null)
                {
                    result = OperationResult.Fail("This record no longer exists. It may have been deleted already.");
                    return false;
                }

                db.Delete("CardStubs", new { TransactionID = transactionId }, "TransactionID");
                db.Delete("ParkingTransactions", new { TransactionID = transactionId }, "TransactionID");

                string message = "Record No. " + transactionId + " (" + record.PlateNumber + ") deleted.";
                if (record.IsParked)
                {
                    db.CUD("UPDATE ParkingSlots SET Status = 'Available', UpdatedAt = @Now WHERE SlotID = @SlotID AND Status = 'Occupied'",
                           new { Now = DateTime.Now, record.SlotID });
                    message += " " + record.SlotNumber + " is now free.";
                }

                db.CUD("DELETE FROM Vehicles WHERE VehicleID = @VehicleID " +
                       "AND NOT EXISTS (SELECT 1 FROM ParkingTransactions WHERE VehicleID = @VehicleID)",
                       new { record.VehicleID });

                result = OperationResult.Ok(message);
                return true;
            });
            return result;
        }
    }
}
