using System.ComponentModel.DataAnnotations;

namespace StreetReporterAPI.Domain.Entities.Users
{
    public class User
    {
        public required uint Id { get; set; }
        public required uint NIF { get; set; }
        public required UserTypeEnum TypeId { get; set; }
    }

    public enum UserTypeEnum
    {
        Reporter = 0,
        Manager = 1,
        Admin = 2
    }
}
