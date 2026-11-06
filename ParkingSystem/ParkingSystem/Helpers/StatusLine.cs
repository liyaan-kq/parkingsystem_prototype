using System.Drawing;
using System.Windows.Forms;

namespace ParkingSystem.Helpers
{
    public static class StatusLine
    {
        public static readonly Color OkColor = Color.FromArgb(21, 128, 61);
        public static readonly Color ErrorColor = Color.FromArgb(185, 28, 28);
        public static readonly Color HintColor = Color.FromArgb(100, 116, 139);

        public static void Ok(Label label, string message)
        {
            Set(label, message, OkColor);
        }

        public static void Error(Label label, string message)
        {
            Set(label, message, ErrorColor);
        }

        public static void Error(Label label, string message, Control fixThis)
        {
            Set(label, message, ErrorColor);
            if (fixThis != null && fixThis.CanFocus) fixThis.Focus();
        }

        public static void Hint(Label label, string message)
        {
            Set(label, message, HintColor);
        }

        public static void Clear(Label label)
        {
            label.Text = "";
        }

        public static bool IsError(Label label)
        {
            return label.ForeColor == ErrorColor && label.Text.Length > 0;
        }

        private static void Set(Label label, string message, Color color)
        {
            label.ForeColor = color;
            label.Text = message ?? "";
        }
    }
}
