using InoCar.Api.Model;
using InoCar.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Services.Interfaces
{
    public interface IServiceConsultantService
    {
        Task<ApiResponseMessage<ApiResponse<ApiConsultant>>> GetConsultantsByDealershipIdAsync(int dealershipId);
        Task<ApiResponseMessage<ApiResponse<ApiTimeSlot>>> GetConsultantsTimeSlotsAsync(int consultantId);
        Task<ApiResponseMessage<int>> AddServiceConsultantAsync(int dealershipId,ServiceConsultantDTO dto);
        Task<ApiResponseMessage<int>> AddTimeSlotAsync(int serviceConsultantId, TimeSlotDTO dto);
        Task<ApiResponseMessage<ApiResponse<ApiConsultant>>> GetAllServiceConsultantAsync();
        Task<ApiResponseMessage<bool>> UpdateServiceConsultantAsync(int serviceConsultantId, ServiceConsultantDTO dto);
        Task<ApiResponseMessage<bool>> DeleteServiceConsultantAsync(int serviceConsultantId);
    }
}
