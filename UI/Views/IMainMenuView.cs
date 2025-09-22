using System;
using System.Collections.Generic;
using HieuThuoc.Domain.DTOs;
using HieuThuoc.Domain.Entities;

namespace HieuThuoc.UI.Views
{
    public interface IMainMenuView
    {
        // KPI
        void ShowDashboard(DashboardStatsDto stats);

        // Batches near expiry
        void ShowNearExpiry(IEnumerable<Batch> batches);

        // Role-based UI mask
        void ApplyRoleMask(int roleId);

        // Bind revenue series for chart
        void BindRevenueSeries(IEnumerable<RevenuePointDto> series);
    }
}
