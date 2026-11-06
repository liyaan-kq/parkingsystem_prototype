namespace ParkingSystem.Forms
{
    partial class VehicleExitForm
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
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSlots = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.dgvParked = new System.Windows.Forms.DataGridView();
            this.colPlate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOwner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSlot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSince = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBill = new System.Windows.Forms.Panel();
            this.lblBillTitle = new System.Windows.Forms.Label();
            this.lblBillKeys = new System.Windows.Forms.Label();
            this.lblBillDetails = new System.Windows.Forms.Label();
            this.txtStub = new System.Windows.Forms.TextBox();
            this.pnlTotal = new System.Windows.Forms.Panel();
            this.lblTotalCaption = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnPay = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlBill.SuspendLayout();
            this.pnlTotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParked)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(92)))));
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1000, 60);
            this.pnlHeader.Controls.Add(this.lblHeader);
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(20, 15);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Text = "Vehicle Exit";
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(20, 72);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Text = "Find parked vehicle: plate, owner or slot";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(23, 94);
            this.txtSearch.MaxLength = 40;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(400, 27);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
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
            this.btnSlots.Location = new System.Drawing.Point(433, 93);
            this.btnSlots.Name = "btnSlots";
            this.btnSlots.Size = new System.Drawing.Size(150, 29);
            this.btnSlots.Text = "Parking slots";
            this.btnSlots.UseVisualStyleBackColor = false;
            this.btnSlots.Click += new System.EventHandler(this.btnSlots_Click);
            // 
            // lblCount
            // 
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblCount.Location = new System.Drawing.Point(23, 128);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(560, 18);
            this.lblCount.Text = "";
            // 
            // dgvParked
            // 
            this.dgvParked.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.colPlate, this.colOwner, this.colType, this.colSlot, this.colSince, this.colDuration });
            this.dgvParked.AllowUserToAddRows = false;
            this.dgvParked.AllowUserToDeleteRows = false;
            this.dgvParked.AllowUserToResizeRows = false;
            this.dgvParked.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvParked.BackgroundColor = System.Drawing.Color.White;
            this.dgvParked.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvParked.ColumnHeadersHeight = 34;
            this.dgvParked.Location = new System.Drawing.Point(23, 150);
            this.dgvParked.MultiSelect = false;
            this.dgvParked.Name = "dgvParked";
            this.dgvParked.ReadOnly = true;
            this.dgvParked.RowHeadersVisible = false;
            this.dgvParked.RowTemplate.Height = 28;
            this.dgvParked.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvParked.Size = new System.Drawing.Size(560, 390);
            this.dgvParked.SelectionChanged += new System.EventHandler(this.dgvParked_SelectionChanged);
            // 
            // colPlate
            // 
            this.colPlate.FillWeight = 95F;
            this.colPlate.HeaderText = "Plate No.";
            this.colPlate.Name = "colPlate";
            this.colPlate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colOwner
            // 
            this.colOwner.FillWeight = 140F;
            this.colOwner.HeaderText = "Owner / Driver";
            this.colOwner.Name = "colOwner";
            this.colOwner.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colType
            // 
            this.colType.FillWeight = 85F;
            this.colType.HeaderText = "Type";
            this.colType.Name = "colType";
            this.colType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colSlot
            // 
            this.colSlot.FillWeight = 55F;
            this.colSlot.HeaderText = "Slot";
            this.colSlot.Name = "colSlot";
            this.colSlot.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colSince
            // 
            this.colSince.FillWeight = 85F;
            this.colSince.HeaderText = "Since";
            this.colSince.Name = "colSince";
            this.colSince.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colDuration
            // 
            this.colDuration.FillWeight = 100F;
            this.colDuration.HeaderText = "Time parked";
            this.colDuration.Name = "colDuration";
            this.colDuration.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // pnlBill
            // 
            this.pnlBill.BackColor = System.Drawing.Color.White;
            this.pnlBill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBill.Location = new System.Drawing.Point(603, 72);
            this.pnlBill.Name = "pnlBill";
            this.pnlBill.Size = new System.Drawing.Size(377, 468);
            this.pnlBill.Controls.Add(this.lblBillTitle);
            this.pnlBill.Controls.Add(this.lblBillKeys);
            this.pnlBill.Controls.Add(this.lblBillDetails);
            this.pnlBill.Controls.Add(this.txtStub);
            this.pnlBill.Controls.Add(this.pnlTotal);
            this.pnlBill.Controls.Add(this.lblStatus);
            this.pnlBill.Controls.Add(this.btnPay);
            this.pnlBill.Controls.Add(this.btnPrint);
            // 
            // lblBillTitle
            // 
            this.lblBillTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBillTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(92)))));
            this.lblBillTitle.Location = new System.Drawing.Point(14, 10);
            this.lblBillTitle.Name = "lblBillTitle";
            this.lblBillTitle.Size = new System.Drawing.Size(345, 34);
            this.lblBillTitle.Text = "";
            this.lblBillTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBillKeys
            // 
            this.lblBillKeys.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBillKeys.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblBillKeys.Location = new System.Drawing.Point(16, 50);
            this.lblBillKeys.Name = "lblBillKeys";
            this.lblBillKeys.Size = new System.Drawing.Size(86, 190);
            this.lblBillKeys.Text = "";
            // 
            // lblBillDetails
            // 
            this.lblBillDetails.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBillDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblBillDetails.Location = new System.Drawing.Point(104, 50);
            this.lblBillDetails.Name = "lblBillDetails";
            this.lblBillDetails.Size = new System.Drawing.Size(255, 190);
            this.lblBillDetails.Text = "";
            // 
            // txtStub
            // 
            this.txtStub.BackColor = System.Drawing.Color.White;
            this.txtStub.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStub.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStub.Location = new System.Drawing.Point(16, 48);
            this.txtStub.Multiline = true;
            this.txtStub.Name = "txtStub";
            this.txtStub.ReadOnly = true;
            this.txtStub.Size = new System.Drawing.Size(343, 272);
            this.txtStub.TabStop = false;
            // 
            // pnlTotal
            // 
            this.pnlTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.pnlTotal.Location = new System.Drawing.Point(16, 248);
            this.pnlTotal.Name = "pnlTotal";
            this.pnlTotal.Size = new System.Drawing.Size(343, 70);
            this.pnlTotal.Controls.Add(this.lblTotalCaption);
            this.pnlTotal.Controls.Add(this.lblTotal);
            // 
            // lblTotalCaption
            // 
            this.lblTotalCaption.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(92)))));
            this.lblTotalCaption.Location = new System.Drawing.Point(0, 6);
            this.lblTotalCaption.Name = "lblTotalCaption";
            this.lblTotalCaption.Size = new System.Drawing.Size(343, 20);
            this.lblTotalCaption.Text = "AMOUNT DUE";
            this.lblTotalCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(92)))));
            this.lblTotal.Location = new System.Drawing.Point(0, 25);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(343, 42);
            this.lblTotal.Text = "0.00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblStatus.Location = new System.Drawing.Point(16, 326);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(343, 40);
            this.lblStatus.Text = "";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnPay
            // 
            this.btnPay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.btnPay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPay.FlatAppearance.BorderSize = 0;
            this.btnPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPay.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPay.ForeColor = System.Drawing.Color.White;
            this.btnPay.Location = new System.Drawing.Point(16, 372);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(343, 40);
            this.btnPay.Text = "Process payment";
            this.btnPay.UseVisualStyleBackColor = false;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.White;
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnPrint.FlatAppearance.BorderSize = 1;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(92)))));
            this.btnPrint.Location = new System.Drawing.Point(16, 418);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(343, 36);
            this.btnPrint.Text = "Print stub";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // VehicleExitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1000, 560);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSlots);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.dgvParked);
            this.Controls.Add(this.pnlBill);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VehicleExitForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Parking Location Management System - Vehicle Exit";
            this.Load += new System.EventHandler(this.VehicleExitForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvParked)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlBill.ResumeLayout(false);
            this.pnlBill.PerformLayout();
            this.pnlTotal.ResumeLayout(false);
            this.pnlTotal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSlots;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.DataGridView dgvParked;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPlate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOwner;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSlot;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSince;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDuration;
        private System.Windows.Forms.Panel pnlBill;
        private System.Windows.Forms.Label lblBillTitle;
        private System.Windows.Forms.Label lblBillKeys;
        private System.Windows.Forms.Label lblBillDetails;
        private System.Windows.Forms.TextBox txtStub;
        private System.Windows.Forms.Panel pnlTotal;
        private System.Windows.Forms.Label lblTotalCaption;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Button btnPrint;
    }
}
