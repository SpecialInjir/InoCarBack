using AutoMapper;
using InoCar.Api.Model;
using InoCar.Data.Entities;
using InoCar.Data.Enums;
using InoCar.Repositories;
using InoCar.Services.DTO;
using InoCar.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Services.Impl
{
    
    public class ServiceRequestServiceImpl : IServiceRequest
    {
        #region constructors
        public ServiceRequestServiceImpl(IMapper mapper,
             IServiceRequestRepository serviceRequestRepository, IVisitReasonRepository visitReasonRepository,
             IServiceConsultantRepository serviceConsultantRepository, ICarRepository carRepository)
        {
           
            _mapper = mapper;
            _serviceRequestRepository = serviceRequestRepository;
            _visitReasonRepository = visitReasonRepository;
            _serviceConsultantRepository = serviceConsultantRepository;
            _carRepository = carRepository;
           
        }
        #endregion constructors

        #region public methods
        public async Task<bool> UserServiceRequestExistsAsync(string userId, int dealershipId) => await _serviceRequestRepository.UserServiceRequestExistsAsync(userId, dealershipId);
        public async Task<ApiResponseMessage<int>> AddServiceRequestAsync(ServiceRequestDTO dto, string UserId)
          {

            var result = new ApiResponseMessage<int>();
            try
            {

                ServiceRequest serviceRequest = _mapper.Map<ServiceRequest>(dto);

                serviceRequest.UserId = UserId;
                serviceRequest.RequestType = RequestTypes.CommercialRequest;


                if (serviceRequest.ServiceConsultantId == null)
                {
                    Random random = new();

                    List<ServiceConsultant> consultants = await _serviceConsultantRepository.GetConsultantsByDealershipIdAsync(serviceRequest.DealershipId);

                    serviceRequest.ServiceConsultantId = consultants[random.Next(consultants.Count)].Id;

                    List<TimeSlot> timeSlots = await _serviceConsultantRepository.GetConsultantsTimeSlotsAsync(serviceRequest.ServiceConsultantId.Value);

                    serviceRequest.TimeSlotId = timeSlots[random.Next(timeSlots.Count)].Id;

                }

                if (dto.Mileage != null)
                {
                    var maintenanceWorks = await _serviceRequestRepository.GetMaintenanceWorksAsync(dto.VisitReasonId, dto.Mileage.Value);
                    if (maintenanceWorks != null)
                    {
                        Decimal workSum = maintenanceWorks.Sum(x => x.Price);
                        Decimal productSum = 0;
                        foreach (var maintenanceWork in maintenanceWorks)
                        {
                            foreach (var product in maintenanceWork.Products)
                            {
                                var maxProduct = product.MileageLevels.MaxBy(x => x.Mileage);
                                productSum += (maxProduct != null && maxProduct.WorkTypes == WorkTypes.Replacement) ? product.Price : 0;
                            }

                        }
                        decimal totalSum = workSum + productSum;
                        serviceRequest.RequestPrice = totalSum;
                        serviceRequest.VisitReasonPrice = totalSum;
                    }
                    
                }
                else
                {
                    result.IsSuccess = false;
                    result.Message = "Service request not added";
                    return result;
                }

                await _serviceRequestRepository.AddServiceRequestAsync(serviceRequest);
                result.IsSuccess = true;
                result.Message = "Service request added";
                result.Result = serviceRequest.Id;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(AddServiceRequestAsync)} - {ex}";
            }

            return result;
           
        }

        
       public async Task<ApiResponseMessage<bool>> AddOffersAsync(AddOffersDTO dto)
        {
            var result = new ApiResponseMessage<bool>();
            try
            {
                var serviceRequest = await _serviceRequestRepository.GetServiceRequestsByIdAsync(dto.ServiceRequestId);
                if (serviceRequest != null && !serviceRequest.IsRequestConfirm)
                {

                    List<PersonalOfferServiceRequest> personalOfferServiceRequests = new();

                    Decimal personalOfferPrice = 0;
                    Decimal discount = 0;
                    foreach (int personalOfferId in dto.PersonalOfferIds)
                    {
                        PersonalOfferServiceRequest personalOfferServiceRequest = new();

                        personalOfferServiceRequest.PersonalOfferId = personalOfferId;
                        personalOfferServiceRequest.ServiceRequestId = dto.ServiceRequestId;
                        personalOfferServiceRequests.Add(personalOfferServiceRequest);
                        PersonalOffer? personalOffer = await _serviceRequestRepository.GetPersonalOfferByIdAsync(personalOfferId);
                        if (personalOffer == null)
                        {
                            result.IsSuccess = false;
                            result.Message = "Personal offer not found";
                            return result;
                        }
                        var products = await _serviceRequestRepository.GetProductByPersonalOfferIdAsync(personalOfferId);
                        if (products == null)
                        {
                            
                                result.IsSuccess = false;
                                result.Message = "Products not found";
                                return result;
                            
                        }
                        if (personalOffer.Products == null)
                        {
                            result.IsSuccess = false;
                            result.Message = "Personal product not found";
                            return result;
                        }
                        foreach (var product in products)
                        {
                            personalOfferPrice += product.Price - personalOffer.Discount;
                            discount += personalOffer.Discount;
                        }

                    }

                    serviceRequest.PersonalOffersPrice = personalOfferPrice;
                    serviceRequest.Discount = discount;
                    serviceRequest.RequestPrice += personalOfferPrice;
                    await _serviceRequestRepository.UpdateServiceRequest(serviceRequest);
                    await _serviceRequestRepository.AddOffersAsync(personalOfferServiceRequests);

                    result.IsSuccess = true;
                    result.Result = true;
                    result.Message = "Personal offers added";
                  
                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(AddOffersAsync)} - {ex}";
            }

            return result;


        }
        public async Task<ApiResponseMessage<bool>> AddRecommendationsAsync(AddRecommendationsDTO dto)
        {
            var result = new ApiResponseMessage<bool>();
            try
            {
                var serviceRequest = await _serviceRequestRepository.GetServiceRequestsByIdAsync(dto.ServiceRequestId);
                if (serviceRequest != null && !serviceRequest.IsRequestConfirm)
                {
                    Decimal recommendationPrice = 0;
                    
                    List<RecommendationServiceRequest> recommendationServiceRequests = new();

                    foreach (int recommendationId in dto.RecommedationIds)
                    {
                        RecommendationServiceRequest recommendationServiceRequest = new();

                        recommendationServiceRequest.RecommendationId = recommendationId;
                        recommendationServiceRequest.ServiceRequestId = dto.ServiceRequestId;
                        recommendationServiceRequests.Add(recommendationServiceRequest);
                        Recommendation? recommendation = await _serviceRequestRepository.GetRecommendationByIdAsync(recommendationId);
                        if (recommendation == null)
                        {
                            result.IsSuccess = false;
                            result.Message = "Recommendation not found";
                            return result;
                        }
                        recommendationPrice += recommendation.Price;
                    }
                    serviceRequest.RecommendationsPrice = recommendationPrice;
                    serviceRequest.RequestPrice += recommendationPrice;
                    await _serviceRequestRepository.UpdateServiceRequest(serviceRequest);
                   await _serviceRequestRepository.AddRecommendationsAsync(recommendationServiceRequests);

                    result.IsSuccess = true;
                    result.Result = true;
                    result.Message = "Recommendations added";
                }
                else
                {
                    result.IsSuccess = false;
                    result.Message = "Service Request not found";
                    return result;
                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(AddRecommendationsAsync)} - {ex}";
            }

            return result;

        }

        
        public async Task<ApiResponseMessage<ApiResponse<ApiPersonalOffer>>> GetPersonalOffersAsync(int serviceRequestId)
        {
            var result = new ApiResponseMessage<ApiResponse<ApiPersonalOffer>>();
            try
            {
                var serviceRequest = await _serviceRequestRepository.GetServiceRequestsByIdAsync(serviceRequestId);
                if (serviceRequest == null)
                {
                    result.IsSuccess = false;
                    result.Message = "Service Request not found";
                    return result;
                }
                var car = await _carRepository.GetCarByIdAsync(serviceRequest.CarId);
                var carBrand = "";
                if (car != null) carBrand = car.Mark;
                var serviceRequests = await _serviceRequestRepository.GetServiceRequestsByBrandAsync(carBrand, serviceRequest.UserId);
                if (serviceRequests == null)
                {
                    result.IsSuccess = false;
                    result.Message = "Service Requests not found";
                    return result;
                }
                Decimal servicesPrice = serviceRequests.Sum(x => x.RequestPrice);

                var personalOffers = await _serviceRequestRepository.GetPersonalOfferAsync(servicesPrice, carBrand);
              
                List<ApiPersonalOffer> apiPersonalOffers = _mapper.Map<List<ApiPersonalOffer>>(personalOffers);

                ApiResponse<ApiPersonalOffer> apiResponse = new(apiPersonalOffers);
                result.IsSuccess = true;
                result.Result = apiResponse;
                result.Message = "Personal offers received";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(GetPersonalOffersAsync)} - {ex}";
            }

            return result;

        }

        
        public async Task<ApiResponseMessage<ApiResponse<ApiRecommendation>>> GetRecommendationsAsync(int serviceRequestId)
        {
            var result = new ApiResponseMessage<ApiResponse<ApiRecommendation>>();
            try
            {
                var serviceRequest = await _serviceRequestRepository.GetServiceRequestsByIdAsync(serviceRequestId);
                if (serviceRequest == null)
                {
                    result.IsSuccess = false;
                    result.Message = "Service Request not found";
                    return result;
                }
                var query = await _visitReasonRepository.GetVisitReasonAsync();
                VisitReason[] visitReasons = query.Where(x => x.Type == VisitReasonTypes.BodyRepair).ToArray();

                Car? car = await _carRepository.GetCarByIdAsync(serviceRequest.CarId);
                if (car == null)
                {
                    result.IsSuccess = false;
                    result.Message = "Car not found";
                    return result;
                }

                var serviceRequests = await _serviceRequestRepository.GetServiceRequestsByBrandAsync(car.Mark, serviceRequest.UserId);
               
                var lastDate = serviceRequests.Max(x => x.CreateRequestDate);

                var interval = (DateTime.UtcNow.Month - lastDate.Month) + 12 * (DateTime.UtcNow.Year - lastDate.Year);


                List<ApiRecommendation> apiRecommendations = new();

                if (serviceRequest != null && serviceRequest.VisitReasonId == visitReasons.FirstOrDefault(x => x.Type == VisitReasonTypes.BodyRepair).Id
                    && interval >= 6)
                {

                    var recommendations = await _serviceRequestRepository.GetRecommendationAsync();

                    apiRecommendations = _mapper.Map<List<ApiRecommendation>>(recommendations);



                }
                ApiResponse<ApiRecommendation> apiResponse = new(apiRecommendations);

                result.IsSuccess = true;
                result.Result = apiResponse;
                result.Message = "Recommendations received";

            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(GetRecommendationsAsync)} - {ex}";
            }

            return result;
           

        }


        public async Task<ApiResponseMessage<ApiResponse<ApiServiceRequestHistory>>> GetCarServiceRequestsAsync(int carId)
        {
            var result = new ApiResponseMessage<ApiResponse<ApiServiceRequestHistory>>();
            try
            {
                var query = await _serviceRequestRepository.GetServiceRequestsByCarIdAsync(carId);

                ServiceRequest[] carServiceRequests = query.ToArray();

                List<ApiServiceRequestHistory> apiServiceRequests = _mapper.Map<List<ApiServiceRequestHistory>>(carServiceRequests);

                foreach (var apiServiceRequest in apiServiceRequests)
                {
                    foreach (var carServiceRequest in carServiceRequests)
                    {

                        apiServiceRequest.MaintenanceWorks = _mapper.Map<List<ApiMaintenanceWork>>(carServiceRequest.VisitReason.MaintenanceWorks);

                    }

                }

                ApiResponse<ApiServiceRequestHistory> apiResponse = new(apiServiceRequests);
                result.IsSuccess = true;
                result.Result = apiResponse;
                result.Message = "Service requests received";
            }

            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(GetCarServiceRequestsAsync)} - {ex}";
            }

            return result;

        }

        public async Task<ApiResponseMessage<ApiServiceRequest>> GetServiceRequestAsync(int serviceRequestId)
        {
            var result = new ApiResponseMessage<ApiServiceRequest>();
            try
            {
                var serviceRequest = await _serviceRequestRepository.GetServiceRequestsByIdAsync(serviceRequestId);
                if (serviceRequest == null)
                {
                    result.IsSuccess = false;
                    result.Message = "Service Request not found";
                    return result;
                }
                ApiServiceRequest apiServiceRequest = _mapper.Map<ApiServiceRequest>(serviceRequest);
                result.IsSuccess = true;
                result.Result = apiServiceRequest;
                result.Message = "Service request received";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(GetServiceRequestAsync)} - {ex}";
            }

            return result;
        }

        #endregion public methods

        #region private fields


        private readonly IMapper _mapper;
        private readonly IServiceRequestRepository _serviceRequestRepository;
        private readonly IVisitReasonRepository _visitReasonRepository;
        private readonly IServiceConsultantRepository _serviceConsultantRepository;
        private readonly ICarRepository _carRepository;

        #endregion private fields
    }
}
