using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ParkingSystem.Helpers;
using ParkingSystem.Logic;
using red_framework;

namespace ParkingSystem.Forms
{
    public partial class RecordsForm : Form
    {
        private const string TimeFormat = "yyyy-MM-dd hh:mm tt";

        private string statusFilter;
        private string statusFilterName = "All Records";
        private DataTable records;
        private Font statusFont;
        private readonly string presetSearch;
        private bool settingFilters;

        private static readonly string[] ReportHeaders =
            { "Txn No.", "Stub No.", "Plate No.", "Type", "Owner / Driver", "Slot", "Entry Time", "Exit Time", "Duration", "Fee", "Status", "Last Updated" };
        private static readonly float[] ReportWidths = { 0.6f, 0.7f, 0.9f, 0.9f, 1.5f, 0.5f, 1.5f, 1.5f, 1.1f, 0.9f, 0.9f, 1.5f };

        public RecordsForm(string presetSearch = null)
        {
            InitializeComponent();
            this.presetSearch = presetSearch;
        }

        private void RecordsForm_Load(object sender, EventArgs e)
        {
            SetDefaultFilters();
            SetActiveTab(btnTabAll, null);
            if (!string.IsNullOrEmpty(presetSearch))
            {
                settingFilters = true;
                txtSearch.Text = presetSearch;
                settingFilters = false;
                lblHeader.Text = "Vehicle History: " + presetSearch;
            }
            LoadRecords();
        }

        private void SetDefaultFilters()
        {
            settingFilters = true;
            FormControls.ClearInputs(txtSearch);
            FormControls.ClearInputs(chkDateFilter);
            FormControls.ClearInputs(dtpTo);
            dtpFrom.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpFrom.Enabled = dtpTo.Enabled = false;
            settingFilters = false;
        }

        private void chkDateFilter_CheckedChanged(object sender, EventArgs e)
        {
            dtpFrom.Enabled = dtpTo.Enabled = chkDateFilter.Checked;
            Filter_Changed(sender, e);
        }

        private void Filter_Changed(object sender, EventArgs e)
        {
            if (!settingFilters) LoadRecords();
        }

        private void Tab_Click(object sender, EventArgs e)
        {
            if (sender == btnTabParked) SetActiveTab(btnTabParked, "Parked");
            else if (sender == btnTabCompleted) SetActiveTab(btnTabCompleted, "Completed");
            else SetActiveTab(btnTabAll, null);
            LoadRecords();
        }

        private void SetActiveTab(Button active, string status)
        {
            statusFilter = status;
            statusFilterName = active.Text;
            foreach (Button tab in new[] { btnTabAll, btnTabParked, btnTabCompleted })
            {
                bool isActive = tab == active;
                tab.BackColor = isActive ? Theme.Primary : Color.White;
                tab.ForeColor = isActive ? Color.White : Theme.Navy;
            }
        }

        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            SetDefaultFilters();
            SetActiveTab(btnTabAll, null);
            LoadRecords();
        }

        private void LoadRecords()
        {
            string search = txtSearch.Text.Trim();

            DateTime? from = null, to = null;
            if (chkDateFilter.Checked)
            {
                if (dtpFrom.Value.Date > dtpTo.Value.Date)
                {
                    StatusLine.Error(lblStatus, "From date cannot be later than To date.");
                    return;
                }
                from = dtpFrom.Value.Date;
                to = dtpTo.Value.Date;
            }

            try
            {
                records = ReportService.GetRecords(statusFilter, search, from, to);
            }
            catch (Exception ex)
            {
                UiHelper.DbError(ex);
                return;
            }

            AppDb.Instance.Table(records, dgvRecords, ReportHeaders);
            SetupColumns();
            UpdateSummary();
            if (StatusLine.IsError(lblStatus)) StatusLine.Hint(lblStatus, "Double-click a record to edit it.");
        }

