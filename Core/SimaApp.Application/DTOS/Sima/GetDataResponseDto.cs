using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.DTOS.Sima
{
    public class GetDataResponseDto
    {
        public string SessionId { get; set; } = string.Empty;
        public string Type { get; set; } = "raw";
        public List<DataObjectDto> DataObjects { get; set; } = [];
        public string? SignFormat { get; set; }
        public List<string> Claims { get; set; } = [];
        public string? Message { get; set; }
    }
}
