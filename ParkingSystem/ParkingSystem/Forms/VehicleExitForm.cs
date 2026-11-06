using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ParkingSystem.Controls;
using ParkingSystem.Helpers;
using ParkingSystem.Logic;
using red_framework;

namespace ParkingSystem.Forms
{
    public partial class VehicleExitForm : Form
    {
        private const string TimeFormat = "MMM dd, hh:mm tt";

        private readonly int? presetTransactionId;
        private List<ActiveParking> parked = new List<ActiveParking>();
        private ActiveParking current;
        private VehicleRate currentRate;
        private StubInfo issuedStub;
        private bool filling;

        public string ResultMessage { get; private set; }

        public VehicleExitForm(int? presetTransactionId = null)
        {
            InitializeComponent();
            this.presetTransactionId = presetTransactionId;
        }

        private void VehicleExitForm_Load(object sender, EventArgs e)
        {
            LoadParked(presetTransactionId);
            ActiveControl = txtSearch;
        }

        private void LoadParked(int? selectTransactionId)
        {
            try
            {
                parked = ParkingService.GetActiveList();
            }
            catch (Exception ex)
            {
                UiHelper.DbError(ex);
                parked = new List<ActiveParking>();
            }
            FillGrid(selectTransactionId);
        }

        private void FillGrid(int? selectTransactionId)
        {
            List<ActiveParking> shown = SearchHelper.MatchActive(parked, txtSearch.Text);
            filling = true;
            dgvParked.Rows.Clear();
            foreach (ActiveParking p in shown)
            {
                int minutes = FeeCalculator.GetDurationMinutes(p.EntryTime, DateTime.Now);
                int row = dgvParked.Rows.Add(p.PlateNumber, p.OwnerName, p.VehicleType, p.SlotNumber,
                                             p.EntryTime.ToString("hh:mm tt"), FeeCalculator.FormatDuration(minutes));
                dgvParked.Rows[row].Tag = p;
            }
            dgvParked.ClearSelection();
            filling = false;

            lblCount.Text = parked.Count == 0 ? "No vehicles are parked right now."
                          : shown.Count == parked.Count ? parked.Count + " vehicle(s) parked."
                          : shown.Count + " of " + parked.Count + " parked vehicle(s) match \"" + txtSearch.Text.Trim() + "\".";

            int index = -1;
            for (int i = 0; i < dgvParked.Rows.Count; i++)
                if (selectTransactionId.HasValue && ((ActiveParking)dgvParked.Rows[i].Tag).TransactionID == selectTransactionId.Value) index = i;
            if (index < 0 && dgvParked.Rows.Count > 0 && issuedStub == null) index = 0;

            if (index >= 0)
            {
                dgvParked.Rows[index].Selected = true;
                dgvParked.CurrentCell = dgvParked.Rows[index].Cells[0];
                ShowBill((ActiveParking)dgvParked.Rows[index].Tag);
            }
            else if (issuedStub == null)
            {
                ShowEmpty(parked.Count == 0 ? "No vehicles are parked right now." : "No parked vehicle matches your search.");
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            issuedStub = null;
            FillGrid(null);
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (current != null && btnPay.Enabled) btnPay.Focus();
            }
            else if (e.KeyCode == Keys.Down && dgvParked.Rows.Count > 0)
            {
                dgvParked.Focus();
            }
        }

        private void dgvParked_SelectionChanged(object sender, EventArgs e)
        {
            if (filling || dgvParked.CurrentRow == null || !dgvParked.CurrentRow.Selected) return;
            issuedStub = null;
            ShowBill((ActiveParking)dgvParked.CurrentRow.Tag);
        }

        private void btnSlots_Click(object sender, EventArgs e)
        {
            using (SlotPickerForm picker = new SlotPickerForm(SlotMapMode.PickOccupied))
            {
                if (picker.ShowDialog(this) != DialogResult.OK) return;
                txtSearch.TextChanged -= txtSearch_TextChanged;
                FormControls.ClearText(txtSearch);
                txtSearch.TextChanged += txtSearch_TextChanged;
                issuedStub = null;
                LoadParked(picker.SelectedSlot.TransactionID);
            }
        }

