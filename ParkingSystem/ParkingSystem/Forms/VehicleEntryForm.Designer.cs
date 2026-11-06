namespace ParkingSystem.Forms
{
    partial class VehicleEntryForm
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
            this.components = new System.ComponentModel.Container();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblPlate = new System.Windows.Forms.Label();
            this.txtPlate = new System.Windows.Forms.TextBox();
            this.lblPlateHint = new System.Windows.Forms.Label();
            this.lblVehicleType = new System.Windows.Forms.Label();
            this.cboVehicleType = new System.Windows.Forms.ComboBox();
            this.lblOwner = new System.Windows.Forms.Label();
            this.txtOwner = new System.Windows.Forms.TextBox();
            this.lblRate = new System.Windows.Forms.Label();
            this.lblRateInfo = new System.Windows.Forms.Label();
            this.lblSlotHeader = new System.Windows.Forms.Label();
            this.lblZone = new System.Windows.Forms.Label();
            this.cboZone = new System.Windows.Forms.ComboBox();
            this.lblNumber = new System.Windows.Forms.Label();
            this.cboNumber = new System.Windows.Forms.ComboBox();
            this.btnSlots = new System.Windows.Forms.Button();
            this.lblSlotHint = new System.Windows.Forms.Label();
            this.lblEntryTime = new System.Windows.Forms.Label();
            this.txtEntryTime = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tmrClock = new System.Windows.Forms.Timer(this.components);
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(92)))));
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(660, 60);
            this.pnlHeader.Controls.Add(this.lblHeader);
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(20, 15);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Text = "Vehicle Entry";
            // 
            // lblPlate
            // 
            this.lblPlate.AutoSize = true;
            this.lblPlate.Location = new System.Drawing.Point(25, 75);
            this.lblPlate.Name = "lblPlate";
            this.lblPlate.Text = "Plate number *";
            // 
            // txtPlate
            // 
            this.txtPlate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPlate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlate.Location = new System.Drawing.Point(28, 97);
            this.txtPlate.MaxLength = 15;
            this.txtPlate.Name = "txtPlate";
            this.txtPlate.Size = new System.Drawing.Size(290, 27);
            // 
            // lblPlateHint
            // 
            this.lblPlateHint.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlateHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblPlateHint.Location = new System.Drawing.Point(25, 128);
            this.lblPlateHint.Name = "lblPlateHint";
            this.lblPlateHint.Size = new System.Drawing.Size(293, 18);
            this.lblPlateHint.Text = "Type to see registered vehicles.";
            // 
            // lblVehicleType
            // 
            this.lblVehicleType.AutoSize = true;
            this.lblVehicleType.Location = new System.Drawing.Point(345, 75);
            this.lblVehicleType.Name = "lblVehicleType";
            this.lblVehicleType.Text = "Vehicle type *";
            // 
            // cboVehicleType
            // 
            this.cboVehicleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVehicleType.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboVehicleType.FormattingEnabled = true;
            this.cboVehicleType.Location = new System.Drawing.Point(348, 97);
            this.cboVehicleType.Name = "cboVehicleType";
            this.cboVehicleType.Size = new System.Drawing.Size(285, 28);
            this.cboVehicleType.SelectedIndexChanged += new System.EventHandler(this.cboVehicleType_SelectedIndexChanged);
            // 
            // lblOwner
            // 
            this.lblOwner.AutoSize = true;
            this.lblOwner.Location = new System.Drawing.Point(25, 150);
            this.lblOwner.Name = "lblOwner";
            this.lblOwner.Text = "Owner / driver *";
            // 
            // txtOwner
            // 
            this.txtOwner.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOwner.Location = new System.Drawing.Point(28, 172);
            this.txtOwner.MaxLength = 100;
            this.txtOwner.Name = "txtOwner";
            this.txtOwner.Size = new System.Drawing.Size(290, 27);
            // 
            // lblRate
            // 
            this.lblRate.AutoSize = true;
            this.lblRate.Location = new System.Drawing.Point(345, 150);
            this.lblRate.Name = "lblRate";
            this.lblRate.Text = "Rate";
            // 
            // lblRateInfo
            // 
            this.lblRateInfo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRateInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblRateInfo.Location = new System.Drawing.Point(348, 172);
            this.lblRateInfo.Name = "lblRateInfo";
            this.lblRateInfo.Size = new System.Drawing.Size(285, 40);
            this.lblRateInfo.Text = "Select a vehicle type to see its rate.";
            // 
            // lblSlotHeader
            // 
            this.lblSlotHeader.AutoSize = true;
            this.lblSlotHeader.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSlotHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(92)))));
            this.lblSlotHeader.Location = new System.Drawing.Point(25, 216);
            this.lblSlotHeader.Name = "lblSlotHeader";
            this.lblSlotHeader.Text = "Parking slot *";
            // 
            // lblZone
            // 
            this.lblZone.AutoSize = true;
            this.lblZone.Location = new System.Drawing.Point(25, 240);
            this.lblZone.Name = "lblZone";
            this.lblZone.Text = "Zone";
            // 
            // cboZone
            // 
            this.cboZone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZone.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboZone.FormattingEnabled = true;
            this.cboZone.Location = new System.Drawing.Point(28, 262);
            this.cboZone.Name = "cboZone";
            this.cboZone.Size = new System.Drawing.Size(200, 28);
            this.cboZone.SelectedIndexChanged += new System.EventHandler(this.cboZone_SelectedIndexChanged);
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Location = new System.Drawing.Point(245, 240);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Text = "Slot no.";
            // 
            // cboNumber
            // 
            this.cboNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNumber.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNumber.FormattingEnabled = true;
            this.cboNumber.Location = new System.Drawing.Point(248, 262);
            this.cboNumber.Name = "cboNumber";
            this.cboNumber.Size = new System.Drawing.Size(120, 28);
            this.cboNumber.SelectedIndexChanged += new System.EventHandler(this.cboNumber_SelectedIndexChanged);
            // 
            // btnSlots
            // 
            this.btnSlots.BackColor = System.Drawing.Color.White;
            this.btnSlots.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSlots.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnSlots.FlatAppearance.BorderSize = 1;
            this.btnSlots.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSlots.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSlots.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(92)))));
            this.btnSlots.Location = new System.Drawing.Point(385, 261);
            this.btnSlots.Name = "btnSlots";
            this.btnSlots.Size = new System.Drawing.Size(150, 30);
            this.btnSlots.Text = "Parking slots";
            this.btnSlots.UseVisualStyleBackColor = false;
            this.btnSlots.Click += new System.EventHandler(this.btnSlots_Click);
            // 
            // lblSlotHint
            // 
            this.lblSlotHint.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSlotHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblSlotHint.Location = new System.Drawing.Point(25, 296);
            this.lblSlotHint.Name = "lblSlotHint";
            this.lblSlotHint.Size = new System.Drawing.Size(608, 20);
            this.lblSlotHint.Text = "";
            // 
            // lblEntryTime
            // 
            this.lblEntryTime.AutoSize = true;
            this.lblEntryTime.Location = new System.Drawing.Point(25, 322);
            this.lblEntryTime.Name = "lblEntryTime";
            this.lblEntryTime.Text = "Entry time (automatic)";
            // 
            // txtEntryTime
            // 
            this.txtEntryTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.txtEntryTime.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEntryTime.Location = new System.Drawing.Point(28, 344);
            this.txtEntryTime.Name = "txtEntryTime";
            this.txtEntryTime.ReadOnly = true;
            this.txtEntryTime.Size = new System.Drawing.Size(290, 27);
            this.txtEntryTime.TabStop = false;
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblStatus.Location = new System.Drawing.Point(25, 378);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(608, 36);
            this.lblStatus.Text = "";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(78)))), ((int)(((byte)(216)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(28, 418);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(290, 40);
            this.btnSave.Text = "Save and park";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnCancel.FlatAppearance.BorderSize = 1;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(92)))));
            this.btnCancel.Location = new System.Drawing.Point(343, 418);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(290, 40);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tmrClock
            // 
            this.tmrClock.Interval = 1000;
            this.tmrClock.Tick += new System.EventHandler(this.tmrClock_Tick);
            // 
            // VehicleEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(660, 472);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.lblPlate);
            this.Controls.Add(this.txtPlate);
            this.Controls.Add(this.lblPlateHint);
            this.Controls.Add(this.lblVehicleType);
            this.Controls.Add(this.cboVehicleType);
            this.Controls.Add(this.lblOwner);
            this.Controls.Add(this.txtOwner);
            this.Controls.Add(this.lblRate);
            this.Controls.Add(this.lblRateInfo);
            this.Controls.Add(this.lblSlotHeader);
            this.Controls.Add(this.lblZone);
            this.Controls.Add(this.cboZone);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.cboNumber);
            this.Controls.Add(this.btnSlots);
            this.Controls.Add(this.lblSlotHint);
            this.Controls.Add(this.lblEntryTime);
            this.Controls.Add(this.txtEntryTime);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VehicleEntryForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Parking Location Management System - Vehicle Entry";
            this.Load += new System.EventHandler(this.VehicleEntryForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblPlate;
        private System.Windows.Forms.TextBox txtPlate;
        private System.Windows.Forms.Label lblPlateHint;
        private System.Windows.Forms.Label lblVehicleType;
        private System.Windows.Forms.ComboBox cboVehicleType;
        private System.Windows.Forms.Label lblOwner;
        private System.Windows.Forms.TextBox txtOwner;
        private System.Windows.Forms.Label lblRate;
        private System.Windows.Forms.Label lblRateInfo;
        private System.Windows.Forms.Label lblSlotHeader;
        private System.Windows.Forms.Label lblZone;
        private System.Windows.Forms.ComboBox cboZone;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.ComboBox cboNumber;
        private System.Windows.Forms.Button btnSlots;
        private System.Windows.Forms.Label lblSlotHint;
        private System.Windows.Forms.Label lblEntryTime;
        private System.Windows.Forms.TextBox txtEntryTime;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Timer tmrClock;
    }
}
