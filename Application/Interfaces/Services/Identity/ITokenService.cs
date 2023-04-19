using System.Threading.Tasks;
using WordyWellHero.Application.Interfaces.Common;
using WordyWellHero.Application.Requests.Identity;
using WordyWellHero.Application.Responses.Identity;
using WordyWellHero.Shared.Wrapper;

namespace WordyWellHero.Application.Interfaces.Services.Identity
{
    public interface ITokenService : IService
    {
        Task<Result<TokenResponse>> LoginAsync(TokenRequest model);

        Task<Result<TokenResponse>> GetRefreshTokenAsync(RefreshTokenRequest model);
    }
}