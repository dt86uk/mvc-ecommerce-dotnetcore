using AutoMapper;
using ECommerceDatabase.Database.Entities;
using ECommerceRepository.BusinessLogic;
using ECommerceService.Models;
using System.Collections.Generic;

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

        public List<ProductTypeDTO> GetAllProductTypes()
        {
            return mapper.Map<List<ProductType>, List<ProductTypeDTO>>(_productTypeRepository.GetAllProductTypes());
        }

        public ProductTypeDTO GetProductTypeById(int productTypeId)
        {
            return mapper.Map<ProductType, ProductTypeDTO>(_productTypeRepository.GetProductTypeById(productTypeId));
        }
    }
}