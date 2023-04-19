using System.Collections.Generic;
using System.Threading.Tasks;
using WordyWellHero.Application.Requests.Identity;
using WordyWellHero.Application.Responses.Identity;
using WordyWellHero.Shared.Wrapper;

namespace WordyWellHero.Client.Infrastructure.Managers.Identity.RoleClaims
{
    public interface IRoleClaimManager : IManager
    {
        Task<IResult<List<RoleClaimResponse>>> GetRoleClaimsAsync();

        Task<IResult<List<RoleClaimResponse>>> GetRoleClaimsByRoleIdAsync(string roleId);

        Task<IResult<string>> SaveAsync(RoleClaimRequest role);

        Task<IResult<string>> DeleteAsync(string id);
    }
}