namespace ParkingSystem.Forms
{
    partial class RecordEditForm
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
            this.lblRecordInfo = new System.Windows.Forms.Label();
            this.lblPlate = new System.Windows.Forms.Label();
            this.txtPlate = new System.Windows.Forms.TextBox();
            this.lblVehicleType = new System.Windows.Forms.Label();
            this.cboVehicleType = new System.Windows.Forms.ComboBox();
            this.lblOwner = new System.Windows.Forms.Label();
            this.txtOwner = new System.Windows.Forms.TextBox();
            this.lblSlot = new System.Windows.Forms.Label();
            this.txtSlot = new System.Windows.Forms.TextBox();
            this.btnChangeSlot = new System.Windows.Forms.Button();
            this.lblVehicleNote = new System.Windows.Forms.Label();
            this.pnlLocked = new System.Windows.Forms.Panel();
            this.lblLocked = new System.Windows.Forms.Label();
            this.lblEntry = new System.Windows.Forms.Label();
            this.txtEntry = new System.Windows.Forms.TextBox();
            this.lblExit = new System.Windows.Forms.Label();
            this.txtExit = new System.Windows.Forms.TextBox();
            this.lblDurationFee = new System.Windows.Forms.Label();
            this.lblUpdated = new System.Windows.Forms.Label();
            this.lblLockedNote = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlLocked.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(92)))));
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(640, 60);
            this.pnlHeader.Controls.Add(this.lblHeader);
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(20, 15);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Text = "Edit Parking Record";
            // 
            // lblRecordInfo
            // 
            this.lblRecordInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(92)))));
            this.lblRecordInfo.Location = new System.Drawing.Point(25, 70);
            this.lblRecordInfo.Name = "lblRecordInfo";
            this.lblRecordInfo.Size = new System.Drawing.Size(593, 24);
            this.lblRecordInfo.Text = "";
            this.lblRecordInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPlate
            // 
            this.lblPlate.AutoSize = true;
            this.lblPlate.Location = new System.Drawing.Point(25, 102);
            this.lblPlate.Name = "lblPlate";
            this.lblPlate.Text = "Plate number *";
            // 
            // txtPlate
            // 
            this.txtPlate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPlate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlate.Location = new System.Drawing.Point(28, 124);
            this.txtPlate.MaxLength = 15;
            this.txtPlate.Name = "txtPlate";
            this.txtPlate.Size = new System.Drawing.Size(280, 27);
            // 
            // lblVehicleType
            // 
            this.lblVehicleType.AutoSize = true;
            this.lblVehicleType.Location = new System.Drawing.Point(335, 102);
            this.lblVehicleType.Name = "lblVehicleType";
            this.lblVehicleType.Text = "Vehicle type *";
            // 
            // cboVehicleType
            // 
            this.cboVehicleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVehicleType.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboVehicleType.FormattingEnabled = true;
            this.cboVehicleType.Location = new System.Drawing.Point(338, 124);
            this.cboVehicleType.Name = "cboVehicleType";
            this.cboVehicleType.Size = new System.Drawing.Size(280, 28);
            // 
            // lblOwner
            // 
            this.lblOwner.AutoSize = true;
            this.lblOwner.Location = new System.Drawing.Point(25, 167);
            this.lblOwner.Name = "lblOwner";
            this.lblOwner.Text = "Owner / driver *";
            // 
            // txtOwner
            // 
            this.txtOwner.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOwner.Location = new System.Drawing.Point(28, 189);
            this.txtOwner.MaxLength = 100;
            this.txtOwner.Name = "txtOwner";
            this.txtOwner.Size = new System.Drawing.Size(280, 27);
            // 
            // lblSlot
            // 
            this.lblSlot.AutoSize = true;
            this.lblSlot.Location = new System.Drawing.Point(335, 167);
            this.lblSlot.Name = "lblSlot";
            this.lblSlot.Text = "Parking slot";
            // 
            // txtSlot
            // 
            this.txtSlot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.txtSlot.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSlot.Location = new System.Drawing.Point(338, 189);
            this.txtSlot.Name = "txtSlot";
            this.txtSlot.ReadOnly = true;
            this.txtSlot.Size = new System.Drawing.Size(140, 27);
            this.txtSlot.TabStop = false;
            // 
            // btnChangeSlot
            // 
            this.btnChangeSlot.BackColor = System.Drawing.Color.White;
            this.btnChangeSlot.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangeSlot.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnChangeSlot.FlatAppearance.BorderSize = 1;
            this.btnChangeSlot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeSlot.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeSlot.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(92)))));
            this.btnChangeSlot.Location = new System.Drawing.Point(488, 188);
            this.btnChangeSlot.Name = "btnChangeSlot";
            this.btnChangeSlot.Size = new System.Drawing.Size(130, 29);
            this.btnChangeSlot.Text = "Change slot";
            this.btnChangeSlot.UseVisualStyleBackColor = false;
            this.btnChangeSlot.Click += new System.EventHandler(this.btnChangeSlot_Click);
            // 
            // lblVehicleNote
            // 
            this.lblVehicleNote.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVehicleNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblVehicleNote.Location = new System.Drawing.Point(25, 224);
            this.lblVehicleNote.Name = "lblVehicleNote";
            this.lblVehicleNote.Size = new System.Drawing.Size(593, 20);
            this.lblVehicleNote.Text = "Plate, type and owner belong to the vehicle, so changes apply to all of its visits.";
            // 
            // pnlLocked
            // 
            this.pnlLocked.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.pnlLocked.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLocked.Location = new System.Drawing.Point(28, 250);
            this.pnlLocked.Name = "pnlLocked";
            this.pnlLocked.Size = new System.Drawing.Size(590, 142);
            this.pnlLocked.Controls.Add(this.lblLocked);
            this.pnlLocked.Controls.Add(this.lblEntry);
            this.pnlLocked.Controls.Add(this.txtEntry);
            this.pnlLocked.Controls.Add(this.lblExit);
            this.pnlLocked.Controls.Add(this.txtExit);
            this.pnlLocked.Controls.Add(this.lblDurationFee);
            this.pnlLocked.Controls.Add(this.lblUpdated);
            // 
            // lblLocked
            // 
            this.lblLocked.AutoSize = true;
            this.lblLocked.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocked.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(92)))));
            this.lblLocked.Location = new System.Drawing.Point(10, 8);
            this.lblLocked.Name = "lblLocked";
            this.lblLocked.Text = "Locked fields (recorded automatically)";
            // 
            // lblEntry
            // 
            this.lblEntry.AutoSize = true;
            this.lblEntry.Location = new System.Drawing.Point(10, 34);
            this.lblEntry.Name = "lblEntry";
            this.lblEntry.Text = "Entry time";
            // 
            // txtEntry
            // 
            this.txtEntry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.txtEntry.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEntry.Location = new System.Drawing.Point(13, 54);
            this.txtEntry.Name = "txtEntry";
            this.txtEntry.ReadOnly = true;
            this.txtEntry.Size = new System.Drawing.Size(275, 27);
            this.txtEntry.TabStop = false;
            // 
            // lblExit
            // 
            this.lblExit.AutoSize = true;
            this.lblExit.Location = new System.Drawing.Point(298, 34);
            this.lblExit.Name = "lblExit";
            this.lblExit.Text = "Exit time";
            // 
            // txtExit
            // 
            this.txtExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.txtExit.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExit.Location = new System.Drawing.Point(301, 54);
            this.txtExit.Name = "txtExit";
            this.txtExit.ReadOnly = true;
            this.txtExit.Size = new System.Drawing.Size(275, 27);
            this.txtExit.TabStop = false;
            // 
            // lblDurationFee
            // 
            this.lblDurationFee.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDurationFee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(92)))));
            this.lblDurationFee.Location = new System.Drawing.Point(10, 90);
            this.lblDurationFee.Name = "lblDurationFee";
            this.lblDurationFee.Size = new System.Drawing.Size(565, 22);
            this.lblDurationFee.Text = "";
            this.lblDurationFee.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUpdated
            // 
            this.lblUpdated.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdated.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblUpdated.Location = new System.Drawing.Point(10, 113);
            this.lblUpdated.Name = "lblUpdated";
            this.lblUpdated.Size = new System.Drawing.Size(565, 20);
            this.lblUpdated.Text = "Last updated: -";
            this.lblUpdated.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLockedNote
            // 
            this.lblLockedNote.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLockedNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblLockedNote.Location = new System.Drawing.Point(25, 398);
            this.lblLockedNote.Name = "lblLockedNote";
            this.lblLockedNote.Size = new System.Drawing.Size(593, 34);
            this.lblLockedNote.Text = "Times and fee cannot be edited: they are recorded at entry and payment to prevent tampering. To correct a wrong entry, delete it and register the vehicle again.";
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblStatus.Location = new System.Drawing.Point(25, 434);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(593, 36);
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
            this.btnSave.Location = new System.Drawing.Point(28, 476);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(280, 44);
            this.btnSave.Text = "Save changes";
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
            this.btnCancel.Location = new System.Drawing.Point(338, 476);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(280, 44);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // RecordEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(640, 536);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.lblRecordInfo);
            this.Controls.Add(this.lblPlate);
            this.Controls.Add(this.txtPlate);
            this.Controls.Add(this.lblVehicleType);
            this.Controls.Add(this.cboVehicleType);
            this.Controls.Add(this.lblOwner);
            this.Controls.Add(this.txtOwner);
            this.Controls.Add(this.lblSlot);
            this.Controls.Add(this.txtSlot);
            this.Controls.Add(this.btnChangeSlot);
            this.Controls.Add(this.lblVehicleNote);
            this.Controls.Add(this.pnlLocked);
            this.Controls.Add(this.lblLockedNote);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RecordEditForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Parking Location Management System - Edit Record";
            this.Load += new System.EventHandler(this.RecordEditForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlLocked.ResumeLayout(false);
            this.pnlLocked.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblRecordInfo;
        private System.Windows.Forms.Label lblPlate;
        private System.Windows.Forms.TextBox txtPlate;
        private System.Windows.Forms.Label lblVehicleType;
        private System.Windows.Forms.ComboBox cboVehicleType;
        private System.Windows.Forms.Label lblOwner;
        private System.Windows.Forms.TextBox txtOwner;
        private System.Windows.Forms.Label lblSlot;
        private System.Windows.Forms.TextBox txtSlot;
        private System.Windows.Forms.Button btnChangeSlot;
        private System.Windows.Forms.Label lblVehicleNote;
        private System.Windows.Forms.Panel pnlLocked;
        private System.Windows.Forms.Label lblLocked;
        private System.Windows.Forms.Label lblEntry;
        private System.Windows.Forms.TextBox txtEntry;
        private System.Windows.Forms.Label lblExit;
        private System.Windows.Forms.TextBox txtExit;
        private System.Windows.Forms.Label lblDurationFee;
        private System.Windows.Forms.Label lblUpdated;
        private System.Windows.Forms.Label lblLockedNote;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
