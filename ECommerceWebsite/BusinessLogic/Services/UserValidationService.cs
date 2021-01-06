using System;
using System.Text.RegularExpressions;
using ECommerceService.BusinessLogic;

namespace ECommerceWebsite.BusinessLogic
{
    public class UserValidationService : IUserValidationService
    {
        private readonly IUserService _userService;
        private const string RegexPasswordPattern = @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$";

        public UserValidationService(IUserService userService)
        {
            _userService = userService;
        }

        public bool DoPasswordsMatch(string password, string confirmPassword)
        {
            return string.Equals(password, confirmPassword, StringComparison.InvariantCultureIgnoreCase);
        }

        public bool IsDateOfBirthOver18(int day, int month, int year)
        {
            var dob = new DateTime(year, month, day);

            return (DateTime.Now.Year - dob.Year) > 18;
        }

        public bool IsDateOfBirthValid(string day, string month, string year)
        {
            try
            {
                var dob = new DateTime(
                    Convert.ToInt32(year),
                    Convert.ToInt32(month),
                    Convert.ToInt32(day));

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool IsDateOfBirthWithinHumanLivingYears(int year)
        {
            try
            {
                return (DateTime.Now.Year - year) < 120;
            }
            catch
            {
                return false;
            }
        }

        public bool IsEmailInUse(string emailAddress)
        {
            return _userService.IsEmailInUse(emailAddress);
        }

        public bool IsPasswordValid(string password)
        {
            return new Regex(RegexPasswordPattern)
                .Match(password)
                .Success;
        }
    }
}
