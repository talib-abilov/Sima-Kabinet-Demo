using Microsoft.AspNetCore.SignalR;

namespace SimaApp.API.Hubs
{
    public class SimaHub:Hub
    {
        public override async Task OnConnectedAsync()
        {
            Console.WriteLine($"Connected: {Context.ConnectionId}");
            await base.OnConnectedAsync();
        }
        public async Task TestMessage()
        {
            await Clients.Caller.SendAsync(
                "TestMessage",
                "SignalR işləyir!");
        }
        public async Task JoinOperation(string operationId)
        {
            await Groups.AddToGroupAsync(
                Context.ConnectionId,
                operationId);
        }
    }
}
