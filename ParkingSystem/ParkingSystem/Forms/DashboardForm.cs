using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ParkingSystem.Controls;
using ParkingSystem.Helpers;
using ParkingSystem.Logic;

namespace ParkingSystem.Forms
{
    public partial class DashboardForm : Form
    {
        private const string ActPark = "Park";
        private const string ActReserve = "Reserve";
        private const string ActRelease = "Release";
        private const string ActExit = "Exit";
        private const string ActEdit = "Edit";
        private const string ActHistory = "History";

        private List<VehicleRate> rates = new List<VehicleRate>();
        private SuggestBox findSuggest;

        public bool LoggedOut { get; private set; }

        public DashboardForm()
        {
            InitializeComponent();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Welcome, " + (Session.FullName ?? "Admin");
            btnNavDashboard.BackColor = Theme.Primary;
            slotMap.Mode = SlotMapMode.Browse;
            slotMap.SlotClicked += delegate (object s, SlotInfo slot) { ShowSlot(slot); };

            findSuggest = new SuggestBox(txtFind, FindMatches);
            findSuggest.Picked += FindSuggest_Picked;
            findSuggest.Submitted += delegate { FindFirstMatch(); };

            tmrClock_Tick(null, EventArgs.Empty);
            tmrClock.Start();
            tmrRefresh.Start();
            RefreshAll();
            SelectFirstSlot();
        }

        public void RefreshAll()
        {
            try
            {
                rates = RateService.GetAll();
                DashboardStats s = ReportService.GetDashboardStats();
                lblCard1Value.Text = s.Available + " / " + s.TotalSlots;
                lblCard2Value.Text = s.Occupied.ToString();
                lblCard3Value.Text = s.Reserved.ToString();
                lblCard4Value.Text = FeeCalculator.FormatMoney(s.TodayIncome);
                lblCard4Title.Text = "Today's income (" + s.StubsToday + " stub" + (s.StubsToday == 1 ? "" : "s") + ")";

                slotMap.ShowSlots(SlotService.GetAll());
                ShowSlot(slotMap.SelectedSlot);
            }
            catch (Exception ex)
            {
                UiHelper.DbError(ex);
            }
        }

        private void SelectFirstSlot()
        {
            if (slotMap.Slots.Count == 0) return;
            slotMap.SelectSlot(slotMap.Slots[0].SlotID);
            ShowSlot(slotMap.SelectedSlot);
        }

        private void tmrRefresh_Tick(object sender, EventArgs e)
        {
            if (Form.ActiveForm == this && !findSuggest.IsOpen) RefreshAll();
        }

        private void tmrClock_Tick(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy  hh:mm:ss tt");
        }

        private void ShowSlot(SlotInfo slot)
        {
            if (slot == null)
            {
                lblInfoSlot.Text = "-";
                lblInfoStatus.Text = "";
                lblInfoKeys.Text = "";
                lblInfoDetails.Text = "Click a slot on the map.";
                SetActions(null, null, null);
                return;
            }

            lblInfoSlot.Text = slot.SlotNumber;
            lblInfoStatus.ForeColor = Theme.StatusFore(slot.Status);

            if (slot.IsOccupied)
            {
                int minutes = FeeCalculator.GetDurationMinutes(slot.EntryTime.Value, DateTime.Now);
                VehicleRate rate = rates.Find(r => r.VehicleType == slot.VehicleType);
                string feeSoFar = rate == null ? "-" : FeeCalculator.FormatMoney(FeeCalculator.ComputeFee(minutes, rate));

                lblInfoStatus.Text = "Occupied";
                lblInfoKeys.Text = "Plate\nOwner\nType\n\nSince\nParked\nFee so far";
                lblInfoDetails.Text =
                    slot.PlateNumber + "\n" +
                    slot.OwnerName + "\n" +
                    slot.VehicleType + "\n\n" +
                    slot.EntryTime.Value.ToString("MMM dd, hh:mm tt") + "\n" +
                    FeeCalculator.FormatDuration(minutes) + "\n" +
                    feeSoFar;
                SetActions(ActExit, ActEdit, ActHistory);
            }
            else if (slot.IsReserved)
            {
                lblInfoStatus.Text = "Reserved";
                lblInfoKeys.Text = "Since";
                lblInfoDetails.Text = slot.UpdatedAt.ToString("MMM dd, hh:mm tt") + "\n\n" +
                                      "Not offered at vehicle entry until released.";
                SetActions(ActRelease, null, null);
            }
            else
            {
                lblInfoStatus.Text = "Free";
                lblInfoKeys.Text = "Free since";
                lblInfoDetails.Text = slot.UpdatedAt.ToString("MMM dd, hh:mm tt");
                SetActions(ActPark, ActReserve, null);
            }
        }

        private void SetActions(string first, string second, string third)
        {
            SetAction(btnAction1, first);
            SetAction(btnAction2, second);
            SetAction(btnAction3, third);
        }

        private static void SetAction(Button button, string action)
        {
            button.Tag = action;
            button.Visible = action != null;
            switch (action)
            {
                case ActPark: button.Text = "Park vehicle here"; break;
                case ActReserve: button.Text = "Reserve slot"; break;
                case ActRelease: button.Text = "Release reservation"; break;
                case ActExit: button.Text = "Process exit"; break;
                case ActEdit: button.Text = "Edit record"; break;
                case ActHistory: button.Text = "Vehicle history"; break;
            }
        }

