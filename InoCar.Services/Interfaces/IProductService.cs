using InoCar.Api.Model;
using InoCar.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Services.Interfaces
{
    public interface IProductService
    {
        Task<ApiResponseMessage<int>> AddProductAsync(ProductDTO dto);
        ApiResponseMessage<ApiResponse<ApiProduct>> GetProducts();
        Task<ApiResponseMessage<bool>> UpdateProductAsync(int productId, ProductDTO dto);
        Task<ApiResponseMessage<bool>> DeleteProductAsync(int productId);
    }
}
