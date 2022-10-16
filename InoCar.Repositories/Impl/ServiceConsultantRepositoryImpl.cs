using InoCar.Data;
using InoCar.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Repositories.Impl
{
    public class ServiceConsultantRepositoryImpl : IServiceConsultantRepository
    {
        #region constructors

        public ServiceConsultantRepositoryImpl(InoCarContext context)
        {
            _context = context;
        }

        #endregion constructors

        #region public methods

        public async Task<List<ServiceConsultant>> GetConsultantsByDealershipIdAsync(int dealershipId)
        {

            return await _context.ServiceConsultants.Where(x => x.DealershipId== dealershipId && !x.IsDeleted)
                  .ToListAsync();
        }

        public async Task<List<TimeSlot>> GetConsultantsTimeSlotsAsync(int consultantId)
        {
            return await _context.TimeSlots.Where(x => x.ServiceConsultantId == consultantId && !x.IsDeleted)
                  .ToListAsync();
        }

        public async Task<ServiceConsultant?> GetConsultantByIdAsync(int consultantId) => await _context.ServiceConsultants.FirstOrDefaultAsync(x=>x.Id==consultantId && !x.IsDeleted);
        public  async Task<TimeSlot?> GetTimeSlotByIdAsync(int timeSlotId)=> await _context.TimeSlots.FirstOrDefaultAsync(x=>x.Id==timeSlotId && !x.IsDeleted);
        public async Task AddServiceConsultantAsync(ServiceConsultant serviceConsultant)
        {
            await _context.ServiceConsultants.AddAsync(serviceConsultant);

            await _context.SaveChangesAsync();
        }
        public async Task AddTimeSlotAsync(TimeSlot timeSlot)
        {
            await _context.TimeSlots.AddAsync(timeSlot);

            await _context.SaveChangesAsync();
        }

       public async Task<IEnumerable<ServiceConsultant>> GetAllConsultants()
        {
            return await _context.ServiceConsultants

                 .ToArrayAsync();
        }

       public async Task UpdateServiceConsultantAsync(ServiceConsultant serviceConsultant)
        {
             _context.ServiceConsultants.Update(serviceConsultant);
            await _context.SaveChangesAsync();

        }
        #endregion public methods

        #region private fields

        private readonly InoCarContext _context;

        #endregion private fields
    }
}
