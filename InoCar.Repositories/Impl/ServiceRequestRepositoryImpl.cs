
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
    public class ServiceRequestRepositoryImpl : IServiceRequestRepository
    {
        private const int MaxMileageDifference = 10000;
        #region constructors

        public ServiceRequestRepositoryImpl(InoCarContext context)
        {
            _context = context;
        }

        #endregion constructors

        #region public methods
        public async Task<bool> UserServiceRequestExistsAsync(string userId, int dealershipId) => await _context.ServiceRequests.AnyAsync(x => x.DealershipId == dealershipId && x.UserId == userId);
        public async Task AddServiceRequestAsync(ServiceRequest serviceRequest)
        {

            await _context.ServiceRequests.AddAsync(serviceRequest);

            await _context.SaveChangesAsync();

        }

      
        public async Task<List<PersonalOffer>?> GetPersonalOfferAsync(Decimal servicesPrice, string brand)
        {
            var dateNow = DateTime.UtcNow;
            return await _context.PersonalOffers.Where(x=>x.Brand == brand && x.EndDate <= dateNow
            && x.ActivatedPrice <= servicesPrice && !x.IsDeleted)
                .ToListAsync();

        }
      

        public async Task<IEnumerable<Recommendation>?> GetRecommendationAsync()
        {
            return await _context.Recommendations
                .ToListAsync();
        }

        public async Task<List<ServiceRequest>?> GetServiceRequestsByBrandAsync(string brand, string userId)
        {
            return await _context.ServiceRequests
                .Include(x => x.VisitReason)
                .Include(x=>x.Car)
                .Where(x => x.UserId == userId && x.Car.Mark==brand)
                .ToListAsync();
           
        }

        public async Task<List<MaintenanceWork>?> GetMaintenanceWorksAsync(int visitReasonId, int mileage)
        {
           
            return await _context.MaintenanceWorks.Where(x => x.VisitReasonId == visitReasonId && !x.IsDeleted)
                .Include(x => x.Products)
                .ThenInclude( x=> x.MileageLevels
                .Where(x => x.Mileage <= mileage && (mileage-x.Mileage)<= MaxMileageDifference))
                .ToListAsync();

    
        }


        public async Task<ServiceRequest?> GetServiceRequestsByIdAsync(int serviceRequestId)
        {
            return await _context.ServiceRequests
                .Include(x => x.Car)
                .Include(x => x.Dealership)
                .Include(x => x.VisitReason)
                .Include(x => x.ServiceConsultant)
                .Include(x => x.TimeSlot)
                .FirstOrDefaultAsync(x => x.Id == serviceRequestId);

        }

        public async Task<IEnumerable<ServiceRequest>?> GetServiceRequestsByCarIdAsync(int carId)
        {
            return await _context.ServiceRequests.Where(x => x.CarId == carId)
                .Include(x=>x.VisitReason)
                .ThenInclude(x=>x.MaintenanceWorks)
                .Include(x=>x.TimeSlot)
                .ToArrayAsync();


        }

        public async Task AddRecommendationsAsync(List<RecommendationServiceRequest> recommendations) 
        {
            await _context.RecommendationServiceRequests.AddRangeAsync(recommendations); 

            await _context.SaveChangesAsync();

        }
          
        public async Task AddOffersAsync(List<PersonalOfferServiceRequest> personalOffers)
        {

            await _context.PersonalOfferServiceRequests.AddRangeAsync(personalOffers);

            await _context.SaveChangesAsync();
        }

        public async Task<PersonalOffer?> GetPersonalOfferByIdAsync(int personalOfferId)
        {
            return await _context.PersonalOffers.FirstOrDefaultAsync(x => x.Id == personalOfferId && !x.IsDeleted);
             
        }



        public async Task<Recommendation?> GetRecommendationByIdAsync(int recommendationId)
        {
            return await _context.Recommendations.FirstOrDefaultAsync(x => x.Id == recommendationId);


        }
        public async Task<IEnumerable<Product>?> GetProductByPersonalOfferIdAsync(int personalOfferId)
        {
            return await _context.Products.Where(x => x.PersonalOfferId == personalOfferId && !x.IsDeleted)
                .ToArrayAsync();
;        }

        public async  Task UpdateServiceRequest(ServiceRequest serviceRequest) 
        {
            _context.ServiceRequests.Update(serviceRequest);

            await _context.SaveChangesAsync();
        }

        #endregion public methods

        #region private fields

        private readonly InoCarContext _context;
        


        #endregion private fields
        
    }
}
