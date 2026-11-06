using System;

namespace ParkingSystem.Logic
{
    public class SlotInfo
    {
        public int SlotID { get; set; }
        public string SlotNumber { get; set; }
        public string Zone { get; set; }
        public string Status { get; set; }
        public DateTime UpdatedAt { get; set; }

        public int? TransactionID { get; set; }
        public string PlateNumber { get; set; }
        public string OwnerName { get; set; }
        public string VehicleType { get; set; }
        public DateTime? EntryTime { get; set; }

        public string Number
        {
            get { return SlotNumber.Substring(1); }
        }

        public bool IsAvailable { get { return Status == "Available"; } }
        public bool IsOccupied { get { return Status == "Occupied"; } }
        public bool IsReserved { get { return Status == "Reserved"; } }
    }

    public class VehicleRate
    {
        public string VehicleType { get; set; }
        public decimal FlatRate { get; set; }
        public int FlatHours { get; set; }
        public decimal SucceedingRate { get; set; }

        public string Describe()
        {
            return FeeCalculator.FormatMoney(FlatRate) + " for the first " + FlatHours + " hr" + (FlatHours == 1 ? "" : "s") +
                   ", then " + FeeCalculator.FormatMoney(SucceedingRate) + " per succeeding hour";
        }

        public string DescribeShort()
        {
            return FeeCalculator.FormatMoney(FlatRate) + " / " + FlatHours + " hr" + (FlatHours == 1 ? "" : "s") +
                   " + " + FeeCalculator.FormatMoney(SucceedingRate) + "/hr";
        }
    }

    public class VehicleInfo
    {
        public int VehicleID { get; set; }
        public string PlateNumber { get; set; }
        public string VehicleType { get; set; }
        public string OwnerName { get; set; }
    }

    public class ActiveParking
    {
        public int TransactionID { get; set; }
        public int VehicleID { get; set; }
        public string PlateNumber { get; set; }
        public string VehicleType { get; set; }
        public string OwnerName { get; set; }
        public int SlotID { get; set; }
        public string SlotNumber { get; set; }
        public DateTime EntryTime { get; set; }
    }

    public class StubInfo
    {
        public string StubNo { get; set; }
        public string PlateNumber { get; set; }
        public string VehicleType { get; set; }
        public string OwnerName { get; set; }
        public string SlotNumber { get; set; }
        public DateTime EntryTime { get; set; }
        public DateTime ExitTime { get; set; }
        public int DurationMinutes { get; set; }
        public decimal Fee { get; set; }
        public DateTime IssuedAt { get; set; }
    }

    public class DashboardStats
    {
        public int TotalSlots { get; set; }
        public int Available { get; set; }
        public int Occupied { get; set; }
        public int Reserved { get; set; }
        public decimal TodayIncome { get; set; }
        public int StubsToday { get; set; }
    }

    public class CheckResult
    {
        public string Name { get; set; }
        public bool Passed { get; set; }
        public string Detail { get; set; }
    }

    public class RecordDetails
    {
        public int TransactionID { get; set; }
        public int VehicleID { get; set; }
        public string PlateNumber { get; set; }
        public string VehicleType { get; set; }
        public string OwnerName { get; set; }
        public int SlotID { get; set; }
        public string SlotNumber { get; set; }
        public DateTime EntryTime { get; set; }
        public DateTime? ExitTime { get; set; }
        public int? DurationMinutes { get; set; }
        public decimal? Fee { get; set; }
        public string Status { get; set; }
        public string StubNo { get; set; }
        public DateTime UpdatedAt { get; set; }

        public bool IsParked
        {
            get { return Status == "Parked"; }
        }
    }
}
