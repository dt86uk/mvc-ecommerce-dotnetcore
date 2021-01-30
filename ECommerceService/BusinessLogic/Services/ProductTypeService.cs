using AutoMapper;
using ECommerceDatabase.Database.Entities;
using ECommerceRepository.BusinessLogic;
using ECommerceService.Models;

namespace ECommerceService.BusinessLogic
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly IProductTypeRepository _productTypeRepository;

        private readonly IMapper mapper;
        private MapperConfiguration _config;

        public ProductTypeService(IProductTypeRepository productTypeRepository)
        {
            _productTypeRepository = productTypeRepository;

            _config = new Mapping.AutoMapperService().Configuration;
            mapper = _config.CreateMapper();
        }

        public ProductTypeDTO GetProductTypeById(int productTypeId)
        {
            return mapper.Map<ProductType, ProductTypeDTO>(_productTypeRepository.GetProductTypeById(productTypeId));
        }
    }
}