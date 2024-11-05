using StreetReporterAPI.Domain.Entities.Reports;
using StreetReporterAPI.Domain.Entities.Users;

namespace StreetReporterAPI.Domain.Interfaces.Reports
{
    public interface IReportRepository
    {
        Task<Report> GetById(uint id);
        Task<List<Report>> GetByUserId(uint userId);
        Task<List<Report>> GetByOrganizationId(uint organizationId);
        Task AddReport(Report report);
        Task<int> SaveChanges();
        //Task<List<Report>> GetByCategoryId(uint categoryId);
        //Task<List<Report>> GetByStatusId(uint statusId);      
    }
}
