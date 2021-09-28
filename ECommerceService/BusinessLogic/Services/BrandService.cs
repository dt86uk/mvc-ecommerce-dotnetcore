using System.Collections.Generic;
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

        public bool Add(BrandDTO brand)
        {
            var brandEntity = mapper.Map<BrandDTO, Brand>(brand);
            return _brandRepository.Add(brandEntity);
        }

        public List<BrandDTO> GetAllBrands()
        {
            var listBrands = _brandRepository.GetAllBrands();
            return mapper.Map<List<Brand>, List<BrandDTO>>(listBrands);
        }

        public BrandDTO GetBrandById(int brandId)
        {
            var brandEntity = _brandRepository.GetBrandById(brandId);
            return mapper.Map<Brand, BrandDTO>(brandEntity);
        }

        public bool BrandNameExists(BrandDTO brandDto)
        {
            var brand = mapper.Map<BrandDTO, Brand>(brandDto);
            return _brandRepository.BrandNameExists(brand);
        }

        public bool Delete(int brandId)
        {
            return _brandRepository.Delete(brandId);
        }

        public bool Update(BrandDTO brand)
        {
            var brandEntity = mapper.Map<BrandDTO, Brand>(brand);
            return _brandRepository.Update(brandEntity);
        }

        public bool BrandHasProducts(int brandId)
        {
            return _brandRepository.BrandHasProducts(brandId);
        }
    }
}