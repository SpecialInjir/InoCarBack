using InoCar.Api.Model;
using InoCar.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Repositories
{
    public interface IServiceRequestRepository
    {
        Task AddServiceRequestAsync(ServiceRequest serviceReques);
        Task<List<PersonalOffer>?> GetPersonalOfferAsync(Decimal servicesPrice, string brand);
        Task<IEnumerable<Recommendation>?> GetRecommendationAsync();
        Task<List<ServiceRequest>?> GetServiceRequestsByBrandAsync(string brand, string userId);
        Task<ServiceRequest?> GetServiceRequestsByIdAsync(int serviceRequestId);
        Task AddRecommendationsAsync(List<RecommendationServiceRequest> recommendations);
        Task AddOffersAsync(List<PersonalOfferServiceRequest> personalOffers);
        Task<List<MaintenanceWork>?> GetMaintenanceWorksAsync(int visitReasonId, int mileage);
        Task<IEnumerable<Product>?> GetProductByPersonalOfferIdAsync(int personalOfferId);
        Task<PersonalOffer?> GetPersonalOfferByIdAsync(int personalOfferId);
        Task<Recommendation?> GetRecommendationByIdAsync(int recommendationId);
        Task<IEnumerable<ServiceRequest>?> GetServiceRequestsByCarIdAsync(int carId);
        Task UpdateServiceRequest (ServiceRequest serviceRequest);
        Task<bool> UserServiceRequestExistsAsync(string userId, int dealershipId);

    }
}
