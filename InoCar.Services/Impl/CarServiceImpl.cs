using AutoMapper;
using InoCar.Data.Entities;
using InoCar.Data.Enums;
using InoCar.Repositories;
using InoCar.Services.DTO;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using MailKit.Net.Smtp;
using System.Text;
using System.Threading.Tasks;
using MailKit.Security;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using InoCar.Api.Model;
using HandlebarsDotNet;

namespace InoCar.Services.Impl
{
    public class CarServiceImpl:ICarService
    {
        private readonly string OnTheService = "Находится на сервисе";
        #region constructors
        public CarServiceImpl(ICarRepository carRepository, IUserRepository userRepository,
            IMapper mapper, IServiceRequestRepository serviceRequestRepository, IUserCodeService userCodeService)
        {
            _carRepository = carRepository;
            _userRepository = userRepository;
            _mapper = mapper;
            _serviceRequestRepository = serviceRequestRepository;
            _userCodeService = userCodeService;

        }
        #endregion constructors

        #region public methods
        public async Task<ApiResponseMessage<int>> AddCarAsync(AddCarDTO dto)
        {
            var result = new ApiResponseMessage<int>();
            try
            {
                Car car = _mapper.Map<Car>(dto);
                car.CertificateId = dto.CarCertificateId;
                await _carRepository.AddCarAsync(car);
                result.IsSuccess = true;
                result.Result=car.Id;
                result.Message = "Car added";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(AddCarAsync)} - {ex}";
               
            }

            return result;
          
        }

        public async Task<ApiResponseMessage<ApiResponse<ApiCar>>> GetUserCarsAsync(string userId)
        {
            var result = new ApiResponseMessage<ApiResponse<ApiCar>>();
            try
            {
                var query = await _carRepository.GetUserCarsAsync(userId);
                Car[] userCars = query.Cast<Car>().Where(x => !x.IsDeleted).ToArray();
                List<ApiCar> apiCars = _mapper.Map<List<ApiCar>>(userCars);
                ApiResponse<ApiCar> apiResponse = new(apiCars);
                result.IsSuccess = true;
                result.Result = apiResponse;
                result.Message = "Cars list received";

            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(GetUserCarsAsync)} - {ex}";

            }

