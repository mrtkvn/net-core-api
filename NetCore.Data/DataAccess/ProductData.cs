using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NetCore.Data.Context;
using NetCore.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCore.Data.DataAccess
{
    public class ProductData : IProductData
    {
        private readonly NetCoreContext _db;
        private readonly IConfiguration _configuration;

        public ProductData(IConfiguration configuration)
        {
            _configuration = configuration;
            var optionsBuilder = new DbContextOptionsBuilder<NetCoreContext>();
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("Database"));

            _db = new NetCoreContext(optionsBuilder.Options);
        }

        public async Task<Product> GetProductWithProductId(int productId)
        {
            return await _db.Products.FindAsync(productId);
        }

        public async Task<List<Product>> GetProductList()
        {
            return await _db.Products.ToListAsync();
        }

        public async Task<Product> SetProduct(Product data, int productId)
        {
            var old = await _db.Products.FindAsync(productId);
            if (old == null)
            {
                return new Product();
            }

            old.Description = data.Description;
            old.Name = data.Name;
            old.Price = data.Price;

            await _db.SaveChangesAsync();

            return data;
        }

        public async Task<Product> AddProduct(Product data)
        {
            _db.Products.Add(data);
            await _db.SaveChangesAsync();

            return data;
        }

        public async Task<int> RemoveProduct(int productId)
        {
            Product data = await _db.Products.FindAsync(productId);
            _db.Products.Remove(data);
            return await _db.SaveChangesAsync();
        }

    }
}
