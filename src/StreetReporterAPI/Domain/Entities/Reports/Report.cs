using StreetReporterAPI.Domain.Entities.Incidents;
using StreetReporterAPI.Domain.Entities.Users;
using System.ComponentModel.DataAnnotations.Schema;

namespace StreetReporterAPI.Domain.Entities.Reports
{
    public class Report
    {
        public required uint Id { get; set; }
        public required string Description { get; set; }

        [ForeignKey(nameof(User))]
        public required uint ReporterId { get; set; }
        public required DateTime CreationDate { get; set; } = DateTime.Now;
        public required string Coordinates { get; set; }

        [ForeignKey(nameof(IncidentCategory))]
        public required IncidentCategoryEnum CategoryId { get; set; } = IncidentCategoryEnum.None;
        public required uint ResponsibleEntityId { get; set; }

        [ForeignKey(nameof(ReportStatus))]
        public required ReportStatusEnum StatusId { get; set; } = ReportStatusEnum.Opened;
        public required bool IsAnonymous { get; set; } = false;
        public required bool HasImages { get; set; } = false;
        public DateTime ConclusionDate { get; set; }

        [ForeignKey(nameof(Incident))]
        public uint IncidentId { get; set; }
    }
}
