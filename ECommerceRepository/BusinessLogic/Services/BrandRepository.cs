using System;
using System.Linq;
using System.Collections.Generic;
using ECommerceDatabase.Database.Entities;
using ECommerceDatabase.Database.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace ECommerceRepository.BusinessLogic
{
    public class BrandRepository : IBrandRepository
    {
        public bool AddBrand(Brand brand)
        {
            using (var context = new ECommerceContextDb(new ECommerceDatabase.StartupDatabase().GetOptions()))
            {
                var brandEntity = context.Brands.Add(brand);
                context.Entry(brand).State = EntityState.Added;
                context.SaveChanges();
                
                return context.Brands.Any(p => p.Id == brandEntity.Entity.Id);
            }
        }

        public bool BrandNameExists(string brandName)
        {
            using (var context = new ECommerceContextDb(new ECommerceDatabase.StartupDatabase().GetOptions()))
            {
                return context.Brands.Any(p => string.Equals(brandName, p.BrandName, StringComparison.InvariantCultureIgnoreCase));
            }
        }

        public bool BrandNameExists(string brandName, int brandId)
        {
            using (var context = new ECommerceContextDb(new ECommerceDatabase.StartupDatabase().GetOptions()))
            {
                return context.Brands.Any(p => string.Equals(brandName, p.BrandName, StringComparison.InvariantCultureIgnoreCase) && p.Id != brandId);
            }
        }

        public bool DeleteBrand(int brandId)
        {
            using (var context = new ECommerceContextDb(new ECommerceDatabase.StartupDatabase().GetOptions()))
            {
                var brandEntity = context.Brands.FirstOrDefault(p => p.Id == brandId);

                if (brandEntity != null)
                {
                    context.Entry(brandEntity).State = EntityState.Deleted;
                    context.Brands.Remove(brandEntity);
                    context.SaveChanges();

                    return true;
                }

                return false;
            }
        }

        public List<Brand> GetAllBrands()
        {
            using (var context = new ECommerceContextDb(new ECommerceDatabase.StartupDatabase().GetOptions()))
            {
                return context.Brands.ToList();
            }
        }

        public Brand GetBrandById(int brandId)
        {
            using (var context = new ECommerceContextDb(new ECommerceDatabase.StartupDatabase().GetOptions()))
            {
                return context.Brands.Single(p => p.Id == brandId);
            }
        }

        public bool UpdateBrand(Brand brand)
        {
            using (var context = new ECommerceContextDb(new ECommerceDatabase.StartupDatabase().GetOptions()))
            {
                var brandEntity = context.Brands.SingleOrDefault(p => p.Id == brand.Id);

                if (brandEntity != null)
                {
                    brandEntity.BrandName = brand.BrandName;

                    context.Entry(brandEntity).State = EntityState.Modified;
                    context.Brands.Update(brandEntity);
                    context.SaveChanges();

                    return true;
                }

                return false;
            }
        }

        public bool BrandHasProducts(int brandId)
        {
            using (var context = new ECommerceContextDb(new ECommerceDatabase.StartupDatabase().GetOptions()))
            {
                return context.Products.Any(p => p.BrandId == brandId);
            }
        }
    }
}