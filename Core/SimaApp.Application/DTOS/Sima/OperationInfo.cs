using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.DTOS.Sima
{
    public class OperationInfo
    {
        public string Type { get; set; } = null!;
        public string OperationId { get; set; } = null!;
        public long NbfUTC { get; set; }
        public long ExpUTC { get; set; }
        public List<string> Assignee { get; set; } = [];
    }
}
