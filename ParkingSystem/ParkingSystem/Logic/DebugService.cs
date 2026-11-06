using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using red_framework;

namespace ParkingSystem.Logic
{
    public static class DebugService
    {
        private const int SampleVehicles = 30;
        private const int SampleParked = 12;
        private const int SampleReserved = 3;

        private static readonly string[] FirstNames =
        {
            "Juan", "Maria", "Jose", "Ana", "Pedro", "Carlo", "Liza", "Mark", "Grace", "Paolo",
            "Kristine", "Miguel", "Andrea", "Rafael", "Joy", "Ramon", "Bea", "Luis", "Camille", "Noel"
        };

        private static readonly string[] LastNames =
        {
            "Dela Cruz", "Santos", "Reyes", "Garcia", "Mendoza", "Lopez", "Bautista", "Villanueva", "Ramos", "Aquino",
            "Castillo", "Flores", "Navarro", "Torres", "Gonzales", "Rivera", "Domingo", "Mercado", "Pascual", "Salazar"
        };

        private class SampleVisit
        {
            public int VehicleIndex;
            public int SlotID;
            public DateTime EntryTime;
            public DateTime ExitTime;
            public int DurationMinutes;
            public decimal Fee;
        }

        private class SampleVehicle
        {
            public string PlateNumber;
            public string OwnerName;
            public VehicleRate Rate;
            public DateTime CreatedAt;
            public int VehicleID;
        }

        public static OperationResult GenerateSampleData()
        {
            List<VehicleRate> rates = RateService.GetAll();
            if (rates.Count == 0)
                return OperationResult.Fail("No vehicle rates found. Run Database/02_seed.sql first.");

            List<SlotInfo> slots = SlotService.GetAll();
            if (slots.Count < SampleParked + SampleReserved)
                return OperationResult.Fail("Not enough parking slots found. Run Database/02_seed.sql first.");

            Random random = new Random();
            DateTime now = TrimSeconds(DateTime.Now);
            DateTime today = DateTime.Today;

            List<SampleVehicle> vehicles = MakeVehicles(random, rates, now);

            List<int> order = Shuffled(random, SampleVehicles);
            HashSet<int> parkedVehicles = new HashSet<int>(order.GetRange(0, SampleParked));

            List<SampleVisit> visits = new List<SampleVisit>();
            for (int i = 0; i < vehicles.Count; i++)
                visits.AddRange(MakeVisits(random, i, vehicles[i], parkedVehicles.Contains(i), slots, today, now));
            visits.Sort((a, b) => a.ExitTime.CompareTo(b.ExitTime));

            List<int> slotOrder = Shuffled(random, slots.Count);
            List<int> parkedList = new List<int>(parkedVehicles);
            DateTime[] parkedEntry = new DateTime[parkedList.Count];
            for (int p = 0; p < parkedList.Count; p++)
            {
                parkedEntry[p] = now.AddMinutes(-random.Next(10, 361));
                SampleVehicle v = vehicles[parkedList[p]];
                if (parkedEntry[p] < v.CreatedAt) v.CreatedAt = parkedEntry[p];
            }

            decimal income = 0m;
            IDatabase db = AppDb.Instance;
            db.ExecuteTransaction(tran =>
            {
                DeleteAll(db, now);

                foreach (SampleVehicle v in vehicles)
                {
                    v.VehicleID = Convert.ToInt32(db.Scalar(
                        "INSERT INTO Vehicles (PlateNumber, VehicleType, OwnerName, CreatedAt) " +
                        "VALUES (@PlateNumber, @VehicleType, @OwnerName, @CreatedAt); " +
                        "SELECT CAST(SCOPE_IDENTITY() AS INT);",
                        new { v.PlateNumber, v.Rate.VehicleType, v.OwnerName, v.CreatedAt }));
                }

                foreach (SampleVisit visit in visits)
                {
                    int transactionId = Convert.ToInt32(db.Scalar(
                        "INSERT INTO ParkingTransactions (VehicleID, SlotID, EntryTime, ExitTime, DurationMinutes, Fee, Status, UpdatedAt) " +
                        "VALUES (@VehicleID, @SlotID, @EntryTime, @ExitTime, @DurationMinutes, @Fee, 'Completed', @ExitTime); " +
                        "SELECT CAST(SCOPE_IDENTITY() AS INT);",
                        new
                        {
                            vehicles[visit.VehicleIndex].VehicleID,
                            visit.SlotID,
                            visit.EntryTime,
                            visit.ExitTime,
                            visit.DurationMinutes,
                            visit.Fee
                        }));
                    db.CUD("INSERT INTO CardStubs (TransactionID, IssuedAt) VALUES (@TransactionID, @IssuedAt)",
                           new { TransactionID = transactionId, IssuedAt = visit.ExitTime });
                    income += visit.Fee;
                }

                for (int p = 0; p < parkedList.Count; p++)
                {
                    int slotId = slots[slotOrder[p]].SlotID;
                    db.CUD("INSERT INTO ParkingTransactions (VehicleID, SlotID, EntryTime, Status, UpdatedAt) " +
                           "VALUES (@VehicleID, @SlotID, @EntryTime, 'Parked', @EntryTime)",
                           new { vehicles[parkedList[p]].VehicleID, SlotID = slotId, EntryTime = parkedEntry[p] });
                    db.CUD("UPDATE ParkingSlots SET Status = 'Occupied', UpdatedAt = @EntryTime WHERE SlotID = @SlotID",
                           new { EntryTime = parkedEntry[p], SlotID = slotId });
                }

                for (int r = 0; r < SampleReserved; r++)
                {
                    db.CUD("UPDATE ParkingSlots SET Status = 'Reserved', UpdatedAt = @UpdatedAt WHERE SlotID = @SlotID",
                           new { UpdatedAt = now.AddMinutes(-random.Next(5, 241)), slots[slotOrder[SampleParked + r]].SlotID });
                }
                return true;
            });

            return OperationResult.Ok("Sample data generated: " + vehicles.Count + " vehicles, " + visits.Count +
                                      " completed visits (" + FeeCalculator.FormatMoney(income) + "), " +
                                      parkedList.Count + " parked vehicles, " + SampleReserved + " reserved slots.");
        }

