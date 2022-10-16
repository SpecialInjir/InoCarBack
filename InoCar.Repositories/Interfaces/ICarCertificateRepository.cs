using InoCar.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Repositories
{
    public interface ICarCertificateRepository
    {
        Task AddCarCertificateAsync(CarCertificate carCertificate);
        Task<CarCertificate> GetCarCertificateAsync(string userId);
        Task<bool> CarCertificateExistsAsync(CarCertificate carCertificate);
        Task<CarDetails?> GetCarDetailsAsync(int carCertificateId);
        Task<CarCertificate?> GetCarCertificateByIdAsync(int carCertificateId);
    }
}
