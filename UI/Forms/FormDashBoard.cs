using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using HieuThuoc.Common;
using HieuThuoc.Domain.DTOs;
using HieuThuoc.UI.Presenters;
using HieuThuoc.UI.Views;

namespace HieuThuoc.UI.Forms
{
    public partial class FormDashBoard : Form, IMainMenuView
    {
        private MainMenuPresenter _presenter;

        public FormDashBoard()
        {
            InitializeComponent();
            // resolve services via DI and create presenter
            var report = HieuThuoc.UI.Program.ServiceProvider.GetService(typeof(HieuThuoc.Services.Interfaces.IReportService)) as HieuThuoc.Services.Interfaces.IReportService;
            var batch = HieuThuoc.UI.Program.ServiceProvider.GetService(typeof(HieuThuoc.Services.Interfaces.IBatchService)) as HieuThuoc.Services.Interfaces.IBatchService;
            _presenter = new MainMenuPresenter(this, report, batch);

            this.Load += FormDashBoard_Load;
        }

        private void FormDashBoard_Load(object sender, EventArgs e)
        {
            var roleId = CurrentUser.RoleId;
            _presenter.LoadDashboardData(roleId);
            _presenter.LoadExpiryAlerts();
        }

        // IMainMenuView implementations
        public void ShowDashboard(DashboardStatsDto stats)
        {
            if (lblRevenueToday != null)
                lblRevenueToday.Text = $"Revenue Today: {stats.RevenueToday:#,0}";
            if (lblTotalStock != null)
                lblTotalStock.Text = $"Total Stock Pills: {stats.TotalStockPills:#,0}";
        }

        public void ShowNearExpiry(IEnumerable<HieuThuoc.Domain.Entities.Batch> batches)
        {
            if (dgvNearExpiry == null) return;
            dgvNearExpiry.AutoGenerateColumns = true;
            dgvNearExpiry.DataSource = (batches ?? Enumerable.Empty<HieuThuoc.Domain.Entities.Batch>()).ToList();
        }

        public void BindRevenueSeries(IEnumerable<RevenuePointDto> series)
        {
            if (chartRevenue == null) return;

            var data = (series ?? Enumerable.Empty<RevenuePointDto>()).ToList();
            if (data.Count == 0)
            {
                var today = DateTime.Today;
                for (int i = 6; i >= 0; i--)
                {
                    data.Add(new RevenuePointDto { Date = today.AddDays(-i), Total = 0m });
                }
            }

            if (chartRevenue.ChartAreas.Count == 0)
            {
                chartRevenue.ChartAreas.Add(new ChartArea("Default"));
            }

            chartRevenue.Series.Clear();
            var s = new Series("Revenue")
            {
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.Date,
                YValueType = ChartValueType.Double,
                BorderWidth = 2,
                Color = Color.FromArgb(0, 150, 136),
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 5
            };

            double max = 0;
            foreach (var p in data)
            {
                var val = (double)p.Total;
                if (val > max) max = val;
                s.Points.AddXY(p.Date, val);
            }

            chartRevenue.Series.Add(s);
            var area = chartRevenue.ChartAreas[0];
            area.AxisX.LabelStyle.Format = "dd/MM";
            area.AxisY.LabelStyle.Format = "#,0";
            area.AxisY.Minimum = 0;
            if (max <= 0)
            {
                area.AxisY.Maximum = 1;
                area.AxisY.Interval = 0.2;
            }
            else
            {
                area.AxisY.Maximum = double.NaN;
                area.AxisY.Interval = double.NaN;
            }

            chartRevenue.Invalidate();
        }
        
        void IMainMenuView.ApplyRoleMask(int roleId){}
    }
}
