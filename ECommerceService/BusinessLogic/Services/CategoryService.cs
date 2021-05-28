using AutoMapper;
using ECommerceDatabase.Database.Entities;
using ECommerceRepository.BusinessLogic;
using ECommerceService.Models;
using System.Collections.Generic;

namespace ECommerceService.BusinessLogic
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        private readonly IMapper mapper;
        private MapperConfiguration _config;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

            _config = new Mapping.AutoMapperService().Configuration;
            mapper = _config.CreateMapper();
        }

        public List<CategoryDTO> GetAllCategories()
        {
            return mapper.Map<List<Category>, List<CategoryDTO>>(_categoryRepository.GetAllCategories());
        }

        public CategoryDTO GetCategoryById(int categoryId)
        {
            return mapper.Map<Category, CategoryDTO>(_categoryRepository.GetCategoryById(categoryId));
        }

        public bool CategoryHasProducts(int categoryId)
        {
            return _categoryRepository.CategoryHasProducts(categoryId);
        }

        public bool DeleteCategory(int categoryId)
        {
            return _categoryRepository.DeleteCategory(categoryId);
        }

        public bool CategoryExists(CategoryDTO category)
        {
            var categoryEntity = mapper.Map<CategoryDTO, Category>(category);
            return _categoryRepository.CategoryExists(categoryEntity);
        }

        public bool UpdateCategory(CategoryDTO category)
        {
            var categoryEntity = mapper.Map<CategoryDTO, Category>(category);
            return _categoryRepository.UpdateCategory(categoryEntity);
        }

        public bool AddCategory(CategoryDTO category)
        {
            var categoryEntity = mapper.Map<CategoryDTO, Category>(category);
            return _categoryRepository.AddCategory(categoryEntity);
        }
    }
}