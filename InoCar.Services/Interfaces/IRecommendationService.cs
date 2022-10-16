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
    public interface IRecommendationService
    {
        Task<ApiResponseMessage<int>> AddRecommendationAsync(RecommendationDTO dto);
        ApiResponseMessage<ApiResponse<ApiRecommendation>> GetAllRecommendations();
        Task<ApiResponseMessage<bool>> DeleteRecommendationAsync(int recommendationId);
        Task<ApiResponseMessage<bool>> UpdateRecommendationAsync(int recommendationId, RecommendationDTO dto);

    }
}
