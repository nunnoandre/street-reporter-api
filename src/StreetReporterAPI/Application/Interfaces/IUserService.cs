using StreetReporterAPI.Application.DTO;
using StreetReporterAPI.Domain.Entities.Users;

namespace StreetReporterAPI.Application.Interfaces
{
    public interface IUserService
    {
        Task<ApiResponse<UserResponse>> GetById(uint id);
        Task<ApiResponse<UserResponse>> GetByEmail(string email);
        Task<bool> AddUser(UserRequest userToAdd);
    }
}
