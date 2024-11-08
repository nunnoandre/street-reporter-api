using StreetReporterAPI.Domain.Entities.Incidents;
using StreetReporterAPI.Domain.Entities.Organizations;
using StreetReporterAPI.Domain.Entities.Users;

namespace StreetReporterAPI.Application.DTO
{
    public class ReportRequest
    {
        public string Description { get; set; }
        public uint UserId { get; set; }
        public string Coordinates { get; set; }
        public uint IncidentCategoryId { get; set; } 
        public uint ResponsibleOrganizationId { get; set; }
        public  bool IsAnonymous { get; set; }
        public  bool HasImages { get; set; }
    }
}