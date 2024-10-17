using StreetReporterAPI.Domain.Entities.Users;
using System.ComponentModel.DataAnnotations.Schema;

namespace StreetReporterAPI.Domain.Entities.Incidents
{
    public class IncidentMessage
    {
        public required uint Id { get; set; }

        [ForeignKey(nameof(Incident))]
        public required uint IncidentId { get; set; }

        [ForeignKey(nameof(User))]
        public required uint UserId { get; set; }
        public required string Message {  get; set; }
        public required bool IsPublic { get; set; } = false;
    }
}
