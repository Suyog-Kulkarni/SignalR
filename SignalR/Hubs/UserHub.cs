using Microsoft.AspNetCore.SignalR;
using SignalR.Models;

namespace SignalR.Hubs;

public class UserHub : Hub
{
    public static int TotalViews { get; set; } = 0;

    public static int TotalUsers { get; set; } = 0;

    public override Task OnConnectedAsync()
    {
        TotalUsers++;
        Clients.All.SendAsync("updateTotalUsers", TotalUsers).GetAwaiter().GetResult();
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        TotalUsers--;
        Clients.All.SendAsync("updateTotalUsers", TotalUsers).GetAwaiter().GetResult();
        return base.OnDisconnectedAsync(exception);
    }

    public async Task<string> NewWindowLoaded(string text)
    {
        TotalViews++;
        Messages messages = new();
        // send to all clients that the total views has changed
        await Clients.All.SendAsync("updateTotalViews", TotalViews);
        await Clients.All.SendAsync("updateMessage", messages.Message);
        return $"Total views and text is {messages.Message} : {TotalViews}";
        // we can also return a string to the caller of this method if we want to 
    }

    public async Task<string> SendMessage(string message)
    {
        Messages messages = new();
        messages.Message = message;
        await Clients.All.SendAsync("updateMessage", messages.Message);
        return $"Message is {messages.Message}";
    }
}

