namespace StreetReporterAPI.Application.DTO
{
    public class UserRequest
    {
        public uint NIF { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public uint RoleId { get; set; }
        public uint? PublicOrganizationId { get; set; }

    }
}
