namespace StreetReporterAPI.Domain.Entities.Incidents
{
    public class IncidentMessage
    {
        public required uint Id { get; set; }
        public required uint IncidentId { get; set; }
        public required uint UserId { get; set; }
        public required string Message {  get; set; }
        public required bool IsPublic { get; set; } = false;
    }
}
