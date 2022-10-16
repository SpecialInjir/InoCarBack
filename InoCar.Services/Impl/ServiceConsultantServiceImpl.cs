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
    public class ServiceConsultantServiceImpl : IServiceConsultantService
    {
        #region constructors
        public ServiceConsultantServiceImpl(IServiceConsultantRepository serviceConsultantRepository, IMapper mapper)
        {
            _serviceConsultantRepository = serviceConsultantRepository;
            _mapper = mapper;

        }
        #endregion constructors

        #region public methods
        public async Task<ApiResponseMessage<ApiResponse<ApiConsultant>>> GetConsultantsByDealershipIdAsync(int dealershipId)
        {

            var result = new ApiResponseMessage<ApiResponse<ApiConsultant>>();
            try
            {
                var consultants = await _serviceConsultantRepository.GetConsultantsByDealershipIdAsync(dealershipId);
                List<ApiConsultant> apiConsultants = _mapper.Map<List<ApiConsultant>>(consultants);
                ApiResponse<ApiConsultant> apiResponse = new ApiResponse<ApiConsultant>(apiConsultants);
                result.IsSuccess = true;
                result.Result = apiResponse;
                result.Message = "Dealership consultants received";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(GetConsultantsByDealershipIdAsync)} - {ex}";
            }

            return result;


        }
        public async Task<ApiResponseMessage<ApiResponse<ApiConsultant>>> GetAllServiceConsultantAsync()
        {
            var result = new ApiResponseMessage<ApiResponse<ApiConsultant>>();
            try
            {
                var consultants = await _serviceConsultantRepository.GetAllConsultants();
                ApiConsultant[] apiConsultants = _mapper.Map<ApiConsultant[]>(consultants);
                ApiResponse<ApiConsultant> apiResponse = new ApiResponse<ApiConsultant>(apiConsultants);
                result.IsSuccess = true;
                result.Result = apiResponse;
                result.Message = "Consultants received";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(GetAllServiceConsultantAsync)} - {ex}";
            }

            return result;
        }
        public async Task<ApiResponseMessage<ApiResponse<ApiTimeSlot>>> GetConsultantsTimeSlotsAsync(int consultantId)
        {
            var result = new ApiResponseMessage<ApiResponse<ApiTimeSlot>>();
            try
            {
                var timeSlots = await _serviceConsultantRepository.GetConsultantsTimeSlotsAsync(consultantId);
                List<ApiTimeSlot> apiTimeSlots = _mapper.Map<List<ApiTimeSlot>>(timeSlots);
                ApiResponse<ApiTimeSlot> apiResponse = new ApiResponse<ApiTimeSlot>(apiTimeSlots);
                result.IsSuccess = true;
                result.Result = apiResponse;
                result.Message = "Consultants time slots received";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(GetConsultantsTimeSlotsAsync)} - {ex}";
            }

            return result;
        }
        public async Task<ApiResponseMessage<int>> AddServiceConsultantAsync(int dealershipId, ServiceConsultantDTO dto)
        {
            var result = new ApiResponseMessage<int>();
            try
            {
                ServiceConsultant serviceConsultant = _mapper.Map<ServiceConsultant>(dto);
                serviceConsultant.DealershipId = dealershipId;
                await _serviceConsultantRepository.AddServiceConsultantAsync(serviceConsultant);
                result.IsSuccess = true;
                result.Result = serviceConsultant.Id;
                result.Message = "Service-Consultant added";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(AddServiceConsultantAsync)} - {ex}";
            }
            return result;
        }
        public async Task<ApiResponseMessage<bool>> UpdateServiceConsultantAsync(int serviceConsultantId, ServiceConsultantDTO dto)
        {
            var result = new ApiResponseMessage<bool>();
            try
            {
                ServiceConsultant? serviceConsultant = await _serviceConsultantRepository.GetConsultantByIdAsync(serviceConsultantId);
                if (serviceConsultant == null)
                {
                    result.IsSuccess = false;
                    result.Message = "Service consultant not found";
                    result.Result = false;
                    return result;
                }
                serviceConsultant.FirstName = dto.FirstName;
                serviceConsultant.LastName = dto.LastName;
                await _serviceConsultantRepository.UpdateServiceConsultantAsync(serviceConsultant);
                result.IsSuccess = true;
                result.Result = true;
                result.Message = "Service-Consultant updated";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(UpdateServiceConsultantAsync)} - {ex}";
            }
            return result;
        }


        public async Task<ApiResponseMessage<bool>> DeleteServiceConsultantAsync(int serviceConsultantId)
        {
            var result = new ApiResponseMessage<bool>();
            try
            {
                ServiceConsultant? serviceConsultant = await _serviceConsultantRepository.GetConsultantByIdAsync(serviceConsultantId);
                if (serviceConsultant == null)
                {
                    result.IsSuccess = false;
                    result.Message = "Service consultant not found";
                    result.Result = false;
                    return result;
                }
               
                serviceConsultant.IsDeleted = true;
                await _serviceConsultantRepository.UpdateServiceConsultantAsync(serviceConsultant);
                result.IsSuccess = true;
                result.Result = true;
                result.Message = "Service-Consultant deleted";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(DeleteServiceConsultantAsync)} - {ex}";
            }
            return result;
        }

        public async Task<ApiResponseMessage<int>> AddTimeSlotAsync(int serviceConsultantId, TimeSlotDTO dto)
        {
            var result = new ApiResponseMessage<int>();
            try
            {
                TimeSlot timeSlot = _mapper.Map<TimeSlot>(dto);
                timeSlot.ServiceConsultantId = serviceConsultantId;
                await _serviceConsultantRepository.AddTimeSlotAsync(timeSlot);
                result.IsSuccess = true;
                result.Result = timeSlot.Id;
                result.Message = "Time Slot added";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(AddTimeSlotAsync)} - {ex}";
            }
            return result;
        }
        #endregion public methods

        #region private fields

        private readonly IMapper _mapper;
        private readonly IServiceConsultantRepository _serviceConsultantRepository;

        #endregion private fields
    }
}
