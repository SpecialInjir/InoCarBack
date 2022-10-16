using InoCar.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task AddProductAsync(Product product);
        IQueryable<Product> GetAllProducts();
        Task UpdateProdutAsync(Product product);
        Task<Product?> GetProductById(int productId);
    }
}
