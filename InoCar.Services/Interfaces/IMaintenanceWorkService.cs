using InoCar.Api.Model;
using InoCar.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Services.Interfaces
{
    public interface IMaintenanceWorkService
    {
         Task<ApiResponseMessage<bool>> UpdateMaintenanceWorkAsync(int maintenanceWorkId, MaintenanceWorkDTO dto);
         Task<ApiResponseMessage<bool>> DeleteMaintenanceWorkAsync(int maintenanceWorkId);
    }
}
