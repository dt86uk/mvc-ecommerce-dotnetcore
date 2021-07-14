using ECommerceWebsite.Models;

namespace ECommerceWebsite.BusinessLogic
{
    public interface IUserValidationService
    {
        /// <summary>
        /// Makes several validation checks on Date of Birth.
        /// </summary>
        /// <param name="day"></param>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        ErrorServiceViewModel ValidateUserDateOfBirth(int day, int month, int year);

        /// <summary>
        /// Makes several validation checks on Password.
        /// </summary>
        /// <param name="day"></param>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        ErrorServiceViewModel ValidatePassword(string password, string confirmPassword);

        /// <summary>
        /// Checks if the email address exists in the database
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        bool IsEmailInUse(string emailAddress);
    }
}