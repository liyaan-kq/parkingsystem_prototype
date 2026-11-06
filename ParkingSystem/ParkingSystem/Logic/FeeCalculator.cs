using System;

namespace ParkingSystem.Logic
{
    public static class FeeCalculator
    {
        public const string Peso = "\u20B1";

        public static int GetDurationMinutes(DateTime entry, DateTime exit)
        {
            int minutes = (int)Math.Floor((exit - entry).TotalMinutes);
            return minutes < 0 ? 0 : minutes;
        }

        public static int GetBillableHours(int minutes)
        {
            int hours = (int)Math.Ceiling(minutes / 60.0);
            return hours < 1 ? 1 : hours;
        }

        public static decimal ComputeFee(int minutes, VehicleRate rate)
        {
            if (rate == null) throw new ArgumentNullException("rate");

            int hours = GetBillableHours(minutes);
            if (hours <= rate.FlatHours)
                return rate.FlatRate;

            int extraHours = hours - rate.FlatHours;
            return rate.FlatRate + (extraHours * rate.SucceedingRate);
        }

        public static string FormatDuration(int minutes)
        {
            int h = minutes / 60;
            int m = minutes % 60;
            string mins = m + (m == 1 ? " min" : " mins");
            if (h == 0) return mins;
            return h + (h == 1 ? " hr " : " hrs ") + mins;
        }

        public static string FormatMoney(decimal amount)
        {
            return Peso + amount.ToString("N2");
        }
    }
}
