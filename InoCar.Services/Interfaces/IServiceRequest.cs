using InoCar.Api.Model;
using InoCar.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Services.Interfaces
{
    public interface IServiceRequest
    {
        Task<ApiResponseMessage<int>> AddServiceRequestAsync(ServiceRequestDTO dto, string Id);
        Task<ApiResponseMessage<bool>> AddOffersAsync(AddOffersDTO dto);
        Task<ApiResponseMessage<bool>> AddRecommendationsAsync(AddRecommendationsDTO dto);
        Task<ApiResponseMessage<ApiResponse<ApiPersonalOffer>>> GetPersonalOffersAsync(int serviceRequestId);
        Task<ApiResponseMessage<ApiResponse<ApiRecommendation>>> GetRecommendationsAsync(int serviceRequestId);
        Task<ApiResponseMessage<ApiResponse<ApiServiceRequestHistory>>> GetCarServiceRequestsAsync(int carId);
        Task<ApiResponseMessage<ApiServiceRequest>> GetServiceRequestAsync(int serviceRequestId);
        Task<bool> UserServiceRequestExistsAsync(string userId, int dealershipId);
      

    }
}
