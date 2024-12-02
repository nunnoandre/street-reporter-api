using StreetReporterAPI.Domain.Entities.Organizations;
using StreetReporterAPI.Domain.Entities.Users;
using System.ComponentModel.DataAnnotations.Schema;

namespace StreetReporterAPI.Application.DTO
{
    public class UserResponse
    {
        public uint NIF { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public UserRole Role { get; set; }
        public  PublicOrganization PublicOrganization { get; set; }
    }
}
