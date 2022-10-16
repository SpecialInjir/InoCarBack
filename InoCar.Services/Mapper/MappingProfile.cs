using AutoMapper;
using InoCar.Api.Model;
using InoCar.Data.Entities;
using InoCar.Services.DTO;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace InoCar.Servises.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {



            CreateMap<RegistrationUserDTO, User>();

            CreateMap<AddPasswordDTO, LoginUserDTO>();
              
            CreateMap<User, RefreshToken>()
               .ForMember(dest => dest.UserId, y => y.MapFrom(src => src.Id))
               .ForMember(dest => dest.CreatedDate, y => y.MapFrom(src => DateTime.Now))
               .ForMember(dest => dest.UpdatedDate, y => y.MapFrom(src => DateTime.Now)) // не нужно
               .ForMember(dest => dest.IsActive, y => y.MapFrom(src => true));

            CreateMap<CreateUserDTO, User>();

            CreateMap<AddCarCertificateDTO, CarCertificate>();

            CreateMap<AddCarDTO, Car>();

            CreateMap<ServiceRequestDTO, ServiceRequest>();

            CreateMap<Car, ApiCar>();

            CreateMap<Dealership, ApiDealership>();

            CreateMap<ServiceConsultant, ApiConsultant>();

            //CreateMap<TimeSlot, ApiTimeSlot>();

            CreateMap<User, ApiUserProfile>();
         
            CreateMap<VisitReason, ApiVisitReason>();

            CreateMap<PersonalOffer, ApiPersonalOffer>();

            CreateMap<Recommendation, ApiRecommendation>();

            CreateMap<RemoveCarReason, ApiRemoveCarReason>();

            CreateMap<AddRemoveCarReasonDTO, RemoveCarReason>();

            CreateMap<Car, ApiCarEntry>();

            CreateMap<Dealership, ApiDealershipInformation>();

            CreateMap<Car, ApiCarDetails>();
            
                


            CreateMap<CarCertificate, ApiCarDetails>();

            CreateMap<CarDetails, ApiCarDetails>();

            CreateMap<ServiceRequest, ApiServiceRequestHistory>()
              .ForMember(dest => dest.Description, y => y.MapFrom(src => src.VisitReason.Description))
              .ForMember(dest => dest.EndTime, y => y.MapFrom(src => src.TimeSlot.EndTime));
            
            CreateMap<MaintenanceWork, ApiMaintenanceWork>();
            CreateMap<Car, ApiCar>();
            CreateMap<Dealership, ApiDealership>();
            CreateMap<VisitReason, ApiVisitReason>();
            CreateMap<ServiceConsultant, ApiServiceConsultant>();
            CreateMap<TimeSlot, ApiTimeSlot>()
                  .ForMember(dest => dest.TimeSlot, y => y.MapFrom(src => $"{src.StartTime.Hour} - {src.EndTime.Hour}"));
            CreateMap<ServiceRequest, ApiServiceRequest>();
            CreateMap<DealershipFeedbackDTO, DealershipFeedback>();
            CreateMap<DealershipFeedback, ApiDealershipFeedback>();
            CreateMap<DealershipDTO, Dealership>();
            CreateMap<ServiceConsultantDTO, ServiceConsultant>();
            CreateMap<VisitReasonDTO, VisitReason>();
            CreateMap<MaintenanceWorkDTO, MaintenanceWork>();
            CreateMap<TimeSlotDTO, TimeSlot>();
            CreateMap<RecommendationDTO, Recommendation>();
            CreateMap<PersonalOfferDTO, PersonalOffer>();
            CreateMap<ProductDTO, Product>();
            CreateMap<Product, ApiProduct>();
            CreateMap<Recommendation, ApiRecommendation>();
            CreateMap<PersonalOffer, ApiPersonalOffer>();
            CreateMap<ServiceConsultant, ApiConsultant>();
           


        }
}
}
