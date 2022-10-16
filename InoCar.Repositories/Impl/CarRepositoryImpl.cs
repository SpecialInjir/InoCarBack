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
    public class CarRepositoryImpl: ICarRepository
    {
        #region constructors

        public CarRepositoryImpl(InoCarContext context)
        {
            _context = context;
        }

        #endregion constructors

        #region public methods
        public async Task AddCarAsync(Car car)
        {

            await _context.Cars.AddAsync(car);

            await _context.SaveChangesAsync();

        }
        public  async Task<Car?> GetCarByIdAsync(int carId)
        {
            return await _context.Cars.Include(x => x.CarCertificate).
                FirstOrDefaultAsync(x => x.Id == carId);
        }

        public  async Task<IEnumerable<Car>> GetUserCarsAsync(string userId)
        {
            return await _context.CarCertificates.Where(x => x.UserId == userId)
                  .Include(x => x.Car).Where(x=>!x.Car.IsDeleted)
                  .Select(x => new Car()
                  {
                      Id = x.Car.Id,

                      StateNumber = x.Car.StateNumber,

                      Model = x.Car.Model,

                      Mark = x.Car.Mark,

                      ImgUrl = x.Car.ImgUrl,

                      CertificateId = x.Car.CertificateId
                  }).ToArrayAsync();
                  

        }


        public async Task<Car?> GetCarByCertificateIdAsync(int certificateId)
        {
            return await _context.Cars
                .Include(x => x.CarCertificate)
                .ThenInclude(x => x.CarDetails)
                .FirstOrDefaultAsync(x => x.CertificateId == certificateId);

        }

        public  async Task DeleteCarByIdAsync(Car car)
        {

            _context.Cars.Update(car);

            await _context.SaveChangesAsync();

        }

        public async Task UpdateCarAsync(Car car)
        {

            _context.Cars.Update(car);

            await _context.SaveChangesAsync();

        }
        #endregion public methods

        #region private fields

        private readonly InoCarContext _context;


        #endregion private fields
    }
}
