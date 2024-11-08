using StreetReporterAPI.Application.DTO;

namespace StreetReporterAPI.Application.Interfaces
{
    public interface IIncidentService
    {
        Task<ApiResponse<IncidentResponse>> GetById(uint idIncident);

        //Task<ApiResponse<List<IncidentResponse>>> GetAllByUser(uint idUser);

        Task<ApiResponse<List<IncidentResponse>>> GetAllByOrganization(uint idOrganization);

        Task<ApiResponse<List<IncidentResponse>>> GetAllActiveByOrganization(uint idOrganization);
        Task<bool> AddIncident(IncidentRequest incidentToAdd);
        Task<bool> DeleteIncident(uint idToDelete);
    }
}
