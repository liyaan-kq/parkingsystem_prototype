using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ParkingSystem.Helpers;
using ParkingSystem.Logic;

namespace ParkingSystem.Controls
{
    public enum SlotMapMode
    {
        Browse,
        PickAvailable,
        PickOccupied
    }

    public class SlotMapControl : UserControl
    {
        private const int Columns = 10;
        private const int Rows = 5;
        private const int Gap = 6;
        private static readonly Font SlotFont = new Font("Segoe UI", 8.25f, FontStyle.Bold);
        private static readonly Color DisabledBack = Color.FromArgb(241, 245, 249);
        private static readonly Color DisabledFore = Color.FromArgb(148, 163, 184);

        private readonly List<Button> buttons = new List<Button>();
        private List<SlotInfo> slots = new List<SlotInfo>();

        public event EventHandler<SlotInfo> SlotClicked;

        public SlotMapMode Mode { get; set; }
        public SlotInfo SelectedSlot { get; private set; }

        public Func<SlotInfo, bool> CanPick { get; set; }

        public SlotMapControl()
        {
            DoubleBuffered = true;
            Resize += delegate { LayoutButtons(); };
        }

        public IList<SlotInfo> Slots
        {
            get { return slots.AsReadOnly(); }
        }

        public void ShowSlots(List<SlotInfo> newSlots)
        {
            slots = newSlots ?? new List<SlotInfo>();
            SuspendLayout();
            while (buttons.Count < slots.Count)
            {
                Button b = new Button();
                b.FlatStyle = FlatStyle.Flat;
                b.Font = SlotFont;
                b.Click += SlotButton_Click;
                buttons.Add(b);
                Controls.Add(b);
            }
            while (buttons.Count > slots.Count)
            {
                Button last = buttons[buttons.Count - 1];
                buttons.RemoveAt(buttons.Count - 1);
                last.Dispose();
            }

            int? keep = SelectedSlot == null ? (int?)null : SelectedSlot.SlotID;
            SelectedSlot = null;
            for (int i = 0; i < slots.Count; i++)
            {
                buttons[i].Tag = slots[i];
                if (keep.HasValue && slots[i].SlotID == keep.Value) SelectedSlot = slots[i];
            }
            LayoutButtons();
            PaintButtons();
            ResumeLayout();
        }

        public bool IsPickable(SlotInfo slot)
        {
            if (CanPick != null) return CanPick(slot);
            switch (Mode)
            {
                case SlotMapMode.PickAvailable: return slot.IsAvailable;
                case SlotMapMode.PickOccupied: return slot.IsOccupied;
                default: return true;
            }
        }

        public void SelectSlot(int slotId)
        {
            SelectedSlot = slots.Find(s => s.SlotID == slotId);
            PaintButtons();
        }

        public bool ClickSlot(string slotNumber)
        {
            Button b = buttons.Find(x => ((SlotInfo)x.Tag).SlotNumber == slotNumber);
            if (b == null || !b.Enabled) return false;
            b.PerformClick();
            return true;
        }

        private void SlotButton_Click(object sender, EventArgs e)
        {
            SlotInfo slot = (SlotInfo)((Button)sender).Tag;
            if (!IsPickable(slot)) return;
            SelectedSlot = slot;
            PaintButtons();
            if (SlotClicked != null) SlotClicked(this, slot);
        }

        private void LayoutButtons()
        {
            if (buttons.Count == 0) return;
            int w = Math.Max(30, (ClientSize.Width - (Columns - 1) * Gap) / Columns);
            int h = Math.Max(30, (ClientSize.Height - (Rows - 1) * Gap) / Rows);
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].Size = new Size(w, h);
                buttons[i].Location = new Point((i % Columns) * (w + Gap), (i / Columns) * (h + Gap));
            }
        }

        private void PaintButtons()
        {
            foreach (Button b in buttons)
            {
                SlotInfo slot = (SlotInfo)b.Tag;
                bool pickable = IsPickable(slot);
                bool selected = SelectedSlot != null && SelectedSlot.SlotID == slot.SlotID;

                b.Text = slot.SlotNumber + "\n" + (slot.IsOccupied ? slot.PlateNumber : slot.IsReserved ? "Reserved" : "Free");
                b.Enabled = pickable;
                b.Cursor = pickable ? Cursors.Hand : Cursors.Default;
                b.BackColor = pickable || Mode == SlotMapMode.Browse ? Theme.StatusBack(slot.Status) : DisabledBack;
                b.ForeColor = pickable || Mode == SlotMapMode.Browse ? Theme.StatusFore(slot.Status) : DisabledFore;
                b.FlatAppearance.BorderSize = selected ? 3 : 1;
                b.FlatAppearance.BorderColor = selected ? Theme.Primary : (pickable ? Theme.StatusFore(slot.Status) : DisabledFore);
            }
        }
    }
}
