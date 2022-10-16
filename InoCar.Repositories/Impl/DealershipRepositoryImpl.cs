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
    public class DealershipRepositoryImpl : IDealershipRepository
    {
        #region constructors

        public DealershipRepositoryImpl(InoCarContext context)
        {
            _context = context;
        }

        #endregion constructors

        #region public methods
        public async Task<IEnumerable<Dealership>> GetDealershipsByCityMarkAsync(string city, string mark)
        {
            return  await _context.Dealerships.Where(x => x.Name.ToLower().Contains(city.ToLower()) && x.Brand.ToLower() == mark.ToLower() && !x.IsDeleted)
                    .Select(x => new Dealership()
                    {
                        Id = x.Id,

                        Name = x.Name

                    }).ToArrayAsync();

        }

        public async Task<IEnumerable<Dealership>> GetDealershipsByCityAsync(string city)
        {
            return await _context.Dealerships.Where(x => x.Address.Contains(city) && !x.IsDeleted)
                  .ToArrayAsync();

        }

        public async Task<Dealership?> GetDealershipByIdAsync(int dealershipId)
        {
            return await _context.Dealerships.FirstOrDefaultAsync(x => x.Id == dealershipId && !x.IsDeleted);

        }

        public async Task<DealershipFeedback?> GetFeedbackAsync(int dealershipFeedbackId) => await _context.DealershipFeedbacks.FirstOrDefaultAsync(x => x.Id == dealershipFeedbackId);

        public async Task AddFeedbackAsync(DealershipFeedback dealershipFeedback)
        {
            await _context.DealershipFeedbacks.AddAsync(dealershipFeedback);

            await _context.SaveChangesAsync();
        }

        public async Task AddDealershipAsync(Dealership dealership)
        {
            await _context.Dealerships.AddAsync(dealership);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateDealershipAsync(Dealership dealership)
        {
            _context.Dealerships.Update(dealership);

            await _context.SaveChangesAsync();
        }
        #endregion public methods

        #region private fields

        private readonly InoCarContext _context;


        #endregion private fields
    }
}
