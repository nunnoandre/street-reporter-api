using StreetReporterAPI.Domain.Entities.Incidents;

namespace StreetReporterAPI.Domain.Entities.Reports
{
    public class Report
    {
        public required uint Id { get; set; }
        public required string Description { get; set; }
        public required uint ReporterId { get; set; }
        public required DateTime CreationDate { get; set; } = DateTime.Now;
        public required string Coordinates { get; set; }
        public required IncidentCategoryEnum CategoryId { get; set; } = IncidentCategoryEnum.None;
        public required uint ResponsibleEntityId { get; set; }
        public required ReportStatusEnum StatusId { get; set; } = ReportStatusEnum.Opened;
        public required bool IsAnonymous { get; set; } = false;
        public required bool HasImages { get; set; } = false;
        public DateTime ConclusionDate { get; set; }
        public uint IncidentId { get; set; }
    }
}
