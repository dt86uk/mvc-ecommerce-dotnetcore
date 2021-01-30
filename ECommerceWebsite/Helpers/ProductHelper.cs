using System.IO;
using Microsoft.AspNetCore.Http;

namespace ECommerceWebsite.Helpers
{
    public static class ProductHelper
    {
        public static string GetGenderDescription(string gender)
        {
            return gender switch
            {
                "Male" => "Men's",
                "Female" => "Women's",
                "Children" => "Kid's",
                "Unisex" => "Unisex",
                _ => "N/A",
            };
        }

        public static string BuildProductUrl(string productName)
        {
            return productName.Replace(" ", "-");
        }

        public static byte[] WriteImageToBytes(IFormFile file)
        {
            if (file?.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    return ms.ToArray();
                }
            }

            return null;
        }
    }
}
