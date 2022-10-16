using InoCar.Api.Model;
using InoCar.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Services.Interfaces
{
    public interface IRemoveCarReasonService
    {
        Task<ApiResponseMessage<ApiResponse<ApiRemoveCarReason>>> GetRemoveCarReasonsAsync();
        Task<ApiResponseMessage<int>> AddRemoveCarReasonAsync(AddRemoveCarReasonDTO dto);
        Task<ApiResponseMessage<bool>> UpdateRemoveCarReasonAsync(int removeCarReasonId, AddRemoveCarReasonDTO dto);
        Task<ApiResponseMessage<bool>> DeleteRemoveCarReasonAsync(int removeCarReasonId);
    }
}
