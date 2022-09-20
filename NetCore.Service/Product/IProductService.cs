using NetCore.Dto;
using NetCore.Dto.Logic;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCore.Service.Product
{
    public interface IProductService
    {
        Task<RequestResult<ProductViewModel>> AddProduct(ProductViewModel data);
        Task<RequestResult<List<ProductViewModel>>> GetProductList();
        Task<RequestResult<ProductViewModel>> GetProductWithProductId(int productId);
        Task<RequestResult> RemoveProduct(int productId);
        Task<RequestResult<ProductViewModel>> SetProduct(ProductViewModel data, int productId);
    }
}