using Microsoft.EntityFrameworkCore;
using StreetReporterAPI.Application.Constants;
using StreetReporterAPI.Application.DTO;
using StreetReporterAPI.Application.Helpers;
using StreetReporterAPI.Application.Interfaces;
using StreetReporterAPI.Domain.Entities.Reports;
using StreetReporterAPI.Infrastructure.Data;

namespace StreetReporterAPI.Application.Services
{
    public class IncidentService : IIncidentService
    {
        private readonly DataContext _context;
        public IncidentService(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> AddIncident(IncidentRequest incidentToAdd)
        {
            var incidentModel = incidentToAdd.ToIncidentModel();

            await _context.Incidents.AddAsync(incidentModel);

            var rowsAdded = await _context.SaveChangesAsync();

            if (rowsAdded == 1 && incidentModel.Id != 0)
                return true;

            return false;
        }

        public async Task<bool> DeleteIncident(uint idToDelete)
        {
            var incidentToDelete = await _context.Incidents.FindAsync(idToDelete);

            if (incidentToDelete == null) return false;

            _context.Incidents.Remove(incidentToDelete);

            var rowsDeleted = await _context.SaveChangesAsync();

            if (rowsDeleted == 1)
                return true;

            return false;
        }

        public async Task<ApiResponse<List<IncidentResponse>>> GetAllActiveByOrganization(uint idOrganization)
        {
            var response = new ApiResponse<List<IncidentResponse>>();

            var incidentsFound = await _context.Incidents.Where(x => x.ResponsibleOrganizationId.Equals(idOrganization) && x.IsArchived == false).ToListAsync();

            if (incidentsFound is null)
            {
                response.ErrorMessage = ErrorMessage.ActiveIncidentsNotFoundByOrganization;
                return response;
            }

            var incidentssResponseList = new List<IncidentResponse>();

            foreach (var incident in incidentsFound)
            {
                incidentssResponseList.Add(incident.ToResponseModel());
            }

            response.ResponseObject = incidentssResponseList;
            return response;
        }

        public async Task<ApiResponse<List<IncidentResponse>>> GetAllByOrganization(uint idOrganization)
        {
            var response = new ApiResponse<List<IncidentResponse>>();

            var incidentsFound = await _context.Incidents.Where(x => x.ResponsibleOrganizationId.Equals(idOrganization)).ToListAsync();

            if (incidentsFound is null)
            {
                response.ErrorMessage = ErrorMessage.IncidentsNotFoundByOrganization;
                return response;
            }

            var incidentssResponseList = new List<IncidentResponse>();

            foreach (var incident in incidentsFound)
            {
                incidentssResponseList.Add(incident.ToResponseModel());
            }

            response.ResponseObject = incidentssResponseList;
            return response;
        }

        public async Task<ApiResponse<IncidentResponse>> GetById(uint idIncident)
        {
            var response = new ApiResponse<IncidentResponse>();
            var incidentFound = await _context.Incidents.FindAsync(idIncident);

            if (incidentFound is null)
            {
                response.ErrorMessage = ErrorMessage.IncidentNotFoundById;
                return response;
            }

            response.ResponseObject = incidentFound.ToResponseModel();
            return response;
        }
    }
}
