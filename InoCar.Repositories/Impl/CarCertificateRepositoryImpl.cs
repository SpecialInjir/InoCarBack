using InoCar.Data;
using InoCar.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Repositories.Impl
{
    public class CarCertificateRepositoryImpl : ICarCertificateRepository
    {
        #region constructors

        public CarCertificateRepositoryImpl(InoCarContext context)
        {
            _context = context;
        }

        #endregion constructors

        #region public methods
        public async Task<CarCertificate> GetCarCertificateAsync(string userId) => await _context.CarCertificates.FirstOrDefaultAsync(x => x.UserId == userId);

        public async Task<bool> CarCertificateExistsAsync(CarCertificate carCertificate)
        {
            CarCertificate results = (CarCertificate) await _context.CarCertificates.FirstOrDefaultAsync(x => x.VIN == carCertificate.VIN

       || (x.SeriaCTC == carCertificate.SeriaCTC && x.NumberCTC == carCertificate.NumberCTC));

            if (results != null) return true;
            else return false;

        }

        public async Task AddCarCertificateAsync(CarCertificate carCertificate)
        {

            await _context.CarCertificates.AddAsync(carCertificate);

            await _context.SaveChangesAsync();

        }

       public async Task<CarDetails?> GetCarDetailsAsync(int carCertificateId) => await _context.CarDetails.FirstOrDefaultAsync(x => x.CertificateId == carCertificateId);
       public async Task<CarCertificate?> GetCarCertificateByIdAsync(int carCertificateId) => await _context.CarCertificates.FirstOrDefaultAsync(x => x.Id == carCertificateId);


        #endregion public methods

        #region private fields

        private readonly InoCarContext _context;


        #endregion private fields

    }
}
