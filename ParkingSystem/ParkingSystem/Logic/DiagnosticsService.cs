using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using ParkingSystem.Helpers;
using red_framework;

namespace ParkingSystem.Logic
{
    public static class DiagnosticsService
    {
        public static List<CheckResult> RunSelfTests()
        {
            VehicleRate car = new VehicleRate { VehicleType = "Car", FlatRate = 50m, FlatHours = 3, SucceedingRate = 20m };
            VehicleRate motorcycle = new VehicleRate { VehicleType = "Motorcycle", FlatRate = 20m, FlatHours = 3, SucceedingRate = 10m };
            VehicleRate van = new VehicleRate { VehicleType = "Van/SUV", FlatRate = 70m, FlatHours = 3, SucceedingRate = 30m };
            DateTime start = new DateTime(2026, 1, 1, 8, 15, 0);
            decimal amount;
            string money = 50.25m.ToString(CultureInfo.CurrentCulture);
            string threeDecimals = 1.234m.ToString(CultureInfo.CurrentCulture);

            List<CheckResult> results = new List<CheckResult>();

            Expect(results, "Fee: Car 0 mins = \u20B150", FeeCalculator.ComputeFee(0, car), 50m);
            Expect(results, "Fee: Car 2 hrs 9 mins = \u20B150", FeeCalculator.ComputeFee(129, car), 50m);
            Expect(results, "Fee: Car 3 hrs 0 mins = \u20B150", FeeCalculator.ComputeFee(180, car), 50m);
            Expect(results, "Fee: Car 3 hrs 1 min = \u20B170", FeeCalculator.ComputeFee(181, car), 70m);
            Expect(results, "Fee: Car 4 hrs 0 mins = \u20B170", FeeCalculator.ComputeFee(240, car), 70m);
            Expect(results, "Fee: Car 4 hrs 30 mins = \u20B190", FeeCalculator.ComputeFee(270, car), 90m);
            Expect(results, "Fee: Motorcycle 1 hr 45 mins = \u20B120", FeeCalculator.ComputeFee(105, motorcycle), 20m);
            Expect(results, "Fee: Van/SUV 3 hrs 35 mins = \u20B1100", FeeCalculator.ComputeFee(215, van), 100m);
            Expect(results, "Billable hours: 61 mins = 2", FeeCalculator.GetBillableHours(61), 2);

            Expect(results, "Duration: exit before entry = 0", FeeCalculator.GetDurationMinutes(start, start.AddMinutes(-5)), 0);
            Expect(results, "Duration: partial minute is dropped", FeeCalculator.GetDurationMinutes(start, start.AddMinutes(129).AddSeconds(59)), 129);
            Expect(results, "Duration text: 129 mins", FeeCalculator.FormatDuration(129), "2 hrs 9 mins");
            Expect(results, "Duration text: 1 min", FeeCalculator.FormatDuration(1), "1 min");

            Expect(results, "Plate: tidied to uppercase, single spaces", Validator.NormalizePlate("  abc   1234 "), "ABC 1234");
            Expect(results, "Plate: ABC 1234 is valid", Validator.IsValidPlate("ABC 1234"), true);
            Expect(results, "Plate: ABC-1234 is valid", Validator.IsValidPlate("ABC-1234"), true);
            Expect(results, "Plate: ABCD (no number) is invalid", Validator.IsValidPlate("ABCD"), false);
            Expect(results, "Plate: AB1 (too short) is invalid", Validator.IsValidPlate("AB1"), false);
            Expect(results, "Plate key: abc-1234 = ABC 1234", Validator.PlateKey("abc-1234") == Validator.PlateKey("ABC 1234"), true);

            Expect(results, "Name: Juan Dela Cruz is valid", Validator.IsValidName("Juan Dela Cruz"), true);
            Expect(results, "Name: O'Neil-Santos Jr. is valid", Validator.IsValidName("O'Neil-Santos Jr."), true);
            Expect(results, "Name: J4ne (digit) is invalid", Validator.IsValidName("J4ne"), false);

            Expect(results, "Amount: " + money + " is valid", Validator.TryParseMoney(money, 0m, 10000m, out amount), true);
            Expect(results, "Amount: -1 is rejected", Validator.TryParseMoney("-1", 0m, 10000m, out amount), false);
            Expect(results, "Amount: " + threeDecimals + " (3 decimals) is rejected", Validator.TryParseMoney(threeDecimals, 0m, 10000m, out amount), false);

            Expect(results, "Search: abc matches plate ABC 1234 first", SearchHelper.Score("abc", "ABC 1234", "Juan Dela Cruz", "A05"), 3);
            Expect(results, "Search: a5 matches slot A05", SearchHelper.SlotMatches("a5", "A05"), true);
            Expect(results, "Search: dela matches owner Juan Dela Cruz", SearchHelper.OwnerMatches("dela", "Juan Dela Cruz"), true);

            return results;
        }