        private void InfoAction_Click(object sender, EventArgs e)
        {
            SlotInfo slot = slotMap.SelectedSlot;
            if (slot == null) return;

            switch ((string)((Button)sender).Tag)
            {
                case ActPark:
                    OpenEntry(slot.SlotID);
                    break;
                case ActReserve:
                    ApplySlotChange(SlotService.Reserve(slot.SlotID), slot.SlotID);
                    break;
                case ActRelease:
                    ApplySlotChange(SlotService.Release(slot.SlotID), slot.SlotID);
                    break;
                case ActExit:
                    OpenExit(slot.TransactionID);
                    break;
                case ActEdit:
                    using (RecordEditForm edit = new RecordEditForm(slot.TransactionID.Value))
                    {
                        if (edit.ShowDialog(this) == DialogResult.OK) StatusLine.Ok(lblStatus, edit.ResultMessage);
                    }
                    RefreshAll();
                    break;
                case ActHistory:
                    using (RecordsForm records = new RecordsForm(slot.PlateNumber))
                    {
                        records.ShowDialog(this);
                    }
                    RefreshAll();
                    break;
            }
        }

        private void ApplySlotChange(OperationResult result, int slotId)
        {
            if (result.Success) StatusLine.Ok(lblStatus, result.Message);
            else StatusLine.Error(lblStatus, result.Message);
            RefreshAll();
            slotMap.SelectSlot(slotId);
            ShowSlot(slotMap.SelectedSlot);
        }

        private List<SuggestItem> FindMatches(string typed)
        {
            List<SuggestItem> items = new List<SuggestItem>();
            foreach (SlotInfo s in slotMap.Slots)
            {
                if (!s.IsOccupied || SearchHelper.Score(typed, s.PlateNumber, s.OwnerName, s.SlotNumber) == 0) continue;
                items.Add(new SuggestItem { Text = s.PlateNumber + "  -  " + s.OwnerName + "  -  " + s.SlotNumber, Value = s });
                if (items.Count == 8) break;
            }
            return items;
        }

        private void FindSuggest_Picked(object sender, SuggestItem item)
        {
            SlotInfo slot = (SlotInfo)item.Value;
            findSuggest.SetTextQuietly("");
            slotMap.SelectSlot(slot.SlotID);
            ShowSlot(slotMap.SelectedSlot);
            StatusLine.Hint(lblStatus, slot.PlateNumber + " is parked at " + slot.SlotNumber + ".");
        }

        private void FindFirstMatch()
        {
            List<SuggestItem> matches = FindMatches(txtFind.Text);
            if (matches.Count > 0) FindSuggest_Picked(this, matches[0]);
            else if (txtFind.Text.Trim().Length > 0) StatusLine.Error(lblStatus, "No parked vehicle matches \"" + txtFind.Text.Trim() + "\".");
        }

        private void OpenEntry(int? presetSlotId)
        {
            int? parkedSlot = null;
            using (VehicleEntryForm entry = new VehicleEntryForm(presetSlotId))
            {
                if (entry.ShowDialog(this) == DialogResult.OK)
                {
                    StatusLine.Ok(lblStatus, entry.ResultMessage);
                    parkedSlot = entry.ParkedSlotId;
                }
            }
            RefreshAll();
            if (parkedSlot.HasValue)
            {
                slotMap.SelectSlot(parkedSlot.Value);
                ShowSlot(slotMap.SelectedSlot);
            }
        }

        private void OpenExit(int? transactionId)
        {
            using (VehicleExitForm exit = new VehicleExitForm(transactionId))
            {
                exit.ShowDialog(this);
                if (exit.ResultMessage != null) StatusLine.Ok(lblStatus, exit.ResultMessage);
            }
            RefreshAll();
        }

        private void OpenModule(Form module)
        {
            using (module)
            {
                module.ShowDialog(this);
            }
            RefreshAll();
        }

        private void btnNavDashboard_Click(object sender, EventArgs e) { RefreshAll(); }
        private void btnNavEntry_Click(object sender, EventArgs e) { OpenEntry(null); }
        private void btnNavExit_Click(object sender, EventArgs e) { OpenExit(null); }
        private void btnNavRecords_Click(object sender, EventArgs e) { OpenModule(new RecordsForm()); }
        private void btnNavRates_Click(object sender, EventArgs e) { OpenModule(new RatesForm()); }
        private void btnNavDebug_Click(object sender, EventArgs e) { OpenModule(new DebugForm()); }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (!UiHelper.Confirm("Are you sure you want to log out?")) return;
            AuthService.Logout();
            LoggedOut = true;
            Close();
        }

        private void DashboardForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!LoggedOut && e.CloseReason == CloseReason.UserClosing)
            {
                if (!UiHelper.Confirm("Exit the Parking Location Management System?"))
                {
                    e.Cancel = true;
                    return;
                }
                AuthService.Logout();
            }
            tmrClock.Stop();
            tmrRefresh.Stop();
        }
    }
}
