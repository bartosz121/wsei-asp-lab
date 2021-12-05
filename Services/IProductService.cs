using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wsei_Lab5.Entities;
using Wsei_Lab5.Models;

namespace Wsei_Lab5.Services
{
    public interface IProductService
    {
        Task Add(ProductModel product);
        Task<IEnumerable<ProductEntity>> GetItemsByName(string name);

        Task<ProductEntity> GetItem(int id);
    }
}
