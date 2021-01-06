using ECommerceWebsite.Models;
using System;
using System.Collections.Generic;
using Service = ECommerceService.BusinessLogic;

namespace ECommerceWebsite.BusinessLogic
{
    public class MenuWebService : IMenuWebService
    {
        private Service.IMenuService _menuService;

        public MenuWebService(Service.IMenuService menuService)
        {
            _menuService = menuService;
        }

        public List<CarouselItemViewModel> GetHomeCarouselItems()
        {
            var listProductsDto = _menuService.GetHomeCarouselItems();
            var listCarouselItems = new List<CarouselItemViewModel>();
            int menuItemIdCount = 0;

            foreach (var product in listProductsDto)
            {
                foreach (var image in product.Images)
                {
                    menuItemIdCount++;
                    
                    if (image.FilePath.Contains("hero"))
                    {
                        var base64 = Convert.ToBase64String(image.Image);
                        var carouselItem = new CarouselItemViewModel()
                        {
                            Id = menuItemIdCount,
                            Text = product.HeroTitle,
                            Url = $"product/{product.HeroTitle.Replace(" ", "-").ToLower()}",
                            ImageSrc = $"data:image/jpeg;base64,{base64}"
                        };

                        listCarouselItems.Add(carouselItem);
                    }
                }
            }
         
            return listCarouselItems;
        }

        public List<MenuItemViewModel> GetSubMenuItems()
        {
            var listCategories = _menuService.GetSubMenuItems();
            var listMenuItems = new List<MenuItemViewModel>();
            int menuItemIdCount = 0;

            foreach (var item in listCategories)
            {
                menuItemIdCount++;
                listMenuItems.Add(
                    new MenuItemViewModel()
                    {
                        Id = menuItemIdCount,
                        Text = item.CategoryName,
                        Url = $"/category/{item.CategoryName.Trim().Replace("'", "")}"
                    });
            }

            return listMenuItems;
        }
    }
}