using System;
using System.Collections.Generic;
using System.Data;
using ParkingSystem.Helpers;
using red_framework;

namespace ParkingSystem.Logic
{
    public static class ReportService
    {
        public static DashboardStats GetDashboardStats()
        {
            DateTime today = DateTime.Today;
            return AppDb.Instance.QuerySingle<DashboardStats>(
                "SELECT s.TotalSlots, s.Available, s.Occupied, s.Reserved, i.TodayIncome, i.StubsToday " +
                "FROM (SELECT COUNT(*) AS TotalSlots, " +
                "             ISNULL(SUM(CASE WHEN Status = 'Available' THEN 1 ELSE 0 END), 0) AS Available, " +
                "             ISNULL(SUM(CASE WHEN Status = 'Occupied'  THEN 1 ELSE 0 END), 0) AS Occupied, " +
                "             ISNULL(SUM(CASE WHEN Status = 'Reserved'  THEN 1 ELSE 0 END), 0) AS Reserved " +
                "      FROM ParkingSlots) s " +
                "CROSS JOIN (SELECT ISNULL(SUM(t.Fee), 0) AS TodayIncome, COUNT(*) AS StubsToday " +
                "            FROM CardStubs c JOIN ParkingTransactions t ON t.TransactionID = c.TransactionID " +
                "            WHERE c.IssuedAt >= @FromDate AND c.IssuedAt < @ToDate) i",
                new { FromDate = today, ToDate = today.AddDays(1) });
        }

        public static DataTable GetRecords(string status, string search, DateTime? from, DateTime? to)
        {
            string text = (search ?? "").Trim();
            DateTime? fromDate = from.HasValue ? from.Value.Date : (DateTime?)null;
            DateTime? toDate = to.HasValue ? to.Value.Date.AddDays(1) : (DateTime?)null;

            return AppDb.Instance.TableData(
                "SELECT t.TransactionID, c.StubNo, v.PlateNumber, v.VehicleType, v.OwnerName, s.SlotNumber, " +
                "       t.EntryTime, t.ExitTime, t.DurationMinutes, t.Fee, t.Status, t.UpdatedAt " +
                "FROM ParkingTransactions t " +
                "JOIN Vehicles v ON v.VehicleID = t.VehicleID " +
                "JOIN ParkingSlots s ON s.SlotID = t.SlotID " +
                "LEFT JOIN CardStubs c ON c.TransactionID = t.TransactionID " +
                "WHERE (@Status IS NULL OR t.Status = @Status) " +
                "  AND (@Text = '' OR v.PlateKey LIKE @KeyPattern OR v.OwnerName LIKE @NamePattern) " +
                "  AND (@FromDate IS NULL OR t.EntryTime >= @FromDate) " +
                "  AND (@ToDate IS NULL OR t.EntryTime < @ToDate) " +
                "ORDER BY t.EntryTime DESC",
                new
                {
                    Status = status,
                    Text = text,
                    KeyPattern = "%" + Validator.PlateKey(text) + "%",
                    NamePattern = "%" + text + "%",
                    FromDate = fromDate,
                    ToDate = toDate
                });
        }

        public static StubInfo GetStub(int transactionId)
        {
            return AppDb.Instance.QuerySingle<StubInfo>(
                "SELECT c.StubNo, c.IssuedAt, v.PlateNumber, v.VehicleType, v.OwnerName, s.SlotNumber, " +
                "       t.EntryTime, t.ExitTime, t.DurationMinutes, t.Fee " +
                "FROM CardStubs c " +
                "JOIN ParkingTransactions t ON t.TransactionID = c.TransactionID " +
                "JOIN Vehicles v ON v.VehicleID = t.VehicleID " +
                "JOIN ParkingSlots s ON s.SlotID = t.SlotID " +
                "WHERE c.TransactionID = @TransactionID",
                new { TransactionID = transactionId });
        }

        public static DataTable DailyIncome(DataTable records)
        {
            SortedDictionary<DateTime, decimal> totals = new SortedDictionary<DateTime, decimal>();
            foreach (DataRow row in records.Rows)
            {
                if ((string)row["Status"] != "Completed") continue;
                DateTime day = Convert.ToDateTime(row["ExitTime"]).Date;
                decimal fee = Convert.ToDecimal(row["Fee"]);
                totals[day] = totals.ContainsKey(day) ? totals[day] + fee : fee;
            }

            DataTable table = new DataTable();
            table.Columns.Add("Day", typeof(string));
            table.Columns.Add("Income", typeof(decimal));
            foreach (KeyValuePair<DateTime, decimal> total in totals)
                table.Rows.Add(total.Key.ToString("MMM dd"), total.Value);
            return table;
        }

        public static DataTable VisitsByType(DataTable records)
        {
            SortedDictionary<string, int> counts = new SortedDictionary<string, int>();
            foreach (DataRow row in records.Rows)
            {
                string type = (string)row["VehicleType"];
                counts[type] = counts.ContainsKey(type) ? counts[type] + 1 : 1;
            }

            DataTable table = new DataTable();
            table.Columns.Add("VehicleType", typeof(string));
            table.Columns.Add("Visits", typeof(int));
            foreach (KeyValuePair<string, int> count in counts)
                table.Rows.Add(count.Key, count.Value);
            return table;
        }
    }
}
