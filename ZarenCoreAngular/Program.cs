using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RepoDb;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

string MyAllowSpecificOrigins = "_myAllowSpecificOrigins"; 

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDistributedSqlServerCache(options =>
{
    options.ConnectionString = builder.Configuration.GetValue<string>("ConnectionStringLog"); ;
    options.SchemaName = "dbo";
    options.TableName = "DistributedServerCache";
    options.DefaultSlidingExpiration = TimeSpan.FromMinutes(120);
    options.ExpiredItemsDeletionInterval = TimeSpan.FromMinutes(120);
});
builder.Services.AddDistributedSqlServerCache(options => {
    options.DefaultSlidingExpiration = TimeSpan.FromMinutes(10);
});

builder.Services.AddDistributedSqlServerCache(options => {
    options.ExpiredItemsDeletionInterval = TimeSpan.FromMinutes(6);
});

//builder.Services.AddCap(x =>
//{
//    x.UseEntityFramework<AppDbContext>();
//    x.UseRabbitMQ(y =>
//    {
//        y.UserName = "user";
//        y.Password = "pass";
//        y.HostName = "localhost:5672,localhost:5673,localhost:5674";
//    });

//    x.UseEntityFramework<AppDbContext>(); //Options, Notice: You don't need to config x.UseSqlServer(""") again! CAP can autodiscovery.

//    // If you are using ADO.NET, choose to add configuration you needed：
//    x.UseSqlServer("Your ConnectionStrings");
//    x.UseMySql("Your ConnectionStrings");
//    x.UsePostgreSql("Your ConnectionStrings");

//    // If you are using MongoDB, you need to add the configuration：
//    x.UseMongoDB("Your ConnectionStrings");  //MongoDB 4.0+ cluster

//    // CAP support RabbitMQ,Kafka,AzureService as the MQ, choose to add configuration you needed：
//    x.UseRabbitMQ("ConnectionString");
//    x.UseKafka("ConnectionString");
//    x.UseAzureServiceBus("ConnectionString");
//    x.UseAmazonSQS();

//    x.UseDashboard();
//    x.FailedRetryCount = 5;
//    x.UseDispatchingPerGroup = true;

//    x.FailedThresholdCallback = failed =>
//    {
//        var logger = failed.ServiceProvider.GetRequiredService<ILogger<Startup>>();
//        logger.LogError($@"A message of type {failed.MessageType} failed after executing {x.FailedRetryCount} several times, 
//                        requiring manual troubleshooting. Message name: {failed.Message.GetName()}");
//    };
//    x.JsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);
//});

builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v2", new OpenApiInfo
    {
        Version = "v2",
        Title = "Unitead API DEV Swagger",
        Description = "Unitead API DEV Swagger on (ASP.NET Core 6.0)",
        Contact = new OpenApiContact()
        {
            Name = "Swagger Implementation (Unitead API Developers)",
        },
    });
    c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "basic",
        In = ParameterLocation.Header,
        Description = "Basic Authorization header using the Bearer scheme."
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "basic"
                                }
                            },
                            new string[] {}
                    }
                });
});

IConfigurationSection audienceConfig = builder.Configuration.GetSection("Audience");
SymmetricSecurityKey signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(audienceConfig["Secret"]));//appsettings.json içerisinde bulunan signingkey değeri
TokenValidationParameters tokenValidationParameters = new TokenValidationParameters()
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
builder.Services.AddAuthentication(o =>
{
    o.DefaultAuthenticateScheme = "Bearer";
    o.DefaultChallengeScheme = "Bearer";

});
builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
    builder =>
    {
        builder.WithOrigins("http://localhost:3001",
            "http://localhost:3000",
            "https://localhost:5000",
            "http://localhost:5001",
            "http://localhost:52438",
            "http://localhost:52436",
            "http://localhost:3002",
            "http://localhost:8008",
            "https://localhost:7140",
            "https://localhost:12010"
           )
        .AllowCredentials()
         .WithMethods("OPTIONS", "GET", "PUT", "POST", "DELETE")
        .WithHeaders("Access-Control-Allow-Headers", "Access-Control-Allow-Origin", "Content-Type", "Authorization", "PURINTDEMSTAPRECOMNAVOTCNOI", "Mail");
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
   
    app.UseDeveloperExceptionPage();
}
else
    app.UseHsts();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Zaren API V1 DEV");
    c.RoutePrefix = "ZarenApiDev";
    c.DisplayRequestDuration();
});

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


 

app.UseCors(MyAllowSpecificOrigins);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
