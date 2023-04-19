using System.Threading.Tasks;
using WordyWellHero.Application.Interfaces.Common;
using WordyWellHero.Application.Requests.Identity;
using WordyWellHero.Shared.Wrapper;

namespace WordyWellHero.Application.Interfaces.Services.Account
{
    public interface IAccountService : IService
    {
        Task<IResult> UpdateProfileAsync(UpdateProfileRequest model, string userId);

        Task<IResult> ChangePasswordAsync(ChangePasswordRequest model, string userId);

        Task<IResult<string>> GetProfilePictureAsync(string userId);

        Task<IResult<string>> UpdateProfilePictureAsync(UpdateProfilePictureRequest request, string userId);
    }
}