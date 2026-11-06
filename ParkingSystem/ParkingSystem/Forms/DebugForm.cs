using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ParkingSystem.Helpers;
using ParkingSystem.Logic;

namespace ParkingSystem.Forms
{
    public partial class DebugForm : Form
    {
        public DebugForm()
        {
            InitializeComponent();
        }

        private void DebugForm_Load(object sender, EventArgs e)
        {
            Log("Debug Tools opened.");
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (!UiHelper.Confirm("Replace ALL parking records with random sample data?\n\nThis cannot be undone.")) return;
            Run("Generate Sample Data", DebugService.GenerateSampleData);
        }

        private void btnClearRecords_Click(object sender, EventArgs e)
        {
            if (!UiHelper.Confirm("Delete ALL vehicles, parking records and card stubs?\n\nUsers and rates are kept. This cannot be undone.")) return;
            Run("Clear All Records", DebugService.ClearAllRecords);
        }

        private void btnResetRates_Click(object sender, EventArgs e)
        {
            if (!UiHelper.Confirm("Reset all vehicle rates to the default values?")) return;
            Run("Reset Rates to Defaults", DebugService.ResetRates);
        }

        private void btnAdvanceTime_Click(object sender, EventArgs e)
        {
            Run("Advance Parked Time (+1 Hour)", DebugService.AdvanceParkedTime);
        }

        private void btnQueryTimeout_Click(object sender, EventArgs e)
        {
            Log("Running a 5-second query with a 2-second timeout...");
            Run("Simulate Query Timeout", DebugService.SimulateQueryTimeout);
        }

        private void btnConnectionFailure_Click(object sender, EventArgs e)
        {
            Log("Connecting to a database file that does not exist...");
            Run("Simulate Connection Failure", DebugService.SimulateConnectionFailure);
        }

        private void btnUnexpectedError_Click(object sender, EventArgs e)
        {
            Log("Simulate Unexpected Error: throwing an unhandled exception. The application-wide handler should catch it.");
            DebugService.ThrowUnexpectedError();
        }

        private void btnSelfTests_Click(object sender, EventArgs e)
        {
            LogChecks("Run Self-Tests", DiagnosticsService.RunSelfTests);
        }

        private void btnIntegrity_Click(object sender, EventArgs e)
        {
            LogChecks("Check Data Integrity", DiagnosticsService.CheckIntegrity);
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            txtLog.Clear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Run(string title, Func<OperationResult> action)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                OperationResult result = action();
                Log(title + (result.Success ? ": " : " failed: ") + result.Message);
            }
            catch (Exception ex)
            {
                Log(title + ": error caught - " + ex.GetType().Name + ": " + FirstLine(ex.Message));
                UiHelper.DbError(ex);
                Log(title + ": the application is still running.");
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void LogChecks(string title, Func<List<CheckResult>> checks)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                List<CheckResult> results = checks();
                int passed = 0;
                Log(title + ":");
                foreach (CheckResult r in results)
                {
                    if (r.Passed) passed++;
                    string detail = string.IsNullOrEmpty(r.Detail) ? "" : " (" + r.Detail + ")";
                    Log("   " + (r.Passed ? "PASS  " : "FAIL  ") + r.Name + detail);
                }
                Log(title + ": " + passed + "/" + results.Count + " passed.");
            }
            catch (Exception ex)
            {
                Log(title + ": error caught - " + FirstLine(ex.Message));
                UiHelper.DbError(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void Log(string line)
        {
            txtLog.AppendText("[" + DateTime.Now.ToString("HH:mm:ss") + "] " + line + Environment.NewLine);
        }

        private static string FirstLine(string text)
        {
            if (string.IsNullOrEmpty(text)) return "";
            int end = text.IndexOfAny(new[] { '\r', '\n' });
            return end < 0 ? text : text.Substring(0, end);
        }
    }
}
