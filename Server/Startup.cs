using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using WordyWellHero.Application.Extensions;
using WordyWellHero.Infrastructure.Extensions;
using WordyWellHero.Server.Extensions;
using WordyWellHero.Server.Filters;
using WordyWellHero.Server.Managers.Preferences;
using WordyWellHero.Server.Middlewares;

namespace WordyWellHero.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private readonly IConfiguration _configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public void ConfigureServices(IServiceCollection services)
        {




            MyConfiguration.Configuration = _configuration;
            services.AddCors();
            services.AddSignalR();
            services.AddLocalization(options =>
            {
                options.ResourcesPath = "Resources";
            });
            services.AddCurrentUserService();
            services.AddSerialization();
            services.AddDatabase(_configuration);
            services.AddServerStorage(); //TODO - should implement ServerStorageProvider to work correctly!
            services.AddScoped<ServerPreferenceManager>();
            services.AddServerLocalization();
            services.AddIdentity();
            services.AddJwtAuthentication(services.GetApplicationSettings(_configuration));
            services.AddApplicationLayer();
            services.AddApplicationServices();
            services.AddRepositories();
            services.AddExtendedAttributesUnitOfWork();
            services.AddSharedInfrastructure(_configuration);
            services.RegisterSwagger();
            services.AddInfrastructureMappings();
            services.AddHangfire(x => x.UseSqlServerStorage(_configuration.GetConnectionString("DefaultConnection")));
            services.AddHangfireServer();
            services.AddControllers().AddValidators();
            services.AddExtendedAttributesValidators();
            services.AddExtendedAttributesHandlers();
            services.AddRazorPages();
            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });
            services.AddLazyCache();
            services.AddApplicationInsightsTelemetry();


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IStringLocalizer<Startup> localizer)
        {
            //app.Use((context, next) =>
            //{
            //    context.Features.Get<IHttpMaxRequestBodySizeFeature>().MaxRequestBodySize = null;
            //    return next.Invoke();
            //});

            app.UseCors();
            app.UseExceptionHandling(env);
            app.UseHttpsRedirection();
            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();
            //app.UseStaticFiles(new StaticFileOptions
            //{
            //    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Files")),
            //    RequestPath = new PathString("/Files")
            //});
            app.UseRequestLocalizationByCulture();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseHangfireDashboard("/agent", new DashboardOptions
            {
                DashboardTitle = localizer["Wordy Jobs"],
                Authorization = new[] { new HangfireAuthorizationFilter() }
            });


            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapPost("/native-upload", async ctx =>
            //    {
            //        var start = DateTime.Now;
            //        var ms = new MemoryStream();
            //        await ctx.Request.Body.CopyToAsync(ms);
            //        var end = DateTime.Now;
            //        await ctx.Response.WriteAsync($"Received {ms.Position} bytes in {(end - start).TotalMilliseconds} ms");
            //    });

            //});
            app.UseEndpoints();
            app.ConfigureSwagger();
            app.Initialize(_configuration);
        }
    }
}