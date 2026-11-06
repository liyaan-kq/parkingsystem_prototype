using System;
using System.Data;
using red_framework;

namespace ParkingSystem.Logic
{
    public static class AuthService
    {
        public static bool Login(string username, string password)
        {
            DataTable rows = AppDb.Instance.TableData(
                "SELECT UserID, Username, Password, FullName FROM Users WHERE Username = @Username",
                new { Username = username.Trim() });

            if (rows.Rows.Count == 0) return false;

            DataRow row = rows.Rows[0];
            if (!string.Equals((string)row["Password"], password, StringComparison.Ordinal))
                return false;

            Session.Start(Convert.ToInt32(row["UserID"]), (string)row["Username"], (string)row["FullName"]);
            return true;
        }

        public static void Logout()
        {
            Session.End();
        }
    }
}
