using ElectroLabModels.Models;
using ElectroLabViewModels;

namespace ElectroLabBusinessLayer.Interfaces
{
    public interface IAdminService
    {
        Task<AdminDashboardViewModel> GetDashboardAsync();
        Task<ReportViewModel> GetReportViewModelAsync(int reportId);
        Task<bool> HandleReportActionAsync(int id, string action, int? banDuration, string currentUserName);
        Task<List<Ban>> GetAllBansAsync();
    }
}
