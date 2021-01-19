using System.Linq;
using System.Collections.Generic;
using ECommerceService.Models;
using ECommerceRepository.BusinessLogic;

namespace ECommerceService.BusinessLogic
{
    public class StockService : IStockService
    {
        private readonly IProductRepository _productRepository;

        public StockService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public bool IsStockAvailable(int productId, int sizeId)
        {
            var productDto = _productRepository.GetProductById(productId);

            //no sizes available
            if (productDto.Sizes.Count == 0)
            {
                return false;
            }

            var sizeDto = productDto.Sizes.SingleOrDefault(p => p.Id == sizeId);

            //size not found
            if (sizeDto == null)
            {
                return false;
            }

            //can stock requested be fulfilled
            return (sizeDto.Quantity - 1) >= 0;
        }

        public List<ProductStockDTO> GetFiveLowestStockProducts()
        {
            var listProducts = _productRepository.GetFiveLowestStockProducts();
            var listProductStockDto = new List<ProductStockDTO>();

            foreach (var product in listProducts)
            {
                var productStockDto = new ProductStockDTO()
                {
                    ProductId = product.Id,
                    ProductName = product.ProductName,
                    BrandName = product.Brand.BrandName,
                    Quantity = product.Sizes.Sum(p => p.Quantity)
                };

                listProductStockDto.Add(productStockDto);
            }

            return listProductStockDto;
        }
    }
}