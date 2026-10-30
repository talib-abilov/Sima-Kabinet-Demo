using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.DTOS.Sima
{
    public class CallBackResponseDto
    {
        public string? Message { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
