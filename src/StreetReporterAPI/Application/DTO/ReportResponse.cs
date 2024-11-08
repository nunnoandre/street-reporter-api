using StreetReporterAPI.Domain.Entities.Incidents;
using StreetReporterAPI.Domain.Entities.Organizations;
using StreetReporterAPI.Domain.Entities.Users;

namespace StreetReporterAPI.Application.DTO
{
    public class ReportResponse
    {
        public uint Id { get; set; }
        public string Description { get; set; }
        public uint UserId { get; set; }
        public DateTime CreationDate { get; set; }
        public string Coordinates { get; set; }
        public IncidentCategory Category { get; set; }
        public PublicOrganization ResponsibleOrganization { get; set; }
        public bool IsValidated { get; set; }
        public bool IsRejected { get; set; } 
        public bool IsArchived { get; set; } 
        public bool IsAnonymous { get; set; }
        public bool HasImages { get; set; }
        public DateTime? ConclusionDate { get; set; }
        public Incident? Incident { get; set; }
    }
}
