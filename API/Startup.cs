using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Linq;
using System.Reflection;
using System.Text;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Zaren.Api
{
    public class Startup
    {
        private readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            MyConfiguration.Configuration = Configuration;

            services.AddLogging();
            services.AddApplicationInsightsTelemetry(Configuration);


            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("http://localhost:3001",
                        "http://localhost:3000",
                        "https://localhost:5000",
                        "http://localhost:5001",
                        "http://localhost:52438",
                      
                        "http://localhost:52436"

                        )
                    .AllowCredentials()
                     .WithMethods("OPTIONS", "GET", "PUT", "POST", "DELETE")
                    .WithHeaders("Access-Control-Allow-Headers", "Access-Control-Allow-Origin", "Content-Type", "Authorization");
                });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Zaren API Documentation",
                    Description = "Zaren API DEV Swagger on (ASP.NET Core 6.0)",
                    Contact = new OpenApiContact()
                    {
                        Name = "Zaren",
                        Email = "gokhan.sahinbas@hotmail.com"
                    },
                });
            });


            services.AddMvc(option =>
            {
                option.EnableEndpointRouting = false;
            })
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.WriteIndented = true;
                options.JsonSerializerOptions.MaxDepth = 64;
            });


            var audienceConfig = Configuration.GetSection("Audience");
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(audienceConfig["Secret"]));//appsettings.json içerisinde bulunan signingkey değeri
            var tokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,
                ValidateIssuer = true,
                ValidIssuer = audienceConfig["Iss"],
                ValidateAudience = true,
                ValidAudience = audienceConfig["Aud"],
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                RequireExpirationTime = true
            };

            services.AddAuthentication(o => { o.DefaultAuthenticateScheme = "Barear"; });
            services.AddAuthentication().AddJwtBearer("Barear", x =>
            {
                x.RequireHttpsMetadata = false;
                x.TokenValidationParameters = tokenValidationParameters;
            });

            // services.AddValidatorConfigrationLayer();

            services.AddDistributedSqlServerCache(options =>
            {
                options.ConnectionString = MyConfiguration.Configuration.GetSection("ConnectionStringLog").Value;
                options.SchemaName = "dbo";
                options.TableName = "DistributedServerCache";
                options.DefaultSlidingExpiration = TimeSpan.FromMinutes(120);
                options.ExpiredItemsDeletionInterval = TimeSpan.FromMinutes(120);
            });

            var businessAssembly = Assembly.Load("Zaren.Business");
            var dataAccessAssembly = Assembly.Load("Zaren.Data");

            var types = businessAssembly.GetTypes()
                                        .Concat(dataAccessAssembly.GetTypes())
                                        .Where(type => type.IsInterface && type.GetInterfaces().Where(r => r.Name.Contains("IEntityRepository")).Any())
                                        .Select(_interface => new
                                        {
                                            Abstract = _interface,
                                            Concrete = _interface.Assembly
                                                                 .GetTypes()
                                                                 .Where(c => c.IsClass
                                                                          && c.GetInterfaces().Where(r => r == _interface).Any())
                                                                 .FirstOrDefault()
                                        }).ToArray();

            foreach (var type in types)
            {
                services.AddScoped(type.Abstract, type.Concrete);
            }


            //services.AddSignalR();

            //services.AddCors(options =>
            //{
            //    options.AddPolicy("ClientPermission", policy =>
            //    {
            //        policy.AllowAnyHeader()
            //            .AllowAnyMethod()
            //            .WithOrigins("http://localhost:3000")
            //            .AllowCredentials();
            //    });
            //});


            //  services.Scan(scan => scan
            //.FromAssembliesOf(new List<Type>()
            //{
            //     typeof(QueryDispatcher),
            //     typeof(CommandResult),
            //})
            ////Register the dispatchers via their namespace
            //.AddClasses(classes => classes.InNamespaces("Client.Project.Infrastructure.Dispatchers"))
            //.AsImplementedInterfaces()
            //.WithScopedLifetime()

            ////Register all query handlers
            //.AddClasses(classes => classes.AssignableTo(typeof(IQueryHandler<,>)))
            //.AsImplementedInterfaces()
            //.WithScopedLifetime()

            ////Register all command handlers
            //.AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<,>)))
            //.AsImplementedInterfaces()
            //.WithScopedLifetime()
            //);


        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //loggerFactory.AddApplicationInsights(app.ApplicationServices, LogLevel.Warning);
            app.UseStatusCodePages();


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async context =>
                    {
                        //var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
                        //if (exceptionHandlerFeature != null)
                        //{
                        //    var logger = loggerFactory.CreateLogger("Global exception logger");
                        //    logger.LogError(500, exceptionHandlerFeature.Error, exceptionHandlerFeature.Error.Message);
                        //}
                        //context.Response.StatusCode = 500;
                        //await context.Response.WriteAsync("An unexpected error has occured. Please try again later.");
                    });
                });
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Zaren API V2 DEV");
            });
            app.UseHsts();

            app.UseHttpsRedirection();


            app.UseCors(MyAllowSpecificOrigins);
            //app.UseAuthentication();
            app.UseStaticFiles();
            app.UseMiddleware<CurrentUserMiddleware>();
            app.UseMiddleware<RequestLogMiddleware>();

            app.UseMvc();

            // app.UseRouting();

        }
    }
}