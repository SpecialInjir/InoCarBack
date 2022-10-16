using InoCar.Api.Model;
using InoCar.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Services.Interfaces
{
    public interface ITimeSlotService
    {
      
        Task<ApiResponseMessage<bool>> UpdateTimeSlotAsync( int timeSlotId, TimeSlotDTO dto);
        Task<ApiResponseMessage<bool>> DeleteTimeSlotAsync( int timeSlotId);
    }
}
