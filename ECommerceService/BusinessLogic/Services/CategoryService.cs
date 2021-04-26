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
    }
}