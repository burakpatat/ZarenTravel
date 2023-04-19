using System.Text.Json;
using WordyWellHero.Application.Interfaces.Serialization.Options;

namespace WordyWellHero.Application.Serialization.Options
{
    public class SystemTextJsonOptions : IJsonSerializerOptions
    {
        public JsonSerializerOptions JsonSerializerOptions { get; } = new();
    }
}