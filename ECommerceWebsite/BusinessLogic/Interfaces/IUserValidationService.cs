namespace ECommerceWebsite.BusinessLogic
{
    public interface IUserValidationService
    {
        //TODO: Add these types of comments in FULLY (///)
        //TODO: Add return types if necessary
        bool IsEmailInUse(string emailAddress);

        //Can it be a DateTime type?
        bool IsDateOfBirthValid(string day, string month, string year);

        bool IsDateOfBirthOver18(int day, int month, int year);

        //over 120 years is too old - add some cheesy message on view/page.
        bool IsDateOfBirthWithinHumanLivingYears(int year);

        //does it meet requirements?
        bool IsPasswordValid(string password);
        bool DoPasswordsMatch(string password, string confirmPassword);
    }
}
