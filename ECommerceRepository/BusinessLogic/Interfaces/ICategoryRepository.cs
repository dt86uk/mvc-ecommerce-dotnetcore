using ECommerceDatabase.Database.Entities;
using System.Collections.Generic;

namespace ECommerceRepository.BusinessLogic
{
    public interface ICategoryRepository
    {
        List<Category> GetAllCategories();
    }
}
