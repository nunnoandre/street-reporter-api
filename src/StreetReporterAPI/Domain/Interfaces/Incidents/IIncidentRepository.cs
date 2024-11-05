using StreetReporterAPI.Domain.Entities.Incidents;
using StreetReporterAPI.Domain.Entities.Reports;
using StreetReporterAPI.Domain.Entities.Users;

namespace StreetReporterAPI.Domain.Interfaces.Incidents
{
    public interface IIncidentRepository
    {
        Task<Incident> GetById(uint id);
        Task<List<Incident>> GetByOrganizationId(uint organizationId);
        Task AddIncident(Incident incident);
        Task<int> SaveChanges();
    }
}
