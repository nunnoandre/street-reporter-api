using StreetReporterAPI.Domain.Entities.Users;

namespace StreetReporterAPI.Domain.Interfaces.Users
{
    public interface IUserRepository
    {
        Task<User> GetByNIF(uint NIF);
        Task AddUser(User user);
        Task<int> SaveChanges();
    }
}
