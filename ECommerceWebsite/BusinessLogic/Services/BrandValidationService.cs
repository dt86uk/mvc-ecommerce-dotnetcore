using ECommerceService.BusinessLogic;

namespace ECommerceWebsite.BusinessLogic
{
    public class BrandValidationService : IBrandValidationService
    {
        private readonly IBrandService _brandService;

        public BrandValidationService(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public bool BrandNameExists(string brandName)
        {
           return _brandService.BrandNameExists(brandName);
        }

        public bool BrandNameExists(string brandName, int brandId)
        {
            return _brandService.BrandNameExists(brandName, brandId);
        }
    }
}