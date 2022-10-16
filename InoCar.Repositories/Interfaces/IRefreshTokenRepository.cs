using InoCar.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Repositories
{
    public interface IRefreshTokenRepository
    {
        Task AddTokenAsync(RefreshToken token);
        Task<RefreshToken> SearchTokenAsync(string token);
        Task<bool> DeleteTokenAsync(RefreshToken refreshToken);
    }
}
