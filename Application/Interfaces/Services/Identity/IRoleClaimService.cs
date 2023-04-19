using System.Collections.Generic;
using System.Threading.Tasks;
using WordyWellHero.Application.Interfaces.Common;
using WordyWellHero.Application.Requests.Identity;
using WordyWellHero.Application.Responses.Identity;
using WordyWellHero.Shared.Wrapper;

namespace WordyWellHero.Application.Interfaces.Services.Identity
{
    public interface IRoleClaimService : IService
    {
        Task<Result<List<RoleClaimResponse>>> GetAllAsync();

        Task<int> GetCountAsync();

        Task<Result<RoleClaimResponse>> GetByIdAsync(int id);

        Task<Result<List<RoleClaimResponse>>> GetAllByRoleIdAsync(string roleId);

        Task<Result<string>> SaveAsync(RoleClaimRequest request);

        Task<Result<string>> DeleteAsync(int id);
    }
}