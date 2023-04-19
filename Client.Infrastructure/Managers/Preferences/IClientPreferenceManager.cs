using MudBlazor;
using System.Threading.Tasks;
using WordyWellHero.Shared.Managers;

namespace WordyWellHero.Client.Infrastructure.Managers.Preferences
{
    public interface IClientPreferenceManager : IPreferenceManager
    {
        Task<MudTheme> GetCurrentThemeAsync();

        Task<bool> ToggleDarkModeAsync();
    }
}