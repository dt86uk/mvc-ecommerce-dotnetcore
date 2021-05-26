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

        public bool AddBrand(BrandDTO brand)
        {
            return _brandRepository.AddBrand(mapper.Map<BrandDTO, Brand>(brand));
        }

        public List<BrandDTO> GetAllBrands()
        {
            return mapper.Map<List<Brand>, List<BrandDTO>>(_brandRepository.GetAllBrands());
        }

        public BrandDTO GetBrandById(int brandId)
        {
            return mapper.Map<Brand, BrandDTO>(_brandRepository.GetBrandById(brandId));
        }

        public bool BrandNameExists(string brandName)
        {
            return _brandRepository.BrandNameExists(brandName);
        }

        public bool BrandNameExists(string brandName, int brandId)
        {
            return _brandRepository.BrandNameExists(brandName, brandId);
        }

        public bool DeleteBrand(int brandId)
        {
            return _brandRepository.DeleteBrand(brandId);
        }

        public bool UpdateBrand(BrandDTO brand)
        {
            return _brandRepository.UpdateBrand(mapper.Map<BrandDTO, Brand>(brand));
        }

        public bool BrandHasProducts(int brandId)
        {
            return _brandRepository.BrandHasProducts(brandId);
        }
    }
}