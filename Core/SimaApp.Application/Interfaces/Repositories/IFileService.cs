using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Interfaces.Repositories
{
    public interface IFileService
    {
        Task<string> ConvertPdfToBase64Async(IFormFile file);
    }
}
