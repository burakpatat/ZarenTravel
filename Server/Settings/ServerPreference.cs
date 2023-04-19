using System.Linq;
using WordyWellHero.Shared.Constants.Localization;
using WordyWellHero.Shared.Settings;

namespace WordyWellHero.Server.Settings
{
    public record ServerPreference : IPreference
    {
        public string LanguageCode { get; set; } = LocalizationConstants.SupportedLanguages.FirstOrDefault()?.Code ?? "en-US";

        //TODO - add server preferences
    }
}