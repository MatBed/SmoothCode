using Microsoft.AspNetCore.SignalR;

namespace BlazorChat.Server.Hubs;

public class ChatHub : Hub
{ 
    private static Dictionary<string, string> Users = new Dictionary<string, string>();

    public override async Task OnConnectedAsync()
    {
        string username = Context.GetHttpContext().Request.Query["username"];
        Users.Add(Context.ConnectionId, username);
        await AddMessageToChat(string.Empty, $"{username} connected!");
        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? ex)
    {
        string username = Users.FirstOrDefault(u => u.Key == Context.ConnectionId).Value;
        await AddMessageToChat(string.Empty, $"{username} left!");
    }

    public async Task AddMessageToChat(string user, string message)
    {
        await Clients.All.SendAsync("GetThatMessageDude", user, message);
    }
}
