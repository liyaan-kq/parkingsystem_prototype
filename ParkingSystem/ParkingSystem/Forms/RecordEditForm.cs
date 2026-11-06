using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ParkingSystem.Controls;
using ParkingSystem.Helpers;
using ParkingSystem.Logic;
using red_framework;

namespace ParkingSystem.Forms
{
    public partial class RecordEditForm : Form
    {
        private const string TimeFormat = "yyyy-MM-dd  hh:mm tt";

        private readonly int transactionId;
        private RecordDetails record;
        private SlotInfo newSlot;

        public string ResultMessage { get; private set; }

        public RecordEditForm(int transactionId)
        {
            InitializeComponent();
            this.transactionId = transactionId;
        }

        private void RecordEditForm_Load(object sender, EventArgs e)
        {
            try
            {
                record = RecordService.GetRecord(transactionId);
                if (record == null)
                {
                    UiHelper.Warn("This record no longer exists. It may have been deleted.");
                    BeginInvoke(new Action(Close));
                    return;
                }
                List<VehicleRate> rates = RateService.GetAll();
                cboVehicleType.DataSource = rates;
                cboVehicleType.DisplayMember = "VehicleType";
                cboVehicleType.SelectedIndex = rates.FindIndex(r => r.VehicleType == record.VehicleType);
            }
            catch (Exception ex)
            {
                UiHelper.DbError(ex);
                BeginInvoke(new Action(Close));
                return;
            }
            ShowRecord();
        }

        private void ShowRecord()
        {
            lblRecordInfo.Text = "Record No. " + record.TransactionID + "     |     Status: " + record.Status +
                                 "     |     Stub No. " + (record.StubNo ?? "-");
            txtPlate.Text = record.PlateNumber;
            txtOwner.Text = record.OwnerName;
            txtSlot.Text = record.SlotNumber;
            btnChangeSlot.Enabled = record.IsParked;
            lblSlot.Text = record.IsParked ? "Parking slot" : "Parking slot (locked: vehicle has exited)";
            txtEntry.Text = record.EntryTime.ToString(TimeFormat);
            txtExit.Text = record.ExitTime.HasValue ? record.ExitTime.Value.ToString(TimeFormat) : "(still parked)";
            lblDurationFee.Text = record.IsParked
                ? "Duration and fee are computed at exit."
                : "Duration: " + FeeCalculator.FormatDuration(record.DurationMinutes.Value) +
                  "          Fee paid: " + FeeCalculator.FormatMoney(record.Fee.Value);
            lblUpdated.Text = "Last updated: " + record.UpdatedAt.ToString(TimeFormat);
        }

        private void btnChangeSlot_Click(object sender, EventArgs e)
        {
            using (SlotPickerForm picker = new SlotPickerForm(SlotMapMode.PickAvailable, record.SlotID))
            {
                if (picker.ShowDialog(this) != DialogResult.OK) return;
                newSlot = picker.SelectedSlot.SlotID == record.SlotID ? null : picker.SelectedSlot;
                txtSlot.Text = newSlot == null ? record.SlotNumber : record.SlotNumber + "  ->  " + newSlot.SlotNumber;
                StatusLine.Clear(lblStatus);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string plate = Validator.NormalizePlate(txtPlate.Text);
            string owner = Regex.Replace(txtOwner.Text.Trim(), @"\s+", " ");
            txtPlate.Text = plate;
            txtOwner.Text = owner;

            Control missing = FormControls.FirstRequired(txtPlate, cboVehicleType, txtOwner);
            if (missing != null) { StatusLine.Error(lblStatus, RequiredMessage(missing), missing); return; }
            if (!Validator.IsValidPlate(plate)) { StatusLine.Error(lblStatus, Validator.PlateRuleMessage.Replace("\n", " "), txtPlate); return; }
            if (!Validator.IsValidName(owner)) { StatusLine.Error(lblStatus, Validator.NameRuleMessage, txtOwner); return; }

            string vehicleType = ((VehicleRate)cboVehicleType.SelectedItem).VehicleType;
            int slotId = newSlot == null ? record.SlotID : newSlot.SlotID;

            bool vehicleChanged = plate != record.PlateNumber || vehicleType != record.VehicleType || owner != record.OwnerName;
            if (!vehicleChanged && newSlot == null)
            {
                StatusLine.Hint(lblStatus, "No changes to save.");
                return;
            }

            if (vehicleChanged && !UiHelper.Confirm("Save changes to " + record.PlateNumber + "?\n\n" +
                                                    "Plate, type and owner apply to every visit of this vehicle."))
                return;

            try
            {
                OperationResult result = RecordService.UpdateRecord(record.TransactionID, plate, vehicleType, owner, slotId);
                if (result.Success)
                {
                    ResultMessage = result.Message;
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    StatusLine.Error(lblStatus, result.Message);
                }
            }
            catch (Exception ex)
            {
                UiHelper.DbError(ex);
            }
        }

        private string RequiredMessage(Control missing)
        {
            if (missing == txtPlate) return "Enter the plate number.";
            if (missing == cboVehicleType) return "Select the vehicle type.";
            return "Enter the owner / driver name.";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
