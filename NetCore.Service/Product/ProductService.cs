using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NetCore.Data.DataAccess;
using NetCore.Dto;
using NetCore.Dto.Logic;
using NetCore.Service.Config;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCore.Service.Product
{
    public class ProductService : IProductService
    {
        private readonly IProductData _db;
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;
        public ProductService(ILogger<ProductService> logger, IConfiguration configuration)
        {
            _configuration = configuration;
            _db = new ProductData(_configuration);
            _logger = logger;
        }

        public async Task<RequestResult<ProductViewModel>> GetProductWithProductId(int productId)
        {
            var result = new RequestResult<ProductViewModel>();
            try
            {
                var data = await _db.GetProductWithProductId(productId);
                if (data == null)
                {
                    return result.NotFound();
                }

                result.Obj = MapperConfig.Mapper.Map<ProductViewModel>(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return result.ServerError(ex.Message);
            }

            return result;
        }

        public async Task<RequestResult<List<ProductViewModel>>> GetProductList()
        {
            var result = new RequestResult<List<ProductViewModel>>();
            try
            {
                var dataList = await _db.GetProductList();
                result.Obj = MapperConfig.Mapper.Map<List<ProductViewModel>>(dataList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return result.ServerError(ex.Message);
            }

            return result;
        }

        public async Task<RequestResult<ProductViewModel>> SetProduct(ProductViewModel data, int productId)
        {
            var result = new RequestResult<ProductViewModel>();

            try
            {
                await _db.SetProduct(MapperConfig.Mapper.Map<Data.Model.Product>(data), productId);
                result.Obj = data;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return result.ServerError(ex.Message);
            }

            return result;
        }

        public async Task<RequestResult<ProductViewModel>> AddProduct(ProductViewModel data)
        {
            var result = new RequestResult<ProductViewModel>();
            try
            {
                var newdata = await _db.AddProduct(MapperConfig.Mapper.Map<Data.Model.Product>(data));
                data.Id = newdata.Id;
                result.Obj = data;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return result.ServerError(ex.Message);
            }

            return result;
        }

        public async Task<RequestResult> RemoveProduct(int productId)
        {
            var result = new RequestResult();
            try
            {
                var id = await _db.RemoveProduct(productId);
                if (id == 0)
                {
                    result.NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return result.ServerError(ex.Message);
            }

            return result;

        }
    }
}
