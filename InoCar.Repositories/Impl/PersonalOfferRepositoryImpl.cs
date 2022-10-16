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
    public class PersonalOfferRepositoryImpl : IPersonalOfferRepository
    {
        #region constructors

        public PersonalOfferRepositoryImpl(InoCarContext context)
        {
            _context = context;
        }

        #endregion constructors

        #region public methods

        public async Task  AddPersonalOfferAsync(PersonalOffer personalOffer)
        {
            await _context.PersonalOffers.AddAsync(personalOffer);
            await _context.SaveChangesAsync();
        }
       public  IQueryable<PersonalOffer> GetAllPersonalOffers()
        {
            return _context.PersonalOffers.Where(x => x.IsDeleted == false);
        }
        public async Task<PersonalOffer?> GetPersonalOfferByIdAsync(int personalOfferId) => await _context.PersonalOffers.FirstOrDefaultAsync(x => x.Id == personalOfferId && !x.IsDeleted);
        public async Task UpdatePersonalOfferAsync(PersonalOffer personalOffer)
        {
            _context.PersonalOffers.Update(personalOffer);
            await _context.SaveChangesAsync();
        }

        #endregion public methods

        #region private fields

        private readonly InoCarContext _context;


        #endregion private fields
    }
}
