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
            return _brandRepository.Add(mapper.Map<BrandDTO, Brand>(brand));
        }

        public List<BrandDTO> GetAllBrands()
        {
            return mapper.Map<List<Brand>, List<BrandDTO>>(_brandRepository.GetAllBrands());
        }

        public BrandDTO GetBrandById(int brandId)
        {
            return mapper.Map<Brand, BrandDTO>(_brandRepository.GetBrandById(brandId));
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
            return _brandRepository.Update(mapper.Map<BrandDTO, Brand>(brand));
        }

        public bool BrandHasProducts(int brandId)
        {
            return _brandRepository.BrandHasProducts(brandId);
        }
    }
}