using Microsoft.Extensions.Logging;

namespace WordyWell.Api.Logger
{
    public static class Logger
    {
        private static ILogger _logger;

        public static void Init(ILoggerFactory loggerFactory) => _logger = loggerFactory.CreateLogger(nameof(WordyWell));

        public static void LogInformation(string message, params object[] args) => _logger?.LogInformation(message, args);

        public static void LogDebug(string message, params object[] args) => _logger?.LogDebug(message, args);

        public static void LogError(string message, params object[] args) => _logger?.LogError(message, args);

        public static void LogWarning(string message, params object[] args) => _logger?.LogWarning(message, args);
    }



}
