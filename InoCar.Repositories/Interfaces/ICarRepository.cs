using InoCar.Data.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Repositories
{
    public interface ICarRepository
    {
        Task AddCarAsync(Car car);
        Task<Car?> GetCarByIdAsync(Int32 id);
        Task<Car?> GetCarByCertificateIdAsync(int certificateId);
        Task<IEnumerable<Car>> GetUserCarsAsync(string userId);
        Task DeleteCarByIdAsync(Car car);
        Task UpdateCarAsync(Car car);
    }
}
