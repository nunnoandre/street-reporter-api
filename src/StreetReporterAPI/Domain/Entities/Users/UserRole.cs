namespace StreetReporterAPI.Domain.Entities.Users
{
    public class UserRole
    {
        public required UserRoleEnum Id { get; set; }
        public required string Name { get; set; }
    }

    public enum UserRoleEnum
    {
        Reporter = 1,
        Manager = 2,
        Admin = 3
    }
}
