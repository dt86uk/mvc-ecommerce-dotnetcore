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
            var listCategoryEntities = _categoryRepository.GetAllCategories();
            return mapper.Map<List<Category>, List<CategoryDTO>>(listCategoryEntities);
        }

        public CategoryDTO GetCategoryById(int categoryId)
        {
            var categoryEntity = _categoryRepository.GetCategoryById(categoryId);
            return mapper.Map<Category, CategoryDTO>(categoryEntity);
        }

        public bool CategoryHasProducts(int categoryId)
        {
            return _categoryRepository.CategoryHasProducts(categoryId);
        }

        public bool Delete(int categoryId)
        {
            return _categoryRepository.Delete(categoryId);
        }

        public bool CategoryExists(CategoryDTO category)
        {
            var categoryEntity = mapper.Map<CategoryDTO, Category>(category);
            return _categoryRepository.CategoryExists(categoryEntity);
        }

        public bool Update(CategoryDTO category)
        {
            var categoryEntity = mapper.Map<CategoryDTO, Category>(category);
            return _categoryRepository.Update(categoryEntity);
        }

        public bool Add(CategoryDTO category)
        {
            var categoryEntity = mapper.Map<CategoryDTO, Category>(category);
            return _categoryRepository.Add(categoryEntity);
        }
    }
}