using ECommerceService.BusinessLogic;
using ECommerceWebsite.Models.Admin;
using AutoMapper;
using System.Collections.Generic;
using ECommerceWebsite.Models;
using ECommerceService.Models;

namespace ECommerceWebsite.BusinessLogic
{
    public class CategoryWebService : ICategoryWebService
    {
        private readonly ICategoryService _categoryService;

        private readonly IMapper mapper;
        private MapperConfiguration _config;

        public CategoryWebService(ICategoryService categoryService)
        {
            _categoryService = categoryService;
            _config = new Mapping.AutoMapperWeb().Configuration;
            mapper = _config.CreateMapper();
        }

        public BaseWebServiceResponse Add(AddCategoryViewModel model)
        {
            var categoryDto = mapper.Map<AddCategoryViewModel, CategoryDTO>(model);
            var categoryExists = _categoryService.CategoryExists(categoryDto);

            var response = new BaseWebServiceResponse
            {
                ActionSuccessful = !categoryExists,
                Error = categoryExists ?
                    new ErrorServiceViewModel()
                    {
                        Name = "Category Name",
                        Message = "Category Name is already in use."
                    } :
                    null
            };

            if (response.Error != null)
            {
                return response;
            }

            var categoryAdded = _categoryService.AddCategory(categoryDto);

            if (!categoryAdded)
            {
                response.ActionSuccessful = false;
                response.Error = categoryAdded ?
                    null :
                    new ErrorServiceViewModel()
                    {
                        Name = "Category",
                        Message = "There was a problem adding the Category. We have been notified of the error but please try again."
                    };
            }

            response.ActionSuccessful = true;
            response.SuccessMessage = "Category added successfully!";
            return response;
        }

        public BaseWebServiceResponse Delete(int categoryId)
        {
            var categoryHasProducts = _categoryService.CategoryHasProducts(categoryId);

            var response = new BaseWebServiceResponse()
            {
                ActionSuccessful = !categoryHasProducts,
                Error = categoryHasProducts ?
                    new ErrorServiceViewModel()
                    {
                        Name = "Category",
                        Message = "This category is currently linked to active products, please ensure no products are associated with the category before deletion."
                    } :
                    null
            };

            if (categoryHasProducts)
            {
                return response;
            }

            var isCategoryDeleted = _categoryService.DeleteCategory(categoryId);

            response.ActionSuccessful = isCategoryDeleted;
            response.SuccessMessage = isCategoryDeleted ?
                "Category Deleted!" :
                string.Empty;
            response.Error = isCategoryDeleted ?
                null :
                new ErrorServiceViewModel
                {
                    Name = "Category",
                    Message = "There was an issue deleting the category. We have been notified of the error but please try again."
                };
            
            return response;
        }

        public AdminCategoriesViewModel GetAllCategories()
        {
            var listCategories = mapper.Map<List<CategoryDTO>, List<CategoryItemViewModel>>(_categoryService.GetAllCategories());

            return new AdminCategoriesViewModel()
            {
                AllCategories = listCategories
            };
        }

        public EditCategoryViewModel GetCategoryById(int categoryId)
        {
            var category = _categoryService.GetCategoryById(categoryId);
            return mapper.Map<CategoryDTO, EditCategoryViewModel>(category);
        }

        public BaseWebServiceResponse Update(EditCategoryViewModel model)
        {
            var categoryDto = mapper.Map<EditCategoryViewModel, CategoryDTO>(model);
            var categoryExists = _categoryService.CategoryExists(categoryDto);

            var response = new BaseWebServiceResponse
            {
                ActionSuccessful = !categoryExists,
                Error = categoryExists ?
                    new ErrorServiceViewModel()
                    {
                        Name = "Category Name",
                        Message = "Category Name is already in use."
                    } :
                    null
            };

            if (response.Error != null)
            {
                return response;
            }
            
            var categoryUpdated = _categoryService.UpdateCategory(categoryDto);

            if (!categoryUpdated)
            {
                response.ActionSuccessful = false;
                response.Error = categoryUpdated ?
                    null :
                    new ErrorServiceViewModel()
                    {
                        Name = "Category",
                        Message = "There was a problem updating the Category. We have been notified of the error but please try again."
                    };
            }

            response.ActionSuccessful = true;
            response.SuccessMessage = "Category successfully updated";
            return response;
        }
    }
}