using Microsoft.EntityFrameworkCore;
using StreetReporterAPI.Application.Constants;
using StreetReporterAPI.Application.DTO;
using StreetReporterAPI.Application.Helpers;
using StreetReporterAPI.Application.Interfaces;
using StreetReporterAPI.Domain.Entities.Users;
using StreetReporterAPI.Infrastructure.Data;

namespace StreetReporterAPI.Application.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        public UserService(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> AddUser(UserRequest userToAdd)
        {
            var userModel = userToAdd.ToUserModel();
            await _context.Users.AddAsync(userModel);

            var rowsAdded = await _context.SaveChangesAsync();

            if (rowsAdded == 1)
                return true;

            return false;
        }

        public async Task<ApiResponse<UserResponse>> GetByEmail(string email)
        {
            var response = new ApiResponse<UserResponse>();
            var userFound = await _context.Users.Where(x => !string.IsNullOrWhiteSpace(x.Email) && x.Email.Equals(email)).SingleAsync();

            if (userFound is null)
            {
                response.ErrorMessage = ErrorMessage.UserNotFoundByEmail;
                return response;
            }

            response.ResponseObject = userFound.ToResponseModel();
            return response;
        }

        public async Task<ApiResponse<UserResponse>> GetById(uint id)
        {
            var response = new ApiResponse<UserResponse>();
            var userFound = await _context.Users.FindAsync(id);

            if (userFound is null)
            {
                response.ErrorMessage = ErrorMessage.UserNotFoundById;
                return response;
            }

            response.ResponseObject = userFound.ToResponseModel();
            return response;

        }

    }
}
