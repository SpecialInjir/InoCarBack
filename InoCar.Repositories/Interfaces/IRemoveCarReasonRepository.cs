using InoCar.Data.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Repositories
{
    public interface IRemoveCarReasonRepository
    {
        Task<IEnumerable<RemoveCarReason>> GetRemoveCarReasonsAsync();
        Task AddRemoveCarReasonAsync(RemoveCarReason removeCarReason);
        Task<RemoveCarReason?> GetRemoveCarReasonById(int removeCarReasonId);
        Task UpdateCarReasonAsync(RemoveCarReason removeCarReason);
    }
}
