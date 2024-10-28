using System.ComponentModel.DataAnnotations;

namespace StreetReporterAPI.Domain.Entities.Users
{
    public class User
    {
        public required uint Id { get; set; }
        public required uint NIF { get; set; }
        public required uint? UserRoleId { get; set; }
        public virtual UserRole? Role { get; set; }
    }
}
