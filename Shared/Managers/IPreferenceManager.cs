using System.Threading.Tasks;
using WordyWellHero.Shared.Settings;
using WordyWellHero.Shared.Wrapper;

namespace WordyWellHero.Shared.Managers
{
    public interface IPreferenceManager
    {
        Task SetPreference(IPreference preference);

        Task<IPreference> GetPreference();

        Task<IResult> ChangeLanguageAsync(string languageCode);
    }
}