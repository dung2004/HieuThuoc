namespace HieuThuoc.UI.Forms
{
    partial class FormDashBoard
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chartRevenue = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgvNearExpiry = new System.Windows.Forms.DataGridView();
            this.lblTotalStock = new System.Windows.Forms.Label();
            this.lblRevenueToday = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNearExpiry)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartRevenue
            // 
            chartArea1.Name = "ChartArea1";
            this.chartRevenue.ChartAreas.Add(chartArea1);
            this.chartRevenue.Dock = System.Windows.Forms.DockStyle.Right;
            legend1.Name = "Legend1";
            this.chartRevenue.Legends.Add(legend1);
            this.chartRevenue.Location = new System.Drawing.Point(457, 0);
            this.chartRevenue.Name = "chartRevenue";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartRevenue.Series.Add(series1);
            this.chartRevenue.Size = new System.Drawing.Size(1061, 502);
            this.chartRevenue.TabIndex = 12;
            this.chartRevenue.Text = "chart1";
            title1.Name = "123123";
            this.chartRevenue.Titles.Add(title1);
            // 
            // dgvNearExpiry
            // 
            this.dgvNearExpiry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNearExpiry.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvNearExpiry.Location = new System.Drawing.Point(0, 502);
            this.dgvNearExpiry.Name = "dgvNearExpiry";
            this.dgvNearExpiry.RowHeadersWidth = 51;
            this.dgvNearExpiry.RowTemplate.Height = 24;
            this.dgvNearExpiry.Size = new System.Drawing.Size(1518, 267);
            this.dgvNearExpiry.TabIndex = 11;
            // 
            // lblTotalStock
            // 
            this.lblTotalStock.AutoSize = true;
            this.lblTotalStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalStock.ForeColor = System.Drawing.Color.Red;
            this.lblTotalStock.Location = new System.Drawing.Point(18, 116);
            this.lblTotalStock.Name = "lblTotalStock";
            this.lblTotalStock.Size = new System.Drawing.Size(171, 31);
            this.lblTotalStock.TabIndex = 10;
            this.lblTotalStock.Text = "lblTotalStock";
            // 
            // lblRevenueToday
            // 
            this.lblRevenueToday.AutoSize = true;
            this.lblRevenueToday.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRevenueToday.ForeColor = System.Drawing.Color.Red;
            this.lblRevenueToday.Location = new System.Drawing.Point(18, 56);
            this.lblRevenueToday.Name = "lblRevenueToday";
            this.lblRevenueToday.Size = new System.Drawing.Size(226, 31);
            this.lblRevenueToday.TabIndex = 9;
            this.lblRevenueToday.Text = "lblRevenueToday";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox3.Controls.Add(this.lblTotalStock);
            this.groupBox3.Controls.Add(this.lblRevenueToday);
            this.groupBox3.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(439, 484);
            this.groupBox3.TabIndex = 26;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Dash Board";
            // 
            // FormDashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1518, 769);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.chartRevenue);
            this.Controls.Add(this.dgvNearExpiry);
            this.Name = "FormDashBoard";
            this.Text = "FormDashBoard";
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNearExpiry)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartRevenue;
        private System.Windows.Forms.DataGridView dgvNearExpiry;
        private System.Windows.Forms.Label lblTotalStock;
        private System.Windows.Forms.Label lblRevenueToday;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}