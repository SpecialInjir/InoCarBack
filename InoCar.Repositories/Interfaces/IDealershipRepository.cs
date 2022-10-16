using InoCar.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Repositories
{
    public interface IDealershipRepository
    {
        Task<IEnumerable<Dealership>> GetDealershipsByCityMarkAsync(string city, string mark);
        Task<IEnumerable<Dealership>> GetDealershipsByCityAsync(string city);
        Task<Dealership?> GetDealershipByIdAsync(int dealershipId);

        Task AddFeedbackAsync(DealershipFeedback dealershipFeedback);
        Task<DealershipFeedback?> GetFeedbackAsync(int dealershipFeedbackId);
        Task AddDealershipAsync(Dealership dealership);
        Task UpdateDealershipAsync(Dealership dealership);

    }
}
