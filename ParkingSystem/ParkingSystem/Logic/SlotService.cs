using System;
using System.Collections.Generic;
using red_framework;

namespace ParkingSystem.Logic
{
    public static class SlotService
    {
        public static List<SlotInfo> GetAll()
        {
            return AppDb.Instance.QueryList<SlotInfo>(
                "SELECT s.SlotID, s.SlotNumber, s.Zone, s.Status, s.UpdatedAt, " +
                "       t.TransactionID, t.EntryTime, v.PlateNumber, v.OwnerName, v.VehicleType " +
                "FROM ParkingSlots s " +
                "LEFT JOIN ParkingTransactions t ON t.SlotID = s.SlotID AND t.Status = 'Parked' " +
                "LEFT JOIN Vehicles v ON v.VehicleID = t.VehicleID " +
                "ORDER BY s.SlotNumber");
        }

        public static List<SlotInfo> GetAvailable()
        {
            return GetAll().FindAll(s => s.IsAvailable);
        }

        public static OperationResult Reserve(int slotId)
        {
            return ChangeStatus(slotId, "Available", "Reserved", "reserved");
        }

        public static OperationResult Release(int slotId)
        {
            return ChangeStatus(slotId, "Reserved", "Available", "released and is now available");
        }

        private static OperationResult ChangeStatus(int slotId, string from, string to, string verb)
        {
            IDatabase db = AppDb.Instance;
            int affected = db.CUD(
                "UPDATE ParkingSlots SET Status = @ToStatus, UpdatedAt = @Now WHERE SlotID = @SlotID AND Status = @FromStatus",
                new { ToStatus = to, Now = DateTime.Now, SlotID = slotId, FromStatus = from });

            object number = db.Scalar("SELECT SlotNumber FROM ParkingSlots WHERE SlotID = @SlotID", new { SlotID = slotId });
            if (affected == 0)
                return OperationResult.Fail("Slot " + number + " is no longer " + from.ToLower() + ". The map has been refreshed.");
            return OperationResult.Ok("Slot " + number + " " + verb + ".");
        }
    }
}
