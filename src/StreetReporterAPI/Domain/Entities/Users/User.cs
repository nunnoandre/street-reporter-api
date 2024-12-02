using StreetReporterAPI.Domain.Entities.Organizations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StreetReporterAPI.Domain.Entities.Users
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public required uint NIF { get; set; }
        public required string Name { get; set; }
        public string? Email { get; set; }
        public required UserRoleEnum? UserRoleId { get; set; } 
        public virtual UserRole? Role { get; set; }
        public uint? PublicOrganizationId { get; set; }
        public virtual PublicOrganization? PublicOrganization { get; set; }
    }
}
