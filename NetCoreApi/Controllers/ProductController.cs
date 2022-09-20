using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NetCore.Dto;
using NetCore.Service.Product;
using System.Threading.Tasks;

namespace NetCoreApi.Controllers
{

    [Route("api/v1/products/")]
    [Produces("application/json")]
    [ApiController]    
    public class ProductController : BaseApiController
    {
        private readonly IConfiguration _configuration;
        private readonly IProductService _productService;

        public ProductController(IProductService productService, IConfiguration configuration)
        {            
            _configuration = configuration;
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _productService.GetProductList();
            return ReturnResult(result);
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> Get(int productId)
        {
            var result = await _productService.GetProductWithProductId(productId);
            return ReturnResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductViewModel product)
        {
            var result = await _productService.AddProduct(product);
            return ReturnResult(result);
        }

        [HttpPatch("{productId}")]
        public async Task<IActionResult> Create([FromBody] ProductViewModel product, int productId)
        {
            var result = await _productService.SetProduct(product, productId);
            return ReturnResult(result);
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> Delete(int productId)
        {
            var result = await _productService.RemoveProduct(productId);
            return ReturnResult(result);
        }



    }
}
