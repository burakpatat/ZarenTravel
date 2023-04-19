using System.Threading.Tasks;
using WordyWellHero.Application.Features.Dashboards.Queries.GetData;
using WordyWellHero.Shared.Wrapper;

namespace WordyWellHero.Client.Infrastructure.Managers.Dashboard
{
    public interface IDashboardManager : IManager
    {
        Task<IResult<DashboardDataResponse>> GetDataAsync();
    }
}