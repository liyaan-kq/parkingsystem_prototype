using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ParkingSystem.Controls
{
    public class SuggestItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }

    public class SuggestBox
    {
        private readonly TextBox box;
        private readonly Func<string, List<SuggestItem>> findMatches;
        private readonly ListBox list = new ListBox();
        private readonly int maxRows;
        private bool suppress;

        public event EventHandler<SuggestItem> Picked;

        public event EventHandler Submitted;

        public SuggestBox(TextBox box, Func<string, List<SuggestItem>> findMatches, int maxRows = 6)
        {
            this.box = box;
            this.findMatches = findMatches;
            this.maxRows = maxRows;

            list.Visible = false;
            list.TabStop = false;
            list.IntegralHeight = false;
            list.Font = new Font("Segoe UI", 9.75f);
            list.BorderStyle = BorderStyle.FixedSingle;
            list.MouseClick += delegate { Pick(list.SelectedIndex); };

            box.TextChanged += Box_TextChanged;
            box.KeyDown += Box_KeyDown;
            box.Leave += delegate { box.BeginInvoke(new Action(HideIfNotFocused)); };
            list.Leave += delegate { Hide(); };
        }

        public bool IsOpen
        {
            get { return list.Visible; }
        }

        public List<SuggestItem> Items
        {
            get
            {
                List<SuggestItem> items = new List<SuggestItem>();
                foreach (object o in list.Items) items.Add((SuggestItem)o);
                return items;
            }
        }

        public void SetTextQuietly(string text)
        {
            suppress = true;
            box.Text = text;
            box.SelectionStart = box.Text.Length;
            suppress = false;
            Hide();
        }

        public void Pick(int index)
        {
            if (index < 0 || index >= list.Items.Count) return;
            SuggestItem item = (SuggestItem)list.Items[index];
            Hide();
            if (Picked != null) Picked(this, item);
        }

        public void Hide()
        {
            list.Visible = false;
        }

        private void Box_TextChanged(object sender, EventArgs e)
        {
            if (suppress) return;
            if (box.Text.Trim().Length == 0)
            {
                Hide();
                return;
            }

            List<SuggestItem> matches = findMatches(box.Text);
            list.BeginUpdate();
            list.Items.Clear();
            foreach (SuggestItem m in matches) list.Items.Add(m);
            list.EndUpdate();

            if (matches.Count == 0)
            {
                Hide();
                return;
            }
            Show(matches.Count);
        }

        private void Show(int count)
        {
            Form form = box.FindForm();
            if (form == null) return;
            if (list.Parent != form)
            {
                form.Controls.Add(list);
            }
            Point below = form.PointToClient(box.Parent.PointToScreen(new Point(box.Left, box.Bottom)));
            list.Location = below;
            list.Width = Math.Max(box.Width, 320);
            list.Height = Math.Min(count, maxRows) * list.ItemHeight + 4;
            list.SelectedIndex = -1;
            list.Visible = true;
            list.BringToFront();
        }

        private void Box_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && IsOpen)
            {
                list.SelectedIndex = Math.Min(list.SelectedIndex + 1, list.Items.Count - 1);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Up && IsOpen)
            {
                list.SelectedIndex = Math.Max(list.SelectedIndex - 1, 0);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Escape && IsOpen)
            {
                Hide();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (IsOpen && list.SelectedIndex >= 0) Pick(list.SelectedIndex);
                else if (IsOpen && list.Items.Count == 1) Pick(0);
                else
                {
                    Hide();
                    if (Submitted != null) Submitted(this, EventArgs.Empty);
                }
            }
        }

        private void HideIfNotFocused()
        {
            if (!list.Focused && !box.Focused) Hide();
        }
    }
}
