using StreetReporterAPI.Application.DTO;
using StreetReporterAPI.Domain.Entities.Incidents;
using StreetReporterAPI.Domain.Entities.Organizations;
using StreetReporterAPI.Domain.Entities.Reports;
using StreetReporterAPI.Domain.Entities.Users;

namespace StreetReporterAPI.Application.Helpers
{
    public static class MapperExtensions
    {
        public static ReportResponse ToReponseModel(this Report report)
        {
            return new ReportResponse
            {
                Id = report.Id,
                Description = report.Description,
                Coordinates = report.Coordinates,
                UserId = report.UserId,
                CreationDate = report.CreationDate,
                ConclusionDate = report.ConclusionDate,
                Category = report.Category,
                ResponsibleOrganization = report.ResponsibleOrganization,
                IsAnonymous = report.IsAnonymous,
                IsArchived = report.IsArchived,
                IsRejected = report.IsRejected,
                IsValidated = report.IsValidated,
                HasImages = report.HasImages,
                Incident = report.Incident
            };
        }

        public static Report ToReportModel(this ReportRequest reportRequest) 
        {
            return new Report 
            {
                Description = reportRequest.Description,
                UserId = reportRequest.UserId,
                Coordinates = reportRequest.Coordinates,
                IncidentCategoryId = (IncidentCategoryEnum)reportRequest.IncidentCategoryId,
                ResponsibleOrganizationId = reportRequest.ResponsibleOrganizationId,
                IsAnonymous = reportRequest.IsAnonymous,
                HasImages = reportRequest.HasImages
            };
        }

        public static IncidentResponse ToResponseModel(this Incident incident) 
        {
            return new IncidentResponse
            {
                Id = incident.Id,
                Description = incident.Description,
                CreationDate = incident.CreationDate,
                Coordinates = incident.Coordinates,
                Category = incident.Category,
                ResponsibleOrganization = incident.ResponsibleOrganization,
                Status = incident.Status,
                IsArchived = incident.IsArchived,
                ConclusionDate = incident.ConclusionDate,
                Messages = incident.Messages,
                Reports = incident.Reports,
                ReportsCount = incident.Reports != null && incident.Reports.Count > 0 ? (uint)incident.Reports.Count : 0
            };
        }

        public static Incident ToIncidentModel(this IncidentRequest incidentRequest)
        {
            return new Incident
            {
                Description = incidentRequest.Description,
                Coordinates = incidentRequest.Coordinates,
                IncidentCategoryId = (IncidentCategoryEnum)incidentRequest.CategoryId,
                ResponsibleOrganizationId = incidentRequest.ResponsibleOrganizationId,                
            };
        }

        public static UserResponse ToResponseModel(this User user) 
        {
            return new UserResponse
            {
                NIF = user.NIF,
                Name = user.Name,
                Email = user.Email,
                Role = user.Role,
                PublicOrganization = user.PublicOrganization
            };
        }

        public static User ToUserModel(this UserRequest userRequest)
        {
            return new User
            {
                NIF = userRequest.NIF,
                Name = userRequest.Name,
                Email = userRequest.Email,
                UserRoleId = (UserRoleEnum)userRequest.RoleId,
                PublicOrganizationId = userRequest.PublicOrganizationId,
            };
        }
    }
}
