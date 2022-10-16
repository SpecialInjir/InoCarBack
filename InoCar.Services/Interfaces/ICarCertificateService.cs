using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InoCar.Api.Model;
using InoCar.Data.Entities;
using InoCar.Services.DTO;

namespace InoCar.Services
{
    public interface ICarCertificateService
    {
       
        Task<ApiResponseMessage<int>> AddCarCertificateAsync(AddCarCertificateDTO dto, string userId);
        Task<ApiResponseMessage<ApiCarDetails>> GetCarDetailsAsync(int carCertificateId);

    }
}