        public static List<CheckResult> CheckIntegrity()
        {
            IDatabase db = AppDb.Instance;
            List<CheckResult> results = new List<CheckResult>();

            Stopwatch watch = Stopwatch.StartNew();
            bool connected = db.Ping();
            watch.Stop();
            results.Add(new CheckResult
            {
                Name = "Database connection",
                Passed = connected,
                Detail = connected ? "Connected in " + watch.ElapsedMilliseconds + " ms" : "Could not connect to ParkingDB.mdf"
            });
            if (!connected) return results;

            int slots = Count(db, "SELECT COUNT(*) FROM ParkingSlots");
            results.Add(new CheckResult { Name = "Parking slots", Passed = slots == 50, Detail = slots + " found (expected 50)" });

            ExpectNone(db, results, "Occupied slots without a parked vehicle",
                "SELECT COUNT(*) FROM ParkingSlots s WHERE s.Status = 'Occupied' " +
                "AND NOT EXISTS (SELECT 1 FROM ParkingTransactions t WHERE t.SlotID = s.SlotID AND t.Status = 'Parked')");
            ExpectNone(db, results, "Parked vehicles on a slot not marked Occupied",
                "SELECT COUNT(*) FROM ParkingTransactions t JOIN ParkingSlots s ON s.SlotID = t.SlotID " +
                "WHERE t.Status = 'Parked' AND s.Status <> 'Occupied'");
            ExpectNone(db, results, "Completed records without a card stub",
                "SELECT COUNT(*) FROM ParkingTransactions t WHERE t.Status = 'Completed' " +
                "AND NOT EXISTS (SELECT 1 FROM CardStubs c WHERE c.TransactionID = t.TransactionID)");
            ExpectNone(db, results, "Card stubs on records that are not completed",
                "SELECT COUNT(*) FROM CardStubs c JOIN ParkingTransactions t ON t.TransactionID = c.TransactionID " +
                "WHERE t.Status <> 'Completed'");
            ExpectNone(db, results, "Completed records with missing exit data",
                "SELECT COUNT(*) FROM ParkingTransactions WHERE Status = 'Completed' " +
                "AND (ExitTime IS NULL OR DurationMinutes IS NULL OR Fee IS NULL)");
            ExpectNone(db, results, "Vehicles with no visits (orphans)",
                "SELECT COUNT(*) FROM Vehicles v " +
                "WHERE NOT EXISTS (SELECT 1 FROM ParkingTransactions t WHERE t.VehicleID = v.VehicleID)");

            return results;
        }

        private static void ExpectNone(IDatabase db, List<CheckResult> results, string name, string countQuery)
        {
            int found = Count(db, countQuery);
            results.Add(new CheckResult { Name = name, Passed = found == 0, Detail = found + " found" });
        }

        private static int Count(IDatabase db, string query)
        {
            return Convert.ToInt32(db.Scalar(query));
        }

        private static void Expect<T>(List<CheckResult> results, string name, T actual, T expected)
        {
            bool passed = Equals(actual, expected);
            results.Add(new CheckResult
            {
                Name = name,
                Passed = passed,
                Detail = passed ? "" : "expected " + expected + ", got " + actual
            });
        }
    }
}
