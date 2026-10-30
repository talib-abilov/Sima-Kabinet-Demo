using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Interfaces.Repositories
{
    public interface IGeneratorService
    {
        public Task<string> GenerateQr(string qrUrl);
    }
}
