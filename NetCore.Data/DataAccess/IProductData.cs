using NetCore.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCore.Data.DataAccess
{
    public interface IProductData
    {
        Task<Product> AddProduct(Product data);
        Task<List<Product>> GetProductList();
        Task<Product> GetProductWithProductId(int productId);
        Task<int> RemoveProduct(int productId);
        Task<Product> SetProduct(Product data,int productId);
    }
}