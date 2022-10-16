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
    public class VisitReasonRepositoryImpl : IVisitReasonRepository
    {
        #region constructors

        public VisitReasonRepositoryImpl(InoCarContext context)
        {
            _context = context;
        }

        #endregion constructors

        #region public methods

        public async Task<IEnumerable<VisitReason>> GetVisitReasonAsync()
        {
            return await _context.VisitReasons.Where(x=>x.IsDeleted==false)
               .ToArrayAsync();
        }

       public async Task<VisitReason?> GetVisitReasonByIdAsync(int visitReasonId) => await _context.VisitReasons.FirstOrDefaultAsync(x => x.Id == visitReasonId && !x.IsDeleted);
        public async Task AddVisitReasonAsync(VisitReason visitReason)
        {
            await _context.VisitReasons.AddAsync(visitReason);
            await _context.SaveChangesAsync();
        }

        public async Task AddMaintenanceWorkAsync(MaintenanceWork maintenanceWork)
        {
            await _context.MaintenanceWorks.AddAsync(maintenanceWork);
            await _context.SaveChangesAsync();
        }

       public async Task UpdateVisitReasonAsync(VisitReason visitReason)
        {
            _context.VisitReasons.Update(visitReason);
            await _context.SaveChangesAsync();
        }
        #endregion public methods

        #region private fields

        private readonly InoCarContext _context;


        #endregion private fields
    }
}
