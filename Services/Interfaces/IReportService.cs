using System.Collections.Generic;
using HieuThuoc.Domain.DTOs;

namespace HieuThuoc.Services.Interfaces
{
    public interface IReportService
    {
        DashboardStatsDto GetDashboardStats(int currentUserRoleId);
        IEnumerable<RevenuePointDto> GetRevenueSeries(int days);
    }
}
