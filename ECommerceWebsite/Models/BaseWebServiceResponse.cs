namespace ECommerceWebsite.Models
{
    public class BaseWebServiceResponse
    {
        public bool ActionSuccessful { get; set; }
        public ErrorServiceResponseModel Error { get; set; }
        public string JsonResponseObject { get; set; }

        public BaseWebServiceResponse() 
        {
            Error = new ErrorServiceResponseModel();
        }
    }
}