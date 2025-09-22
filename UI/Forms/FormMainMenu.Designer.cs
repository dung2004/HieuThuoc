namespace HieuThuoc.UI.Forms
{
    partial class FormMainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panelManagement = new System.Windows.Forms.Panel();
            this.btnMedicineMana = new System.Windows.Forms.Button();
            this.btnPackagingMana = new System.Windows.Forms.Button();
            this.btnBatchMana = new System.Windows.Forms.Button();
            this.btnSupplierMana = new System.Windows.Forms.Button();
            this.btnUserMana = new System.Windows.Forms.Button();
            this.buttonManagement = new System.Windows.Forms.Button();
            this.btnSale = new System.Windows.Forms.Button();
            this.btnPurchase = new System.Windows.Forms.Button();
            this.btnDashBoard = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.labelUserName = new System.Windows.Forms.Label();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnMaximize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCloseChildForm = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelDesktopPanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelMenu.SuspendLayout();
            this.panelManagement.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.panelTitleBar.SuspendLayout();
            this.panelDesktopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.AutoScroll = true;
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panelMenu.Controls.Add(this.btnLogin);
            this.panelMenu.Controls.Add(this.btnLogout);
            this.panelMenu.Controls.Add(this.panelManagement);
            this.panelMenu.Controls.Add(this.buttonManagement);
            this.panelMenu.Controls.Add(this.btnSale);
            this.panelMenu.Controls.Add(this.btnPurchase);
            this.panelMenu.Controls.Add(this.btnDashBoard);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(280, 729);
            this.panelMenu.TabIndex = 0;
            // 
            // btnLogin
            // 
            this.btnLogin.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnLogin.Image = global::HieuThuoc.Properties.Resources.login;
            this.btnLogin.Location = new System.Drawing.Point(0, 629);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnLogin.Size = new System.Drawing.Size(259, 60);
            this.btnLogin.TabIndex = 7;
            this.btnLogin.Text = "  Staff Login";
            this.btnLogin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnLogout.Image = global::HieuThuoc.Properties.Resources.logout;
            this.btnLogout.Location = new System.Drawing.Point(0, 689);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnLogout.Size = new System.Drawing.Size(259, 60);
            this.btnLogout.TabIndex = 8;
            this.btnLogout.Text = "  Logout";
            this.btnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Visible = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // panelManagement
            // 
            this.panelManagement.AutoScroll = true;
            this.panelManagement.Controls.Add(this.btnMedicineMana);
            this.panelManagement.Controls.Add(this.btnPackagingMana);
            this.panelManagement.Controls.Add(this.btnBatchMana);
            this.panelManagement.Controls.Add(this.btnSupplierMana);
            this.panelManagement.Controls.Add(this.btnUserMana);
            this.panelManagement.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelManagement.Location = new System.Drawing.Point(0, 320);
            this.panelManagement.Name = "panelManagement";
            this.panelManagement.Size = new System.Drawing.Size(259, 309);
            this.panelManagement.TabIndex = 13;
            // 
            // btnMedicineMana
            // 
            this.btnMedicineMana.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMedicineMana.FlatAppearance.BorderSize = 0;
            this.btnMedicineMana.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMedicineMana.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMedicineMana.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnMedicineMana.Image = global::HieuThuoc.Properties.Resources.medicine;
            this.btnMedicineMana.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMedicineMana.Location = new System.Drawing.Point(0, 240);
            this.btnMedicineMana.Name = "btnMedicineMana";
            this.btnMedicineMana.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnMedicineMana.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnMedicineMana.Size = new System.Drawing.Size(259, 60);
            this.btnMedicineMana.TabIndex = 2;
            this.btnMedicineMana.Text = "  Medicine";
            this.btnMedicineMana.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMedicineMana.UseVisualStyleBackColor = true;
            this.btnMedicineMana.Click += new System.EventHandler(this.btnMedicineMana_Click);
            // 
            // btnPackagingMana
            // 
            this.btnPackagingMana.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPackagingMana.FlatAppearance.BorderSize = 0;
            this.btnPackagingMana.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPackagingMana.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPackagingMana.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnPackagingMana.Image = global::HieuThuoc.Properties.Resources.value__1_;
            this.btnPackagingMana.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPackagingMana.Location = new System.Drawing.Point(0, 180);
            this.btnPackagingMana.Name = "btnPackagingMana";
            this.btnPackagingMana.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnPackagingMana.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnPackagingMana.Size = new System.Drawing.Size(259, 60);
            this.btnPackagingMana.TabIndex = 3;
            this.btnPackagingMana.Text = "  Package";
            this.btnPackagingMana.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPackagingMana.UseVisualStyleBackColor = true;
            this.btnPackagingMana.Click += new System.EventHandler(this.btnPackagingMana_Click);
            // 
            // btnBatchMana
            // 
            this.btnBatchMana.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBatchMana.FlatAppearance.BorderSize = 0;
            this.btnBatchMana.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBatchMana.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBatchMana.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnBatchMana.Image = global::HieuThuoc.Properties.Resources.batch;
            this.btnBatchMana.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBatchMana.Location = new System.Drawing.Point(0, 120);
            this.btnBatchMana.Name = "btnBatchMana";
            this.btnBatchMana.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnBatchMana.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnBatchMana.Size = new System.Drawing.Size(259, 60);
            this.btnBatchMana.TabIndex = 1;
            this.btnBatchMana.Text = "  Batch";
            this.btnBatchMana.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBatchMana.UseVisualStyleBackColor = true;
            this.btnBatchMana.Click += new System.EventHandler(this.btnBatchMana_Click);
            // 
            // btnSupplierMana
            // 
            this.btnSupplierMana.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSupplierMana.FlatAppearance.BorderSize = 0;
            this.btnSupplierMana.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupplierMana.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupplierMana.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnSupplierMana.Image = global::HieuThuoc.Properties.Resources.supply;
            this.btnSupplierMana.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSupplierMana.Location = new System.Drawing.Point(0, 60);
            this.btnSupplierMana.Name = "btnSupplierMana";
            this.btnSupplierMana.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnSupplierMana.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSupplierMana.Size = new System.Drawing.Size(259, 60);
            this.btnSupplierMana.TabIndex = 8;
            this.btnSupplierMana.Text = "  Supply";
            this.btnSupplierMana.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSupplierMana.UseVisualStyleBackColor = true;
            this.btnSupplierMana.Click += new System.EventHandler(this.btnSupplierMana_Click);
            // 
            // btnUserMana
            // 
            this.btnUserMana.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUserMana.FlatAppearance.BorderSize = 0;
            this.btnUserMana.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserMana.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserMana.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnUserMana.Image = global::HieuThuoc.Properties.Resources.userManage;
            this.btnUserMana.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUserMana.Location = new System.Drawing.Point(0, 0);
            this.btnUserMana.Name = "btnUserMana";
            this.btnUserMana.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnUserMana.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnUserMana.Size = new System.Drawing.Size(259, 60);
            this.btnUserMana.TabIndex = 9;
            this.btnUserMana.Text = "  User";
            this.btnUserMana.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUserMana.UseVisualStyleBackColor = true;
            this.btnUserMana.Click += new System.EventHandler(this.btnUserMana_Click);
            // 
            // buttonManagement
            // 
            this.buttonManagement.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonManagement.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonManagement.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonManagement.Image = global::HieuThuoc.Properties.Resources.management;
            this.buttonManagement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonManagement.Location = new System.Drawing.Point(0, 260);
            this.buttonManagement.Name = "buttonManagement";
            this.buttonManagement.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.buttonManagement.Size = new System.Drawing.Size(259, 60);
            this.buttonManagement.TabIndex = 12;
            this.buttonManagement.Text = "  Management";
            this.buttonManagement.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonManagement.UseVisualStyleBackColor = true;
            this.buttonManagement.Click += new System.EventHandler(this.buttonManagement_Click);
            // 
            // btnSale
            // 
            this.btnSale.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSale.FlatAppearance.BorderSize = 0;
            this.btnSale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSale.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSale.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnSale.Image = global::HieuThuoc.Properties.Resources.sale;
            this.btnSale.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSale.Location = new System.Drawing.Point(0, 200);
            this.btnSale.Name = "btnSale";
            this.btnSale.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnSale.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSale.Size = new System.Drawing.Size(259, 60);
            this.btnSale.TabIndex = 6;
            this.btnSale.Text = "  Sale";
            this.btnSale.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSale.UseVisualStyleBackColor = true;
            this.btnSale.Click += new System.EventHandler(this.btnSale_Click);
            // 
            // btnPurchase
            // 
            this.btnPurchase.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPurchase.FlatAppearance.BorderSize = 0;
            this.btnPurchase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPurchase.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPurchase.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnPurchase.Image = global::HieuThuoc.Properties.Resources.bar_chart;
            this.btnPurchase.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPurchase.Location = new System.Drawing.Point(0, 140);
            this.btnPurchase.Name = "btnPurchase";
            this.btnPurchase.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnPurchase.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnPurchase.Size = new System.Drawing.Size(259, 60);
            this.btnPurchase.TabIndex = 4;
            this.btnPurchase.Text = "  Purchase";
            this.btnPurchase.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPurchase.UseVisualStyleBackColor = true;
            this.btnPurchase.Click += new System.EventHandler(this.btnPurchase_Click);
            // 
            // btnDashBoard
            // 
            this.btnDashBoard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDashBoard.FlatAppearance.BorderSize = 0;
            this.btnDashBoard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashBoard.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashBoard.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnDashBoard.Image = global::HieuThuoc.Properties.Resources.dashboard;
            this.btnDashBoard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashBoard.Location = new System.Drawing.Point(0, 80);
            this.btnDashBoard.Name = "btnDashBoard";
            this.btnDashBoard.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnDashBoard.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnDashBoard.Size = new System.Drawing.Size(259, 60);
            this.btnDashBoard.TabIndex = 10;
            this.btnDashBoard.Text = "  DashBoard";
            this.btnDashBoard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDashBoard.UseVisualStyleBackColor = true;
            this.btnDashBoard.Click += new System.EventHandler(this.btnDashBoard_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.panelLogo.Controls.Add(this.labelUserName);
            this.panelLogo.Controls.Add(this.pbImage);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(259, 80);
            this.panelLogo.TabIndex = 0;
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUserName.Location = new System.Drawing.Point(70, 26);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(0, 22);
            this.labelUserName.TabIndex = 1;
            // 
            // pbImage
            // 
            this.pbImage.Location = new System.Drawing.Point(13, 13);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(50, 50);
            this.pbImage.TabIndex = 0;
            this.pbImage.TabStop = false;
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.panelTitleBar.Controls.Add(this.btnMinimize);
            this.panelTitleBar.Controls.Add(this.btnMaximize);
            this.panelTitleBar.Controls.Add(this.btnClose);
            this.panelTitleBar.Controls.Add(this.btnCloseChildForm);
            this.panelTitleBar.Controls.Add(this.lblTitle);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(280, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(902, 80);
            this.panelTitleBar.TabIndex = 1;
            this.panelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Times New Roman", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnMinimize.ForeColor = System.Drawing.Color.White;
            this.btnMinimize.Location = new System.Drawing.Point(808, 4);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(30, 30);
            this.btnMinimize.TabIndex = 4;
            this.btnMinimize.Text = "-";
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnMaximize
            // 
            this.btnMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximize.FlatAppearance.BorderSize = 0;
            this.btnMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaximize.Font = new System.Drawing.Font("Times New Roman", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnMaximize.ForeColor = System.Drawing.Color.White;
            this.btnMaximize.Location = new System.Drawing.Point(838, 3);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Size = new System.Drawing.Size(30, 30);
            this.btnMaximize.TabIndex = 3;
            this.btnMaximize.Text = "O";
            this.btnMaximize.UseVisualStyleBackColor = true;
            this.btnMaximize.Click += new System.EventHandler(this.btnMaximize_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(868, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCloseChildForm
            // 
            this.btnCloseChildForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCloseChildForm.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCloseChildForm.FlatAppearance.BorderSize = 0;
            this.btnCloseChildForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseChildForm.Image = global::HieuThuoc.Properties.Resources.cross_out__2_;
            this.btnCloseChildForm.Location = new System.Drawing.Point(0, 0);
            this.btnCloseChildForm.Name = "btnCloseChildForm";
            this.btnCloseChildForm.Size = new System.Drawing.Size(75, 80);
            this.btnCloseChildForm.TabIndex = 1;
            this.btnCloseChildForm.UseVisualStyleBackColor = true;
            this.btnCloseChildForm.Click += new System.EventHandler(this.btnCloseChildForm_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(400, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(95, 31);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "HOME";
            // 
            // panelDesktopPanel
            // 
            this.panelDesktopPanel.Controls.Add(this.pictureBox1);
            this.panelDesktopPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktopPanel.Location = new System.Drawing.Point(280, 80);
            this.panelDesktopPanel.Name = "panelDesktopPanel";
            this.panelDesktopPanel.Size = new System.Drawing.Size(902, 649);
            this.panelDesktopPanel.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::HieuThuoc.Properties.Resources.background1;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(902, 649);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // FormMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 729);
            this.Controls.Add(this.panelDesktopPanel);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.panelMenu);
            this.MinimumSize = new System.Drawing.Size(1200, 730);
            this.Name = "FormMainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMainMenu";
            this.Load += new System.EventHandler(this.FormMainMenu_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelManagement.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            this.panelDesktopPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnBatchMana;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Button btnSale;
        private System.Windows.Forms.Button btnPurchase;
        private System.Windows.Forms.Button btnPackagingMana;
        private System.Windows.Forms.Button btnMedicineMana;
        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelDesktopPanel;
        private System.Windows.Forms.Button btnCloseChildForm;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnMaximize;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnUserMana;
        private System.Windows.Forms.Button btnSupplierMana;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button buttonManagement;
        private System.Windows.Forms.Panel panelManagement;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Button btnDashBoard;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

