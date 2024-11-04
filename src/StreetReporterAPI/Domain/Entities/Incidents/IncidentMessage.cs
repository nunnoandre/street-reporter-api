using StreetReporterAPI.Domain.Entities.Users;
using System.ComponentModel.DataAnnotations.Schema;

namespace StreetReporterAPI.Domain.Entities.Incidents
{
    public class IncidentMessage
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required uint Id { get; set; }
        public required uint IncidentId { get; set; }
        public virtual Incident? Incident { get; set; }
        public required uint? UserId { get; set; }
        public virtual User? User { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required string Message {  get; set; }
        public required bool IsPublic { get; set; } = false;
    }
}
