using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ParkingSystem.Controls;
using ParkingSystem.Helpers;
using ParkingSystem.Logic;

namespace ParkingSystem.Forms
{
    public partial class SlotPickerForm : Form
    {
        private readonly SlotMapMode mode;
        private readonly int? extraAllowedSlotId;

        public SlotInfo SelectedSlot { get; private set; }

        public SlotPickerForm(SlotMapMode mode, int? extraAllowedSlotId = null)
        {
            InitializeComponent();
            this.mode = mode;
            this.extraAllowedSlotId = extraAllowedSlotId;
        }

        private void SlotPickerForm_Load(object sender, EventArgs e)
        {
            slotMap.Mode = mode;
            if (extraAllowedSlotId.HasValue)
                slotMap.CanPick = s => s.IsAvailable || s.SlotID == extraAllowedSlotId.Value;

            List<SlotInfo> slots;
            try
            {
                slots = SlotService.GetAll();
            }
            catch (Exception ex)
            {
                UiHelper.DbError(ex);
                BeginInvoke(new Action(Close));
                return;
            }
            slotMap.ShowSlots(slots);
            if (extraAllowedSlotId.HasValue) slotMap.SelectSlot(extraAllowedSlotId.Value);

            int pickable = slots.FindAll(s => slotMap.IsPickable(s)).Count;
            if (mode == SlotMapMode.PickOccupied)
            {
                lblHeader.Text = "Choose a parked vehicle";
                lblHint.Text = pickable == 0 ? "No vehicles are parked right now." : "Click an occupied slot to select its vehicle (" + pickable + " parked).";
            }
            else
            {
                lblHeader.Text = "Choose a free slot";
                lblHint.Text = pickable == 0 ? "Parking is full. No free slots." : "Click a green slot to choose it (" + pickable + " free).";
            }

            slotMap.SlotClicked += delegate (object s, SlotInfo slot)
            {
                SelectedSlot = slot;
                DialogResult = DialogResult.OK;
            };
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
