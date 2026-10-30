using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.DTOS.Sima
{
    public class SimaTransactionCache
    {
        public string OperationId { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;
        public long NbfUTC { get; set; }
        public long ExpUTC { get; set; }
        public string? RawFile { get; set; }
        public string? FileName { get; set; }
    }
}