        public static OperationResult ClearAllRecords()
        {
            IDatabase db = AppDb.Instance;
            int[] counts = null;
            db.ExecuteTransaction(tran =>
            {
                counts = DeleteAll(db, DateTime.Now);
                return true;
            });
            return OperationResult.Ok("All records cleared: " + counts[0] + " stubs, " + counts[1] + " transactions and " +
                                      counts[2] + " vehicles deleted. All slots are now available.");
        }

        public static OperationResult ResetRates()
        {
            IDatabase db = AppDb.Instance;
            DateTime now = DateTime.Now;
            VehicleRate[] defaults =
            {
                new VehicleRate { VehicleType = "Car", FlatRate = 50m, FlatHours = 3, SucceedingRate = 20m },
                new VehicleRate { VehicleType = "Motorcycle", FlatRate = 20m, FlatHours = 3, SucceedingRate = 10m },
                new VehicleRate { VehicleType = "Van/SUV", FlatRate = 70m, FlatHours = 3, SucceedingRate = 30m }
            };

            db.ExecuteTransaction(tran =>
            {
                foreach (VehicleRate r in defaults)
                {
                    var row = new { r.VehicleType, r.FlatRate, r.FlatHours, r.SucceedingRate, UpdatedAt = now };
                    if (!db.Update("VehicleRates", row, "VehicleType"))
                        db.Save("VehicleRates", row);
                }
                return true;
            });
            return OperationResult.Ok("Rates reset to defaults: Car " + defaults[0].DescribeShort() +
                                      ", Motorcycle " + defaults[1].DescribeShort() +
                                      ", Van/SUV " + defaults[2].DescribeShort() + ".");
        }

        public static OperationResult AdvanceParkedTime()
        {
            int affected = AppDb.Instance.CUD(
                "UPDATE ParkingTransactions SET EntryTime = DATEADD(HOUR, -1, EntryTime) WHERE Status = 'Parked'");
            if (affected == 0)
                return OperationResult.Fail("No parked vehicles to advance.");
            return OperationResult.Ok("Entry time of " + affected + " parked vehicle" + (affected == 1 ? "" : "s") +
                                      " moved back one hour. Durations and fees so far are now one hour longer.");
        }

        public static OperationResult SimulateQueryTimeout()
        {
            IDatabase db = AppDb.Instance;
            int original = db.CommandTimeoutSeconds;
            db.CommandTimeoutSeconds = 2;
            try
            {
                db.CUD("WAITFOR DELAY '00:00:05'");
            }
            finally
            {
                db.CommandTimeoutSeconds = original;
            }
            return OperationResult.Fail("The query finished without a timeout.");
        }

