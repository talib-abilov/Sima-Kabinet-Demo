using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Interfaces.Repositories
{
    public interface ISimaNotifier
    {
        Task SendLoginTokenAsync(string operationId, string token);

        Task SendSignedDataHashAsync(string operationId, string signedDataHash);
    }
}
