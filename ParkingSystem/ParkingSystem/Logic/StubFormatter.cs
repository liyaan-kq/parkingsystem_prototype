using System.Collections.Generic;

namespace ParkingSystem.Logic
{
    public static class StubFormatter
    {
        public const int Width = 36;
        private const string DateFormat = "yyyy-MM-dd hh:mm tt";

        public static List<string> BuildLines(StubInfo stub)
        {
            List<string> lines = new List<string>();
            lines.Add(Center("PARKING LOCATION"));
            lines.Add(Center("MANAGEMENT SYSTEM"));
            lines.Add(Center("PARKING STUB"));
            lines.Add(new string('=', Width));
            lines.Add(Row("Stub No.", stub.StubNo));
            lines.Add(Row("Plate No.", stub.PlateNumber));
            lines.Add(Row("Vehicle", stub.VehicleType));
            lines.Add(Row("Slot No.", stub.SlotNumber));
            lines.Add(new string('-', Width));
            lines.Add(Row("Entry", stub.EntryTime.ToString(DateFormat)));
            lines.Add(Row("Exit", stub.ExitTime.ToString(DateFormat)));
            lines.Add(Row("Duration", FeeCalculator.FormatDuration(stub.DurationMinutes)));
            lines.Add(new string('-', Width));
            lines.Add(Row("TOTAL", FeeCalculator.FormatMoney(stub.Fee)));
            lines.Add(new string('=', Width));
            lines.Add(Center("Thank you!"));
            lines.Add(Center("Safe travels!"));
            return lines;
        }

        public static string BuildText(StubInfo stub)
        {
            return string.Join("\r\n", BuildLines(stub));
        }

        private static string Row(string label, string value)
        {
            string left = (label + ":").PadRight(11);
            return left + (value ?? "").PadLeft(Width - left.Length);
        }

        private static string Center(string text)
        {
            int pad = (Width - text.Length) / 2;
            return pad > 0 ? new string(' ', pad) + text : text;
        }
    }
}
