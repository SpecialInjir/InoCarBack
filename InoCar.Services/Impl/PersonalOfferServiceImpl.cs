using AutoMapper;
using InoCar.Api.Model;
using InoCar.Data.Entities;
using InoCar.Repositories.Interfaces;
using InoCar.Services.DTO;
using InoCar.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Services.Impl
{
    public class PersonalOfferServiceImpl : IPersonalOfferService
    {
        #region constructors
        public PersonalOfferServiceImpl(IPersonalOfferRepository personalOfferRepository, IMapper mapper)
        {
            _personalOfferRepository = personalOfferRepository;
            _mapper = mapper;

        }
        #endregion constructors

        #region public methods
        public async Task<ApiResponseMessage<int>> AddPersonalOfferAsync(PersonalOfferDTO dto)
        {
            var result = new ApiResponseMessage<int>();
            try
            {
                PersonalOffer personalOffer = _mapper.Map<PersonalOffer>(dto);

                await _personalOfferRepository.AddPersonalOfferAsync(personalOffer);
                result.IsSuccess = true;
                result.Result = personalOffer.Id;
                result.Message = "Personal Offer added";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(AddPersonalOfferAsync)} - {ex}";
            }
            return result;
        }
        public ApiResponseMessage<ApiResponse<ApiPersonalOffer>> GetAllPersonalOffers()
        {
            var result = new ApiResponseMessage<ApiResponse<ApiPersonalOffer>>();
            try
            {
                var query = _personalOfferRepository.GetAllPersonalOffers();
                PersonalOffer[] personalOffers = query.ToArray();
                ApiPersonalOffer[] apiPersonalOffers = _mapper.Map<ApiPersonalOffer[]>(personalOffers);
                ApiResponse<ApiPersonalOffer> apiResponse = new(apiPersonalOffers);

                result.IsSuccess = true;
                result.Result = apiResponse;
                result.Message = "Personal Offers list received";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(GetAllPersonalOffers)} - {ex}";
            }
            return result;
        }
     
       public async Task<ApiResponseMessage<bool>> UpdatePersonalOfferAsync(int personalOfferId, PersonalOfferDTO dto)
        {
            var result = new ApiResponseMessage<bool>();
            try
            {

                PersonalOffer? personalOffer = await _personalOfferRepository.GetPersonalOfferByIdAsync(personalOfferId);
                if (personalOffer == null)
                {
                    result.IsSuccess = false;
                    result.Result = false;
                    result.Message = "Personal Offer  not found";
                    return result;
                }
                personalOffer.Description = dto.Description;
                personalOffer.Discount = dto.Discount;
                personalOffer.ActivatedPrice = dto.ActivatedPrice;
                personalOffer.Brand = dto.Brand;
                personalOffer.EndDate = dto.EndDate;
                await _personalOfferRepository.UpdatePersonalOfferAsync(personalOffer);
                result.IsSuccess = true;
                result.Result = true;
                result.Message = "Personal Offer updated";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(UpdatePersonalOfferAsync)} - {ex}";
            }
            return result;
        }
        public async Task<ApiResponseMessage<bool>> DeletePersonalOfferAsync(int personalOfferId)
        {
            var result = new ApiResponseMessage<bool>();
            try
            {

                PersonalOffer? personalOffer = await _personalOfferRepository.GetPersonalOfferByIdAsync(personalOfferId);
                if (personalOffer == null)
                {
                    result.IsSuccess = false;
                    result.Result = false;
                    result.Message = "Personal Offer  not found";
                    return result;
                }
                personalOffer.IsDeleted=true;
                await _personalOfferRepository.UpdatePersonalOfferAsync(personalOffer);
                result.IsSuccess = true;
                result.Result = true;
                result.Message = "Personal Offer deleted";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(DeletePersonalOfferAsync)} - {ex}";
            }
            return result;
        }
    

        #endregion public methods

        #region private fields

        private readonly IMapper _mapper;
        private readonly IPersonalOfferRepository _personalOfferRepository;

        #endregion private fields
    }
}
