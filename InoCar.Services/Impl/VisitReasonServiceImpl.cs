using AutoMapper;
using InoCar.Api.Model;
using InoCar.Data.Entities;
using InoCar.Repositories;
using InoCar.Services.DTO;
using InoCar.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Services.Impl
{
    public class VisitReasonServiceImpl : IVisitReasonService
    {

        #region constructors
        public VisitReasonServiceImpl(IVisitReasonRepository visitReasonRepository, IMapper mapper)
        {

            _visitReasonRepository = visitReasonRepository;
            _mapper = mapper;

        }
        #endregion constructors
        public async Task<ApiResponseMessage<ApiResponse<ApiVisitReason>>> GetVisitReasonAsync()
        {
            var result = new ApiResponseMessage<ApiResponse<ApiVisitReason>>();
            try
            {
                var visitReasons = await _visitReasonRepository.GetVisitReasonAsync();

                List<ApiVisitReason> apiVisitReasons = _mapper.Map<List<ApiVisitReason>>(visitReasons);

                ApiResponse<ApiVisitReason> apiResponse = new(apiVisitReasons);

                result.IsSuccess = true;
                result.Result = apiResponse;
                result.Message = "Visit reason received";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(GetVisitReasonAsync)} - {ex}";
            }

            return result;

        }

        public async Task<ApiResponseMessage<int>> AddVisitReasonAsync(VisitReasonDTO dto)
        {
            var result = new ApiResponseMessage<int>();
            try
            {
                VisitReason visitReason = _mapper.Map<VisitReason>(dto);
                await _visitReasonRepository.AddVisitReasonAsync(visitReason);
                result.IsSuccess = true;
                result.Result = visitReason.Id;
                result.Message = "VisitReason added";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(AddVisitReasonAsync)} - {ex}";
            }
            return result;
        }
        public async Task<ApiResponseMessage<bool>> UpdateVisitReasonAsync(int visitReasonId, VisitReasonDTO dto)
        {
            var result = new ApiResponseMessage<bool>();
            try
            {
                VisitReason? visitReason =await _visitReasonRepository.GetVisitReasonByIdAsync(visitReasonId);
                if (visitReason == null)
                {
                    result.IsSuccess = false;
                    result.Result = false;
                    result.Message = "VisitReason not found";
                    return result;
                }
                visitReason.Description = dto.Description;
                visitReason.Type = dto.Type;
                await _visitReasonRepository.UpdateVisitReasonAsync(visitReason);
                result.IsSuccess = true;
                result.Result =true;
                result.Message = "VisitReason updated";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(UpdateVisitReasonAsync)} - {ex}";
            }
            return result;
        }

        public async Task<ApiResponseMessage<bool>> DeleteVisitReasonAsync(int visitReasonId)
        {
            var result = new ApiResponseMessage<bool>();
            try
            {
                VisitReason? visitReason = await _visitReasonRepository.GetVisitReasonByIdAsync(visitReasonId);
                if (visitReason == null)
                {
                    result.IsSuccess = false;
                    result.Result = false;
                    result.Message = "VisitReason not found";
                    return result;
                }
                visitReason.IsDeleted = true;
              
                await _visitReasonRepository.UpdateVisitReasonAsync(visitReason);
                result.IsSuccess = true;
                result.Result = true;
                result.Message = "VisitReason deleted";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(DeleteVisitReasonAsync)} - {ex}";
            }
            return result;
        }
        public async Task<ApiResponseMessage<int>> AddMaintenanceWorkAsync(int visitReasonId, MaintenanceWorkDTO dto)
        {
            var result = new ApiResponseMessage<int>();
            try
            {
                MaintenanceWork maintenanceWork = _mapper.Map<MaintenanceWork>(dto);
                maintenanceWork.VisitReasonId = visitReasonId;
                await _visitReasonRepository.AddMaintenanceWorkAsync(maintenanceWork);
                result.IsSuccess = true;
                result.Result = maintenanceWork.Id;
                result.Message = "MaintenanceWork added";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(AddMaintenanceWorkAsync)} - {ex}";
            }
            return result;
        }
        #region private fields

        private readonly IVisitReasonRepository _visitReasonRepository;
        private readonly IMapper _mapper;



        #endregion private fields
    }
}
