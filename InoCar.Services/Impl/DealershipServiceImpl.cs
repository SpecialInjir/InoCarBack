using AutoMapper;
using InoCar.Api.Model;
using InoCar.Data.Entities;
using InoCar.Repositories;
using InoCar.Services.DTO;
using InoCar.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Services.Impl
{
    public class DealershipServiceImpl : IDealershipService
    {

        #region constructors
        public DealershipServiceImpl(ICarRepository carRepository, IUserRepository userRepository, IDealershipRepository dealershipRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _dealershipRepository = dealershipRepository;
            _userRepository = userRepository;
            _mapper = mapper;

        }
        #endregion constructors
        #region public methods



        public async Task<ApiResponseMessage<int>> AddFeedbackAsync(int dealershipId, DealershipFeedbackDTO dto)
        {
            var result = new ApiResponseMessage<int>();
            try
            {
                DealershipFeedback dealershipFeedback = _mapper.Map<DealershipFeedback>(dto);
                dealershipFeedback.DealershipId = dealershipId;
                await _dealershipRepository.AddFeedbackAsync(dealershipFeedback);
                result.IsSuccess = true;
                result.Result = dealershipFeedback.Id;
                result.Message="Feedback added";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(AddFeedbackAsync)} - {ex}";
            }
            return result;
           

        }

        public async Task<ApiResponseMessage<ApiDealershipFeedback>> GetFeedbackAsync(int dealershipId)
        {
            var result = new ApiResponseMessage<ApiDealershipFeedback>();
            try
            {
                DealershipFeedback? dealershipFeedback = await _dealershipRepository.GetFeedbackAsync(dealershipId);
                if (dealershipFeedback == null)
                {
                    result.IsSuccess = false;
                    result.Result = null;
                    result.Message = "Dealership Feedback not found";
                    return result;
                }
                ApiDealershipFeedback apiDealershipFeedback = _mapper.Map<ApiDealershipFeedback>(dealershipFeedback);
                result.IsSuccess = true;
                result.Result = apiDealershipFeedback;

            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(GetFeedbackAsync)} - {ex}";
            }
            return result;
          

        }
        public async Task<ApiResponseMessage<ApiResponse<ApiDealership>>> GetDealershipsAsync(string userCity, int carId)
        {
            var result=new ApiResponseMessage<ApiResponse<ApiDealership>>();
            try
            {
                Car? car = await _carRepository.GetCarByIdAsync(carId);
                if (car == null)
                {
                    result.IsSuccess = false;
                    result.Message = "Car not found";
                    return result;
                }

                string userCarMark = car.Mark;

                var dealerships = await _dealershipRepository.GetDealershipsByCityMarkAsync(userCity, userCarMark);

                List<ApiDealership> apiDealerships = _mapper.Map<List<ApiDealership>>(dealerships);

                ApiResponse<ApiDealership> apiResponse = new(apiDealerships);
                result.IsSuccess = true;
                result.Result = apiResponse;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(GetDealershipsAsync)} - {ex}";
            }

            return result;
        }

        public async Task<ApiResponseMessage<ApiResponse<ApiDealershipInformation>>> GetDealershipsAllAsync(string userId)
        {
            var result = new ApiResponseMessage<ApiResponse<ApiDealershipInformation>>();
            try
            {
                User? user = await _userRepository.GetUserByIdAsync(userId);
                if (user == null || user.City==null)
                {
                    result.IsSuccess = false;
                    result.Message = "User city not found";
                    return result;
                }
                var dealerships = await _dealershipRepository.GetDealershipsByCityAsync(user.City);

                List<ApiDealershipInformation> apiDealershipInformations = _mapper.Map<List<ApiDealershipInformation>>(dealerships);

                ApiResponse<ApiDealershipInformation> apiResponse = new(apiDealershipInformations);
                result.IsSuccess = true;
                result.Result = apiResponse;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(GetDealershipsAllAsync)} - {ex}";
            }

            return result; 
        }

        public async Task<ApiResponseMessage<ApiDealershipInformation>> GetDealershipByIdAsync(int dealershipId)
        {
            var result = new ApiResponseMessage<ApiDealershipInformation>();
            try
            {
                var dealership = await _dealershipRepository.GetDealershipByIdAsync(dealershipId);
                if (dealership == null)
                {
                    result.IsSuccess = false;
                    result.Message = "Dealership not found";
                    return result;
                }

                ApiDealershipInformation apiDealershipInformation = _mapper.Map<ApiDealershipInformation>(dealership);
                result.IsSuccess = true;
                result.Result = apiDealershipInformation;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(GetDealershipByIdAsync)} - {ex}";
            }

            return result;

            
        }
        public async Task<ApiResponseMessage<int>> AddDealershipAsync(DealershipDTO dto)
        {
            var result = new ApiResponseMessage<int>();
            try
            {
                Dealership dealership = _mapper.Map<Dealership>(dto);
                dealership.OpeningTime = dto.OpenTime.TimeOfDay;
                dealership.ClosingTime = dto.CloseTime.TimeOfDay;
                await _dealershipRepository.AddDealershipAsync(dealership);
                result.IsSuccess = true;
                result.Result = dealership.Id;
                result.Message = "Dealership added";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(AddDealershipAsync)} - {ex}";
            }
            return result;

        }

        public async Task<ApiResponseMessage<bool>> UpdateDealershipAsync(int dealershipId, DealershipDTO dto)
        {
            var result = new ApiResponseMessage<bool>();
            try
            {
                Dealership? dealership = await _dealershipRepository.GetDealershipByIdAsync(dealershipId);
               
                if (dealership==null)
                {
                    result.IsSuccess = false;
                    result.Result = false;
                    result.Message = "Dealership not found";
                    return result;
                }
                dealership.Name = dto.Name;
                dealership.Brand = dto.Brand;
                dealership.Address = dto.Address;
                dealership.OperatorNum = dto.OperatorNum;
                dealership.ClosingTime = dto.OpenTime.TimeOfDay;
                dealership.ClosingTime = dto.CloseTime.TimeOfDay;
                dealership.ImgUrl = dto.ImgUrl;
               
                await _dealershipRepository.UpdateDealershipAsync(dealership);
                result.IsSuccess = true;
                result.Result = true;
                result.Message = "Dealership updated";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(UpdateDealershipAsync)} - {ex}";
            }
            return result;
        }

        public async Task<ApiResponseMessage<bool>> DeleteDealershipAsync(int dealershipId)
        {
            var result = new ApiResponseMessage<bool>();
            try
            {
                Dealership? dealership = await _dealershipRepository.GetDealershipByIdAsync(dealershipId);
                if (dealership == null)
                {
                    result.IsSuccess = false;
                    result.Result = false;
                    result.Message = "Dealership not found";
                    return result;
                }
                dealership.IsDeleted = true;
                await _dealershipRepository.UpdateDealershipAsync(dealership);
                result.IsSuccess = true;
                result.Result = true;
                result.Message = "Dealership deleted";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(UpdateDealershipAsync)} - {ex}";
            }
            return result;
        }
        #endregion public methods
        #region private fields

        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;
        private readonly IDealershipRepository _dealershipRepository;
        private readonly IUserRepository _userRepository;

        #endregion private fields
    }
}

