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
    public class RemoveCarReasonRepositoryImpl : IRemoveCarReasonRepository
    {
        #region constructors

        public RemoveCarReasonRepositoryImpl(InoCarContext context)
        {
            _context = context;
        }

        #endregion constructors

        #region public methods

        public async Task<IEnumerable<RemoveCarReason>> GetRemoveCarReasonsAsync()
        {
            return await _context.RemoveCarReasons.Where(x=>x.IsDeleted).ToArrayAsync();     
        }

        public async Task AddRemoveCarReasonAsync(RemoveCarReason removeCarReason)
        {
            await _context.RemoveCarReasons.AddAsync(removeCarReason);

            await _context.SaveChangesAsync();
        }

        public async Task<RemoveCarReason?> GetRemoveCarReasonById(int removeCarReasonId) => await _context.RemoveCarReasons.FirstOrDefaultAsync(x => x.Id == removeCarReasonId && !x.IsDeleted);


        public async Task UpdateCarReasonAsync(RemoveCarReason removeCarReason)
        {
             _context.RemoveCarReasons.Update(removeCarReason);

            await _context.SaveChangesAsync();
        }
        #endregion public methods

        #region private fields

        private readonly InoCarContext _context;


        #endregion private fields
       
}
}
