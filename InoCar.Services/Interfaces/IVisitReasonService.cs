using InoCar.Api.Model;
using InoCar.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Services.Interfaces
{
    public interface IVisitReasonService
    {
        Task<ApiResponseMessage<ApiResponse<ApiVisitReason>>> GetVisitReasonAsync();
        Task<ApiResponseMessage<int>> AddVisitReasonAsync(VisitReasonDTO dto);
        Task<ApiResponseMessage<int>> AddMaintenanceWorkAsync(int visitReasonId, MaintenanceWorkDTO dto);
        Task<ApiResponseMessage<bool>> UpdateVisitReasonAsync(int visitReasonId, VisitReasonDTO dto);
        Task<ApiResponseMessage<bool>> DeleteVisitReasonAsync(int visitReasonId);
    }

}
