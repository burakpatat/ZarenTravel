
using Newtonsoft.Json;
using WordyWellHero.Application.Interfaces.Serialization.Settings;

namespace WordyWellHero.Application.Serialization.Settings
{
    public class NewtonsoftJsonSettings : IJsonSerializerSettings
    {
        public JsonSerializerSettings JsonSerializerSettings { get; } = new();
    }
}