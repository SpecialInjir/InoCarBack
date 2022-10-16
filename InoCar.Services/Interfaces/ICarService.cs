using InoCar.Api.Model;
using InoCar.Data.Entities;
using InoCar.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Services
{
    public interface ICarService
    {
        Task<ApiResponseMessage<int>> AddCarAsync(AddCarDTO dto);
        Task<ApiResponseMessage<ApiCar>> GetCarByIdAsync(int carId);
        Task<ApiResponseMessage<ApiResponse<ApiCar>>> GetUserCarsAsync(string userId);
        Task<ApiResponseMessage<ApiResponse<ApiCarEntry>>> GetUserCarsListAsync(string userId);
        Task<ApiResponseMessage<bool>> DeleteCarAsync(int carCertificateId, int removeCarReasonId);
        Task<ApiResponseMessage<bool>> SendCarCharacteristics(CarCharacteristicsRequestDTO dto, string userId);
        Task<ApiResponseMessage<bool>> UpdateCarAsync(int carId, UpdateCarDTO dto);
    }
}
