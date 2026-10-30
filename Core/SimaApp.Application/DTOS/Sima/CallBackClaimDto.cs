using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SimaApp.Application.DTOS.Sima
{
    public class CallBackClaimDto
    {
        public string Type { get; set; } = string.Empty;

        public JsonElement Value { get; set; }
    }
}
