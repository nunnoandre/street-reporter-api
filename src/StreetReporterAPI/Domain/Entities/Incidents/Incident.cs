using StreetReporterAPI.Domain.Entities.Reports;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using StreetReporterAPI.Domain.Entities.Organizations;

namespace StreetReporterAPI.Domain.Entities.Incidents
{
    public class Incident
    {
        public required uint Id { get; set; }
        public required string Description { get; set; }
        public required DateTime CreationDate { get; set; } = DateTime.Now;
        public required string Coordinates { get; set; }
        public required uint? IncidentCategoryId { get; set; }
        public virtual IncidentCategory? Category { get; set; }
        public required uint? ResponsibleOrganizationId { get; set; }
        public virtual PublicOrganization? ResponsibleOrganization { get; set; }
        public required uint? IncidentStatusId { get; set; } 
        public virtual IncidentStatus? Status { get; set; }
        public DateTime? ConclusionDate { get; set; }
        public virtual List<IncidentMessage>? Messages { get; set; }
        public virtual List<Report>? Reports { get; set; }
    }
}
