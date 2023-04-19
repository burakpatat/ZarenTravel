using System.Collections.Generic;
using System.Threading.Tasks;
using WordyWellHero.Application.Interfaces.Chat;
using WordyWellHero.Application.Models.Chat;
using WordyWellHero.Application.Responses.Identity;
using WordyWellHero.Shared.Wrapper;

namespace WordyWellHero.Application.Interfaces.Services
{
    public interface IChatService
    {
        Task<Result<IEnumerable<ChatUserResponse>>> GetChatUsersAsync(string userId);

        Task<IResult> SaveMessageAsync(ChatHistory<IChatUser> message);

        Task<Result<IEnumerable<ChatHistoryResponse>>> GetChatHistoryAsync(string userId, string contactId);
    }
}