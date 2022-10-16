using InoCar.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Repositories
{
    public interface IUserRepository
    {
        Task CreateUserAsync(User user);
        Task<bool> EmailExistsAsync(string email);
        Task<User?> GetUserByEmailAsync(string email);
        Task AddResetPasswordCodeAsync(ResetPasswordCode code);

        Task<ResetPasswordCode?> GetResetCodeAsync(string Id);
        Task UpdatePasswordAsync(User user);
        Task UpdateResetPasswordCodeAsync(ResetPasswordCode code);
        Task<User?> GetUserByIdAsync(string Id);
        Task UpdateUserAsync(User updateUser);
    }
}
