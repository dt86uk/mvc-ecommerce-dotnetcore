﻿using ECommerceDatabase.Database.Entities;
using System.Collections.Generic;

namespace ECommerceRepository.BusinessLogic
{
    public interface ICategoryRepository
    {
        List<Category> GetAllCategories();
        Category GetCategoryById(int categoryId);
        bool DeleteCategory(int categoryId);
        bool CategoryHasProducts(int categoryId);
    }
}