        private void SetupColumns()
        {
            string[] names = { "TransactionID", "StubNo", "PlateNumber", "VehicleType", "OwnerName", "SlotNumber",
                               "EntryTime", "ExitTime", "DurationMinutes", "Fee", "Status", "UpdatedAt" };
            for (int i = 0; i < names.Length; i++)
            {
                DataGridViewColumn col = dgvRecords.Columns[names[i]];
                if (col == null) continue;
                col.FillWeight = ReportWidths[i] * 100;
                col.SortMode = DataGridViewColumnSortMode.Automatic;
            }
            dgvRecords.Columns["EntryTime"].DefaultCellStyle.Format = TimeFormat;
            dgvRecords.Columns["ExitTime"].DefaultCellStyle.Format = TimeFormat;
            dgvRecords.Columns["UpdatedAt"].DefaultCellStyle.Format = TimeFormat;
            dgvRecords.Columns["Fee"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void dgvRecords_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.Value == null) return;
            string column = dgvRecords.Columns[e.ColumnIndex].DataPropertyName;

            if (column == "DurationMinutes")
            {
                e.Value = e.Value == DBNull.Value ? "-" : FeeCalculator.FormatDuration(Convert.ToInt32(e.Value));
                e.FormattingApplied = true;
            }
            else if (column == "Fee")
            {
                e.Value = e.Value == DBNull.Value ? "-" : FeeCalculator.FormatMoney(Convert.ToDecimal(e.Value));
                e.FormattingApplied = true;
            }
            else if ((column == "ExitTime" || column == "StubNo") && e.Value == DBNull.Value)
            {
                e.Value = "-";
                e.FormattingApplied = true;
            }
            else if (column == "Status")
            {
                bool parked = Convert.ToString(e.Value) == "Parked";
                e.CellStyle.ForeColor = parked ? Theme.Primary : Theme.AvailableFore;
                if (statusFont == null) statusFont = new Font(dgvRecords.Font, FontStyle.Bold);
                e.CellStyle.Font = statusFont;
            }
        }

        private void UpdateSummary()
        {
            int parked = 0, completed = 0;
            decimal income = 0;
            foreach (DataRow row in records.Rows)
            {
                if ((string)row["Status"] == "Parked") parked++;
                else
                {
                    completed++;
                    income += Convert.ToDecimal(row["Fee"]);
                }
            }
            lblSummary.Text = "Showing " + records.Rows.Count + " record(s)     |     Parked: " + parked +
                              "     |     Completed: " + completed + "     |     Total Income: " + FeeCalculator.FormatMoney(income);
        }

        private DataTable BuildReportTable()
        {
            DataTable table = new DataTable();
            foreach (string header in ReportHeaders)
                table.Columns.Add(header, typeof(string));

            foreach (DataRow r in records.Rows)
            {
                bool done = (string)r["Status"] == "Completed";
                table.Rows.Add(new object[]
                {
                    r["TransactionID"].ToString(),
                    done ? r["StubNo"].ToString() : "-",
                    (string)r["PlateNumber"],
                    (string)r["VehicleType"],
                    (string)r["OwnerName"],
                    (string)r["SlotNumber"],
                    (Convert.ToDateTime(r["EntryTime"])).ToString(TimeFormat),
                    done ? (Convert.ToDateTime(r["ExitTime"])).ToString(TimeFormat) : "-",
                    done ? FeeCalculator.FormatDuration(Convert.ToInt32(r["DurationMinutes"])) : "-",
                    done ? FeeCalculator.FormatMoney(Convert.ToDecimal(r["Fee"])) : "-",
                    (string)r["Status"],
                    (Convert.ToDateTime(r["UpdatedAt"])).ToString(TimeFormat)
                });
            }
            return table;
        }

        private string DescribeFilters()
        {
            string plate = txtSearch.Text.Trim().Length == 0 ? "any" : "\"" + txtSearch.Text.Trim() + "\"";
            string dates = chkDateFilter.Checked
                ? dtpFrom.Value.ToString("yyyy-MM-dd") + " to " + dtpTo.Value.ToString("yyyy-MM-dd")
                : "all dates";
            return "Filter: " + statusFilterName + "   |   Plate/owner: " + plate + "   |   Entry date: " + dates;
        }

        private bool HasRecords(string action)
        {
            if (records != null && records.Rows.Count > 0) return true;
            StatusLine.Error(lblStatus, "There are no records to " + action + ". Change the filters first.");
            return false;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (!HasRecords("print")) return;
            string subtitle = UiHelper.AppTitle + "\n" +
                              DescribeFilters() + "\n" +
                              "Prepared by: " + (Session.FullName ?? "Admin");
            ReportPrinter.Preview(BuildReportTable(), "Parking Records Report", subtitle, lblSummary.Text, ReportWidths, this);
        }

