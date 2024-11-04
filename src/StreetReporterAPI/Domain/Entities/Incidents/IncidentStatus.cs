namespace StreetReporterAPI.Domain.Entities.Incidents
{
    public class IncidentStatus
    {
        public required IncidentStatusEnum Id { get; set; }
        public required string Name { get; set; }
    }

    public enum IncidentStatusEnum
    {
        Aknowledged = 1,
        InProgress = 2,
        Done = 3,
        Aborted = 4,
        Archived = 5,
        Affected = 6,
        NotAffected = 7
    }
}
