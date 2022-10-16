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
    public class RecommendationRepositoryImpl: IRecommendationRepository
    {
        #region constructors

        public RecommendationRepositoryImpl(InoCarContext context)
        {
            _context = context;
        }

        #endregion constructors

        #region public methods

        public async Task AddRecommendationAsync(Recommendation recommendation)
        {
            await _context.Recommendations.AddAsync(recommendation);
            await _context.SaveChangesAsync();
        }
        public IQueryable<Recommendation> GetAllRecommendation() => _context.Recommendations.Where(x => x.IsDeleted == false);
           
        public async Task UpdateRecommendationAsync(Recommendation recommendation)
        {
             _context.Recommendations.Update(recommendation);
            await _context.SaveChangesAsync();
        }
        public async Task<Recommendation?> GetRecommendationById(int removeCarReasonId) => await _context.Recommendations.FirstOrDefaultAsync(x => x.Id == removeCarReasonId && !x.IsDeleted);

        #endregion public methods

        #region private fields

        private readonly InoCarContext _context;


        #endregion private fields
    }
}
