using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace ECommerceWebsite.BusinessLogic
{
    public class FileValidationWebService : IFileValidationWebService
    {
        public bool FileExists(IFormFile file)
        {
            return file != null;
        }

        public bool FileExists(List<IFormFile> listFiles)
        {
            var file = listFiles.FirstOrDefault(p => p != null);
            return file != null;
        }

        public bool IsFileFormatJpg(List<IFormFile> listFiles)
        {
            foreach (var file in listFiles)
            {
                if(!IsFileFormatJpg(file))
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsFileFormatJpg(IFormFile file)
        {
            return file.FileName.EndsWith(".jpg", StringComparison.InvariantCultureIgnoreCase);
        }
    }
}