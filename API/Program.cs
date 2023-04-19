using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace WordyWell.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {

            const string logTemplate = @"{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u4}] [{SourceContext:l}] {Message:lj}{NewLine}{Exception}";
            Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                    .Enrich.FromLogContext()
                    .WriteTo.Logger(l =>
                    {
                        l.WriteTo.File("information.txt", LogEventLevel.Information, logTemplate,
                            rollingInterval: RollingInterval.Day, rollOnFileSizeLimit: true,
                     fileSizeLimitBytes: 123456
                        );

                    })
                    .WriteTo.Logger(l =>
                    {
                        l.WriteTo.File("debug.txt", LogEventLevel.Debug, logTemplate,
                            rollingInterval: RollingInterval.Day
                        );

                    }).
                    WriteTo.Logger(l =>
                    {
                        l.WriteTo.File("error.txt", LogEventLevel.Error, logTemplate,
                            rollingInterval: RollingInterval.Day
                        );

                    })
                    .CreateLogger();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseContentRoot(Directory.GetCurrentDirectory());
                webBuilder.UseIISIntegration();
                webBuilder.UseStartup<Startup>();
            });

    }
}
