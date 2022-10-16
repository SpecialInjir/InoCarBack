using AutoMapper;
using InoCar.Api.Model;
using InoCar.Data.Entities;
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
    public class TimeSlotServiceImpl : ITimeSlotService
    {
        #region constructors
        public TimeSlotServiceImpl(ITimeSlotRepository timeSlotRepository, IMapper mapper)
        {
            _timeSlotRepository = timeSlotRepository;
            _mapper = mapper;

        }
        #endregion constructors
        #region public methods


        public async Task<ApiResponseMessage<bool>> UpdateTimeSlotAsync(int timeSlotId, TimeSlotDTO dto)
        {
            var result = new ApiResponseMessage<bool>();
            try
            {
                TimeSlot? timeSlot = await _timeSlotRepository.GetTimeSlotByIdAsync(timeSlotId);
                if (timeSlot == null)
                {
                    result.IsSuccess = false;
                    result.Result = false;
                    result.Message = "Time Slot not found";
                    return result;
                }
                timeSlot.StartTime=dto.StartTime;
                timeSlot.EndTime = dto.EndTime;
                await _timeSlotRepository.UpdateTimeSlotAsync(timeSlot);
                result.IsSuccess = true;
                result.Result = true;
                result.Message = "Time Slot updated";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(UpdateTimeSlotAsync)} - {ex}";
            }
            return result;
        }
        public async Task<ApiResponseMessage<bool>> DeleteTimeSlotAsync(int timeSlotId)
        {
            var result = new ApiResponseMessage<bool>();
            try
            {
                TimeSlot? timeSlot = await _timeSlotRepository.GetTimeSlotByIdAsync(timeSlotId);
                if (timeSlot == null)
                {
                    result.IsSuccess = false;
                    result.Result = false;
                    result.Message = "Time Slot not found";
                    return result;
                }
                timeSlot.IsDeleted = true;
                await _timeSlotRepository.UpdateTimeSlotAsync(timeSlot);
                result.IsSuccess = true;
                result.Result = true;
                result.Message = "Time Slot deleted";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(DeleteTimeSlotAsync)} - {ex}";
            }
            return result;
        }
        #endregion public methods

        #region private fields

        private readonly IMapper _mapper;
        private readonly ITimeSlotRepository _timeSlotRepository;

        #endregion private fields
    }
}
