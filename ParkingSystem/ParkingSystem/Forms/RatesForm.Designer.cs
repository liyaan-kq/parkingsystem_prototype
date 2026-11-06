namespace ParkingSystem.Forms
{
    partial class RatesForm
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
            this.lblInfo = new System.Windows.Forms.Label();
            this.dgvRates = new System.Windows.Forms.DataGridView();
            this.colVehicleType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFlatRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFlatHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSucceedingRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblNote = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRates)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(92)))));
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(600, 60);
            this.pnlHeader.Controls.Add(this.lblHeader);
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(20, 15);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Text = "Rates Settings";
            // 
            // lblInfo
            // 
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblInfo.Location = new System.Drawing.Point(23, 70);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(554, 34);
            this.lblInfo.Text = "Fee rule: the flat rate covers the first flat hours. Every succeeding hour (or part of an hour) adds the succeeding rate.";
            // 
            // dgvRates
            // 
            this.dgvRates.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.colVehicleType, this.colFlatRate, this.colFlatHours, this.colSucceedingRate });
            this.dgvRates.AllowUserToAddRows = false;
            this.dgvRates.AllowUserToDeleteRows = false;
            this.dgvRates.AllowUserToResizeRows = false;
            this.dgvRates.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRates.BackgroundColor = System.Drawing.Color.White;
            this.dgvRates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRates.ColumnHeadersHeight = 34;
            this.dgvRates.Location = new System.Drawing.Point(23, 108);
            this.dgvRates.MultiSelect = false;
            this.dgvRates.Name = "dgvRates";
            this.dgvRates.RowHeadersVisible = false;
            this.dgvRates.RowTemplate.Height = 28;
            this.dgvRates.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvRates.Size = new System.Drawing.Size(554, 130);
            this.dgvRates.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRates_CellValueChanged);
            // 
            // colVehicleType
            // 
            this.colVehicleType.FillWeight = 110F;
            this.colVehicleType.HeaderText = "Vehicle Type";
            this.colVehicleType.Name = "colVehicleType";
            this.colVehicleType.ReadOnly = true;
            this.colVehicleType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colFlatRate
            // 
            this.colFlatRate.FillWeight = 90F;
            this.colFlatRate.HeaderText = "Flat Rate";
            this.colFlatRate.Name = "colFlatRate";
            this.colFlatRate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colFlatHours
            // 
            this.colFlatHours.FillWeight = 80F;
            this.colFlatHours.HeaderText = "Flat Hours";
            this.colFlatHours.Name = "colFlatHours";
            this.colFlatHours.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colSucceedingRate
            // 
            this.colSucceedingRate.FillWeight = 120F;
            this.colSucceedingRate.HeaderText = "Succeeding Rate / hr";
            this.colSucceedingRate.Name = "colSucceedingRate";
            this.colSucceedingRate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // lblNote
            // 
            this.lblNote.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblNote.Location = new System.Drawing.Point(23, 246);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(554, 34);
            this.lblNote.Text = "Changes apply to vehicles that exit after saving. Fees already recorded are not changed.";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(78)))), ((int)(((byte)(216)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(23, 286);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(170, 40);
            this.btnSave.Text = "Save Changes";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.BackColor = System.Drawing.Color.White;
            this.btnUndo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUndo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnUndo.FlatAppearance.BorderSize = 1;
            this.btnUndo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUndo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUndo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(92)))));
            this.btnUndo.Location = new System.Drawing.Point(203, 286);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(170, 40);
            this.btnUndo.Text = "Undo Changes";
            this.btnUndo.UseVisualStyleBackColor = false;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnClose.FlatAppearance.BorderSize = 1;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(92)))));
            this.btnClose.Location = new System.Drawing.Point(407, 286);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(170, 40);
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // RatesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(600, 345);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.dgvRates);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RatesForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Parking Location Management System - Rates Settings";
            this.Load += new System.EventHandler(this.RatesForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RatesForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRates)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.DataGridView dgvRates;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVehicleType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFlatRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFlatHours;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSucceedingRate;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnClose;
    }
}
