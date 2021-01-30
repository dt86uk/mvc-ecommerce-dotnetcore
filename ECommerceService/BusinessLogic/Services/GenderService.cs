using ECommerceRepository.BusinessLogic;

namespace ECommerceService.BusinessLogic
{
    public class GenderService : IGenderService
    {
        private readonly IGenderRepository _genderRepository;

        public GenderService(IGenderRepository genderRepository)
        {
            _genderRepository = genderRepository;
        }

        public string GetGenderById(int genderId)
        {
            return _genderRepository.GetGenderById(genderId);
        }
    }
}