        public static OperationResult SimulateConnectionFailure()
        {
            SqlConnectionStringBuilder builder =
                new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["AppDB"].ConnectionString);
            builder.AttachDBFilename = Path.Combine(Path.GetTempPath(), "ParkingDB_missing_" + Guid.NewGuid().ToString("N") + ".mdf");
            builder.ConnectTimeout = 5;
            builder.Pooling = false;

            using (IDatabase missing = new SqlDatabase(builder.ConnectionString))
            {
                missing.Scalar("SELECT 1");
            }
            return OperationResult.Fail("The connection to the missing database unexpectedly succeeded.");
        }

        public static void ThrowUnexpectedError()
        {
            throw new InvalidOperationException("Simulated unexpected error from Debug Tools.");
        }

        private static int[] DeleteAll(IDatabase db, DateTime now)
        {
            int stubs = db.CUD("DELETE FROM CardStubs");
            int transactions = db.CUD("DELETE FROM ParkingTransactions");
            int vehicles = db.CUD("DELETE FROM Vehicles");
            db.CUD("UPDATE ParkingSlots SET Status = 'Available', UpdatedAt = @Now WHERE Status <> 'Available'", new { Now = now });
            return new[] { stubs, transactions, vehicles };
        }

        private static List<SampleVehicle> MakeVehicles(Random random, List<VehicleRate> rates, DateTime now)
        {
            List<SampleVehicle> vehicles = new List<SampleVehicle>();
            HashSet<string> plates = new HashSet<string>();
            while (vehicles.Count < SampleVehicles)
            {
                string plate = "" + RandomLetter(random) + RandomLetter(random) + RandomLetter(random) + " " + random.Next(100, 10000);
                if (!plates.Add(plate)) continue;

                vehicles.Add(new SampleVehicle
                {
                    PlateNumber = plate,
                    OwnerName = FirstNames[random.Next(FirstNames.Length)] + " " + LastNames[random.Next(LastNames.Length)],
                    Rate = PickRate(random, rates),
                    CreatedAt = now
                });
            }
            return vehicles;
        }

        private static List<SampleVisit> MakeVisits(Random random, int index, SampleVehicle vehicle, bool parkedNow,
                                                    List<SlotInfo> slots, DateTime today, DateTime now)
        {
            List<int> days = new List<int>();
            for (int d = parkedNow ? 2 : 0; d <= 6; d++) days.Add(d);
            List<int> dayOrder = Shuffled(random, days.Count);

            int wanted = random.Next(1, 4);
            List<SampleVisit> visits = new List<SampleVisit>();
            for (int k = 0; k < dayOrder.Count && visits.Count < wanted; k++)
            {
                int day = days[dayOrder[k]];
                int duration = random.Next(15, 421);
                DateTime entry;
                if (day == 0)
                {
                    DateTime earliest = today.AddHours(6);
                    DateTime latest = now.AddMinutes(-duration - 5);
                    if (latest < earliest) continue;
                    entry = earliest.AddMinutes(random.Next((int)(latest - earliest).TotalMinutes + 1));
                }
                else
                {
                    entry = today.AddDays(-day).AddHours(6).AddMinutes(random.Next(0, 601));
                }

                DateTime exit = entry.AddMinutes(duration);
                int minutes = FeeCalculator.GetDurationMinutes(entry, exit);
                visits.Add(new SampleVisit
                {
                    VehicleIndex = index,
                    SlotID = slots[random.Next(slots.Count)].SlotID,
                    EntryTime = entry,
                    ExitTime = exit,
                    DurationMinutes = minutes,
                    Fee = FeeCalculator.ComputeFee(minutes, vehicle.Rate)
                });
                if (entry < vehicle.CreatedAt) vehicle.CreatedAt = entry;
            }
            return visits;
        }

        private static VehicleRate PickRate(Random random, List<VehicleRate> rates)
        {
            int roll = random.Next(100);
            string type = roll < 60 ? "Car" : roll < 85 ? "Motorcycle" : "Van/SUV";
            VehicleRate rate = rates.Find(r => r.VehicleType == type);
            return rate ?? rates[random.Next(rates.Count)];
        }

        private static char RandomLetter(Random random)
        {
            return (char)('A' + random.Next(26));
        }

        private static List<int> Shuffled(Random random, int count)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < count; i++) list.Add(i);
            for (int i = count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                int t = list[i];
                list[i] = list[j];
                list[j] = t;
            }
            return list;
        }

        private static DateTime TrimSeconds(DateTime value)
        {
            return new DateTime(value.Year, value.Month, value.Day, value.Hour, value.Minute, 0);
        }
    }
}
