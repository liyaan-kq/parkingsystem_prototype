using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ParkingSystem.Helpers
{
    public static class UiHelper
    {
        public const string AppTitle = "Parking Location Management System";

        public static void Info(string message)
        {
            MessageBox.Show(message, AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Warn(string message)
        {
            MessageBox.Show(message, AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void Error(string message)
        {
            MessageBox.Show(message, AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void WarnAndFocus(string message, Control control)
        {
            Warn(message);
            if (control != null && control.CanFocus) control.Focus();
        }

        public static bool Confirm(string message)
        {
            return MessageBox.Show(message, AppTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                   MessageBoxDefaultButton.Button2) == DialogResult.Yes;
        }

        public static void DbError(Exception ex)
        {
            if (ex is SqlException)
            {
                Error("Cannot connect to the database or the query failed.\n\n" +
                      "Check that ParkingDB.mdf exists in the project folder and that the setup scripts were run " +
                      "(see Docs/SETUP.md).\n\nDetails: " + ex.Message);
            }
            else
            {
                Error("Something went wrong.\n\nDetails: " + ex.Message);
            }
        }
    }
}
