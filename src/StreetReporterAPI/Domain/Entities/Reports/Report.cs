using StreetReporterAPI.Domain.Entities.Incidents;
using StreetReporterAPI.Domain.Entities.Organizations;
using StreetReporterAPI.Domain.Entities.Users;
using System.ComponentModel.DataAnnotations.Schema;

namespace StreetReporterAPI.Domain.Entities.Reports
{
    public class Report
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint Id { get; set; }
        public required string Description { get; set; }
        public required uint UserId { get; set; }
        public virtual User? User { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public required string Coordinates { get; set; }
        public required IncidentCategoryEnum IncidentCategoryId { get; set; } = IncidentCategoryEnum.Other;
        public virtual IncidentCategory? Category { get; set; }
        public required uint ResponsibleOrganizationId { get; set; }
        public virtual PublicOrganization? ResponsibleOrganization { get; set; }
        //public required ReportStatusEnum ReportStatusId { get; set; } = ReportStatusEnum.Opened;
        //public virtual ReportStatus? Status { get; set; }
        public bool IsValidated { get; set; } = false;
        public bool IsRejected { get; set; } = false;
        public bool IsArchived { get; set; } = false;  
        public required bool IsAnonymous { get; set; } = false;
        public required bool HasImages { get; set; } = false;
        public DateTime? ConclusionDate { get; set; }
        public uint? IncidentId { get; set; }
        public virtual Incident? Incident { get; set; }
    }
}
