using ECommerceDatabase.Database.Entities;
using ECommerceRepository.BusinessLogic;
using ECommerceService.Models;
using System.Collections.Generic;

namespace ECommerceService.BusinessLogic
{
    public class GenderService : IGenderService
    {
        private readonly IGenderRepository _genderRepository;

        public GenderService(IGenderRepository genderRepository)
        {
            _genderRepository = genderRepository;
        }

        public List<GenderDTO> GetAllGenders()
        {
            return new List<GenderDTO>() {
                new GenderDTO()
                {
                    Id = (int)GenderEnum.Female,
                    GenderName = GenderEnum.Female.ToString()
                },
                new GenderDTO()
                {
                    Id = (int)GenderEnum.Male,
                    GenderName = GenderEnum.Male.ToString()
                },
                new GenderDTO()
                {
                    Id = (int)GenderEnum.Unisex,
                    GenderName = GenderEnum.Unisex.ToString()
                }
            };
        }

        public string GetGenderById(int genderId)
        {
            return _genderRepository.GetGenderById(genderId);
        }
    }
}