namespace StreetReporterAPI.Domain.Entities.Users
{
    public class UserRole
    {
        public required uint Id { get; set; }
        public required string Name { get; set; }
    }

    public enum UserRoleEnum
    {
        Reporter = 0,
        Manager = 1,
        Admin = 2
    }
}
