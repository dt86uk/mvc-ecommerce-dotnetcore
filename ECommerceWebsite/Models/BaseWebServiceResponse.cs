namespace ECommerceWebsite.Models
{
    public class BaseWebServiceResponse
    {
        public bool ActionSuccessful { get; set; }
        public string SuccessMessage { get; set; }
        public ErrorServiceViewModel Error { get; set; }
        public string JsonResponseObject { get; set; }

        public BaseWebServiceResponse() 
        {
            Error = new ErrorServiceViewModel();
        }
    }
}