        private void ShowEmpty(string message)
        {
            current = null;
            lblBillTitle.Text = "No vehicle selected";
            lblBillKeys.Text = "";
            lblBillDetails.Left = lblBillKeys.Left;
            lblBillDetails.Text = message;
            lblBillDetails.Visible = true;
            lblBillKeys.Visible = true;
            txtStub.Visible = false;
            pnlTotal.Visible = false;
            StatusLine.Clear(lblStatus);
            btnPay.Enabled = false;
            btnPrint.Enabled = false;
        }

        private void ShowBill(ActiveParking p)
        {
            try
            {
                currentRate = RateService.Get(p.VehicleType);
            }
            catch (Exception ex)
            {
                UiHelper.DbError(ex);
                return;
            }
            current = p;
            if (currentRate == null)
            {
                ShowEmpty("No rate is defined for '" + p.VehicleType + "'. Check Rates Settings.");
                return;
            }

            int minutes = FeeCalculator.GetDurationMinutes(p.EntryTime, DateTime.Now);
            decimal fee = FeeCalculator.ComputeFee(minutes, currentRate);

            lblBillTitle.Text = p.PlateNumber;
            lblBillKeys.Text = "Owner\nType\nSlot\n\nEntry\nExit\nDuration\nRate";
            lblBillDetails.Left = lblBillKeys.Right + 2;
            lblBillDetails.Text =
                p.OwnerName + "\n" +
                p.VehicleType + "\n" +
                p.SlotNumber + "\n\n" +
                p.EntryTime.ToString(TimeFormat) + "\n" +
                DateTime.Now.ToString(TimeFormat) + "\n" +
                FeeCalculator.FormatDuration(minutes) + "\n" +
                currentRate.DescribeShort();
            lblTotal.Text = FeeCalculator.FormatMoney(fee);
            lblBillDetails.Visible = true;
            lblBillKeys.Visible = true;
            pnlTotal.Visible = true;
            txtStub.Visible = false;
            StatusLine.Clear(lblStatus);
            btnPay.Enabled = true;
            btnPrint.Enabled = false;
        }

        private void ShowStub(StubInfo stub)
        {
            lblBillTitle.Text = "Stub No. " + stub.StubNo;
            txtStub.Text = StubFormatter.BuildText(stub);
            txtStub.Visible = true;
            lblBillDetails.Visible = false;
            lblBillKeys.Visible = false;
            pnlTotal.Visible = false;
            btnPay.Enabled = false;
            btnPrint.Enabled = true;
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (current == null) return;
            try
            {
                VehicleRate latest = RateService.Get(current.VehicleType);
                if (latest != null) currentRate = latest;
                DateTime exitTime = DateTime.Now;
                int minutes = FeeCalculator.GetDurationMinutes(current.EntryTime, exitTime);
                decimal fee = FeeCalculator.ComputeFee(minutes, currentRate);
                lblTotal.Text = FeeCalculator.FormatMoney(fee);

                if (!UiHelper.Confirm("Receive " + FeeCalculator.FormatMoney(fee) + " from " + current.PlateNumber + "?\n\n" +
                                      "Slot " + current.SlotNumber + ", parked " + FeeCalculator.FormatDuration(minutes) + "."))
                    return;

                OperationResult<StubInfo> result = ParkingService.CompleteExit(current, exitTime, minutes, fee);
                if (!result.Success)
                {
                    issuedStub = null;
                    LoadParked(null);
                    StatusLine.Error(lblStatus, result.Message);
                    return;
                }

                issuedStub = result.Data;
                ResultMessage = result.Message;
                filling = true;
                parked.RemoveAll(p => p.TransactionID == current.TransactionID);
                filling = false;
                current = null;
                FillGrid(null);
                ShowStub(issuedStub);
                StatusLine.Ok(lblStatus, result.Message);
                btnPrint.Focus();
            }
            catch (Exception ex)
            {
                UiHelper.DbError(ex);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (issuedStub == null) return;
            ReportPrinter.PreviewStub(StubFormatter.BuildLines(issuedStub), issuedStub.StubNo, this);
        }
    }
}
