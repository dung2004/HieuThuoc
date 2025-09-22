namespace HieuThuoc.UI.Forms
{
    partial class FormPackagingManagement
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblSearch = new System.Windows.Forms.Label();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.tbPillsPerPack = new System.Windows.Forms.TextBox();
            this.lblPillsPerPack = new System.Windows.Forms.Label();
            this.tbNamePackage = new System.Windows.Forms.TextBox();
            this.lblPackageName = new System.Windows.Forms.Label();
            this.tbPackageCode = new System.Windows.Forms.TextBox();
            this.lblPackageCode = new System.Windows.Forms.Label();
            this.tbPackageId = new System.Windows.Forms.TextBox();
            this.lblPackageId = new System.Windows.Forms.Label();
            this.dgvLoadPackage = new System.Windows.Forms.DataGridView();
            this.lblMedicine = new System.Windows.Forms.Label();
            this.cbMedicine = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbMedicineId = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nudPricePerPack = new System.Windows.Forms.NumericUpDown();
            this.nudPricePerPill = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoadPackage)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPricePerPack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPricePerPill)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(810, 259);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(106, 46);
            this.btnDelete.TabIndex = 37;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(677, 259);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(106, 46);
            this.btnEdit.TabIndex = 36;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(551, 259);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(106, 46);
            this.btnAdd.TabIndex = 35;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(387, 61);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(98, 39);
            this.btnSearch.TabIndex = 34;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
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
            // tbSearch
            // 
            this.tbSearch.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearch.Location = new System.Drawing.Point(28, 68);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(353, 27);
            this.tbSearch.TabIndex = 32;
            // 
            // tbPillsPerPack
            // 
            this.tbPillsPerPack.Location = new System.Drawing.Point(168, 239);
            this.tbPillsPerPack.Name = "tbPillsPerPack";
            this.tbPillsPerPack.Size = new System.Drawing.Size(276, 34);
            this.tbPillsPerPack.TabIndex = 27;
            // 
            // lblPillsPerPack
            // 
            this.lblPillsPerPack.AutoSize = true;
            this.lblPillsPerPack.Location = new System.Drawing.Point(1, 239);
            this.lblPillsPerPack.Name = "lblPillsPerPack";
            this.lblPillsPerPack.Size = new System.Drawing.Size(140, 26);
            this.lblPillsPerPack.TabIndex = 26;
            this.lblPillsPerPack.Text = "Pills Per Pack";
            // 
            // tbNamePackage
            // 
            this.tbNamePackage.Location = new System.Drawing.Point(168, 189);
            this.tbNamePackage.Name = "tbNamePackage";
            this.tbNamePackage.Size = new System.Drawing.Size(276, 34);
            this.tbNamePackage.TabIndex = 25;
            // 
            // lblPackageName
            // 
            this.lblPackageName.AutoSize = true;
            this.lblPackageName.Location = new System.Drawing.Point(1, 189);
            this.lblPackageName.Name = "lblPackageName";
            this.lblPackageName.Size = new System.Drawing.Size(148, 26);
            this.lblPackageName.TabIndex = 24;
            this.lblPackageName.Text = "Package Name";
            // 
            // tbPackageCode
            // 
            this.tbPackageCode.Location = new System.Drawing.Point(168, 139);
            this.tbPackageCode.Name = "tbPackageCode";
            this.tbPackageCode.Size = new System.Drawing.Size(276, 34);
            this.tbPackageCode.TabIndex = 23;
            // 
            // lblPackageCode
            // 
            this.lblPackageCode.AutoSize = true;
            this.lblPackageCode.Location = new System.Drawing.Point(1, 139);
            this.lblPackageCode.Name = "lblPackageCode";
            this.lblPackageCode.Size = new System.Drawing.Size(143, 26);
            this.lblPackageCode.TabIndex = 22;
            this.lblPackageCode.Text = "Package Code";
            // 
            // tbPackageId
            // 
            this.tbPackageId.Location = new System.Drawing.Point(168, 89);
            this.tbPackageId.Name = "tbPackageId";
            this.tbPackageId.ReadOnly = true;
            this.tbPackageId.Size = new System.Drawing.Size(276, 34);
            this.tbPackageId.TabIndex = 21;
            // 
            // lblPackageId
            // 
            this.lblPackageId.AutoSize = true;
            this.lblPackageId.Location = new System.Drawing.Point(1, 89);
            this.lblPackageId.Name = "lblPackageId";
            this.lblPackageId.Size = new System.Drawing.Size(114, 26);
            this.lblPackageId.TabIndex = 20;
            this.lblPackageId.Text = "Package Id";
            // 
            // dgvLoadPackage
            // 
            this.dgvLoadPackage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoadPackage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvLoadPackage.Location = new System.Drawing.Point(0, 373);
            this.dgvLoadPackage.Name = "dgvLoadPackage";
            this.dgvLoadPackage.RowHeadersWidth = 51;
            this.dgvLoadPackage.RowTemplate.Height = 24;
            this.dgvLoadPackage.Size = new System.Drawing.Size(1518, 396);
            this.dgvLoadPackage.TabIndex = 19;
            this.dgvLoadPackage.SelectionChanged += new System.EventHandler(this.DgvLoadMedicine_SelectionChanged);
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
            // cbMedicine
            // 
            this.cbMedicine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMedicine.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMedicine.FormattingEnabled = true;
            this.cbMedicine.Location = new System.Drawing.Point(31, 178);
            this.cbMedicine.Name = "cbMedicine";
            this.cbMedicine.Size = new System.Drawing.Size(345, 34);
            this.cbMedicine.TabIndex = 39;
            this.cbMedicine.SelectedIndexChanged += new System.EventHandler(this.CbMedicine_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 315);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(371, 55);
            this.label2.TabIndex = 40;
            this.label2.Text = "Package Management";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbPillsPerPack);
            this.groupBox1.Controls.Add(this.tbMedicineId);
            this.groupBox1.Controls.Add(this.lblPackageId);
            this.groupBox1.Controls.Add(this.tbPackageId);
            this.groupBox1.Controls.Add(this.lblPackageCode);
            this.groupBox1.Controls.Add(this.tbPackageCode);
            this.groupBox1.Controls.Add(this.lblPackageName);
            this.groupBox1.Controls.Add(this.tbNamePackage);
            this.groupBox1.Controls.Add(this.lblPillsPerPack);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(474, 293);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Information";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(2, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 26);
            this.label3.TabIndex = 45;
            this.label3.Text = "Medicine Id";
            // 
            // tbMedicineId
            // 
            this.tbMedicineId.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMedicineId.Location = new System.Drawing.Point(168, 41);
            this.tbMedicineId.Name = "tbMedicineId";
            this.tbMedicineId.Size = new System.Drawing.Size(276, 34);
            this.tbMedicineId.TabIndex = 44;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(28, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(297, 17);
            this.label7.TabIndex = 43;
            this.label7.Text = "*Search by PackagingCode or Name of Package";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.groupBox2.Controls.Add(this.nudPricePerPack);
            this.groupBox2.Controls.Add(this.nudPricePerPill);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(509, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(473, 141);
            this.groupBox2.TabIndex = 42;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Price";
            // 
            // nudPricePerPack
            // 
            this.nudPricePerPack.Location = new System.Drawing.Point(165, 87);
            this.nudPricePerPack.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nudPricePerPack.Name = "nudPricePerPack";
            this.nudPricePerPack.Size = new System.Drawing.Size(287, 34);
            this.nudPricePerPack.TabIndex = 40;
            // 
            // nudPricePerPill
            // 
            this.nudPricePerPill.Location = new System.Drawing.Point(165, 35);
            this.nudPricePerPill.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nudPricePerPill.Name = "nudPricePerPill";
            this.nudPricePerPill.Size = new System.Drawing.Size(287, 34);
            this.nudPricePerPill.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 26);
            this.label1.TabIndex = 20;
            this.label1.Text = "Price Per Pack";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 26);
            this.label4.TabIndex = 38;
            this.label4.Text = "Price Per Pill";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.groupBox3.Controls.Add(this.cbMedicine);
            this.groupBox3.Controls.Add(this.tbSearch);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.lblSearch);
            this.groupBox3.Controls.Add(this.btnSearch);
            this.groupBox3.Controls.Add(this.lblMedicine);
            this.groupBox3.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(997, 10);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(509, 233);
            this.groupBox3.TabIndex = 44;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filter & Search";
            // 
            // FormPackagingManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1518, 769);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvLoadPackage);
            this.Name = "FormPackagingManagement";
            this.Text = "FormPackagingManagement";
            this.Load += new System.EventHandler(this.FormPackagingManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoadPackage)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPricePerPack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPricePerPill)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.TextBox tbPillsPerPack;
        private System.Windows.Forms.Label lblPillsPerPack;
        private System.Windows.Forms.TextBox tbNamePackage;
        private System.Windows.Forms.Label lblPackageName;
        private System.Windows.Forms.TextBox tbPackageCode;
        private System.Windows.Forms.Label lblPackageCode;
        private System.Windows.Forms.TextBox tbPackageId;
        private System.Windows.Forms.Label lblPackageId;
        private System.Windows.Forms.DataGridView dgvLoadPackage;
        private System.Windows.Forms.Label lblMedicine;
        private System.Windows.Forms.ComboBox cbMedicine;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown nudPricePerPack;
        private System.Windows.Forms.NumericUpDown nudPricePerPill;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbMedicineId;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}