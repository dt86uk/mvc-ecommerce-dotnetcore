using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace ECommerceWebsite.BusinessLogic
{
    public interface IFileValidationWebService
    {
        bool FileExists(IFormFile file);
        bool FileExists(List<IFormFile> listFiles);
        bool IsFileFormatJpg(IFormFile file);
        bool IsFileFormatJpg(List<IFormFile> listFiles);
    }
}