using AutoMapper;
using InoCar.Api.Model;
using InoCar.Data.Entities;
using InoCar.Repositories;
using InoCar.Repositories.Interfaces;
using InoCar.Services.DTO;
using InoCar.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Services.Impl
{
    public class RecommendationServiceImpl : IRecommendationService
    {
        #region constructors
        public RecommendationServiceImpl(IRecommendationRepository recommendationRepository, IMapper mapper)
        {
            _recommendationRepository = recommendationRepository;
            _mapper = mapper;

        }
        #endregion constructors

        #region public methods
        public async Task<ApiResponseMessage<int>> AddRecommendationAsync(RecommendationDTO dto)
        {
            var result = new ApiResponseMessage<int>();
            try
            {
                Recommendation recommendation = _mapper.Map<Recommendation>(dto);
               
                await _recommendationRepository.AddRecommendationAsync(recommendation);
                result.IsSuccess = true;
                result.Result = recommendation.Id;
                result.Message = "recommendation added";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(AddRecommendationAsync)} - {ex}";
            }
            return result;
        }
        public ApiResponseMessage<ApiResponse<ApiRecommendation>> GetAllRecommendations()
        {
            var result = new ApiResponseMessage<ApiResponse<ApiRecommendation>>();
            try
            {
                var query = _recommendationRepository.GetAllRecommendation();
                Recommendation[] recommendations = query.ToArray();
                ApiRecommendation[] apiRecommendations = _mapper.Map<ApiRecommendation[]>(recommendations);
                ApiResponse<ApiRecommendation> apiResponse = new(apiRecommendations);

                result.IsSuccess = true;
                result.Result = apiResponse;
                result.Message = "Recommendations list received";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(GetAllRecommendations)} - {ex}";
            }
            return result;
        }
         public async  Task<ApiResponseMessage<bool>> DeleteRecommendationAsync(int recommendationId)
        {
            var result = new ApiResponseMessage<bool>();
            try
            {

                Recommendation? recommendation = await _recommendationRepository.GetRecommendationById(recommendationId);
                if (recommendation == null)
                {
                    result.IsSuccess = false;
                    result.Result = false;
                    result.Message = "Recommendation  not found";
                    return result;
                }
                recommendation.IsDeleted = true;

                await _recommendationRepository.UpdateRecommendationAsync(recommendation);
                result.IsSuccess = true;
                result.Result = true;
                result.Message = "Recommendation deleted";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(DeleteRecommendationAsync)} - {ex}";
            }
            return result;
        }
        public async Task<ApiResponseMessage<bool>> UpdateRecommendationAsync(int recommendationId, RecommendationDTO dto)
        {
            var result = new ApiResponseMessage<bool>();
            try
            {

                Recommendation? recommendation = await _recommendationRepository.GetRecommendationById(recommendationId);
                if (recommendation == null)
                {
                    result.IsSuccess = false;
                    result.Result = false;
                    result.Message = "Recommendation  not found";
                    return result;
                }
                recommendation.Description=dto.Description;
                recommendation.Price = dto.Price;
                await _recommendationRepository.UpdateRecommendationAsync(recommendation);
                result.IsSuccess = true;
                result.Result = true;
                result.Message = "Recommendation updated";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(UpdateRecommendationAsync)} - {ex}";
            }
            return result;
        }
        #endregion public methods

        #region private fields

        private readonly IMapper _mapper;
        private readonly IRecommendationRepository _recommendationRepository;

        #endregion private fields
    }
}
