using InoCar.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Repositories.Interfaces
{
    public interface IRecommendationRepository
    {
        Task AddRecommendationAsync(Recommendation recommendation);
        IQueryable<Recommendation> GetAllRecommendation();
        Task UpdateRecommendationAsync(Recommendation recommendation);
       Task<Recommendation?> GetRecommendationById(int removeCarReasonId);
    }
}
