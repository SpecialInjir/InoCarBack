using InoCar.Data;
using InoCar.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InoCar;
using Microsoft.EntityFrameworkCore;
using InoCar.Common;

namespace InoCar.Repositories.Impl
{
    public class UserRepositoryImpl : IUserRepository
    {
        #region constructors

        public UserRepositoryImpl(InoCarContext context)
        {
            _context = context;
        }

        #endregion constructors

        #region public methods

        public async Task CreateUserAsync(User user)
        {
           
            await _context.Users.AddAsync(user);
   
            await _context.SaveChangesAsync(); 

        }

        public async Task<bool> EmailExistsAsync(string email) => await _context.Users.AnyAsync(x => x.Email == email);
             
        public async Task<User?> GetUserByEmailAsync(string email) => await _context.Users.FirstOrDefaultAsync(x => x.Email == email);

        public async Task<User?> GetUserByIdAsync(string id) => await _context.Users.FindAsync(id);
        public async Task AddResetPasswordCodeAsync(ResetPasswordCode code) 
         {

            await _context.ResetPasswordCodes.AddAsync(code);

            await _context.SaveChangesAsync();

         }


        public async Task<ResetPasswordCode?> GetResetCodeAsync(string Id) => await  _context.ResetPasswordCodes.FirstOrDefaultAsync(x => x.UserId == Id && x.IsActive);

        public async Task UpdatePasswordAsync(User updateUser)
        {

            _context.Users.Update(updateUser);

            await _context.SaveChangesAsync();

        }

        public async Task UpdateUserAsync(User updateUser)
        {

            _context.Users.Update(updateUser);

            await _context.SaveChangesAsync();

        }

        public async Task UpdateResetPasswordCodeAsync(ResetPasswordCode code)
        {
            _context.ResetPasswordCodes.Update(code);

            await _context.SaveChangesAsync();

        }
        

        #endregion public methods

        #region private fields

        private readonly InoCarContext _context;


        #endregion private fields
    }
   
       
    
}
