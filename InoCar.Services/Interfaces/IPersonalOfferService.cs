using InoCar.Api.Model;
using InoCar.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Services.Interfaces
{
    public interface IPersonalOfferService
    {
        Task<ApiResponseMessage<int>> AddPersonalOfferAsync(PersonalOfferDTO dto);
        ApiResponseMessage<ApiResponse<ApiPersonalOffer>> GetAllPersonalOffers();
        Task<ApiResponseMessage<bool>> DeletePersonalOfferAsync(int personalOfferId);
        Task<ApiResponseMessage<bool>> UpdatePersonalOfferAsync(int personalOfferId, PersonalOfferDTO dto);
    }
}
