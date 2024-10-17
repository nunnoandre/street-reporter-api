namespace StreetReporterAPI.Domain.Entities.Incidents
{
    public class IncidentStatus
    {
        public required IncidentStatusEnum Id { get; set; }
        public required string Name { get; set; }
    }

    public enum IncidentStatusEnum
    {
        Aknowledged = 0,
        InProgress = 1,
        Done = 2,
        Aborted = 3,
        Archived = 4
    }
}
