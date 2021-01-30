using AutoMapper;
using ECommerceDatabase.Database.Entities;
using ECommerceRepository.BusinessLogic;
using ECommerceService.Models;

namespace ECommerceService.BusinessLogic
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;

        private readonly IMapper mapper;
        private MapperConfiguration _config;

        public BrandService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;

            _config = new Mapping.AutoMapperService().Configuration;
            mapper = _config.CreateMapper();
        }

        public BrandDTO GetBrandById(int brandId)
        {
            return mapper.Map<Brand, BrandDTO>(_brandRepository.GetBrandById(brandId));
        }
    }
}