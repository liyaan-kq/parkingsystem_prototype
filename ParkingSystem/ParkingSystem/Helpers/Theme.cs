using System.Drawing;

namespace ParkingSystem.Helpers
{
    public static class Theme
    {
        public static readonly Color Navy = Color.FromArgb(23, 42, 92);
        public static readonly Color Primary = Color.FromArgb(29, 78, 216);
        public static readonly Color Light = Color.FromArgb(243, 246, 251);
        public static readonly Color Neutral = Color.FromArgb(226, 232, 240);
        public static readonly Color TextDark = Color.FromArgb(30, 41, 59);

        public static readonly Color AvailableBack = Color.FromArgb(220, 252, 231);
        public static readonly Color AvailableFore = Color.FromArgb(21, 128, 61);
        public static readonly Color OccupiedBack = Color.FromArgb(254, 226, 226);
        public static readonly Color OccupiedFore = Color.FromArgb(185, 28, 28);
        public static readonly Color ReservedBack = Color.FromArgb(254, 243, 199);
        public static readonly Color ReservedFore = Color.FromArgb(161, 98, 7);

        public static Color StatusBack(string status)
        {
            switch (status)
            {
                case "Occupied": return OccupiedBack;
                case "Reserved": return ReservedBack;
                default: return AvailableBack;
            }
        }

        public static Color StatusFore(string status)
        {
            switch (status)
            {
                case "Occupied": return OccupiedFore;
                case "Reserved": return ReservedFore;
                default: return AvailableFore;
            }
        }
    }
}
