using InoCar.Common;
using InoCar.Data;
using InoCar.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Repositories.Impl
{
    public class RefreshTokenRepositoryImpl : IRefreshTokenRepository
    {
        #region constructors

        public RefreshTokenRepositoryImpl(InoCarContext context)
        {
            _context = context;
        }
        #endregion constructors

        #region public methods
        public async Task AddTokenAsync(RefreshToken token)
        {
      
            await _context.RefreshTokens.AddAsync(token);
        
            await _context.SaveChangesAsync();

        }

        public async Task<RefreshToken> SearchTokenAsync(string token) =>  await _context.RefreshTokens.Include(x=> x.User)
                .FirstOrDefaultAsync(x => x.Token == token);

      
        public async Task<bool> DeleteTokenAsync(RefreshToken refreshToken)
        {
            _context.RefreshTokens.Remove(refreshToken);
            await _context.SaveChangesAsync();
            return true;
        }
        #endregion public methods

        #region private fields

        private readonly InoCarContext _context;


        #endregion private fields
    }
}
