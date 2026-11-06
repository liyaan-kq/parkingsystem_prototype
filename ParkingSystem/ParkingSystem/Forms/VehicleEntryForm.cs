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
    public partial class VehicleEntryForm : Form
    {
        private readonly int? presetSlotId;
        private List<SlotInfo> freeSlots = new List<SlotInfo>();
        private List<VehicleInfo> vehicles = new List<VehicleInfo>();
        private List<ActiveParking> parked = new List<ActiveParking>();
        private SuggestBox plateSuggest;
        private bool loadingSlots;
        private bool plateMessageShown;

        public string ResultMessage { get; private set; }
        public int? ParkedSlotId { get; private set; }

        public VehicleEntryForm(int? presetSlotId = null)
        {
            InitializeComponent();
            this.presetSlotId = presetSlotId;
        }

        private void VehicleEntryForm_Load(object sender, EventArgs e)
        {
            plateSuggest = new SuggestBox(txtPlate, PlateMatches);
            plateSuggest.Picked += PlateSuggest_Picked;
            txtPlate.TextChanged += delegate { if (plateMessageShown) { StatusLine.Clear(lblStatus); plateMessageShown = false; } };
            txtPlate.Leave += delegate { CheckPlate(); };

            try
            {
                cboVehicleType.DataSource = RateService.GetAll();
                cboVehicleType.DisplayMember = "VehicleType";
                cboVehicleType.SelectedIndex = -1;
                vehicles = ParkingService.GetVehicles();
                parked = ParkingService.GetActiveList();
                LoadSlots(presetSlotId);
            }
            catch (Exception ex)
            {
                UiHelper.DbError(ex);
                btnSave.Enabled = false;
            }
            tmrClock_Tick(null, EventArgs.Empty);
            tmrClock.Start();
            ActiveControl = txtPlate;
        }

        private void tmrClock_Tick(object sender, EventArgs e)
        {
            txtEntryTime.Text = DateTime.Now.ToString("yyyy-MM-dd  hh:mm:ss tt");
        }

        private List<SuggestItem> PlateMatches(string typed)
        {
            List<SuggestItem> items = new List<SuggestItem>();
            foreach (VehicleInfo v in SearchHelper.MatchVehicles(vehicles, typed, 8))
            {
                ActiveParking inside = parked.Find(p => p.VehicleID == v.VehicleID);
                string where = inside == null ? "" : "   (parked at " + inside.SlotNumber + ")";
                items.Add(new SuggestItem { Text = v.PlateNumber + "  -  " + v.OwnerName + "  -  " + v.VehicleType + where, Value = v });
            }
            return items;
        }

        private void PlateSuggest_Picked(object sender, SuggestItem item)
        {
            VehicleInfo v = (VehicleInfo)item.Value;
            plateSuggest.SetTextQuietly(v.PlateNumber);
            FillVehicle(v);
            CheckPlate();
            txtOwner.Focus();
        }

        private void FillVehicle(VehicleInfo v)
        {
            for (int i = 0; i < cboVehicleType.Items.Count; i++)
                if (((VehicleRate)cboVehicleType.Items[i]).VehicleType == v.VehicleType) cboVehicleType.SelectedIndex = i;
            txtOwner.Text = v.OwnerName;
        }

        private void CheckPlate()
        {
            string plate = Validator.NormalizePlate(txtPlate.Text);
            if (plate.Length == 0) return;
            plateSuggest.SetTextQuietly(plate);

            ActiveParking inside = parked.Find(p => Validator.PlateKey(p.PlateNumber) == Validator.PlateKey(plate));
            if (inside != null)
            {
                StatusLine.Error(lblStatus, inside.PlateNumber + " is already parked at " + inside.SlotNumber +
                                 " (since " + inside.EntryTime.ToString("hh:mm tt") + "). Process its exit first.");
                plateMessageShown = true;
                return;
            }

            VehicleInfo known = vehicles.Find(v => Validator.PlateKey(v.PlateNumber) == Validator.PlateKey(plate));
            if (known != null)
            {
                if (txtOwner.Text.Trim().Length == 0 || cboVehicleType.SelectedIndex < 0) FillVehicle(known);
                StatusLine.Hint(lblStatus, "Returning vehicle " + known.PlateNumber + ": details filled in. You can update them.");
                plateMessageShown = true;
            }
            else if (plateMessageShown)
            {
                StatusLine.Clear(lblStatus);
                plateMessageShown = false;
            }
        }

        private void cboVehicleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            VehicleRate rate = cboVehicleType.SelectedItem as VehicleRate;
            lblRateInfo.Text = rate == null ? "Select a vehicle type to see its rate." : rate.Describe();
        }

        private class ZoneOption
        {
            public string Zone;
            public int Free;
            public override string ToString() { return "Zone " + Zone + "  -  " + (Free == 0 ? "full" : Free + " free"); }
        }

        private void LoadSlots(int? preferSlotId)
        {
            freeSlots = SlotService.GetAvailable();
            loadingSlots = true;
            cboZone.Items.Clear();
            foreach (string zone in new[] { "A", "B", "C", "D", "E" })
                cboZone.Items.Add(new ZoneOption { Zone = zone, Free = freeSlots.FindAll(s => s.Zone == zone).Count });
            loadingSlots = false;

            if (freeSlots.Count == 0)
            {
                cboNumber.Items.Clear();
                lblSlotHint.Text = "";
                StatusLine.Error(lblStatus, "Parking is full. Free a slot (vehicle exit or release a reservation) first.");
                btnSave.Enabled = false;
                btnSlots.Enabled = false;
                return;
            }

            btnSave.Enabled = true;
            btnSlots.Enabled = true;
            SlotInfo target = preferSlotId.HasValue ? freeSlots.Find(s => s.SlotID == preferSlotId.Value) : null;
            if (preferSlotId.HasValue && target == null)
                StatusLine.Error(lblStatus, "That slot was just taken or reserved. The next free slot is selected instead.");
            SelectSlot(target ?? freeSlots[0]);
        }

        private void SelectSlot(SlotInfo slot)
        {
            for (int i = 0; i < cboZone.Items.Count; i++)
                if (((ZoneOption)cboZone.Items[i]).Zone == slot.Zone) cboZone.SelectedIndex = i;
            for (int i = 0; i < cboNumber.Items.Count; i++)
                if (((SlotInfo)cboNumber.Items[i]).SlotID == slot.SlotID) cboNumber.SelectedIndex = i;
        }

        private void cboZone_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loadingSlots) return;
            ZoneOption zone = cboZone.SelectedItem as ZoneOption;
            cboNumber.Items.Clear();
            cboNumber.DisplayMember = "Number";
            if (zone == null) return;

            foreach (SlotInfo s in freeSlots.FindAll(x => x.Zone == zone.Zone)) cboNumber.Items.Add(s);
            if (cboNumber.Items.Count > 0) cboNumber.SelectedIndex = 0;
            else lblSlotHint.Text = "Zone " + zone.Zone + " is full. Choose another zone or use Parking slots.";
        }

        private void cboNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            SlotInfo slot = cboNumber.SelectedItem as SlotInfo;
            if (slot != null)
                lblSlotHint.Text = "Selected slot: " + slot.SlotNumber + "   (" + freeSlots.Count + " free in total)";
        }

        private void btnSlots_Click(object sender, EventArgs e)
        {
            using (SlotPickerForm picker = new SlotPickerForm(SlotMapMode.PickAvailable))
            {
                if (picker.ShowDialog(this) != DialogResult.OK) return;
                try
                {
                    LoadSlots(picker.SelectedSlot.SlotID);
                }
                catch (Exception ex)
                {
                    UiHelper.DbError(ex);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            plateSuggest.Hide();
            string plate = Validator.NormalizePlate(txtPlate.Text);
            string owner = Regex.Replace(txtOwner.Text.Trim(), @"\s+", " ");
            plateSuggest.SetTextQuietly(plate);
            txtOwner.Text = owner;

            plateMessageShown = false;

            Control missing = FormControls.FirstRequired(txtPlate, cboVehicleType, txtOwner);
            if (missing != null) { StatusLine.Error(lblStatus, RequiredMessage(missing), missing); return; }
            if (!Validator.IsValidPlate(plate)) { StatusLine.Error(lblStatus, Validator.PlateRuleMessage.Replace("\n", " "), txtPlate); return; }
            if (!Validator.IsValidName(owner)) { StatusLine.Error(lblStatus, Validator.NameRuleMessage, txtOwner); return; }
            SlotInfo slot = cboNumber.SelectedItem as SlotInfo;
            if (slot == null) { StatusLine.Error(lblStatus, "Choose a free slot.", cboZone); return; }

            try
            {
                string type = ((VehicleRate)cboVehicleType.SelectedItem).VehicleType;
                OperationResult result = ParkingService.ParkVehicle(plate, type, owner, slot.SlotID, DateTime.Now);
                if (result.Success)
                {
                    ResultMessage = result.Message;
                    ParkedSlotId = slot.SlotID;
                    DialogResult = DialogResult.OK;
                    return;
                }
                StatusLine.Error(lblStatus, result.Message);
                parked = ParkingService.GetActiveList();
                LoadSlots(null);
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

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            tmrClock.Stop();
            base.OnFormClosing(e);
        }
    }
}
