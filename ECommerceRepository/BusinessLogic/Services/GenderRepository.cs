using ECommerceDatabase.Database.Entities;

namespace ECommerceRepository.BusinessLogic
{
    public class GenderRepository : IGenderRepository
    {
        public string GetGenderById(int genderId)
        {
            var gender = (GenderEnum)genderId;
            return gender.ToString();
        }
    }
}