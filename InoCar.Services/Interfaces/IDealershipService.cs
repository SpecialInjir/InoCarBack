using InoCar.Api.Model;
using InoCar.Data.Entities;
using InoCar.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Services.Interfaces
{
    public interface IDealershipService
    {
        Task<ApiResponseMessage<ApiResponse<ApiDealership>>> GetDealershipsAsync(string city, int carId);
        Task<ApiResponseMessage<ApiResponse<ApiDealershipInformation>>> GetDealershipsAllAsync(string userId);
        Task<ApiResponseMessage<ApiDealershipInformation>> GetDealershipByIdAsync(int dealershipId);
        Task<ApiResponseMessage<int>>  AddFeedbackAsync(int dealershipId, DealershipFeedbackDTO dto);
        Task<ApiResponseMessage<ApiDealershipFeedback>> GetFeedbackAsync(int dealershipId);
        Task<ApiResponseMessage<int>> AddDealershipAsync(DealershipDTO dto);
        Task<ApiResponseMessage<bool>> UpdateDealershipAsync(int dealershipId, DealershipDTO dto);
        Task<ApiResponseMessage<bool>> DeleteDealershipAsync(int dealershipId);

    }
}
