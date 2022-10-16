using InoCar.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Repositories.Interfaces
{
    public interface IPersonalOfferRepository
    {
        Task AddPersonalOfferAsync(PersonalOffer personalOffer);
        IQueryable<PersonalOffer> GetAllPersonalOffers();
        Task<PersonalOffer?> GetPersonalOfferByIdAsync(int personalOfferId);
        Task UpdatePersonalOfferAsync(PersonalOffer personalOffer);
    }
}
