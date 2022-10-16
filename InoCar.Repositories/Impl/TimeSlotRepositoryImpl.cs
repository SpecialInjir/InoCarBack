using InoCar.Data;
using InoCar.Data.Entities;
using InoCar.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Repositories.Impl
{
    public class TimeSlotRepositoryImpl : ITimeSlotRepository
    {
        #region constructors

        public TimeSlotRepositoryImpl(InoCarContext context)
        {
            _context = context;
        }

        #endregion constructors

        #region public methods


      
        public async Task UpdateTimeSlotAsync(TimeSlot timeSlot)
        {
            _context.TimeSlots.Update(timeSlot);
            await _context.SaveChangesAsync();
        }
        public async Task<TimeSlot?> GetTimeSlotByIdAsync(int timeSlotId) => await _context.TimeSlots.FirstOrDefaultAsync(x => x.Id == timeSlotId && !x.IsDeleted);

        #endregion public methods

        #region private fields

        private readonly InoCarContext _context;


        #endregion private fields
    }
}
