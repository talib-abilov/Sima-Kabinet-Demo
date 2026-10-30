using Microsoft.AspNetCore.SignalR;
using SimaApp.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Infrastructure.Services
{
    //public class SignalRRealTimeService : IRealTimeService
    //{
    //    private readonly IHubContext<SimaHub> _hubContext;

    //    public SignalRRealtimeService(
    //        IHubContext<SimaHub> hubContext)
    //    {
    //        _hubContext = hubContext;
    //    }
    //    public async Task SendAsync(string eventName, object data)
    //    {
    //        await _hubContext.Clients.All.SendAsync(
    //            eventName,
    //            data);
    //    }
    //}
}
