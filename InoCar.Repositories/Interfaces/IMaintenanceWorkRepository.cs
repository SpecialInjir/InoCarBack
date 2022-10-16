using InoCar.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Repositories.Interfaces
{
    public interface IMaintenanceWorkRepository
    {
       Task<MaintenanceWork?> GetMaintenanceWorkByIdAsync(int maintenanceWorkId);
       Task UpdateMaintenanceWorkAsync(MaintenanceWork maintenanceWork);
    }
}
