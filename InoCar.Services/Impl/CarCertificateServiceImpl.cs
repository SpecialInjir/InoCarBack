using AutoMapper;
using InoCar.Api.Model;
using InoCar.Common;
using InoCar.Data.Entities;
using InoCar.Repositories;
using InoCar.Services.DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Services.Impl
{
    public class CarCertificateServiceImpl : ICarCertificateService
    {

        #region constructors
        public CarCertificateServiceImpl(IUserRepository userRepository, IMapper mapper,
            IConfiguration configuration, ICarCertificateRepository carCertificateRepository, ICarRepository carRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _configuration = configuration;
            _carCertificateRepository = carCertificateRepository;
            _carRepository = carRepository;

        }
        #endregion constructors


        #region public methods
      

        public async Task<ApiResponseMessage<int>> AddCarCertificateAsync(AddCarCertificateDTO dto, string UserId)
        {
            var result = new ApiResponseMessage<int>();

            try
            {
                CarCertificate carCertificate = _mapper.Map<CarCertificate>(dto);

                carCertificate.UserId = UserId;
                bool vinValidation = await _carCertificateRepository.CarCertificateExistsAsync(carCertificate);
                if (vinValidation) 
                {
                    result.IsSuccess = false;
                    result.Message = "This VIN or CTC passport already exist";
                    return result;
                }
               
                await _carCertificateRepository.AddCarCertificateAsync(carCertificate);
                result.IsSuccess = true;
                result.Message = "Car Certificate added";
                result.Result = carCertificate.Id;
                return result;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(AddCarCertificateAsync)} - {ex}";
            }

            return result;

            
        }

     


        public async Task<ApiResponseMessage<ApiCarDetails>> GetCarDetailsAsync(int carCertificateId)
        {
            var result = new ApiResponseMessage<ApiCarDetails>();

            try
            {
                var car = await _carRepository.GetCarByCertificateIdAsync(carCertificateId);
                if (car == null)
                {
                    result.IsSuccess = false;
                    result.Message = "Car not found";
                    return result;
                }

                ApiCarDetails apiCarDetails = _mapper.Map<ApiCarDetails>(car);
                result.IsSuccess = false;
                result.Message = "Car not found";
                result.Result = apiCarDetails;
                
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(GetCarDetailsAsync)} - {ex}";
            }


            return result;
        }



        #endregion public methods
        #region private fields

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly ICarCertificateRepository _carCertificateRepository;
        private readonly ICarRepository _carRepository;





        #endregion private fields
    }
}
