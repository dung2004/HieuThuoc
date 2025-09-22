using System;
using HieuThuoc.Services.Interfaces;
using HieuThuoc.UI.Views;

namespace HieuThuoc.UI.Presenters
{
    public class MainMenuPresenter
    {
        private readonly IMainMenuView _view;
        private readonly IReportService _reportService;
        private readonly IBatchService _batchService;
        int soNgayLoadChart = 7;

        public MainMenuPresenter(IMainMenuView view, IReportService reportService, IBatchService batchService)
        {
            _view = view;
            _reportService = reportService;
            _batchService = batchService;
        }

        public void LoadDashboardData(int roleId)
        {
            var stats = _reportService.GetDashboardStats(roleId);
            _view.ShowDashboard(stats);

            // load chart mặc định 7 ngày
            var series = _reportService.GetRevenueSeries(soNgayLoadChart);
            _view.BindRevenueSeries(series);
        }

        public void LoadExpiryAlerts(int days = 14)
        {
            var items = _batchService.GetNearExpiry(DateTime.Today, days);
            _view.ShowNearExpiry(items);
        }
    }
}
