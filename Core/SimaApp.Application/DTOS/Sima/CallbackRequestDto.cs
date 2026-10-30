using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.DTOS.Sima
{
    public class CallbackRequestDto
    {
        public string sessionid { get; set; } = string.Empty;

        public string type { get; set; } = string.Empty;

        public string operationId { get; set; } = string.Empty;

        public string dataSignature { get; set; } = string.Empty;

        public string? token { get; set; }

        public string? kid { get; set; }

        public string? signedDataHash { get; set; }

        public string? signFormat { get; set; }

        public List<CallBackClaimDto> claims { get; set; } = [];

        public string? algName { get; set; }

        public string? dataName { get; set; }

        public string? statuscode { get; set; }

        public string? message { get; set; }
    }
}
