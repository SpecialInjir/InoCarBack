using InoCar.Data;
using InoCar.Data.Entities;
using InoCar.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Repositories.Impl
{
    public class ProductRepositoryImpl : IProductRepository
    {
        #region constructors

        public ProductRepositoryImpl(InoCarContext context)
        {
            _context = context;
        }

        #endregion constructors

        #region public methods


        public async Task AddProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public  IQueryable<Product> GetAllProducts()
        {
           return  _context.Products.Where(x=>x.IsDeleted ==false);
        }

        public async Task UpdateProdutAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
       public async Task<Product?> GetProductById(int productId)=> await _context.Products.FirstOrDefaultAsync(x=>x.Id==productId && !x.IsDeleted);

        #endregion public methods

        #region private fields

        private readonly InoCarContext _context;


        #endregion private fields
    }
}
