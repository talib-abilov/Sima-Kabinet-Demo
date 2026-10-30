using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.DTOS.Sima
{
    public class SignableContainer
    {
        public ProtoInfo ProtoInfo { get; set; } = null!;
        public OperationInfo OperationInfo { get; set; } = null!;
        public DataInfo DataInfo { get; set; } = null!;
        public ClientInfo ClientInfo { get; set; } = null!;
    }
}
