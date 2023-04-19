using System.Collections.Generic;
using System.Threading.Tasks;
using WordyWellHero.Application.Responses.Audit;
using WordyWellHero.Shared.Wrapper;

namespace WordyWellHero.Application.Interfaces.Services
{
    public interface IAuditService
    {
        Task<IResult<IEnumerable<AuditResponse>>> GetCurrentUserTrailsAsync(string userId);

        Task<IResult<string>> ExportToExcelAsync(string userId, string searchString = "", bool searchInOldValues = false, bool searchInNewValues = false);
    }
}