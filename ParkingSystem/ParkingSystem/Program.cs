using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using ParkingSystem.Forms;
using ParkingSystem.Helpers;
using red_framework;

namespace ParkingSystem
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            UseProjectFolderDatabase();

            Application.ThreadException += OnThreadException;
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ApplicationExit += delegate { AppDb.Dispose(); };
            Application.Run(new LoginForm());
        }

        private static void UseProjectFolderDatabase()
        {
            string projectFolder = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\.."));
            if (File.Exists(Path.Combine(projectFolder, "ParkingDB.mdf")))
                AppDomain.CurrentDomain.SetData("DataDirectory", projectFolder);
        }

        private static void OnThreadException(object sender, ThreadExceptionEventArgs e)
        {
            UiHelper.DbError(e.Exception);
        }
    }
}
