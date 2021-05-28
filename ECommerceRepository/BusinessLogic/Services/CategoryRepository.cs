using System;
using System.Linq;
using System.Collections.Generic;
using ECommerceDatabase.Database.Entities;
using ECommerceDatabase.Database.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace ECommerceRepository.BusinessLogic
{
    public class CategoryRepository : ICategoryRepository
    {
        public List<Category> GetAllCategories()
        {
            using (var context = new ECommerceContextDb(new ECommerceDatabase.StartupDatabase().GetOptions()))
            {
                return context.Categories.ToList();
            }
        }

        public Category GetCategoryById(int categoryId)
        {
            using (var context = new ECommerceContextDb(new ECommerceDatabase.StartupDatabase().GetOptions()))
            {
                return context.Categories.Single(p => p.Id == categoryId);
            }
        }

        public bool Delete(int categoryId)
        {
            using (var context = new ECommerceContextDb(new ECommerceDatabase.StartupDatabase().GetOptions()))
            {
                var categoryEntity = context.Categories.SingleOrDefault(p => p.Id == categoryId);

                if (categoryEntity != null)
                {
                    context.Entry(categoryEntity).State = EntityState.Deleted;
                    context.Categories.Remove(categoryEntity);
                    context.SaveChanges();

                    return true;
                }

                return false;
            }
        }

        public bool CategoryHasProducts(int categoryId)
        {
            using (var context = new ECommerceContextDb(new ECommerceDatabase.StartupDatabase().GetOptions()))
            {
                return context.Products.Any(p => p.CategoryId == categoryId);
            }
        }

        public bool CategoryExists(Category category)
        {
            using (var context = new ECommerceContextDb(new ECommerceDatabase.StartupDatabase().GetOptions()))
            {
                if (category.Id != 0)
                {
                    return context.Categories.Any(p => string.Equals(p.CategoryName, category.CategoryName, StringComparison.InvariantCultureIgnoreCase) && 
                            p.Id != category.Id);
                }

                return context.Categories.Any(p => string.Equals(p.CategoryName, category.CategoryName, StringComparison.InvariantCultureIgnoreCase));
            }
        }

        public bool Update(Category category)
        {
            using (var context = new ECommerceContextDb(new ECommerceDatabase.StartupDatabase().GetOptions()))
            {
                var categoryEntity = context.Categories.SingleOrDefault(p => p.Id == category.Id);

                if (categoryEntity != null)
                {
                    categoryEntity.CategoryName = category.CategoryName;

                    context.Entry(categoryEntity).State = EntityState.Modified;
                    context.Categories.Update(categoryEntity);
                    context.SaveChanges();

                    return true;
                }

                return false;
            }
        }

        public bool Add(Category category)
        {
            using (var context = new ECommerceContextDb(new ECommerceDatabase.StartupDatabase().GetOptions()))
            {
                var categoryEntity = context.Categories.Add(category);
                context.Entry(category).State = EntityState.Added;
                context.SaveChanges();

                return context.Categories.Any(p => p.Id == categoryEntity.Entity.Id);
            }
        }
    }
}