using System.Collections.Generic;
using System.Threading.Tasks;
using WordyWellHero.Application.Responses.Audit;
using WordyWellHero.Shared.Wrapper;

namespace WordyWellHero.Client.Infrastructure.Managers.Audit
{
    public interface IAuditManager : IManager
    {
        Task<IResult<IEnumerable<AuditResponse>>> GetCurrentUserTrailsAsync();

        Task<IResult<string>> DownloadFileAsync(string searchString = "", bool searchInOldValues = false, bool searchInNewValues = false);
    }
}