using AutoMapper;
using InoCar.Api.Model;
using InoCar.Data.Entities;
using InoCar.Data.Enums;
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
    public class RemoveCarReasonServiceImpl : IRemoveCarReasonService
    {
        #region constructors
        public RemoveCarReasonServiceImpl(IMapper mapper, IRemoveCarReasonRepository removeCarReasonRepository)
        {

            _removeCarReasonRepository = removeCarReasonRepository;
            _mapper = mapper;

        }
        #endregion constructors
        public async Task<ApiResponseMessage<ApiResponse<ApiRemoveCarReason>>> GetRemoveCarReasonsAsync()
        {
            var result = new ApiResponseMessage<ApiResponse<ApiRemoveCarReason>>();
            try
            {
                var query = await _removeCarReasonRepository.GetRemoveCarReasonsAsync();
                RemoveCarReason[] removeCarReasons = query.Where(x=>x.IsDeleted==false).ToArray();
                List<ApiRemoveCarReason> apiRemoveCarReasons = _mapper.Map<List<ApiRemoveCarReason>>(removeCarReasons);
                ApiResponse<ApiRemoveCarReason> apiResponse = new(apiRemoveCarReasons);
                result.IsSuccess = true;
                result.Result = apiResponse;
                result.Message = "Remove car reasons received";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(GetRemoveCarReasonsAsync)} - {ex}";
            }

            return result;
        }


        public async Task<ApiResponseMessage<int>> AddRemoveCarReasonAsync(AddRemoveCarReasonDTO dto)
        {
            var result = new ApiResponseMessage<int>();
            try
            {

                RemoveCarReason removeCarReason = _mapper.Map<RemoveCarReason>(dto);
                removeCarReason.Type = RemoveCarReasonTypes.CustomReason;
                await _removeCarReasonRepository.AddRemoveCarReasonAsync(removeCarReason);
                result.IsSuccess = true;
                result.Result = removeCarReason.Id;
                result.Message = "Remove car reason added";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(AddRemoveCarReasonAsync)} - {ex}";
            }
            return result;

        }
        public async Task<ApiResponseMessage<bool>> UpdateRemoveCarReasonAsync(int removeCarReasonId, AddRemoveCarReasonDTO dto)
        {
            var result = new ApiResponseMessage<bool>();
            try
            {

                RemoveCarReason? removeCarReason = await _removeCarReasonRepository.GetRemoveCarReasonById(removeCarReasonId);
                if (removeCarReason == null)
                {
                    result.IsSuccess = false;
                    result.Result = false;
                    result.Message = "Remove car reason not found";
                    return result;
                }
                removeCarReason.Description=dto.Description;
                 await _removeCarReasonRepository.UpdateCarReasonAsync(removeCarReason);
                result.IsSuccess = true;
                result.Result = true;
                result.Message = "Remove car reason updated";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(UpdateRemoveCarReasonAsync)} - {ex}";
            }
            return result;
        }
        public async Task<ApiResponseMessage<bool>> DeleteRemoveCarReasonAsync(int removeCarReasonId)
        {
            var result = new ApiResponseMessage<bool>();
            try
            {

                RemoveCarReason? removeCarReason = await _removeCarReasonRepository.GetRemoveCarReasonById(removeCarReasonId);
                if (removeCarReason == null)
                {
                    result.IsSuccess = false;
                    result.Result = false;
                    result.Message = "Remove car reason not found";
                    return result;
                }
                removeCarReason.IsDeleted=true;
                await _removeCarReasonRepository.UpdateCarReasonAsync(removeCarReason);
                result.IsSuccess = true;
                result.Result = true;
                result.Message = "Remove car reason deleted";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(DeleteRemoveCarReasonAsync)} - {ex}";
            }
            return result;
        }

        #region private fields

        private readonly IRemoveCarReasonRepository _removeCarReasonRepository;
        private readonly IMapper _mapper;



        #endregion private fields
    }
}

