using System;
using System.Text.RegularExpressions;
using ECommerceService.BusinessLogic;
using ECommerceWebsite.Models;

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

        public ErrorServiceViewModel ValidateUserDateOfBirth(int day, int month, int year)
        {
            var isDobValid = !IsDateOfBirthValid(day, month, year);
            if (isDobValid)
            {
                return new ErrorServiceViewModel()
                {
                    Name = "Date of Birth",
                    Message = "Date of Birth is not valid."
                };
            }

            var isDobOver18 = IsDateOfBirthOver18(day, month, year);
            if (!isDobOver18)
            {
                return new ErrorServiceViewModel()
                {
                    Name = "Date of Birth",
                    Message = "Date of Birth must be over 18 years old."
                };
            }

            var isDobInLivingYears = IsDateOfBirthWithinHumanLivingYears(year);
            if (!isDobInLivingYears)
            {
                return new ErrorServiceViewModel()
                {
                    Name = "Date of Birth",
                    Message = "Date of Birth must be over 18 years old."
                };
            }

            return null;
        }

        public ErrorServiceViewModel ValidatePassword(string password, string confirmPassword)
        {
            var isPasswordValid = !IsPasswordValid(password);
            if (isPasswordValid)
            {
                return new ErrorServiceViewModel()
                {
                    Name = "Password",
                    Message = "Password does not meet requirements; at least one number, one special character, one upper and lower case and 8 characters minimum."
                };
            }

            var passwordsMatch = PasswordsMatch(password, confirmPassword);
            if (!passwordsMatch)
            {
                return new ErrorServiceViewModel()
                {
                    Name = "Password",
                    Message = "Password and Confirm Password do not match."
                };
            }

            return null;
        }

        public bool IsEmailInUse(string emailAddress)
        {
            return _userService.IsEmailInUse(emailAddress);
        }

        /// <summary>
        /// Checks both passwords match with case sensitivity.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="confirmPassword"></param>
        /// <returns></returns>
        private bool PasswordsMatch(string password, string confirmPassword)
        {
            return string.Equals(password, confirmPassword, StringComparison.InvariantCulture);
        }

        /// <summary>
        /// Verifies that the Date of Birth provided is over 18 years old
        /// </summary>
        /// <param name="day"></param>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        private bool IsDateOfBirthOver18(int day, int month, int year)
        {
            var dob = new DateTime(year, month, day);

            return (DateTime.Now.Year - dob.Year) > 18;
        }

        /// <summary>
        /// Attempts to build a DateTime, returning the result as a bool
        /// </summary>
        /// <param name="day"></param>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        private bool IsDateOfBirthValid(int day, int month, int year)
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

        /// <summary>
        /// Verifies that the Date of Birth provided is under 120 years old
        /// </summary>
        /// <param name="day"></param>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        private bool IsDateOfBirthWithinHumanLivingYears(int year)
        {
            return (DateTime.Now.Year - year) < 120;
        }

        /// <summary>
        /// Checks password meets strength requirements: at least one number, one special character, one upper and lower case and 8 characters minimum.
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        private bool IsPasswordValid(string password)
        {
            return new Regex(RegexPasswordPattern)
                .Match(password)
                .Success;
        }
    }
}