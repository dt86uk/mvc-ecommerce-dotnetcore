using System.Collections.Generic;
using AutoMapper;
using ECommerceService.BusinessLogic;
using ECommerceService.Models;
using ECommerceWebsite.Models;
using ECommerceWebsite.Models.Admin;

namespace ECommerceWebsite.BusinessLogic
{
    public class BrandWebService : IBrandWebService
    {
        private readonly IBrandService _brandService;
        private readonly IBrandValidationService _brandValidationService;
        private readonly IMapper mapper;
        private MapperConfiguration _config;

        public BrandWebService(IBrandService brandService, IBrandValidationService brandValidationService)
        {
            _brandService = brandService;
            _brandValidationService = brandValidationService;
            _config = new Mapping.AutoMapperWeb().Configuration;
            mapper = _config.CreateMapper();
        }

        public AdminBrandsViewModel GetAllBrands()
        {
            var listBrands = mapper.Map<List<BrandDTO>, List<BrandViewModel>>(_brandService.GetAllBrands());

            return new AdminBrandsViewModel()
            {
                AllBrands = listBrands
            };
        }

        public BaseWebServiceResponse AddBrand(AddBrandViewModel model)
        {
            var brandDto = mapper.Map<AddBrandViewModel, BrandDTO>(model);
            var brandNameExists = _brandValidationService.BrandNameExists(brandDto.BrandName);

            var response = new BaseWebServiceResponse
            {
                ActionSuccessful = !brandNameExists,
                Error = brandNameExists ? 
                    new ErrorServiceViewModel()
                    {
                        Name = "Brand Name",
                        Message = "Brand Name is already in use."
                    } :
                    null
            };

            if (response.Error != null)
            {
                return response;
            }

            var brandAdded = _brandService.AddBrand(brandDto);

            if (!brandAdded)
            {
                response.ActionSuccessful = false;
                response.Error = brandNameExists ?
                    null :
                    new ErrorServiceViewModel()
                    {
                        Name = "Brand",
                        Message = "There was a problem creating the Brand. We have been notified of the error but please try again."
                    };
            }

            response.SuccessMessage = "Brand added successfully!";
            response.ActionSuccessful = true;
            return response;
        }

        public BaseWebServiceResponse UpdatedBrand(EditBrandViewModel model)
        {
            var brandDto = mapper.Map<EditBrandViewModel, BrandDTO>(model);
            var brandNameExists = _brandValidationService.BrandNameExists(brandDto.BrandName, model.Id);

            var response = new BaseWebServiceResponse
            {
                ActionSuccessful = brandNameExists,
                Error = brandNameExists ?
                    null :
                    new ErrorServiceViewModel()
                    {
                        Name = "Brand Name",
                        Message = "Brand Name is already in use."
                    }
            };

            if (response.Error != null)
            {
                return response;
            }

            var brandAdded = _brandService.UpdateBrand(brandDto);

            if (!brandAdded)
            {
                response.ActionSuccessful = false;
                response.Error = brandNameExists ?
                    null :
                    new ErrorServiceViewModel()
                    {
                        Name = "Brand",
                        Message = "There was a problem updating the Brand. We have been notified of the error but please try again."
                    };
            }

            response.ActionSuccessful = true;
            response.SuccessMessage = "Brand successfully updated";
            return response;
        }

        public BaseWebServiceResponse DeleteBrand(int brandId)
        {
            var brandHasProducts = _brandValidationService.BrandHasProducts(brandId);

            var response = new BaseWebServiceResponse()
            {
                ActionSuccessful = !brandHasProducts,
                Error = brandHasProducts ?
                    new ErrorServiceViewModel()
                    {
                        Name = "Brand",
                        Message = "This brand is currently linked to active products, please ensure no products are associated with the brand before deletion."
                    } :
                    null
            };

            if (brandHasProducts)
            {
                return response;
            }

            var isBrandDeleted = _brandService.DeleteBrand(brandId);

            response.ActionSuccessful = isBrandDeleted;
            response.SuccessMessage = isBrandDeleted ?
                "Brand Deleted!" :
                string.Empty;
            response.Error = isBrandDeleted ?
                null :
                new ErrorServiceViewModel
                {
                    Name = "Brand",
                    Message = "There was an issue deleting the brand. We have been notified of the error but please try again."
                };

            return response;
        }

        public EditBrandViewModel GetBrandById(int brandId)
        {
            return mapper.Map<BrandDTO, EditBrandViewModel>(_brandService.GetBrandById(brandId));
        }
    }
}