using InoCar.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Repositories
{
    public interface IVisitReasonRepository
    {
        Task<IEnumerable<VisitReason>> GetVisitReasonAsync();
        Task<VisitReason?> GetVisitReasonByIdAsync(int visitReasonId);
        Task AddVisitReasonAsync(VisitReason visitReason);
        Task AddMaintenanceWorkAsync(MaintenanceWork maintenanceWork);
        Task UpdateVisitReasonAsync(VisitReason visitReason);
    }
}