            return result;

        }

        public async Task<ApiResponseMessage<ApiResponse<ApiCarEntry>>> GetUserCarsListAsync(string userId)
        {
            var result = new ApiResponseMessage<ApiResponse<ApiCarEntry>>();
            try
            {

                var query = await _carRepository.GetUserCarsAsync(userId);
                Car[] cars = query.Where(x => !x.IsDeleted).ToArray();

                List<ApiCarEntry> apiCars = _mapper.Map<List<ApiCarEntry>>(cars);

                foreach (var apiCar in apiCars)
                {

                    var serviceRequests = await _serviceRequestRepository.GetServiceRequestsByCarIdAsync(apiCar.Id);

                    if (serviceRequests != null)

                    {
                        var serviceRequest = serviceRequests.FirstOrDefault(x => !x.IsCompleted);
                        if (serviceRequest != null)
                        {
                            apiCar.IsCompleted = false;
                            apiCar.EndWorkDate = serviceRequest.TimeSlot.EndTime;
                            apiCar.ExplainationText = OnTheService;

                        }
                    }

                }

                ApiResponse<ApiCarEntry> apiResponse = new(apiCars);
                result.IsSuccess = true;
                result.Result = apiResponse;
                result.Message = "Cars list received";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(GetUserCarsListAsync)} - {ex}";

            }

            return result;
          

        }
        public async Task<ApiResponseMessage<ApiCar>> GetCarByIdAsync(int carId)
        {
            var result = new ApiResponseMessage<ApiCar>();
          
            try
            {
               var car =  await _carRepository.GetCarByIdAsync(carId);
                ApiCar apiCar = _mapper.Map<ApiCar>(car);
                result.IsSuccess = true;
                result.Result = apiCar;
                result.Message = "Car received";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(GetCarByIdAsync)} - {ex}";
            }

            return result;
        }

        public async Task<ApiResponseMessage<bool>> DeleteCarAsync(int carCertificateId, int removeCarReasonId)
        {
            var result = new ApiResponseMessage<bool>();
            try
            {
                Car? car = await _carRepository.GetCarByCertificateIdAsync(carCertificateId);
                if (car == null)
                {
                    result.IsSuccess = false;
                    result.Message ="Car not found";
                    return result;
                }
                var query = await _serviceRequestRepository.GetServiceRequestsByCarIdAsync(car.Id);


                ServiceRequest[] serviceRequests = query.ToArray();

                if (serviceRequests.Any(x => !x.IsCompleted))
                {
                    result.IsSuccess = false;
                    result.Message = "Car service request is not completed yet";
                    return result;
                }
               
                car.IsDeleted = true;
                car.RemoveCarReasonId = removeCarReasonId;

                await _carRepository.DeleteCarByIdAsync(car);
                result.IsSuccess = true;
               
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(DeleteCarAsync)} - {ex}";
            }

            return result;
        }

        public async Task<ApiResponseMessage<bool>> SendCarCharacteristics(CarCharacteristicsRequestDTO dto, string userId)
        {
            var result = new ApiResponseMessage<bool>();
           
            try
            {
                Car? car = await _carRepository.GetCarByIdAsync(dto.CarId);
                if (car == null)
                {
                    result.IsSuccess = false;
                    result.Message = "Car not found";
                    return result;
                }
                if (dto.Email == null)
                {
                    User? user = await _userRepository.GetUserByIdAsync(userId);
                    if (user == null)
                    {
                        result.IsSuccess = false;
                        result.Message = "User not found";
                        return result;
                    }
                    dto.Email = user.Email;
                }
                string mailSubject = "Характеристики авто:";
                var emailTemplate = Handlebars.Compile(EmailHandlebarsTemplate.CarCharacteristicsTemplate);

                var mailBody = emailTemplate(car);

                _userCodeService.SendEmail(dto.Email, mailBody, mailSubject);
                result.IsSuccess = true;
                result.Result = true;
                result.Message = "Car characteristics sent";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(SendCarCharacteristics)} - {ex}";
            }

            return result;

        }

       public async Task<ApiResponseMessage<bool>> UpdateCarAsync(int carId, UpdateCarDTO dto)
        {
            var result = new ApiResponseMessage<bool>();

            try
            {
                Car? car = await _carRepository.GetCarByIdAsync(carId);

                if (car == null)
                {
                    result.IsSuccess = false;
                    result.Message = "Car not found";
                    return result;
                }


                if (!String.IsNullOrEmpty(dto.Mark)) car.Mark = dto.Mark;
                if (!String.IsNullOrEmpty(dto.Model)) car.Model = dto.Model;
                if (dto.Year.HasValue) car.Year = dto.Year.Value;
                if (!String.IsNullOrEmpty(dto.StateNumber)) car.StateNumber = dto.StateNumber;
                if (dto.Transmission.HasValue) car.Transmission = dto.Transmission;
                if (!String.IsNullOrEmpty(dto.EngineType)) car.EngineType = dto.EngineType;
                if (!String.IsNullOrEmpty(dto.Drive)) car.Drive = dto.Drive;
                if (dto.Mileage.HasValue) car.Mileage = dto.Mileage.Value;

                await _carRepository.UpdateCarAsync(car);
                
                    result.IsSuccess = true;
                    result.Message = "Car updated";
                    result.Result = true;
                    return result;
                
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(UpdateCarAsync)} - {ex}";
            }

            return result;
         
        }
    

    #endregion public methods

        #region private fields

        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;
        private readonly IUserCodeService _userCodeService;
        private readonly IUserRepository _userRepository;
        private readonly IServiceRequestRepository _serviceRequestRepository;

        #endregion private fields
    }
}
