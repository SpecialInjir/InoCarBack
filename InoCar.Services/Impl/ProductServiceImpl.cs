using AutoMapper;
using InoCar.Api.Model;
using InoCar.Data.Entities;
using InoCar.Repositories.Interfaces;
using InoCar.Services.DTO;
using InoCar.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Services.Impl
{
    public class ProductServiceImpl: IProductService
    {
        #region constructors
        public ProductServiceImpl(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;

        }
        #endregion constructors
        #region public methods
       
        public async Task<ApiResponseMessage<int>> AddProductAsync(ProductDTO dto)
        {
            var result = new ApiResponseMessage<int>();
            try
            {
                Product product = _mapper.Map<Product>(dto);
                await _productRepository.AddProductAsync(product);
                result.IsSuccess = true;
                result.Result = product.Id;
                result.Message = "Product added";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(AddProductAsync)} - {ex}";
            }
            return result;
        }
        public ApiResponseMessage<ApiResponse<ApiProduct>> GetProducts()
        {
            var result = new ApiResponseMessage<ApiResponse<ApiProduct>>();
            try
            {
                var query = _productRepository.GetAllProducts();
                Product[] products = query.ToArray();
                ApiProduct[] apiProducts = _mapper.Map<ApiProduct[]>(products);
                ApiResponse<ApiProduct> apiResponse = new(apiProducts);
                result.IsSuccess = true;
                result.Result = apiResponse;
                result.Message = "Products list received";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(GetProducts)} - {ex}";
            }
            return result;
        }

        public async Task<ApiResponseMessage<bool>> UpdateProductAsync(int productId, ProductDTO dto)
        {
            var result = new ApiResponseMessage<bool>();
            try
            {
                Product? product = await _productRepository.GetProductById(productId);
                if(product == null)
                {
                    result.IsSuccess = false;
                    result.Result = false;
                    result.Message = "Product not found";
                    return result;
                }
                product.MaintenanceWorkId = dto.MaintenanceWorkId;
                product.Name = dto.Name;
                product.PersonalOfferId = dto.PersonalOfferId;
                product.Price = dto.Price;
                await _productRepository.UpdateProdutAsync(product);
                result.IsSuccess = true;
                result.Result = true;
                result.Message = "Product added";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(UpdateProductAsync)} - {ex}";
            }
            return result;
        }
        public async Task<ApiResponseMessage<bool>> DeleteProductAsync(int productId)
        {
            var result = new ApiResponseMessage<bool>();
            try
            {
                Product? product = await _productRepository.GetProductById(productId);
                if (product == null)
                {
                    result.IsSuccess = false;
                    result.Result = false;
                    result.Message = "Product not found";
                    return result;
                }
                product.IsDeleted = true;
                await _productRepository.UpdateProdutAsync(product);
                result.IsSuccess = true;
                result.Result = true;
                result.Message = "Product deleted";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Something Went Wrong in the {nameof(DeleteProductAsync)} - {ex}";
            }
            return result;
        }
        #endregion public methods

        #region private fields

        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        #endregion private fields
       
    }
}
