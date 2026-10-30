using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Constants
{
    public static class SimaRedisKeys
    {
        public static string Transaction(string operationId)
            => $"sima:transaction:{operationId}";
    }
}
