using System.Collections.Generic;
using System.Threading.Tasks;
using WordyWellHero.Application.Interfaces.Chat;
using WordyWellHero.Application.Models.Chat;
using WordyWellHero.Application.Responses.Identity;
using WordyWellHero.Shared.Wrapper;

namespace WordyWellHero.Client.Infrastructure.Managers.Communication
{
    public interface IChatManager : IManager
    {
        Task<IResult<IEnumerable<ChatUserResponse>>> GetChatUsersAsync();

        Task<IResult> SaveMessageAsync(ChatHistory<IChatUser> chatHistory);

        Task<IResult<IEnumerable<ChatHistoryResponse>>> GetChatHistoryAsync(string cId);
    }
}