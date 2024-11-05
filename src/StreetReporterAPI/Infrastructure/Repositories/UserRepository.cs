using Microsoft.EntityFrameworkCore;
using StreetReporterAPI.Domain.Entities.Users;
using StreetReporterAPI.Domain.Interfaces.Users;
using StreetReporterAPI.Infrastructure.Data;

namespace StreetReporterAPI.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context) 
        {
            _context = context;
        }
        public async Task AddUser(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<User> GetByNIF(uint NIF)
        {
            return await _context.Users.FindAsync(NIF);
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
