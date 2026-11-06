namespace ParkingSystem.Logic
{
    public static class Session
    {
        public static int UserID { get; private set; }
        public static string Username { get; private set; }
        public static string FullName { get; private set; }

        public static bool IsLoggedIn
        {
            get { return UserID > 0; }
        }

        public static void Start(int userId, string username, string fullName)
        {
            UserID = userId;
            Username = username;
            FullName = fullName;
        }

        public static void End()
        {
            UserID = 0;
            Username = null;
            FullName = null;
        }
    }
}
