using ECommerceService.Models;
using System.Collections.Generic;

namespace ECommerceService.BusinessLogic
{
    public interface IGenderService
    {
        string GetGenderById(int genderId);
        List<GenderDTO> GetAllGenders();
    }
}