        private void btnChart_Click(object sender, EventArgs e)
        {
            if (!HasRecords("chart")) return;
            using (ReportChartForm chart = new ReportChartForm(records.Copy(), DescribeFilters()))
                chart.ShowDialog(this);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (!HasRecords("export")) return;
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "CSV file (*.csv)|*.csv";
                dialog.FileName = "ParkingReport_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".csv";
                if (dialog.ShowDialog(this) != DialogResult.OK) return;
                try
                {
                    ExportHelper.SaveCsv(dialog.FileName, BuildReportTable());
                    StatusLine.Ok(lblStatus, "Report exported to " + dialog.FileName);
                }
                catch (Exception ex)
                {
                    UiHelper.Error("Could not save the file. Is it open in Excel?\n\nDetails: " + ex.Message);
                }
            }
        }

        private void btnReprint_Click(object sender, EventArgs e)
        {
            ReprintSelected();
        }

        private void dgvRecords_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) EditSelected();
        }

        private void ReprintSelected()
        {
            DataRowView view = GetSelectedRecord();
            if (view == null) return;
            if ((string)view["Status"] != "Completed")
            {
                StatusLine.Error(lblStatus, view["PlateNumber"] + " is still parked, so it has no stub yet. Stubs are issued at exit.");
                return;
            }

            try
            {
                StubInfo stub = ReportService.GetStub(Convert.ToInt32(view["TransactionID"]));
                if (stub == null)
                {
                    StatusLine.Error(lblStatus, "No stub was found for this record.");
                    return;
                }
                ReportPrinter.PreviewStub(StubFormatter.BuildLines(stub), stub.StubNo, this);
            }
            catch (Exception ex)
            {
                UiHelper.DbError(ex);
            }
        }

        private DataRowView GetSelectedRecord()
        {
            if (dgvRecords.SelectedRows.Count == 0 || dgvRecords.SelectedRows[0].DataBoundItem == null)
            {
                StatusLine.Error(lblStatus, "Select a record first.");
                return null;
            }
            return (DataRowView)dgvRecords.SelectedRows[0].DataBoundItem;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string message = null;
            using (VehicleEntryForm entry = new VehicleEntryForm())
            {
                if (entry.ShowDialog(this) == DialogResult.OK) message = entry.ResultMessage;
            }
            LoadRecords();
            if (message != null) StatusLine.Ok(lblStatus, message);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditSelected();
        }

        private void EditSelected()
        {
            DataRowView view = GetSelectedRecord();
            if (view == null) return;

            string message;
            using (RecordEditForm edit = new RecordEditForm(Convert.ToInt32(view["TransactionID"])))
            {
                if (edit.ShowDialog(this) != DialogResult.OK) return;
                message = edit.ResultMessage;
            }
            LoadRecords();
            StatusLine.Ok(lblStatus, message);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataRowView view = GetSelectedRecord();
            if (view == null) return;

            int id = Convert.ToInt32(view["TransactionID"]);
            string plate = (string)view["PlateNumber"];
            string question;
            if ((string)view["Status"] == "Parked")
            {
                question = "Void the parking entry of " + plate + " at slot " + view["SlotNumber"] + "?\n\n" +
                           "Record No. " + id + " will be deleted and slot " + view["SlotNumber"] + " will become Available.\n" +
                           "This cannot be undone.";
            }
            else
            {
                question = "Delete the completed record of " + plate + " (Stub No. " + view["StubNo"] + ", " +
                           FeeCalculator.FormatMoney(Convert.ToDecimal(view["Fee"])) + ")?\n\n" +
                           "Record No. " + id + " and its stub will be deleted, and income totals will change.\n" +
                           "This cannot be undone.";
            }
            if (!UiHelper.Confirm(question)) return;

            try
            {
                OperationResult result = RecordService.DeleteRecord(id);
                LoadRecords();
                if (result.Success) StatusLine.Ok(lblStatus, result.Message);
                else StatusLine.Error(lblStatus, result.Message);
                return;
            }
            catch (Exception ex)
            {
                UiHelper.DbError(ex);
            }
            LoadRecords();
        }
    }
}
