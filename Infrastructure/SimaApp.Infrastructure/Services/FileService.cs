using Microsoft.AspNetCore.Http;
using SimaApp.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Infrastructure.Services
{
    public class FileService : IFileService
    {
        private const long MaxFileSize = 2 * 1024 * 1024;
        public async Task<string> ConvertPdfToBase64Async(IFormFile file)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("Fayl boşdur.");

            if (file.Length > MaxFileSize)
                throw new ArgumentException("Faylın ölçüsü maksimum 2 MB ola bilər.");

            if (file.ContentType != "application/pdf")
                throw new ArgumentException("Fayl tipi PDF olmalıdır.");

            using var memoryStream = new MemoryStream();

            await file.CopyToAsync(memoryStream);

            var base64 = Convert.ToBase64String(memoryStream.ToArray());

            return base64;
        }
    }
}
