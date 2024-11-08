using Microsoft.AspNetCore.Mvc;
using StreetReporterAPI.Application.DTO;

namespace StreetReporterAPI.Application.Interfaces
{
    public interface IReportService
    {
        Task<ApiResponse<ReportResponse>> GetById(uint idReport);

        Task<ApiResponse<List<ReportResponse>>> GetAllByUser(uint idUser);

        Task<ApiResponse<List<ReportResponse>>> GetAllByOrganization(uint idOrganization);

        Task<ApiResponse<List<ReportResponse>>> GetAllActiveByOrganization(uint idOrganization);
        Task<bool> AddReport(ReportRequest reportToAdd);
        Task<bool> DeleteReport(uint idToDelete);

    }
}
