namespace ECommerceWebsite.Models
{
    public class BaseUserWebServiceResponse
    {
        public bool ActionSuccessful { get; set; }
        public ErrorServiceResponseModel Error { get; set; }
        public string JsonResponseObject { get; set; }
    }
}