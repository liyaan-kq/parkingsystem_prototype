using System;
using System.Configuration;

namespace red_framework
{
    public static class AppDb
    {
        private static readonly Lazy<IDatabase> _instance = new Lazy<IDatabase>(() =>
        {
            string connStr = ConfigurationManager.ConnectionStrings["AppDB"].ConnectionString;
            return new SqlDatabase(connStr);
        });

        public static IDatabase Instance => _instance.Value;

        public static void Dispose()
        {
            if (_instance.IsValueCreated)
                _instance.Value.Dispose();
        }
    }
}