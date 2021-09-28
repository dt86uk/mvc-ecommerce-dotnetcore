using System.Collections.Generic;
using AutoMapper;
using ECommerceDatabase.Database.Entities;
using ECommerceRepository.BusinessLogic;
using ECommerceService.Models;

namespace ECommerceService.BusinessLogic
{
    /// <summary>
    /// Queries the Repository and returns Data Transfer Objects (DTO) for the site Menu Items
    /// </summary>
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepository;
        private readonly IMapper mapper;
        private MapperConfiguration _config;
        
        public MenuService(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
            _config = new Mapping.AutoMapperService().Configuration;
            mapper = _config.CreateMapper();
        }

        public List<ProductDTO> GetHomeCarouselItems()
        {
            var listProducts = _menuRepository.GetHomeCarouselItems();
            var listProductsDto = mapper.Map<List<Product>, List<ProductDTO>>(listProducts);

            return listProductsDto;
        }

        public List<CategoryDTO> GetSubMenuItems()
        {
            var listCategories = _menuRepository.GetSubMenuItems();
            var listCategoryDto = mapper.Map<List<Category>, List<CategoryDTO>>(listCategories);

            return listCategoryDto;
        }
    }
}
