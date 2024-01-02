using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using SignalR.Models;

namespace SignalR.Hubs;
public class NotificationHub : Hub
{
  


    public override Task OnConnectedAsync()
    {
        ConnectedUser.UsersId.Add(Context.ConnectionId);// add connection id to list of connected users id 
        // connection id changes every time the user refreshes the page
        // 
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        ConnectedUser.UsersId.Remove(Context.ConnectionId);// remove connection id from list of connected users id 
        return base.OnDisconnectedAsync(exception);
    }
}

