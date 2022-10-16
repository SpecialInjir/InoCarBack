using InoCar.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Repositories.Interfaces
{
    public interface ITimeSlotRepository
    {
        Task<TimeSlot?> GetTimeSlotByIdAsync(int timeSlotId);
        Task UpdateTimeSlotAsync(TimeSlot timeSlot);
    }
}
