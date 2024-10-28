namespace StreetReporterAPI.Domain.Entities.Incidents
{
    public class IncidentStatus
    {
        public required uint Id { get; set; }
        public required string Name { get; set; }
    }

    public enum IncidentStatusEnum
    {
        Aknowledged = 0,
        InProgress = 1,
        Done = 2,
        Aborted = 3,
        Archived = 4,
        Affected = 5,
        NotAffected = 6
    }
}
