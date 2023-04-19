using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Chat.Interface;
using Chat.Model;

namespace Chat.Hubs
{
    public class ChatHub : Hub<IChatClient>
    {
        public async Task SendMessage(ChatMessage message)
        {
            await Clients.All.ReceiveMessage(message);
        }
    }

}
