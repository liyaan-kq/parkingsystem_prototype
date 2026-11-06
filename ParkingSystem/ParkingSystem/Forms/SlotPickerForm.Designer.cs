namespace ParkingSystem.Forms
{
    partial class SlotPickerForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblHint = new System.Windows.Forms.Label();
            this.pnlLegendAvailable = new System.Windows.Forms.Panel();
            this.lblLegendAvailable = new System.Windows.Forms.Label();
            this.pnlLegendOccupied = new System.Windows.Forms.Panel();
            this.lblLegendOccupied = new System.Windows.Forms.Label();
            this.pnlLegendReserved = new System.Windows.Forms.Panel();
            this.lblLegendReserved = new System.Windows.Forms.Label();
            this.slotMap = new ParkingSystem.Controls.SlotMapControl();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlLegendAvailable.SuspendLayout();
            this.pnlLegendOccupied.SuspendLayout();
            this.pnlLegendReserved.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(92)))));
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(720, 60);
            this.pnlHeader.Controls.Add(this.lblHeader);
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(20, 15);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Text = "Choose a parking slot";
            // 
            // lblHint
            // 
            this.lblHint.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblHint.Location = new System.Drawing.Point(23, 70);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(674, 20);
            this.lblHint.Text = "";
            // 
            // pnlLegendAvailable
            // 
            this.pnlLegendAvailable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(252)))), ((int)(((byte)(231)))));
            this.pnlLegendAvailable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLegendAvailable.Location = new System.Drawing.Point(23, 99);
            this.pnlLegendAvailable.Name = "pnlLegendAvailable";
            this.pnlLegendAvailable.Size = new System.Drawing.Size(14, 14);
            // 
            // lblLegendAvailable
            // 
            this.lblLegendAvailable.AutoSize = true;
            this.lblLegendAvailable.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLegendAvailable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblLegendAvailable.Location = new System.Drawing.Point(41, 96);
            this.lblLegendAvailable.Name = "lblLegendAvailable";
            this.lblLegendAvailable.Text = "Free";
            // 
            // pnlLegendOccupied
            // 
            this.pnlLegendOccupied.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.pnlLegendOccupied.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLegendOccupied.Location = new System.Drawing.Point(133, 99);
            this.pnlLegendOccupied.Name = "pnlLegendOccupied";
            this.pnlLegendOccupied.Size = new System.Drawing.Size(14, 14);
            // 
            // lblLegendOccupied
            // 
            this.lblLegendOccupied.AutoSize = true;
            this.lblLegendOccupied.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLegendOccupied.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblLegendOccupied.Location = new System.Drawing.Point(151, 96);
            this.lblLegendOccupied.Name = "lblLegendOccupied";
            this.lblLegendOccupied.Text = "Occupied";
            // 
            // pnlLegendReserved
            // 
            this.pnlLegendReserved.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(243)))), ((int)(((byte)(199)))));
            this.pnlLegendReserved.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLegendReserved.Location = new System.Drawing.Point(243, 99);
            this.pnlLegendReserved.Name = "pnlLegendReserved";
            this.pnlLegendReserved.Size = new System.Drawing.Size(14, 14);
            // 
            // lblLegendReserved
            // 
            this.lblLegendReserved.AutoSize = true;
            this.lblLegendReserved.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLegendReserved.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblLegendReserved.Location = new System.Drawing.Point(261, 96);
            this.lblLegendReserved.Name = "lblLegendReserved";
            this.lblLegendReserved.Text = "Reserved";
            // 
            // slotMap
            // 
            this.slotMap.BackColor = System.Drawing.Color.White;
            this.slotMap.Location = new System.Drawing.Point(23, 122);
            this.slotMap.Name = "slotMap";
            this.slotMap.Size = new System.Drawing.Size(674, 320);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnCancel.FlatAppearance.BorderSize = 1;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(92)))));
            this.btnCancel.Location = new System.Drawing.Point(557, 452);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(140, 36);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // SlotPickerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(720, 500);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.lblHint);
            this.Controls.Add(this.pnlLegendAvailable);
            this.Controls.Add(this.lblLegendAvailable);
            this.Controls.Add(this.pnlLegendOccupied);
            this.Controls.Add(this.lblLegendOccupied);
            this.Controls.Add(this.pnlLegendReserved);
            this.Controls.Add(this.lblLegendReserved);
            this.Controls.Add(this.slotMap);
            this.Controls.Add(this.btnCancel);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SlotPickerForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Parking Location Management System - Choose Slot";
            this.Load += new System.EventHandler(this.SlotPickerForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlLegendAvailable.ResumeLayout(false);
            this.pnlLegendAvailable.PerformLayout();
            this.pnlLegendOccupied.ResumeLayout(false);
            this.pnlLegendOccupied.PerformLayout();
            this.pnlLegendReserved.ResumeLayout(false);
            this.pnlLegendReserved.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.Panel pnlLegendAvailable;
        private System.Windows.Forms.Label lblLegendAvailable;
        private System.Windows.Forms.Panel pnlLegendOccupied;
        private System.Windows.Forms.Label lblLegendOccupied;
        private System.Windows.Forms.Panel pnlLegendReserved;
        private System.Windows.Forms.Label lblLegendReserved;
        private ParkingSystem.Controls.SlotMapControl slotMap;
        private System.Windows.Forms.Button btnCancel;
    }
}
