using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.DTOS.Sima
{
    public class GenerateQrResponseDto
    {
        public string OperationId { get; set; } = string.Empty;
        public string QrCode { get; set; } = string.Empty;
    }
}
