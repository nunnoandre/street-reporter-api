using StreetReporterAPI.Domain.Entities.Reports;

namespace StreetReporterAPI.Domain.Entities.Incidents
{
    public class Incident
    {
        public required uint Id { get; set; }
        public required string Description { get; set; }
        public required DateTime CreationDate { get; set; } = DateTime.Now;
        public required string Coordinates { get; set; }
        public required IncidentCategoryEnum CategoryId { get; set; } = IncidentCategoryEnum.None;
        public required uint ResponsibleEntityId { get; set; }
        public required IncidentStatusEnum StatusId { get; set; } = IncidentStatusEnum.Aknowledged;
        public DateTime ConclusionDate { get; set; }       
    }
}
