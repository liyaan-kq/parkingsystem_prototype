namespace ParkingSystem.Forms
{
    partial class DebugForm
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
            this.grpData = new System.Windows.Forms.GroupBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnClearRecords = new System.Windows.Forms.Button();
            this.btnResetRates = new System.Windows.Forms.Button();
            this.grpSimulations = new System.Windows.Forms.GroupBox();
            this.btnAdvanceTime = new System.Windows.Forms.Button();
            this.btnQueryTimeout = new System.Windows.Forms.Button();
            this.btnConnectionFailure = new System.Windows.Forms.Button();
            this.btnUnexpectedError = new System.Windows.Forms.Button();
            this.grpDiagnostics = new System.Windows.Forms.GroupBox();
            this.btnSelfTests = new System.Windows.Forms.Button();
            this.btnIntegrity = new System.Windows.Forms.Button();
            this.lblLog = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.grpData.SuspendLayout();
            this.grpSimulations.SuspendLayout();
            this.grpDiagnostics.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(92)))));
            this.pnlHeader.Controls.Add(this.lblHeader);
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(760, 60);
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(20, 15);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Text = "Debug Tools";
            // 
            // lblInfo
            // 
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblInfo.Location = new System.Drawing.Point(20, 70);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(720, 20);
            this.lblInfo.Text = "Data utilities, failure simulations and diagnostics for demonstrations. Every action is recorded in the log.";
            // 
            // grpData
            // 
            this.grpData.Controls.Add(this.btnGenerate);
            this.grpData.Controls.Add(this.btnClearRecords);
            this.grpData.Controls.Add(this.btnResetRates);
            this.grpData.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(92)))));
            this.grpData.Location = new System.Drawing.Point(20, 98);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(250, 164);
            this.grpData.TabStop = false;
            this.grpData.Text = "Data";
            // 
            // btnGenerate
            // 
            this.btnGenerate.BackColor = System.Drawing.Color.White;
            this.btnGenerate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnGenerate.FlatAppearance.BorderSize = 1;
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(92)))));
            this.btnGenerate.Location = new System.Drawing.Point(12, 26);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(226, 38);
            this.btnGenerate.Text = "Generate Sample Data";
            this.btnGenerate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerate.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnClearRecords
            // 
            this.btnClearRecords.BackColor = System.Drawing.Color.White;
            this.btnClearRecords.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearRecords.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnClearRecords.FlatAppearance.BorderSize = 1;
            this.btnClearRecords.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearRecords.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearRecords.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnClearRecords.Location = new System.Drawing.Point(12, 70);
            this.btnClearRecords.Name = "btnClearRecords";
            this.btnClearRecords.Size = new System.Drawing.Size(226, 38);
            this.btnClearRecords.Text = "Clear All Records";
            this.btnClearRecords.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClearRecords.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnClearRecords.UseVisualStyleBackColor = false;
            this.btnClearRecords.Click += new System.EventHandler(this.btnClearRecords_Click);
            // 
            // btnResetRates
            // 
            this.btnResetRates.BackColor = System.Drawing.Color.White;
            this.btnResetRates.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResetRates.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnResetRates.FlatAppearance.BorderSize = 1;
            this.btnResetRates.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetRates.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetRates.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(92)))));
            this.btnResetRates.Location = new System.Drawing.Point(12, 114);
            this.btnResetRates.Name = "btnResetRates";
            this.btnResetRates.Size = new System.Drawing.Size(226, 38);
            this.btnResetRates.Text = "Reset Rates to Defaults";
            this.btnResetRates.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnResetRates.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnResetRates.UseVisualStyleBackColor = false;
            this.btnResetRates.Click += new System.EventHandler(this.btnResetRates_Click);
            // 
            // grpSimulations
            // 
            this.grpSimulations.Controls.Add(this.btnAdvanceTime);
            this.grpSimulations.Controls.Add(this.btnQueryTimeout);
            this.grpSimulations.Controls.Add(this.btnConnectionFailure);
            this.grpSimulations.Controls.Add(this.btnUnexpectedError);
            this.grpSimulations.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSimulations.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(92)))));
            this.grpSimulations.Location = new System.Drawing.Point(20, 270);
            this.grpSimulations.Name = "grpSimulations";
            this.grpSimulations.Size = new System.Drawing.Size(250, 208);
            this.grpSimulations.TabStop = false;
            this.grpSimulations.Text = "Simulations";
            // 
            // btnAdvanceTime
            // 
            this.btnAdvanceTime.BackColor = System.Drawing.Color.White;
            this.btnAdvanceTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdvanceTime.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnAdvanceTime.FlatAppearance.BorderSize = 1;
            this.btnAdvanceTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdvanceTime.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdvanceTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(92)))));
            this.btnAdvanceTime.Location = new System.Drawing.Point(12, 26);
            this.btnAdvanceTime.Name = "btnAdvanceTime";
            this.btnAdvanceTime.Size = new System.Drawing.Size(226, 38);
            this.btnAdvanceTime.Text = "Advance Parked Time (+1 Hour)";
            this.btnAdvanceTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdvanceTime.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnAdvanceTime.UseVisualStyleBackColor = false;
            this.btnAdvanceTime.Click += new System.EventHandler(this.btnAdvanceTime_Click);
            // 
            // btnQueryTimeout
            // 
            this.btnQueryTimeout.BackColor = System.Drawing.Color.White;
            this.btnQueryTimeout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQueryTimeout.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnQueryTimeout.FlatAppearance.BorderSize = 1;
            this.btnQueryTimeout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQueryTimeout.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQueryTimeout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(92)))));
            this.btnQueryTimeout.Location = new System.Drawing.Point(12, 70);
            this.btnQueryTimeout.Name = "btnQueryTimeout";
            this.btnQueryTimeout.Size = new System.Drawing.Size(226, 38);
            this.btnQueryTimeout.Text = "Simulate Query Timeout";
            this.btnQueryTimeout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQueryTimeout.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnQueryTimeout.UseVisualStyleBackColor = false;
            this.btnQueryTimeout.Click += new System.EventHandler(this.btnQueryTimeout_Click);
            // 
            // btnConnectionFailure
            // 
            this.btnConnectionFailure.BackColor = System.Drawing.Color.White;
            this.btnConnectionFailure.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConnectionFailure.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnConnectionFailure.FlatAppearance.BorderSize = 1;
            this.btnConnectionFailure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnectionFailure.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnectionFailure.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(92)))));
            this.btnConnectionFailure.Location = new System.Drawing.Point(12, 114);
            this.btnConnectionFailure.Name = "btnConnectionFailure";
            this.btnConnectionFailure.Size = new System.Drawing.Size(226, 38);
            this.btnConnectionFailure.Text = "Simulate Connection Failure";
            this.btnConnectionFailure.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConnectionFailure.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnConnectionFailure.UseVisualStyleBackColor = false;
            this.btnConnectionFailure.Click += new System.EventHandler(this.btnConnectionFailure_Click);
            // 
            // btnUnexpectedError
            // 
            this.btnUnexpectedError.BackColor = System.Drawing.Color.White;
            this.btnUnexpectedError.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUnexpectedError.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnUnexpectedError.FlatAppearance.BorderSize = 1;
            this.btnUnexpectedError.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnexpectedError.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnexpectedError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(92)))));
            this.btnUnexpectedError.Location = new System.Drawing.Point(12, 158);
            this.btnUnexpectedError.Name = "btnUnexpectedError";
            this.btnUnexpectedError.Size = new System.Drawing.Size(226, 38);
            this.btnUnexpectedError.Text = "Simulate Unexpected Error";
            this.btnUnexpectedError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUnexpectedError.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnUnexpectedError.UseVisualStyleBackColor = false;
            this.btnUnexpectedError.Click += new System.EventHandler(this.btnUnexpectedError_Click);
            // 
            // grpDiagnostics
            // 
            this.grpDiagnostics.Controls.Add(this.btnSelfTests);
            this.grpDiagnostics.Controls.Add(this.btnIntegrity);
            this.grpDiagnostics.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDiagnostics.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(92)))));
            this.grpDiagnostics.Location = new System.Drawing.Point(20, 486);
            this.grpDiagnostics.Name = "grpDiagnostics";
            this.grpDiagnostics.Size = new System.Drawing.Size(250, 120);
            this.grpDiagnostics.TabStop = false;
            this.grpDiagnostics.Text = "Diagnostics";
            // 
            // btnSelfTests
            // 
            this.btnSelfTests.BackColor = System.Drawing.Color.White;
            this.btnSelfTests.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelfTests.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnSelfTests.FlatAppearance.BorderSize = 1;
            this.btnSelfTests.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelfTests.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelfTests.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(92)))));
            this.btnSelfTests.Location = new System.Drawing.Point(12, 26);
            this.btnSelfTests.Name = "btnSelfTests";
            this.btnSelfTests.Size = new System.Drawing.Size(226, 38);
            this.btnSelfTests.Text = "Run Self-Tests";
            this.btnSelfTests.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelfTests.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnSelfTests.UseVisualStyleBackColor = false;
            this.btnSelfTests.Click += new System.EventHandler(this.btnSelfTests_Click);
            // 
            // btnIntegrity
            // 
            this.btnIntegrity.BackColor = System.Drawing.Color.White;
            this.btnIntegrity.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIntegrity.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnIntegrity.FlatAppearance.BorderSize = 1;
            this.btnIntegrity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIntegrity.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIntegrity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(92)))));
            this.btnIntegrity.Location = new System.Drawing.Point(12, 70);
            this.btnIntegrity.Name = "btnIntegrity";
            this.btnIntegrity.Size = new System.Drawing.Size(226, 38);
            this.btnIntegrity.Text = "Check Data Integrity";
            this.btnIntegrity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIntegrity.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnIntegrity.UseVisualStyleBackColor = false;
            this.btnIntegrity.Click += new System.EventHandler(this.btnIntegrity_Click);
            // 
            // lblLog
            // 
            this.lblLog.AutoSize = true;
            this.lblLog.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(92)))));
            this.lblLog.Location = new System.Drawing.Point(286, 98);
            this.lblLog.Name = "lblLog";
            this.lblLog.Text = "Log";
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.Color.White;
            this.txtLog.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLog.Location = new System.Drawing.Point(286, 120);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(454, 434);
            this.txtLog.WordWrap = false;
            // 
            // btnClearLog
            // 
            this.btnClearLog.BackColor = System.Drawing.Color.White;
            this.btnClearLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearLog.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnClearLog.FlatAppearance.BorderSize = 1;
            this.btnClearLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearLog.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(92)))));
            this.btnClearLog.Location = new System.Drawing.Point(286, 566);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(170, 40);
            this.btnClearLog.Text = "Clear Log";
            this.btnClearLog.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnClearLog.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.btnClearLog.UseVisualStyleBackColor = false;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnClose.FlatAppearance.BorderSize = 1;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(92)))));
            this.btnClose.Location = new System.Drawing.Point(570, 566);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(170, 40);
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnClose.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // DebugForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(760, 626);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.grpData);
            this.Controls.Add(this.grpSimulations);
            this.Controls.Add(this.grpDiagnostics);
            this.Controls.Add(this.lblLog);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.btnClearLog);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DebugForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Parking Location Management System - Debug Tools";
            this.Load += new System.EventHandler(this.DebugForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.grpData.ResumeLayout(false);
            this.grpSimulations.ResumeLayout(false);
            this.grpDiagnostics.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.GroupBox grpData;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnClearRecords;
        private System.Windows.Forms.Button btnResetRates;
        private System.Windows.Forms.GroupBox grpSimulations;
        private System.Windows.Forms.Button btnAdvanceTime;
        private System.Windows.Forms.Button btnQueryTimeout;
        private System.Windows.Forms.Button btnConnectionFailure;
        private System.Windows.Forms.Button btnUnexpectedError;
        private System.Windows.Forms.GroupBox grpDiagnostics;
        private System.Windows.Forms.Button btnSelfTests;
        private System.Windows.Forms.Button btnIntegrity;
        private System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.Button btnClose;
    }
}
