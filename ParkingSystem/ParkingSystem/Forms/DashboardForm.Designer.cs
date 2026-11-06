namespace ParkingSystem.Forms
{
    partial class DashboardForm
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
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.lblBrand = new System.Windows.Forms.Label();
            this.btnNavDashboard = new System.Windows.Forms.Button();
            this.btnNavEntry = new System.Windows.Forms.Button();
            this.btnNavExit = new System.Windows.Forms.Button();
            this.btnNavRecords = new System.Windows.Forms.Button();
            this.btnNavRates = new System.Windows.Forms.Button();
            this.btnNavDebug = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.lblFind = new System.Windows.Forms.Label();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblClock = new System.Windows.Forms.Label();
            this.pnlCard1 = new System.Windows.Forms.Panel();
            this.lblCard1Title = new System.Windows.Forms.Label();
            this.lblCard1Value = new System.Windows.Forms.Label();
            this.pnlCard2 = new System.Windows.Forms.Panel();
            this.lblCard2Title = new System.Windows.Forms.Label();
            this.lblCard2Value = new System.Windows.Forms.Label();
            this.pnlCard3 = new System.Windows.Forms.Panel();
            this.lblCard3Title = new System.Windows.Forms.Label();
            this.lblCard3Value = new System.Windows.Forms.Label();
            this.pnlCard4 = new System.Windows.Forms.Panel();
            this.lblCard4Title = new System.Windows.Forms.Label();
            this.lblCard4Value = new System.Windows.Forms.Label();
            this.slotMap = new ParkingSystem.Controls.SlotMapControl();
            this.pnlLegendAvailable = new System.Windows.Forms.Panel();
            this.lblLegendAvailable = new System.Windows.Forms.Label();
            this.pnlLegendOccupied = new System.Windows.Forms.Panel();
            this.lblLegendOccupied = new System.Windows.Forms.Label();
            this.pnlLegendReserved = new System.Windows.Forms.Panel();
            this.lblLegendReserved = new System.Windows.Forms.Label();
            this.lblMapHint = new System.Windows.Forms.Label();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.lblInfoSlot = new System.Windows.Forms.Label();
            this.lblInfoStatus = new System.Windows.Forms.Label();
            this.lblInfoKeys = new System.Windows.Forms.Label();
            this.lblInfoDetails = new System.Windows.Forms.Label();
            this.btnAction1 = new System.Windows.Forms.Button();
            this.btnAction2 = new System.Windows.Forms.Button();
            this.btnAction3 = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.tmrClock = new System.Windows.Forms.Timer(this.components);
            this.tmrRefresh = new System.Windows.Forms.Timer(this.components);
            this.pnlSidebar.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlCard1.SuspendLayout();
            this.pnlCard2.SuspendLayout();
            this.pnlCard3.SuspendLayout();
            this.pnlCard4.SuspendLayout();
            this.pnlLegendAvailable.SuspendLayout();
            this.pnlLegendOccupied.SuspendLayout();
            this.pnlLegendReserved.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(92)))));
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(200, 640);
            this.pnlSidebar.Controls.Add(this.lblBrand);
            this.pnlSidebar.Controls.Add(this.btnNavDashboard);
            this.pnlSidebar.Controls.Add(this.btnNavEntry);
            this.pnlSidebar.Controls.Add(this.btnNavExit);
            this.pnlSidebar.Controls.Add(this.btnNavRecords);
            this.pnlSidebar.Controls.Add(this.btnNavRates);
            this.pnlSidebar.Controls.Add(this.btnNavDebug);
            this.pnlSidebar.Controls.Add(this.btnLogout);
            // 
            // lblBrand
            // 
            this.lblBrand.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrand.ForeColor = System.Drawing.Color.White;
            this.lblBrand.Location = new System.Drawing.Point(0, 14);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(200, 40);
            this.lblBrand.Text = "PARKING SYSTEM";
            this.lblBrand.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNavDashboard
            // 
            this.btnNavDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(92)))));
            this.btnNavDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavDashboard.FlatAppearance.BorderSize = 0;
            this.btnNavDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavDashboard.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavDashboard.ForeColor = System.Drawing.Color.White;
            this.btnNavDashboard.Location = new System.Drawing.Point(0, 70);
            this.btnNavDashboard.Name = "btnNavDashboard";
            this.btnNavDashboard.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnNavDashboard.Size = new System.Drawing.Size(200, 44);
            this.btnNavDashboard.Text = "Parking Map";
            this.btnNavDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavDashboard.UseVisualStyleBackColor = false;
            this.btnNavDashboard.Click += new System.EventHandler(this.btnNavDashboard_Click);
            // 
            // btnNavEntry
            // 
            this.btnNavEntry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(92)))));
            this.btnNavEntry.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavEntry.FlatAppearance.BorderSize = 0;
            this.btnNavEntry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavEntry.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavEntry.ForeColor = System.Drawing.Color.White;
            this.btnNavEntry.Location = new System.Drawing.Point(0, 114);
            this.btnNavEntry.Name = "btnNavEntry";
            this.btnNavEntry.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnNavEntry.Size = new System.Drawing.Size(200, 44);
            this.btnNavEntry.Text = "Vehicle Entry";
            this.btnNavEntry.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavEntry.UseVisualStyleBackColor = false;
            this.btnNavEntry.Click += new System.EventHandler(this.btnNavEntry_Click);
            // 
            // btnNavExit
            // 
            this.btnNavExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(92)))));
            this.btnNavExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavExit.FlatAppearance.BorderSize = 0;
            this.btnNavExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavExit.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavExit.ForeColor = System.Drawing.Color.White;
            this.btnNavExit.Location = new System.Drawing.Point(0, 158);
            this.btnNavExit.Name = "btnNavExit";
            this.btnNavExit.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnNavExit.Size = new System.Drawing.Size(200, 44);
            this.btnNavExit.Text = "Vehicle Exit";
            this.btnNavExit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavExit.UseVisualStyleBackColor = false;
            this.btnNavExit.Click += new System.EventHandler(this.btnNavExit_Click);
            // 
            // btnNavRecords
            // 
            this.btnNavRecords.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(92)))));
            this.btnNavRecords.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavRecords.FlatAppearance.BorderSize = 0;
            this.btnNavRecords.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavRecords.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavRecords.ForeColor = System.Drawing.Color.White;
            this.btnNavRecords.Location = new System.Drawing.Point(0, 202);
            this.btnNavRecords.Name = "btnNavRecords";
            this.btnNavRecords.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnNavRecords.Size = new System.Drawing.Size(200, 44);
            this.btnNavRecords.Text = "Records && Reports";
            this.btnNavRecords.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavRecords.UseVisualStyleBackColor = false;
            this.btnNavRecords.Click += new System.EventHandler(this.btnNavRecords_Click);
            // 
            // btnNavRates
            // 
            this.btnNavRates.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(92)))));
            this.btnNavRates.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavRates.FlatAppearance.BorderSize = 0;
            this.btnNavRates.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavRates.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavRates.ForeColor = System.Drawing.Color.White;
            this.btnNavRates.Location = new System.Drawing.Point(0, 246);
            this.btnNavRates.Name = "btnNavRates";
            this.btnNavRates.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnNavRates.Size = new System.Drawing.Size(200, 44);
            this.btnNavRates.Text = "Rates Settings";
            this.btnNavRates.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavRates.UseVisualStyleBackColor = false;
            this.btnNavRates.Click += new System.EventHandler(this.btnNavRates_Click);
            // 
            // btnNavDebug
            // 
            this.btnNavDebug.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(92)))));
            this.btnNavDebug.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavDebug.FlatAppearance.BorderSize = 0;
            this.btnNavDebug.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavDebug.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavDebug.ForeColor = System.Drawing.Color.White;
            this.btnNavDebug.Location = new System.Drawing.Point(0, 290);
            this.btnNavDebug.Name = "btnNavDebug";
            this.btnNavDebug.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnNavDebug.Size = new System.Drawing.Size(200, 44);
            this.btnNavDebug.Text = "Debug Tools";
            this.btnNavDebug.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavDebug.UseVisualStyleBackColor = false;
            this.btnNavDebug.Click += new System.EventHandler(this.btnNavDebug_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(92)))));
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(0, 580);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnLogout.Size = new System.Drawing.Size(200, 44);
            this.btnLogout.Text = "Logout";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Location = new System.Drawing.Point(200, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(920, 60);
            this.pnlTop.Controls.Add(this.lblPageTitle);
            this.pnlTop.Controls.Add(this.lblFind);
            this.pnlTop.Controls.Add(this.txtFind);
            this.pnlTop.Controls.Add(this.lblWelcome);
            this.pnlTop.Controls.Add(this.lblClock);
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(92)))));
            this.lblPageTitle.Location = new System.Drawing.Point(20, 13);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Text = "Parking Map";
            // 
            // lblFind
            // 
            this.lblFind.AutoSize = true;
            this.lblFind.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFind.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblFind.Location = new System.Drawing.Point(215, 21);
            this.lblFind.Name = "lblFind";
            this.lblFind.Text = "Find vehicle";
            // 
            // txtFind
            // 
            this.txtFind.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFind.Location = new System.Drawing.Point(300, 17);
            this.txtFind.MaxLength = 40;
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(300, 27);
            // 
            // lblWelcome
            // 
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(92)))));
            this.lblWelcome.Location = new System.Drawing.Point(640, 9);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(260, 22);
            this.lblWelcome.Text = "Welcome";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblClock
            // 
            this.lblClock.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblClock.Location = new System.Drawing.Point(640, 31);
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(260, 20);
            this.lblClock.Text = "";
            this.lblClock.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlCard1
            // 
            this.pnlCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.pnlCard1.Location = new System.Drawing.Point(220, 75);
            this.pnlCard1.Name = "pnlCard1";
            this.pnlCard1.Size = new System.Drawing.Size(211, 74);
            this.pnlCard1.Controls.Add(this.lblCard1Title);
            this.pnlCard1.Controls.Add(this.lblCard1Value);
            // 
            // lblCard1Title
            // 
            this.lblCard1Title.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCard1Title.ForeColor = System.Drawing.Color.White;
            this.lblCard1Title.Location = new System.Drawing.Point(12, 8);
            this.lblCard1Title.Name = "lblCard1Title";
            this.lblCard1Title.Size = new System.Drawing.Size(190, 20);
            this.lblCard1Title.Text = "Free slots";
            // 
            // lblCard1Value
            // 
            this.lblCard1Value.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCard1Value.ForeColor = System.Drawing.Color.White;
            this.lblCard1Value.Location = new System.Drawing.Point(9, 28);
            this.lblCard1Value.Name = "lblCard1Value";
            this.lblCard1Value.Size = new System.Drawing.Size(195, 40);
            this.lblCard1Value.Text = "0";
            this.lblCard1Value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlCard2
            // 
            this.pnlCard2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.pnlCard2.Location = new System.Drawing.Point(443, 75);
            this.pnlCard2.Name = "pnlCard2";
            this.pnlCard2.Size = new System.Drawing.Size(211, 74);
            this.pnlCard2.Controls.Add(this.lblCard2Title);
            this.pnlCard2.Controls.Add(this.lblCard2Value);
            // 
            // lblCard2Title
            // 
            this.lblCard2Title.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCard2Title.ForeColor = System.Drawing.Color.White;
            this.lblCard2Title.Location = new System.Drawing.Point(12, 8);
            this.lblCard2Title.Name = "lblCard2Title";
            this.lblCard2Title.Size = new System.Drawing.Size(190, 20);
            this.lblCard2Title.Text = "Occupied";
            // 
            // lblCard2Value
            // 
            this.lblCard2Value.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCard2Value.ForeColor = System.Drawing.Color.White;
            this.lblCard2Value.Location = new System.Drawing.Point(9, 28);
            this.lblCard2Value.Name = "lblCard2Value";
            this.lblCard2Value.Size = new System.Drawing.Size(195, 40);
            this.lblCard2Value.Text = "0";
            this.lblCard2Value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlCard3
            // 
            this.pnlCard3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(119)))), ((int)(((byte)(6)))));
            this.pnlCard3.Location = new System.Drawing.Point(666, 75);
            this.pnlCard3.Name = "pnlCard3";
            this.pnlCard3.Size = new System.Drawing.Size(211, 74);
            this.pnlCard3.Controls.Add(this.lblCard3Title);
            this.pnlCard3.Controls.Add(this.lblCard3Value);
            // 
            // lblCard3Title
            // 
            this.lblCard3Title.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCard3Title.ForeColor = System.Drawing.Color.White;
            this.lblCard3Title.Location = new System.Drawing.Point(12, 8);
            this.lblCard3Title.Name = "lblCard3Title";
            this.lblCard3Title.Size = new System.Drawing.Size(190, 20);
            this.lblCard3Title.Text = "Reserved";
            // 
            // lblCard3Value
            // 
            this.lblCard3Value.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCard3Value.ForeColor = System.Drawing.Color.White;
            this.lblCard3Value.Location = new System.Drawing.Point(9, 28);
            this.lblCard3Value.Name = "lblCard3Value";
            this.lblCard3Value.Size = new System.Drawing.Size(195, 40);
            this.lblCard3Value.Text = "0";
            this.lblCard3Value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlCard4
            // 
            this.pnlCard4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(58)))), ((int)(((byte)(237)))));
            this.pnlCard4.Location = new System.Drawing.Point(889, 75);
            this.pnlCard4.Name = "pnlCard4";
            this.pnlCard4.Size = new System.Drawing.Size(211, 74);
            this.pnlCard4.Controls.Add(this.lblCard4Title);
            this.pnlCard4.Controls.Add(this.lblCard4Value);
            // 
            // lblCard4Title
            // 
            this.lblCard4Title.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCard4Title.ForeColor = System.Drawing.Color.White;
            this.lblCard4Title.Location = new System.Drawing.Point(12, 8);
            this.lblCard4Title.Name = "lblCard4Title";
            this.lblCard4Title.Size = new System.Drawing.Size(190, 20);
            this.lblCard4Title.Text = "Today's income";
            // 
            // lblCard4Value
            // 
            this.lblCard4Value.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCard4Value.ForeColor = System.Drawing.Color.White;
            this.lblCard4Value.Location = new System.Drawing.Point(9, 28);
            this.lblCard4Value.Name = "lblCard4Value";
            this.lblCard4Value.Size = new System.Drawing.Size(195, 40);
            this.lblCard4Value.Text = "0";
            this.lblCard4Value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // slotMap
            // 
            this.slotMap.BackColor = System.Drawing.Color.White;
            this.slotMap.Location = new System.Drawing.Point(220, 165);
            this.slotMap.Name = "slotMap";
            this.slotMap.Size = new System.Drawing.Size(600, 400);
            // 
            // pnlLegendAvailable
            // 
            this.pnlLegendAvailable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(252)))), ((int)(((byte)(231)))));
            this.pnlLegendAvailable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLegendAvailable.Location = new System.Drawing.Point(220, 578);
            this.pnlLegendAvailable.Name = "pnlLegendAvailable";
            this.pnlLegendAvailable.Size = new System.Drawing.Size(14, 14);
            // 
            // lblLegendAvailable
            // 
            this.lblLegendAvailable.AutoSize = true;
            this.lblLegendAvailable.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLegendAvailable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblLegendAvailable.Location = new System.Drawing.Point(238, 575);
            this.lblLegendAvailable.Name = "lblLegendAvailable";
            this.lblLegendAvailable.Text = "Free";
            // 
            // pnlLegendOccupied
            // 
            this.pnlLegendOccupied.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.pnlLegendOccupied.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLegendOccupied.Location = new System.Drawing.Point(330, 578);
            this.pnlLegendOccupied.Name = "pnlLegendOccupied";
            this.pnlLegendOccupied.Size = new System.Drawing.Size(14, 14);
            // 
            // lblLegendOccupied
            // 
            this.lblLegendOccupied.AutoSize = true;
            this.lblLegendOccupied.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLegendOccupied.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblLegendOccupied.Location = new System.Drawing.Point(348, 575);
            this.lblLegendOccupied.Name = "lblLegendOccupied";
            this.lblLegendOccupied.Text = "Occupied";
            // 
            // pnlLegendReserved
            // 
            this.pnlLegendReserved.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(243)))), ((int)(((byte)(199)))));
            this.pnlLegendReserved.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLegendReserved.Location = new System.Drawing.Point(440, 578);
            this.pnlLegendReserved.Name = "pnlLegendReserved";
            this.pnlLegendReserved.Size = new System.Drawing.Size(14, 14);
            // 
            // lblLegendReserved
            // 
            this.lblLegendReserved.AutoSize = true;
            this.lblLegendReserved.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLegendReserved.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblLegendReserved.Location = new System.Drawing.Point(458, 575);
            this.lblLegendReserved.Name = "lblLegendReserved";
            this.lblLegendReserved.Text = "Reserved";
            // 
            // lblMapHint
            // 
            this.lblMapHint.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMapHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblMapHint.Location = new System.Drawing.Point(560, 575);
            this.lblMapHint.Name = "lblMapHint";
            this.lblMapHint.Size = new System.Drawing.Size(260, 20);
            this.lblMapHint.Text = "Click a slot to see details and actions.";
            this.lblMapHint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlInfo
            // 
            this.pnlInfo.BackColor = System.Drawing.Color.White;
            this.pnlInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInfo.Location = new System.Drawing.Point(840, 165);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(260, 400);
            this.pnlInfo.Controls.Add(this.lblInfoSlot);
            this.pnlInfo.Controls.Add(this.lblInfoStatus);
            this.pnlInfo.Controls.Add(this.lblInfoKeys);
            this.pnlInfo.Controls.Add(this.lblInfoDetails);
            this.pnlInfo.Controls.Add(this.btnAction1);
            this.pnlInfo.Controls.Add(this.btnAction2);
            this.pnlInfo.Controls.Add(this.btnAction3);
            // 
            // lblInfoSlot
            // 
            this.lblInfoSlot.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoSlot.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(92)))));
            this.lblInfoSlot.Location = new System.Drawing.Point(14, 10);
            this.lblInfoSlot.Name = "lblInfoSlot";
            this.lblInfoSlot.Size = new System.Drawing.Size(230, 40);
            this.lblInfoSlot.Text = "A01";
            this.lblInfoSlot.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblInfoStatus
            // 
            this.lblInfoStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblInfoStatus.Location = new System.Drawing.Point(16, 50);
            this.lblInfoStatus.Name = "lblInfoStatus";
            this.lblInfoStatus.Size = new System.Drawing.Size(228, 22);
            this.lblInfoStatus.Text = "";
            this.lblInfoStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblInfoKeys
            // 
            this.lblInfoKeys.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoKeys.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblInfoKeys.Location = new System.Drawing.Point(16, 80);
            this.lblInfoKeys.Name = "lblInfoKeys";
            this.lblInfoKeys.Size = new System.Drawing.Size(78, 172);
            this.lblInfoKeys.Text = "";
            // 
            // lblInfoDetails
            // 
            this.lblInfoDetails.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblInfoDetails.Location = new System.Drawing.Point(94, 80);
            this.lblInfoDetails.Name = "lblInfoDetails";
            this.lblInfoDetails.Size = new System.Drawing.Size(150, 172);
            this.lblInfoDetails.Text = "";
            // 
            // btnAction1
            // 
            this.btnAction1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(78)))), ((int)(((byte)(216)))));
            this.btnAction1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAction1.FlatAppearance.BorderSize = 0;
            this.btnAction1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAction1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAction1.ForeColor = System.Drawing.Color.White;
            this.btnAction1.Location = new System.Drawing.Point(16, 260);
            this.btnAction1.Name = "btnAction1";
            this.btnAction1.Size = new System.Drawing.Size(226, 38);
            this.btnAction1.Text = "Action 1";
            this.btnAction1.UseVisualStyleBackColor = false;
            this.btnAction1.Click += new System.EventHandler(this.InfoAction_Click);
            // 
            // btnAction2
            // 
            this.btnAction2.BackColor = System.Drawing.Color.White;
            this.btnAction2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAction2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnAction2.FlatAppearance.BorderSize = 1;
            this.btnAction2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAction2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAction2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(92)))));
            this.btnAction2.Location = new System.Drawing.Point(16, 305);
            this.btnAction2.Name = "btnAction2";
            this.btnAction2.Size = new System.Drawing.Size(226, 38);
            this.btnAction2.Text = "Action 2";
            this.btnAction2.UseVisualStyleBackColor = false;
            this.btnAction2.Click += new System.EventHandler(this.InfoAction_Click);
            // 
            // btnAction3
            // 
            this.btnAction3.BackColor = System.Drawing.Color.White;
            this.btnAction3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAction3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnAction3.FlatAppearance.BorderSize = 1;
            this.btnAction3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAction3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAction3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(92)))));
            this.btnAction3.Location = new System.Drawing.Point(16, 350);
            this.btnAction3.Name = "btnAction3";
            this.btnAction3.Size = new System.Drawing.Size(226, 38);
            this.btnAction3.Text = "Action 3";
            this.btnAction3.UseVisualStyleBackColor = false;
            this.btnAction3.Click += new System.EventHandler(this.InfoAction_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblStatus.Location = new System.Drawing.Point(220, 604);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(880, 24);
            this.lblStatus.Text = "";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tmrClock
            // 
            this.tmrClock.Interval = 1000;
            this.tmrClock.Tick += new System.EventHandler(this.tmrClock_Tick);
            // 
            // tmrRefresh
            // 
            this.tmrRefresh.Interval = 30000;
            this.tmrRefresh.Tick += new System.EventHandler(this.tmrRefresh_Tick);
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1120, 640);
            this.Controls.Add(this.pnlSidebar);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlCard1);
            this.Controls.Add(this.pnlCard2);
            this.Controls.Add(this.pnlCard3);
            this.Controls.Add(this.pnlCard4);
            this.Controls.Add(this.slotMap);
            this.Controls.Add(this.pnlLegendAvailable);
            this.Controls.Add(this.lblLegendAvailable);
            this.Controls.Add(this.pnlLegendOccupied);
            this.Controls.Add(this.lblLegendOccupied);
            this.Controls.Add(this.pnlLegendReserved);
            this.Controls.Add(this.lblLegendReserved);
            this.Controls.Add(this.lblMapHint);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.lblStatus);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parking Location Management System - Parking Map";
            this.Load += new System.EventHandler(this.DashboardForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DashboardForm_FormClosing);
            this.pnlSidebar.ResumeLayout(false);
            this.pnlSidebar.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlCard1.ResumeLayout(false);
            this.pnlCard1.PerformLayout();
            this.pnlCard2.ResumeLayout(false);
            this.pnlCard2.PerformLayout();
            this.pnlCard3.ResumeLayout(false);
            this.pnlCard3.PerformLayout();
            this.pnlCard4.ResumeLayout(false);
            this.pnlCard4.PerformLayout();
            this.pnlLegendAvailable.ResumeLayout(false);
            this.pnlLegendAvailable.PerformLayout();
            this.pnlLegendOccupied.ResumeLayout(false);
            this.pnlLegendOccupied.PerformLayout();
            this.pnlLegendReserved.ResumeLayout(false);
            this.pnlLegendReserved.PerformLayout();
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Button btnNavDashboard;
        private System.Windows.Forms.Button btnNavEntry;
        private System.Windows.Forms.Button btnNavExit;
        private System.Windows.Forms.Button btnNavRecords;
        private System.Windows.Forms.Button btnNavRates;
        private System.Windows.Forms.Button btnNavDebug;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Label lblFind;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblClock;
        private System.Windows.Forms.Panel pnlCard1;
        private System.Windows.Forms.Label lblCard1Title;
        private System.Windows.Forms.Label lblCard1Value;
        private System.Windows.Forms.Panel pnlCard2;
        private System.Windows.Forms.Label lblCard2Title;
        private System.Windows.Forms.Label lblCard2Value;
        private System.Windows.Forms.Panel pnlCard3;
        private System.Windows.Forms.Label lblCard3Title;
        private System.Windows.Forms.Label lblCard3Value;
        private System.Windows.Forms.Panel pnlCard4;
        private System.Windows.Forms.Label lblCard4Title;
        private System.Windows.Forms.Label lblCard4Value;
        private ParkingSystem.Controls.SlotMapControl slotMap;
        private System.Windows.Forms.Panel pnlLegendAvailable;
        private System.Windows.Forms.Label lblLegendAvailable;
        private System.Windows.Forms.Panel pnlLegendOccupied;
        private System.Windows.Forms.Label lblLegendOccupied;
        private System.Windows.Forms.Panel pnlLegendReserved;
        private System.Windows.Forms.Label lblLegendReserved;
        private System.Windows.Forms.Label lblMapHint;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Label lblInfoSlot;
        private System.Windows.Forms.Label lblInfoStatus;
        private System.Windows.Forms.Label lblInfoKeys;
        private System.Windows.Forms.Label lblInfoDetails;
        private System.Windows.Forms.Button btnAction1;
        private System.Windows.Forms.Button btnAction2;
        private System.Windows.Forms.Button btnAction3;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Timer tmrClock;
        private System.Windows.Forms.Timer tmrRefresh;
    }
}
