using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wsei_Lab5.Database;
using Wsei_Lab5.Entities;
using Wsei_Lab5.Models;

namespace Wsei_Lab5.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _dbContext;

        public ProductService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Add(ProductModel product)
        {
            var entity = new ProductEntity
            {
                Name = product.Name,
                Description = product.Description,
                IsVisible = product.IsVisible,
            };

            await _dbContext.Products.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ProductEntity> GetItem(int id)
        {
            var item = await _dbContext.Products.FirstOrDefaultAsync(i => i.Id == id);

            return item;
        }

        public async Task<IEnumerable<ProductEntity>> GetItemsByName(string name)
        {
            IQueryable<ProductEntity> productsQuery = _dbContext.Products;

            if (!string.IsNullOrEmpty(name)) {
                productsQuery = productsQuery.Where(x => x.Name.Contains(name));
            }

            var products = await productsQuery.ToListAsync();

            return products;
        }
    }
}
