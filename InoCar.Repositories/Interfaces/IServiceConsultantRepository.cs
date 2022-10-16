using InoCar.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Repositories
{
    public interface IServiceConsultantRepository
    {
        Task<List<ServiceConsultant>> GetConsultantsByDealershipIdAsync(int dealershipId);
        Task<List<TimeSlot>> GetConsultantsTimeSlotsAsync(int consultantId);
        Task<ServiceConsultant?> GetConsultantByIdAsync(int consultantId);
        Task<TimeSlot?> GetTimeSlotByIdAsync(int timeSlotId);
        Task AddServiceConsultantAsync(ServiceConsultant serviceConsultant);
        Task AddTimeSlotAsync(TimeSlot timeSlot);
        Task<IEnumerable<ServiceConsultant>> GetAllConsultants();
        Task UpdateServiceConsultantAsync(ServiceConsultant serviceConsultant);
    }
}
