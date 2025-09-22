namespace HieuThuoc.UI.Forms
{
    partial class FormSale
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSale));
            this.dgvLoadSale = new System.Windows.Forms.DataGridView();
            this.tbSaleId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddToCart = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSaleDetailId = new System.Windows.Forms.TextBox();
            this.tbMedicineId = new System.Windows.Forms.TextBox();
            this.tbMedicineName = new System.Windows.Forms.TextBox();
            this.tbMedicineCode = new System.Windows.Forms.TextBox();
            this.tbCustomerName = new System.Windows.Forms.TextBox();
            this.tbPackagingId = new System.Windows.Forms.TextBox();
            this.tbPackagingName = new System.Windows.Forms.TextBox();
            this.tbBatchId = new System.Windows.Forms.TextBox();
            this.tbSaleDate = new System.Windows.Forms.TextBox();
            this.tbSaleBy = new System.Windows.Forms.TextBox();
            this.nudTotalQuantityPills = new System.Windows.Forms.NumericUpDown();
            this.nudQuantityPacks = new System.Windows.Forms.NumericUpDown();
            this.nudQuantityPills = new System.Windows.Forms.NumericUpDown();
            this.nudPillsPerPack = new System.Windows.Forms.NumericUpDown();
            this.nudTotalPills = new System.Windows.Forms.NumericUpDown();
            this.nudPricePerPill = new System.Windows.Forms.NumericUpDown();
            this.nudTotalAmount = new System.Windows.Forms.NumericUpDown();
            this.btnSale = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtpSaleDate = new System.Windows.Forms.DateTimePicker();
            this.btnDeleteCart = new System.Windows.Forms.Button();
            this.cbMedicineName = new System.Windows.Forms.ComboBox();
            this.cbMedicineCode = new System.Windows.Forms.ComboBox();
            this.cbPackagingName = new System.Windows.Forms.ComboBox();
            this.cbBatchId = new System.Windows.Forms.ComboBox();
            this.dgvCartSale = new System.Windows.Forms.DataGridView();
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
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label21 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoadSale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotalQuantityPills)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantityPacks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantityPills)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPillsPerPack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotalPills)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPricePerPill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotalAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCartSale)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvLoadSale
            // 
            this.dgvLoadSale.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoadSale.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvLoadSale.Location = new System.Drawing.Point(0, 553);
            this.dgvLoadSale.Name = "dgvLoadSale";
            this.dgvLoadSale.RowHeadersWidth = 51;
            this.dgvLoadSale.RowTemplate.Height = 24;
            this.dgvLoadSale.Size = new System.Drawing.Size(1582, 250);
            this.dgvLoadSale.TabIndex = 46;
            this.dgvLoadSale.SelectionChanged += new System.EventHandler(this.dgvLoadSale_SelectionChanged);
            // 
            // tbSaleId
            // 
            this.tbSaleId.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbSaleId.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSaleId.Location = new System.Drawing.Point(211, 33);
            this.tbSaleId.Name = "tbSaleId";
            this.tbSaleId.ReadOnly = true;
            this.tbSaleId.Size = new System.Drawing.Size(169, 20);
            this.tbSaleId.TabIndex = 45;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(120, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 26);
            this.label3.TabIndex = 44;
            this.label3.Text = "Sale Id";
            // 
            // btnAddToCart
            // 
            this.btnAddToCart.FlatAppearance.BorderSize = 3;
            this.btnAddToCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddToCart.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddToCart.Location = new System.Drawing.Point(312, 475);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.Size = new System.Drawing.Size(157, 55);
            this.btnAddToCart.TabIndex = 47;
            this.btnAddToCart.Text = "Add to Cart";
            this.btnAddToCart.UseVisualStyleBackColor = true;
            this.btnAddToCart.Click += new System.EventHandler(this.btnAddToCart_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Times New Roman", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 389);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(246, 141);
            this.label2.TabIndex = 48;
            this.label2.Text = "Sale System";
            // 
            // tbSaleDetailId
            // 
            this.tbSaleDetailId.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbSaleDetailId.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSaleDetailId.Location = new System.Drawing.Point(211, 63);
            this.tbSaleDetailId.Name = "tbSaleDetailId";
            this.tbSaleDetailId.ReadOnly = true;
            this.tbSaleDetailId.Size = new System.Drawing.Size(169, 20);
            this.tbSaleDetailId.TabIndex = 49;
            // 
            // tbMedicineId
            // 
            this.tbMedicineId.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbMedicineId.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMedicineId.Location = new System.Drawing.Point(211, 93);
            this.tbMedicineId.Name = "tbMedicineId";
            this.tbMedicineId.ReadOnly = true;
            this.tbMedicineId.Size = new System.Drawing.Size(169, 20);
            this.tbMedicineId.TabIndex = 50;
            // 
            // tbMedicineName
            // 
            this.tbMedicineName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbMedicineName.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMedicineName.Location = new System.Drawing.Point(195, 39);
            this.tbMedicineName.Name = "tbMedicineName";
            this.tbMedicineName.Size = new System.Drawing.Size(242, 28);
            this.tbMedicineName.TabIndex = 51;
            // 
            // tbMedicineCode
            // 
            this.tbMedicineCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbMedicineCode.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMedicineCode.Location = new System.Drawing.Point(195, 75);
            this.tbMedicineCode.Name = "tbMedicineCode";
            this.tbMedicineCode.Size = new System.Drawing.Size(242, 28);
            this.tbMedicineCode.TabIndex = 52;
            // 
            // tbCustomerName
            // 
            this.tbCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCustomerName.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCustomerName.Location = new System.Drawing.Point(195, 114);
            this.tbCustomerName.Name = "tbCustomerName";
            this.tbCustomerName.Size = new System.Drawing.Size(242, 28);
            this.tbCustomerName.TabIndex = 53;
            // 
            // tbPackagingId
            // 
            this.tbPackagingId.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbPackagingId.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPackagingId.Location = new System.Drawing.Point(211, 123);
            this.tbPackagingId.Name = "tbPackagingId";
            this.tbPackagingId.ReadOnly = true;
            this.tbPackagingId.Size = new System.Drawing.Size(169, 20);
            this.tbPackagingId.TabIndex = 54;
            // 
            // tbPackagingName
            // 
            this.tbPackagingName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPackagingName.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPackagingName.Location = new System.Drawing.Point(195, 158);
            this.tbPackagingName.Name = "tbPackagingName";
            this.tbPackagingName.Size = new System.Drawing.Size(242, 28);
            this.tbPackagingName.TabIndex = 55;
            // 
            // tbBatchId
            // 
            this.tbBatchId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbBatchId.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBatchId.Location = new System.Drawing.Point(195, 192);
            this.tbBatchId.Name = "tbBatchId";
            this.tbBatchId.Size = new System.Drawing.Size(242, 28);
            this.tbBatchId.TabIndex = 56;
            // 
            // tbSaleDate
            // 
            this.tbSaleDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSaleDate.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSaleDate.Location = new System.Drawing.Point(443, 309);
            this.tbSaleDate.Name = "tbSaleDate";
            this.tbSaleDate.Size = new System.Drawing.Size(223, 28);
            this.tbSaleDate.TabIndex = 57;
            // 
            // tbSaleBy
            // 
            this.tbSaleBy.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbSaleBy.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSaleBy.Location = new System.Drawing.Point(211, 310);
            this.tbSaleBy.Name = "tbSaleBy";
            this.tbSaleBy.ReadOnly = true;
            this.tbSaleBy.Size = new System.Drawing.Size(169, 20);
            this.tbSaleBy.TabIndex = 58;
            // 
            // nudTotalQuantityPills
            // 
            this.nudTotalQuantityPills.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nudTotalQuantityPills.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudTotalQuantityPills.Location = new System.Drawing.Point(211, 154);
            this.nudTotalQuantityPills.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nudTotalQuantityPills.Name = "nudTotalQuantityPills";
            this.nudTotalQuantityPills.ReadOnly = true;
            this.nudTotalQuantityPills.Size = new System.Drawing.Size(169, 23);
            this.nudTotalQuantityPills.TabIndex = 59;
            // 
            // nudQuantityPacks
            // 
            this.nudQuantityPacks.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudQuantityPacks.Location = new System.Drawing.Point(195, 232);
            this.nudQuantityPacks.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nudQuantityPacks.Name = "nudQuantityPacks";
            this.nudQuantityPacks.Size = new System.Drawing.Size(242, 28);
            this.nudQuantityPacks.TabIndex = 60;
            // 
            // nudQuantityPills
            // 
            this.nudQuantityPills.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudQuantityPills.Location = new System.Drawing.Point(195, 268);
            this.nudQuantityPills.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nudQuantityPills.Name = "nudQuantityPills";
            this.nudQuantityPills.Size = new System.Drawing.Size(242, 28);
            this.nudQuantityPills.TabIndex = 61;
            // 
            // nudPillsPerPack
            // 
            this.nudPillsPerPack.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nudPillsPerPack.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudPillsPerPack.Location = new System.Drawing.Point(211, 184);
            this.nudPillsPerPack.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nudPillsPerPack.Name = "nudPillsPerPack";
            this.nudPillsPerPack.ReadOnly = true;
            this.nudPillsPerPack.Size = new System.Drawing.Size(169, 23);
            this.nudPillsPerPack.TabIndex = 62;
            // 
            // nudTotalPills
            // 
            this.nudTotalPills.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nudTotalPills.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudTotalPills.Location = new System.Drawing.Point(211, 214);
            this.nudTotalPills.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nudTotalPills.Name = "nudTotalPills";
            this.nudTotalPills.ReadOnly = true;
            this.nudTotalPills.Size = new System.Drawing.Size(169, 23);
            this.nudTotalPills.TabIndex = 63;
            // 
            // nudPricePerPill
            // 
            this.nudPricePerPill.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nudPricePerPill.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudPricePerPill.Location = new System.Drawing.Point(211, 244);
            this.nudPricePerPill.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nudPricePerPill.Name = "nudPricePerPill";
            this.nudPricePerPill.ReadOnly = true;
            this.nudPricePerPill.Size = new System.Drawing.Size(169, 23);
            this.nudPricePerPill.TabIndex = 64;
            // 
            // nudTotalAmount
            // 
            this.nudTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nudTotalAmount.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudTotalAmount.Location = new System.Drawing.Point(211, 274);
            this.nudTotalAmount.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nudTotalAmount.Name = "nudTotalAmount";
            this.nudTotalAmount.ReadOnly = true;
            this.nudTotalAmount.Size = new System.Drawing.Size(169, 23);
            this.nudTotalAmount.TabIndex = 65;
            // 
            // btnSale
            // 
            this.btnSale.FlatAppearance.BorderSize = 3;
            this.btnSale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSale.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSale.Location = new System.Drawing.Point(485, 475);
            this.btnSale.Name = "btnSale";
            this.btnSale.Size = new System.Drawing.Size(157, 55);
            this.btnSale.TabIndex = 66;
            this.btnSale.Text = "Sale";
            this.btnSale.UseVisualStyleBackColor = true;
            this.btnSale.Click += new System.EventHandler(this.btnSale_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderSize = 3;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(312, 402);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(157, 55);
            this.btnCancel.TabIndex = 67;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.FlatAppearance.BorderSize = 3;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(1250, 125);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(157, 55);
            this.btnSearch.TabIndex = 68;
            this.btnSearch.Text = "Sarch";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtpSaleDate
            // 
            this.dtpSaleDate.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpSaleDate.Location = new System.Drawing.Point(195, 309);
            this.dtpSaleDate.Name = "dtpSaleDate";
            this.dtpSaleDate.Size = new System.Drawing.Size(242, 28);
            this.dtpSaleDate.TabIndex = 69;
            // 
            // btnDeleteCart
            // 
            this.btnDeleteCart.FlatAppearance.BorderSize = 3;
            this.btnDeleteCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteCart.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteCart.Location = new System.Drawing.Point(485, 402);
            this.btnDeleteCart.Name = "btnDeleteCart";
            this.btnDeleteCart.Size = new System.Drawing.Size(157, 55);
            this.btnDeleteCart.TabIndex = 70;
            this.btnDeleteCart.Text = "Delete Cart";
            this.btnDeleteCart.UseVisualStyleBackColor = true;
            this.btnDeleteCart.Click += new System.EventHandler(this.btnDeleteCart_Click);
            // 
            // cbMedicineName
            // 
            this.cbMedicineName.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMedicineName.FormattingEnabled = true;
            this.cbMedicineName.Location = new System.Drawing.Point(443, 39);
            this.cbMedicineName.Name = "cbMedicineName";
            this.cbMedicineName.Size = new System.Drawing.Size(223, 28);
            this.cbMedicineName.TabIndex = 71;
            this.cbMedicineName.SelectedIndexChanged += new System.EventHandler(this.cbMedicineName_SelectedIndexChanged);
            // 
            // cbMedicineCode
            // 
            this.cbMedicineCode.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMedicineCode.FormattingEnabled = true;
            this.cbMedicineCode.Location = new System.Drawing.Point(443, 74);
            this.cbMedicineCode.Name = "cbMedicineCode";
            this.cbMedicineCode.Size = new System.Drawing.Size(223, 28);
            this.cbMedicineCode.TabIndex = 72;
            this.cbMedicineCode.SelectedIndexChanged += new System.EventHandler(this.cbMedicineCode_SelectedIndexChanged);
            // 
            // cbPackagingName
            // 
            this.cbPackagingName.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPackagingName.FormattingEnabled = true;
            this.cbPackagingName.Location = new System.Drawing.Point(443, 158);
            this.cbPackagingName.Name = "cbPackagingName";
            this.cbPackagingName.Size = new System.Drawing.Size(223, 28);
            this.cbPackagingName.TabIndex = 73;
            this.cbPackagingName.SelectedIndexChanged += new System.EventHandler(this.cbPackagingName_SelectedIndexChanged);
            // 
            // cbBatchId
            // 
            this.cbBatchId.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBatchId.FormattingEnabled = true;
            this.cbBatchId.Location = new System.Drawing.Point(443, 192);
            this.cbBatchId.Name = "cbBatchId";
            this.cbBatchId.Size = new System.Drawing.Size(223, 28);
            this.cbBatchId.TabIndex = 74;
            this.cbBatchId.SelectedIndexChanged += new System.EventHandler(this.cbBatchId_SelectedIndexChanged);
            // 
            // dgvCartSale
            // 
            this.dgvCartSale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCartSale.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCartSale.Location = new System.Drawing.Point(664, 389);
            this.dgvCartSale.Name = "dgvCartSale";
            this.dgvCartSale.RowHeadersWidth = 51;
            this.dgvCartSale.RowTemplate.Height = 24;
            this.dgvCartSale.Size = new System.Drawing.Size(918, 163);
            this.dgvCartSale.TabIndex = 75;
            this.dgvCartSale.SelectionChanged += new System.EventHandler(this.dgvCartSale_SelectionChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1102, 201);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(380, 179);
            this.label1.TabIndex = 76;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(74, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 26);
            this.label4.TabIndex = 77;
            this.label4.Text = "Medicine Id";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Green;
            this.label5.Location = new System.Drawing.Point(9, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(163, 25);
            this.label5.TabIndex = 78;
            this.label5.Text = "Medicine Code";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(64, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 26);
            this.label6.TabIndex = 79;
            this.label6.Text = "Packaging Id";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Green;
            this.label7.Location = new System.Drawing.Point(9, 195);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 25);
            this.label7.TabIndex = 80;
            this.label7.Text = "Batch Id";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Green;
            this.label8.Location = new System.Drawing.Point(9, 234);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(165, 25);
            this.label8.TabIndex = 81;
            this.label8.Text = "Quantity Packs";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Blue;
            this.label9.Location = new System.Drawing.Point(57, 183);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(140, 26);
            this.label9.TabIndex = 82;
            this.label9.Text = "Pills Per Pack";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Blue;
            this.label10.Location = new System.Drawing.Point(72, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(125, 26);
            this.label10.TabIndex = 83;
            this.label10.Text = "SaleDetailId";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Green;
            this.label11.Location = new System.Drawing.Point(9, 39);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(169, 25);
            this.label11.TabIndex = 84;
            this.label11.Text = "Medicine Name";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Green;
            this.label12.Location = new System.Drawing.Point(9, 117);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(176, 25);
            this.label12.TabIndex = 85;
            this.label12.Text = "Customer Name";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Green;
            this.label13.Location = new System.Drawing.Point(9, 156);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(162, 25);
            this.label13.TabIndex = 86;
            this.label13.Text = "Package Name";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Blue;
            this.label14.Location = new System.Drawing.Point(7, 152);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(190, 26);
            this.label14.TabIndex = 87;
            this.label14.Text = "Total Quantity Pills";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Green;
            this.label15.Location = new System.Drawing.Point(9, 273);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(145, 25);
            this.label15.TabIndex = 88;
            this.label15.Text = "Quantity Pills";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Blue;
            this.label16.Location = new System.Drawing.Point(94, 212);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(103, 26);
            this.label16.TabIndex = 89;
            this.label16.Text = "Total pills";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Blue;
            this.label17.Location = new System.Drawing.Point(64, 243);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(133, 26);
            this.label17.TabIndex = 90;
            this.label17.Text = "Price Per Pill";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Blue;
            this.label18.Location = new System.Drawing.Point(58, 274);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(139, 26);
            this.label18.TabIndex = 91;
            this.label18.Text = "Total Amount";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.Color.Green;
            this.label19.Location = new System.Drawing.Point(9, 312);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(107, 25);
            this.label19.TabIndex = 92;
            this.label19.Text = "Sale Date";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Blue;
            this.label20.Location = new System.Drawing.Point(115, 306);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(82, 26);
            this.label20.TabIndex = 93;
            this.label20.Text = "Sale By";
            // 
            // tbSearch
            // 
            this.tbSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSearch.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearch.Location = new System.Drawing.Point(1106, 39);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(464, 30);
            this.tbSearch.TabIndex = 98;
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(1106, 72);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(393, 40);
            this.label25.TabIndex = 99;
            this.label25.Text = "*Search by MedicineName or MedicineCode or CustomerName or PackagingName or SaleB" +
    "y.";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.groupBox1.Controls.Add(this.nudTotalAmount);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbSaleId);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.tbSaleDetailId);
            this.groupBox1.Controls.Add(this.tbMedicineId);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.tbPackagingId);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.tbSaleBy);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.nudTotalQuantityPills);
            this.groupBox1.Controls.Add(this.nudPillsPerPack);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.nudTotalPills);
            this.groupBox1.Controls.Add(this.nudPricePerPill);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.IndianRed;
            this.groupBox1.Location = new System.Drawing.Point(5, 8);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(398, 357);
            this.groupBox1.TabIndex = 100;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Read Only Information";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.groupBox2.Controls.Add(this.cbMedicineCode);
            this.groupBox2.Controls.Add(this.tbMedicineCode);
            this.groupBox2.Controls.Add(this.tbCustomerName);
            this.groupBox2.Controls.Add(this.tbPackagingName);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.tbBatchId);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.cbMedicineName);
            this.groupBox2.Controls.Add(this.tbSaleDate);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.nudQuantityPacks);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.nudQuantityPills);
            this.groupBox2.Controls.Add(this.tbMedicineName);
            this.groupBox2.Controls.Add(this.dtpSaleDate);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.cbPackagingName);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cbBatchId);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.IndianRed;
            this.groupBox2.Location = new System.Drawing.Point(413, 9);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(672, 356);
            this.groupBox2.TabIndex = 101;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Editable Information";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(1104, 12);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(71, 25);
            this.label21.TabIndex = 102;
            this.label21.Text = "Searh";
            // 
            // FormSale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1582, 803);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvCartSale);
            this.Controls.Add(this.btnDeleteCart);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSale);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAddToCart);
            this.Controls.Add(this.dgvLoadSale);
            this.Name = "FormSale";
            this.Text = "FormSale";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoadSale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotalQuantityPills)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantityPacks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantityPills)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPillsPerPack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotalPills)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPricePerPill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotalAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCartSale)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLoadSale;
        private System.Windows.Forms.TextBox tbSaleId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddToCart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbSaleDetailId;
        private System.Windows.Forms.TextBox tbMedicineId;
        private System.Windows.Forms.TextBox tbMedicineName;
        private System.Windows.Forms.TextBox tbMedicineCode;
        private System.Windows.Forms.TextBox tbCustomerName;
        private System.Windows.Forms.TextBox tbPackagingId;
        private System.Windows.Forms.TextBox tbPackagingName;
        private System.Windows.Forms.TextBox tbBatchId;
        private System.Windows.Forms.TextBox tbSaleDate;
        private System.Windows.Forms.TextBox tbSaleBy;
        private System.Windows.Forms.NumericUpDown nudTotalQuantityPills;
        private System.Windows.Forms.NumericUpDown nudQuantityPacks;
        private System.Windows.Forms.NumericUpDown nudQuantityPills;
        private System.Windows.Forms.NumericUpDown nudPillsPerPack;
        private System.Windows.Forms.NumericUpDown nudTotalPills;
        private System.Windows.Forms.NumericUpDown nudPricePerPill;
        private System.Windows.Forms.NumericUpDown nudTotalAmount;
        private System.Windows.Forms.Button btnSale;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtpSaleDate;
        private System.Windows.Forms.Button btnDeleteCart;
        private System.Windows.Forms.ComboBox cbMedicineName;
        private System.Windows.Forms.ComboBox cbMedicineCode;
        private System.Windows.Forms.ComboBox cbPackagingName;
        private System.Windows.Forms.ComboBox cbBatchId;
        private System.Windows.Forms.DataGridView dgvCartSale;
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
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label21;
    }
}