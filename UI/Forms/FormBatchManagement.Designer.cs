namespace HieuThuoc.UI.Forms
{
    partial class FormBatchManagement
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
            this.dgvLoadBatch = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbUsePeriod = new System.Windows.Forms.CheckBox();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbMedicine = new System.Windows.Forms.ComboBox();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblMedicine = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nudReceivedLoosePills = new System.Windows.Forms.NumericUpDown();
            this.nudQuantityPills = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.nudReceivedPacks = new System.Windows.Forms.NumericUpDown();
            this.nudPurchasePrice = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPillsPerPack = new System.Windows.Forms.Label();
            this.dtpCreatedAt = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbCreatedAt = new System.Windows.Forms.TextBox();
            this.dtpExpiryDay = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.tbBatchId = new System.Windows.Forms.TextBox();
            this.lblPackageId = new System.Windows.Forms.Label();
            this.tbPackagingId = new System.Windows.Forms.TextBox();
            this.lblPackageCode = new System.Windows.Forms.Label();
            this.tbBatchCode = new System.Windows.Forms.TextBox();
            this.lblPackageName = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnReloadAll = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoadBatch)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudReceivedLoosePills)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantityPills)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudReceivedPacks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPurchasePrice)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvLoadBatch
            // 
            this.dgvLoadBatch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoadBatch.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvLoadBatch.Location = new System.Drawing.Point(0, 414);
            this.dgvLoadBatch.Name = "dgvLoadBatch";
            this.dgvLoadBatch.RowHeadersWidth = 51;
            this.dgvLoadBatch.RowTemplate.Height = 24;
            this.dgvLoadBatch.Size = new System.Drawing.Size(1582, 389);
            this.dgvLoadBatch.TabIndex = 46;
            this.dgvLoadBatch.SelectionChanged += new System.EventHandler(this.DgvLoadBatch_SelectionChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(45, 322);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(407, 53);
            this.label2.TabIndex = 49;
            this.label2.Text = "Batch Management";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Plum;
            this.groupBox3.Controls.Add(this.cbUsePeriod);
            this.groupBox3.Controls.Add(this.dtpTo);
            this.groupBox3.Controls.Add(this.dtpFrom);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.cbMedicine);
            this.groupBox3.Controls.Add(this.tbSearch);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.lblSearch);
            this.groupBox3.Controls.Add(this.btnSearch);
            this.groupBox3.Controls.Add(this.lblMedicine);
            this.groupBox3.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(1014, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(556, 396);
            this.groupBox3.TabIndex = 55;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filter & Search";
            // 
            // cbUsePeriod
            // 
            this.cbUsePeriod.AutoSize = true;
            this.cbUsePeriod.Location = new System.Drawing.Point(29, 264);
            this.cbUsePeriod.Name = "cbUsePeriod";
            this.cbUsePeriod.Size = new System.Drawing.Size(200, 30);
            this.cbUsePeriod.TabIndex = 49;
            this.cbUsePeriod.Text = "Use period filter ?";
            this.cbUsePeriod.UseVisualStyleBackColor = true;
            // 
            // dtpTo
            // 
            this.dtpTo.Location = new System.Drawing.Point(97, 351);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(270, 34);
            this.dtpTo.TabIndex = 48;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Location = new System.Drawing.Point(97, 311);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(270, 34);
            this.dtpFrom.TabIndex = 47;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(23, 235);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(416, 26);
            this.label10.TabIndex = 46;
            this.label10.Text = "Select the period in which the batch expires";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(28, 351);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 26);
            this.label9.TabIndex = 45;
            this.label9.Text = "To";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(27, 312);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 26);
            this.label8.TabIndex = 44;
            this.label8.Text = "From";
            // 
            // cbMedicine
            // 
            this.cbMedicine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMedicine.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMedicine.FormattingEnabled = true;
            this.cbMedicine.Location = new System.Drawing.Point(31, 178);
            this.cbMedicine.Name = "cbMedicine";
            this.cbMedicine.Size = new System.Drawing.Size(515, 34);
            this.cbMedicine.TabIndex = 39;
            // 
            // tbSearch
            // 
            this.tbSearch.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearch.Location = new System.Drawing.Point(28, 68);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(399, 27);
            this.tbSearch.TabIndex = 32;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(27, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(219, 17);
            this.label7.TabIndex = 43;
            this.label7.Text = "*Search by Batch Code or Batch Id";
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(24, 40);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(75, 26);
            this.lblSearch.TabIndex = 33;
            this.lblSearch.Text = "Search";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(448, 60);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(98, 39);
            this.btnSearch.TabIndex = 34;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // lblMedicine
            // 
            this.lblMedicine.AutoSize = true;
            this.lblMedicine.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMedicine.Location = new System.Drawing.Point(26, 149);
            this.lblMedicine.Name = "lblMedicine";
            this.lblMedicine.Size = new System.Drawing.Size(254, 26);
            this.lblMedicine.TabIndex = 38;
            this.lblMedicine.Text = "Chose Medicine to Search";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Plum;
            this.groupBox2.Controls.Add(this.nudReceivedLoosePills);
            this.groupBox2.Controls.Add(this.nudQuantityPills);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.nudReceivedPacks);
            this.groupBox2.Controls.Add(this.nudPurchasePrice);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lblPillsPerPack);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(590, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(418, 216);
            this.groupBox2.TabIndex = 54;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Price";
            // 
            // nudReceivedLoosePills
            // 
            this.nudReceivedLoosePills.Location = new System.Drawing.Point(244, 119);
            this.nudReceivedLoosePills.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nudReceivedLoosePills.Name = "nudReceivedLoosePills";
            this.nudReceivedLoosePills.Size = new System.Drawing.Size(149, 34);
            this.nudReceivedLoosePills.TabIndex = 43;
            // 
            // nudQuantityPills
            // 
            this.nudQuantityPills.Location = new System.Drawing.Point(244, 164);
            this.nudQuantityPills.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nudQuantityPills.Name = "nudQuantityPills";
            this.nudQuantityPills.ReadOnly = true;
            this.nudQuantityPills.Size = new System.Drawing.Size(149, 34);
            this.nudQuantityPills.TabIndex = 45;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(205, 26);
            this.label6.TabIndex = 42;
            this.label6.Text = "Received Loose Pills";
            // 
            // nudReceivedPacks
            // 
            this.nudReceivedPacks.Location = new System.Drawing.Point(244, 74);
            this.nudReceivedPacks.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nudReceivedPacks.Name = "nudReceivedPacks";
            this.nudReceivedPacks.Size = new System.Drawing.Size(149, 34);
            this.nudReceivedPacks.TabIndex = 40;
            // 
            // nudPurchasePrice
            // 
            this.nudPurchasePrice.Location = new System.Drawing.Point(244, 29);
            this.nudPurchasePrice.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nudPurchasePrice.Name = "nudPurchasePrice";
            this.nudPurchasePrice.Size = new System.Drawing.Size(149, 34);
            this.nudPurchasePrice.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 26);
            this.label1.TabIndex = 20;
            this.label1.Text = "Received Packs";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 26);
            this.label4.TabIndex = 38;
            this.label4.Text = "Purchase Price";
            // 
            // lblPillsPerPack
            // 
            this.lblPillsPerPack.AutoSize = true;
            this.lblPillsPerPack.Location = new System.Drawing.Point(15, 168);
            this.lblPillsPerPack.Name = "lblPillsPerPack";
            this.lblPillsPerPack.Size = new System.Drawing.Size(138, 26);
            this.lblPillsPerPack.TabIndex = 26;
            this.lblPillsPerPack.Text = "Quantity Pills";
            // 
            // dtpCreatedAt
            // 
            this.dtpCreatedAt.Location = new System.Drawing.Point(147, 233);
            this.dtpCreatedAt.Name = "dtpCreatedAt";
            this.dtpCreatedAt.Size = new System.Drawing.Size(255, 34);
            this.dtpCreatedAt.TabIndex = 49;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 236);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 26);
            this.label5.TabIndex = 41;
            this.label5.Text = "Created At";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Plum;
            this.groupBox1.Controls.Add(this.tbCreatedAt);
            this.groupBox1.Controls.Add(this.dtpExpiryDay);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtpCreatedAt);
            this.groupBox1.Controls.Add(this.tbBatchId);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblPackageId);
            this.groupBox1.Controls.Add(this.tbPackagingId);
            this.groupBox1.Controls.Add(this.lblPackageCode);
            this.groupBox1.Controls.Add(this.tbBatchCode);
            this.groupBox1.Controls.Add(this.lblPackageName);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(9, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(575, 293);
            this.groupBox1.TabIndex = 53;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Information";
            // 
            // tbCreatedAt
            // 
            this.tbCreatedAt.Location = new System.Drawing.Point(419, 233);
            this.tbCreatedAt.Name = "tbCreatedAt";
            this.tbCreatedAt.Size = new System.Drawing.Size(137, 34);
            this.tbCreatedAt.TabIndex = 50;
            // 
            // dtpExpiryDay
            // 
            this.dtpExpiryDay.Location = new System.Drawing.Point(147, 183);
            this.dtpExpiryDay.Name = "dtpExpiryDay";
            this.dtpExpiryDay.Size = new System.Drawing.Size(411, 34);
            this.dtpExpiryDay.TabIndex = 48;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(2, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 26);
            this.label3.TabIndex = 45;
            this.label3.Text = "Batch Id";
            // 
            // tbBatchId
            // 
            this.tbBatchId.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBatchId.Location = new System.Drawing.Point(147, 41);
            this.tbBatchId.Name = "tbBatchId";
            this.tbBatchId.ReadOnly = true;
            this.tbBatchId.Size = new System.Drawing.Size(411, 34);
            this.tbBatchId.TabIndex = 44;
            // 
            // lblPackageId
            // 
            this.lblPackageId.AutoSize = true;
            this.lblPackageId.Location = new System.Drawing.Point(1, 89);
            this.lblPackageId.Name = "lblPackageId";
            this.lblPackageId.Size = new System.Drawing.Size(133, 26);
            this.lblPackageId.TabIndex = 20;
            this.lblPackageId.Text = "Packaging Id";
            // 
            // tbPackagingId
            // 
            this.tbPackagingId.Location = new System.Drawing.Point(147, 89);
            this.tbPackagingId.Name = "tbPackagingId";
            this.tbPackagingId.ReadOnly = true;
            this.tbPackagingId.Size = new System.Drawing.Size(411, 34);
            this.tbPackagingId.TabIndex = 21;
            // 
            // lblPackageCode
            // 
            this.lblPackageCode.AutoSize = true;
            this.lblPackageCode.Location = new System.Drawing.Point(1, 139);
            this.lblPackageCode.Name = "lblPackageCode";
            this.lblPackageCode.Size = new System.Drawing.Size(119, 26);
            this.lblPackageCode.TabIndex = 22;
            this.lblPackageCode.Text = "Batch Code";
            // 
            // tbBatchCode
            // 
            this.tbBatchCode.Location = new System.Drawing.Point(147, 139);
            this.tbBatchCode.Name = "tbBatchCode";
            this.tbBatchCode.Size = new System.Drawing.Size(411, 34);
            this.tbBatchCode.TabIndex = 23;
            // 
            // lblPackageName
            // 
            this.lblPackageName.AutoSize = true;
            this.lblPackageName.Location = new System.Drawing.Point(1, 189);
            this.lblPackageName.Name = "lblPackageName";
            this.lblPackageName.Size = new System.Drawing.Size(116, 26);
            this.lblPackageName.TabIndex = 24;
            this.lblPackageName.Text = "Expiry Day";
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(902, 240);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(106, 46);
            this.btnDelete.TabIndex = 52;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(590, 240);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(106, 46);
            this.btnEdit.TabIndex = 51;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnReloadAll
            // 
            this.btnReloadAll.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReloadAll.Location = new System.Drawing.Point(715, 240);
            this.btnReloadAll.Name = "btnReloadAll";
            this.btnReloadAll.Size = new System.Drawing.Size(169, 46);
            this.btnReloadAll.TabIndex = 50;
            this.btnReloadAll.Text = "Reload All";
            this.btnReloadAll.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(604, 334);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(117, 19);
            this.label11.TabIndex = 59;
            this.label11.Text = "Sắp hết hạn nhất";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(876, 333);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(104, 19);
            this.label12.TabIndex = 60;
            this.label12.Text = "Sắp hết hạn ba";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(744, 334);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(110, 19);
            this.label13.TabIndex = 61;
            this.label13.Text = "Sắp hết hạn nhì";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Red;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox1.Location = new System.Drawing.Point(607, 303);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(25, 25);
            this.textBox1.TabIndex = 62;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.Yellow;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox2.Location = new System.Drawing.Point(880, 303);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(25, 25);
            this.textBox2.TabIndex = 63;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox3.Location = new System.Drawing.Point(748, 306);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(25, 25);
            this.textBox3.TabIndex = 64;
            // 
            // FormBatchManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(1582, 803);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnReloadAll);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvLoadBatch);
            this.Name = "FormBatchManagement";
            this.Text = "FormBatchManagement";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoadBatch)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudReceivedLoosePills)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantityPills)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudReceivedPacks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPurchasePrice)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLoadBatch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbMedicine;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblMedicine;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown nudReceivedLoosePills;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudReceivedPacks;
        private System.Windows.Forms.NumericUpDown nudPurchasePrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbBatchId;
        private System.Windows.Forms.Label lblPackageId;
        private System.Windows.Forms.TextBox tbPackagingId;
        private System.Windows.Forms.Label lblPackageCode;
        private System.Windows.Forms.TextBox tbBatchCode;
        private System.Windows.Forms.Label lblPackageName;
        private System.Windows.Forms.Label lblPillsPerPack;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnReloadAll;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown nudQuantityPills;
        private System.Windows.Forms.DateTimePicker dtpExpiryDay;
        private System.Windows.Forms.DateTimePicker dtpCreatedAt;
        private System.Windows.Forms.CheckBox cbUsePeriod;
        private System.Windows.Forms.TextBox tbCreatedAt;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
    }
}