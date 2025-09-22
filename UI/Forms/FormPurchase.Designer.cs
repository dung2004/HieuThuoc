namespace HieuThuoc.UI.Forms
{
    partial class FormPurchase
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
            this.dgvLoad = new System.Windows.Forms.DataGridView();
            this.tbPurchaseId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSavePurchase = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbSupplierName = new System.Windows.Forms.ComboBox();
            this.dtpExpiryDate = new System.Windows.Forms.DateTimePicker();
            this.tbPurchaseDetailId = new System.Windows.Forms.TextBox();
            this.tbSupplierId = new System.Windows.Forms.TextBox();
            this.tbSupplierName = new System.Windows.Forms.TextBox();
            this.tbPackagingId = new System.Windows.Forms.TextBox();
            this.tbPackagingName = new System.Windows.Forms.TextBox();
            this.tbMedicineName = new System.Windows.Forms.TextBox();
            this.tbBatchCode = new System.Windows.Forms.TextBox();
            this.cbPackagingName = new System.Windows.Forms.ComboBox();
            this.dtpPurchasDate = new System.Windows.Forms.DateTimePicker();
            this.nudReceivedPacks = new System.Windows.Forms.NumericUpDown();
            this.nudPillsPerPack = new System.Windows.Forms.NumericUpDown();
            this.nudReceivedLoosePills = new System.Windows.Forms.NumericUpDown();
            this.nudQuantityPills = new System.Windows.Forms.NumericUpDown();
            this.nudUnitPricePerPill = new System.Windows.Forms.NumericUpDown();
            this.nudTotalAmount = new System.Windows.Forms.NumericUpDown();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbPurchaseDate = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudReceivedPacks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPillsPerPack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudReceivedLoosePills)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantityPills)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudUnitPricePerPill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotalAmount)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvLoad
            // 
            this.dgvLoad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoad.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvLoad.Location = new System.Drawing.Point(0, 553);
            this.dgvLoad.Name = "dgvLoad";
            this.dgvLoad.RowHeadersWidth = 51;
            this.dgvLoad.RowTemplate.Height = 24;
            this.dgvLoad.Size = new System.Drawing.Size(1582, 250);
            this.dgvLoad.TabIndex = 46;
            this.dgvLoad.SelectionChanged += new System.EventHandler(this.DgvLoad_SelectionChanged);
            // 
            // tbPurchaseId
            // 
            this.tbPurchaseId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPurchaseId.Location = new System.Drawing.Point(206, 44);
            this.tbPurchaseId.Name = "tbPurchaseId";
            this.tbPurchaseId.ReadOnly = true;
            this.tbPurchaseId.Size = new System.Drawing.Size(245, 34);
            this.tbPurchaseId.TabIndex = 45;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 26);
            this.label3.TabIndex = 44;
            this.label3.Text = "Purchase Id";
            // 
            // btnSavePurchase
            // 
            this.btnSavePurchase.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSavePurchase.Location = new System.Drawing.Point(641, 221);
            this.btnSavePurchase.Name = "btnSavePurchase";
            this.btnSavePurchase.Size = new System.Drawing.Size(174, 45);
            this.btnSavePurchase.TabIndex = 48;
            this.btnSavePurchase.Text = "Save purchase";
            this.btnSavePurchase.UseVisualStyleBackColor = true;
            this.btnSavePurchase.Click += new System.EventHandler(this.btnSavePurchase_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(158, 448);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 44);
            this.label2.TabIndex = 49;
            this.label2.Text = "Purchase";
            // 
            // cbSupplierName
            // 
            this.cbSupplierName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbSupplierName.FormattingEnabled = true;
            this.cbSupplierName.Location = new System.Drawing.Point(610, 30);
            this.cbSupplierName.Name = "cbSupplierName";
            this.cbSupplierName.Size = new System.Drawing.Size(330, 34);
            this.cbSupplierName.TabIndex = 50;
            // 
            // dtpExpiryDate
            // 
            this.dtpExpiryDate.Location = new System.Drawing.Point(235, 189);
            this.dtpExpiryDate.Name = "dtpExpiryDate";
            this.dtpExpiryDate.Size = new System.Drawing.Size(369, 34);
            this.dtpExpiryDate.TabIndex = 51;
            // 
            // tbPurchaseDetailId
            // 
            this.tbPurchaseDetailId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPurchaseDetailId.Location = new System.Drawing.Point(206, 93);
            this.tbPurchaseDetailId.Name = "tbPurchaseDetailId";
            this.tbPurchaseDetailId.ReadOnly = true;
            this.tbPurchaseDetailId.Size = new System.Drawing.Size(245, 34);
            this.tbPurchaseDetailId.TabIndex = 53;
            // 
            // tbSupplierId
            // 
            this.tbSupplierId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSupplierId.Location = new System.Drawing.Point(206, 142);
            this.tbSupplierId.Name = "tbSupplierId";
            this.tbSupplierId.ReadOnly = true;
            this.tbSupplierId.Size = new System.Drawing.Size(245, 34);
            this.tbSupplierId.TabIndex = 54;
            // 
            // tbSupplierName
            // 
            this.tbSupplierName.Location = new System.Drawing.Point(235, 30);
            this.tbSupplierName.Name = "tbSupplierName";
            this.tbSupplierName.Size = new System.Drawing.Size(369, 34);
            this.tbSupplierName.TabIndex = 55;
            // 
            // tbPackagingId
            // 
            this.tbPackagingId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPackagingId.Location = new System.Drawing.Point(206, 191);
            this.tbPackagingId.Name = "tbPackagingId";
            this.tbPackagingId.ReadOnly = true;
            this.tbPackagingId.Size = new System.Drawing.Size(245, 34);
            this.tbPackagingId.TabIndex = 56;
            // 
            // tbPackagingName
            // 
            this.tbPackagingName.Location = new System.Drawing.Point(235, 83);
            this.tbPackagingName.Name = "tbPackagingName";
            this.tbPackagingName.Size = new System.Drawing.Size(369, 34);
            this.tbPackagingName.TabIndex = 57;
            // 
            // tbMedicineName
            // 
            this.tbMedicineName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbMedicineName.Location = new System.Drawing.Point(206, 240);
            this.tbMedicineName.Name = "tbMedicineName";
            this.tbMedicineName.ReadOnly = true;
            this.tbMedicineName.Size = new System.Drawing.Size(245, 34);
            this.tbMedicineName.TabIndex = 58;
            // 
            // tbBatchCode
            // 
            this.tbBatchCode.Location = new System.Drawing.Point(235, 136);
            this.tbBatchCode.Name = "tbBatchCode";
            this.tbBatchCode.Size = new System.Drawing.Size(369, 34);
            this.tbBatchCode.TabIndex = 59;
            // 
            // cbPackagingName
            // 
            this.cbPackagingName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbPackagingName.FormattingEnabled = true;
            this.cbPackagingName.Location = new System.Drawing.Point(610, 83);
            this.cbPackagingName.Name = "cbPackagingName";
            this.cbPackagingName.Size = new System.Drawing.Size(330, 34);
            this.cbPackagingName.TabIndex = 60;
            // 
            // dtpPurchasDate
            // 
            this.dtpPurchasDate.Location = new System.Drawing.Point(235, 454);
            this.dtpPurchasDate.Name = "dtpPurchasDate";
            this.dtpPurchasDate.Size = new System.Drawing.Size(369, 34);
            this.dtpPurchasDate.TabIndex = 61;
            // 
            // nudReceivedPacks
            // 
            this.nudReceivedPacks.Location = new System.Drawing.Point(235, 242);
            this.nudReceivedPacks.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nudReceivedPacks.Name = "nudReceivedPacks";
            this.nudReceivedPacks.Size = new System.Drawing.Size(266, 34);
            this.nudReceivedPacks.TabIndex = 62;
            // 
            // nudPillsPerPack
            // 
            this.nudPillsPerPack.Location = new System.Drawing.Point(235, 295);
            this.nudPillsPerPack.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nudPillsPerPack.Name = "nudPillsPerPack";
            this.nudPillsPerPack.Size = new System.Drawing.Size(266, 34);
            this.nudPillsPerPack.TabIndex = 63;
            // 
            // nudReceivedLoosePills
            // 
            this.nudReceivedLoosePills.Location = new System.Drawing.Point(235, 348);
            this.nudReceivedLoosePills.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nudReceivedLoosePills.Name = "nudReceivedLoosePills";
            this.nudReceivedLoosePills.Size = new System.Drawing.Size(266, 34);
            this.nudReceivedLoosePills.TabIndex = 64;
            // 
            // nudQuantityPills
            // 
            this.nudQuantityPills.Location = new System.Drawing.Point(206, 338);
            this.nudQuantityPills.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nudQuantityPills.Name = "nudQuantityPills";
            this.nudQuantityPills.ReadOnly = true;
            this.nudQuantityPills.Size = new System.Drawing.Size(245, 34);
            this.nudQuantityPills.TabIndex = 65;
            // 
            // nudUnitPricePerPill
            // 
            this.nudUnitPricePerPill.Location = new System.Drawing.Point(235, 401);
            this.nudUnitPricePerPill.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nudUnitPricePerPill.Name = "nudUnitPricePerPill";
            this.nudUnitPricePerPill.Size = new System.Drawing.Size(266, 34);
            this.nudUnitPricePerPill.TabIndex = 66;
            // 
            // nudTotalAmount
            // 
            this.nudTotalAmount.Location = new System.Drawing.Point(206, 289);
            this.nudTotalAmount.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nudTotalAmount.Name = "nudTotalAmount";
            this.nudTotalAmount.ReadOnly = true;
            this.nudTotalAmount.Size = new System.Drawing.Size(245, 34);
            this.nudTotalAmount.TabIndex = 67;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(641, 276);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(174, 45);
            this.btnCancel.TabIndex = 68;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
            // 
            // btnLoad
            // 
            this.btnLoad.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.Location = new System.Drawing.Point(641, 331);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(174, 45);
            this.btnLoad.TabIndex = 69;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(641, 386);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(174, 45);
            this.btnEdit.TabIndex = 70;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 26);
            this.label1.TabIndex = 71;
            this.label1.Text = "Supplier Id";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 26);
            this.label4.TabIndex = 72;
            this.label4.Text = "Packaging Id";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 246);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(157, 26);
            this.label5.TabIndex = 73;
            this.label5.Text = "Medicine Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 189);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 26);
            this.label6.TabIndex = 74;
            this.label6.Text = "Expiry Date";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 295);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(140, 26);
            this.label7.TabIndex = 75;
            this.label7.Text = "Pills Per Pack";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 340);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(138, 26);
            this.label8.TabIndex = 76;
            this.label8.Text = "Quantity Pills";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 290);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(139, 26);
            this.label9.TabIndex = 77;
            this.label9.Text = "Total Amount";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 94);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(182, 26);
            this.label10.TabIndex = 78;
            this.label10.Text = "Purchase Detail Id";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 30);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(151, 26);
            this.label11.TabIndex = 79;
            this.label11.Text = "Supplier Name";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 83);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(167, 26);
            this.label12.TabIndex = 80;
            this.label12.Text = "Packaging Name";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 136);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(119, 26);
            this.label13.TabIndex = 81;
            this.label13.Text = "Batch Code";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 242);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(157, 26);
            this.label14.TabIndex = 82;
            this.label14.Text = "Received Packs";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(7, 348);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(205, 26);
            this.label15.TabIndex = 83;
            this.label15.Text = "Received Loose Pills";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(7, 401);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(178, 26);
            this.label16.TabIndex = 84;
            this.label16.Text = "Unit Price Per Pill";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(7, 454);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(144, 26);
            this.label17.TabIndex = 85;
            this.label17.Text = "Purchase Date";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Plum;
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbPurchaseId);
            this.groupBox1.Controls.Add(this.tbPurchaseDetailId);
            this.groupBox1.Controls.Add(this.tbSupplierId);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tbPackagingId);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.tbMedicineName);
            this.groupBox1.Controls.Add(this.nudQuantityPills);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.nudTotalAmount);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(471, 389);
            this.groupBox1.TabIndex = 86;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Read only Information";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Plum;
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.tbPurchaseDate);
            this.groupBox2.Controls.Add(this.nudPillsPerPack);
            this.groupBox2.Controls.Add(this.cbSupplierName);
            this.groupBox2.Controls.Add(this.btnEdit);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.btnLoad);
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.dtpExpiryDate);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.btnSavePurchase);
            this.groupBox2.Controls.Add(this.tbSupplierName);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.tbPackagingName);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.tbBatchCode);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.cbPackagingName);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.dtpPurchasDate);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.nudReceivedPacks);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.nudReceivedLoosePills);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.nudUnitPricePerPill);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(504, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(962, 520);
            this.groupBox2.TabIndex = 87;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Information";
            // 
            // tbPurchaseDate
            // 
            this.tbPurchaseDate.Location = new System.Drawing.Point(621, 454);
            this.tbPurchaseDate.Name = "tbPurchaseDate";
            this.tbPurchaseDate.Size = new System.Drawing.Size(194, 34);
            this.tbPurchaseDate.TabIndex = 86;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(621, 491);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(149, 19);
            this.label18.TabIndex = 87;
            this.label18.Text = "*Format (\"xx:yy:zz\")";
            // 
            // FormPurchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1582, 803);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvLoad);
            this.Name = "FormPurchase";
            this.Text = "FormPurchase";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudReceivedPacks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPillsPerPack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudReceivedLoosePills)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantityPills)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudUnitPricePerPill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotalAmount)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLoad;
        private System.Windows.Forms.TextBox tbPurchaseId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSavePurchase;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbSupplierName;
        private System.Windows.Forms.DateTimePicker dtpExpiryDate;
        private System.Windows.Forms.TextBox tbPurchaseDetailId;
        private System.Windows.Forms.TextBox tbSupplierId;
        private System.Windows.Forms.TextBox tbSupplierName;
        private System.Windows.Forms.TextBox tbPackagingId;
        private System.Windows.Forms.TextBox tbPackagingName;
        private System.Windows.Forms.TextBox tbMedicineName;
        private System.Windows.Forms.TextBox tbBatchCode;
        private System.Windows.Forms.ComboBox cbPackagingName;
        private System.Windows.Forms.DateTimePicker dtpPurchasDate;
        private System.Windows.Forms.NumericUpDown nudReceivedPacks;
        private System.Windows.Forms.NumericUpDown nudPillsPerPack;
        private System.Windows.Forms.NumericUpDown nudReceivedLoosePills;
        private System.Windows.Forms.NumericUpDown nudQuantityPills;
        private System.Windows.Forms.NumericUpDown nudUnitPricePerPill;
        private System.Windows.Forms.NumericUpDown nudTotalAmount;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbPurchaseDate;
        private System.Windows.Forms.Label label18;
    }
}