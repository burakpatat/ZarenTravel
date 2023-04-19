using System.Threading.Tasks;
using Chat.Model;

namespace Chat.Interface
{
    public interface IChatClient
    {
        Task ReceiveMessage(ChatMessage message);
    }
}
