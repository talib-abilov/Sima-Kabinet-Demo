using Microsoft.AspNetCore.SignalR;
using SimaApp.API.Hubs;
using SimaApp.Application.Interfaces.Repositories;

namespace SimaApp.API.Services
{
    public class SimaNotifier : ISimaNotifier
    {
        private readonly IHubContext<SimaHub> _hubContext;

        public SimaNotifier(IHubContext<SimaHub> hubContext)
        {
            _hubContext = hubContext;
        }
        public async Task SendLoginTokenAsync(string operationId, string token)
        {
            await _hubContext
                .Clients
                .Group(operationId)
                .SendAsync("LoginCompleted", new
                {
                    token
                });
        }

        public async Task SendSignedDataHashAsync(string operationId,string signedDataHash)
        {
            await _hubContext
                .Clients
                .Group(operationId)
                .SendAsync("SignCompleted", new
                {
                    signedDataHash
                });
        }
    }
}
