using System.Globalization;
using System.Text.RegularExpressions;

namespace ParkingSystem.Helpers
{
    public static class Validator
    {
        public const string PlateRuleMessage =
            "Plate number must be 4-10 characters (letters, numbers, space or dash) " +
            "and contain at least one letter and one number.\nExample: ABC 1234";

        public const string NameRuleMessage =
            "Owner name must be 2-100 characters and may only contain letters, spaces, period ( . ), apostrophe ( ' ) or dash ( - ).";

        public static string NormalizePlate(string plate)
        {
            if (plate == null) return string.Empty;
            return Regex.Replace(plate.Trim().ToUpperInvariant(), @"\s+", " ");
        }

        public static string PlateKey(string plate)
        {
            if (plate == null) return string.Empty;
            return Regex.Replace(plate.ToUpperInvariant(), @"[\s\-]", "");
        }

        public static bool IsValidPlate(string plate)
        {
            if (string.IsNullOrWhiteSpace(plate)) return false;
            if (!Regex.IsMatch(plate, @"^[A-Z0-9][A-Z0-9 \-]{2,8}[A-Z0-9]$")) return false;
            return Regex.IsMatch(plate, "[A-Z]") && Regex.IsMatch(plate, "[0-9]");
        }

        public static bool IsValidName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return false;
            return Regex.IsMatch(name.Trim(), @"^\p{L}[\p{L} .'\-]{1,99}$");
        }

        public static bool TryParseMoney(string text, decimal min, decimal max, out decimal value)
        {
            bool ok = decimal.TryParse((text ?? "").Trim(), NumberStyles.Number, CultureInfo.CurrentCulture, out value);
            return ok && value >= min && value <= max && decimal.Round(value, 2) == value;
        }

        public static bool TryParseWholeNumber(string text, int min, int max, out int value)
        {
            bool ok = int.TryParse((text ?? "").Trim(), NumberStyles.Integer, CultureInfo.CurrentCulture, out value);
            return ok && value >= min && value <= max;
        }
    }
}
