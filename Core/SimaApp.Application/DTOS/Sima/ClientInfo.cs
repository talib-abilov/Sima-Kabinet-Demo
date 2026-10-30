using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.DTOS.Sima
{
    public class ClientInfo
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; } = null!;
        public string IconURI { get; set; } = null!;
        public string Callback { get; set; } = null!;
        public string? RedirectURI { get; set; }
    }
}
