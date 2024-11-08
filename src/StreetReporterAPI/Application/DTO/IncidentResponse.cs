using StreetReporterAPI.Domain.Entities.Incidents;
using StreetReporterAPI.Domain.Entities.Organizations;
using StreetReporterAPI.Domain.Entities.Reports;
using System.ComponentModel.DataAnnotations.Schema;

namespace StreetReporterAPI.Application.DTO
{
    public class IncidentResponse
    {
        public uint Id { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public string Coordinates { get; set; }
        public IncidentCategory Category { get; set; }
        public PublicOrganization ResponsibleOrganization { get; set; }
        public IncidentStatus Status { get; set; }
        public bool IsArchived { get; set; }
        public DateTime? ConclusionDate { get; set; }
        public uint ReportsCount { get; set; } 
        public List<IncidentMessage>? Messages { get; set; }
        public List<Report>? Reports { get; set; }
    }
}
