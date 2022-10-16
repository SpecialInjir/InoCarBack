using InoCar.Data;
using InoCar.Data.Entities;
using InoCar.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace InoCar.Repositories.Impl
{
    public class MaintenanceWorkRepositoryImpl : IMaintenanceWorkRepository
    {
        #region constructors

        public MaintenanceWorkRepositoryImpl(InoCarContext context)
        {
            _context = context;
        }

        #endregion constructors

        #region public methods



        public async Task UpdateMaintenanceWorkAsync(MaintenanceWork maintenanceWork)
        {
            _context.MaintenanceWorks.Update(maintenanceWork);
            await _context.SaveChangesAsync();
        }



        public async Task<MaintenanceWork?> GetMaintenanceWorkByIdAsync(int maintenanceWorkId)
        {
            return await _context.MaintenanceWorks.FirstOrDefaultAsync(x => x.Id == maintenanceWorkId && !x.IsDeleted);
        }
       

        #endregion public methods

        #region private fields

        private readonly InoCarContext _context;


        #endregion private fields
    }
}
