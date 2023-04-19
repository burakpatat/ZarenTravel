using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;
using Radzen;
using SanTsgHotelBooking.Application.Services;
using SanTsgHotelBooking.Application.Services.IServices;
using SanTsgHotelBooking.Shared.SettingsModels;
using ZarenUI.Data;
using ZarenUI.Models;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
 
using System;
using System.Linq;
using System.Reflection;
using System.Text;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Authentication.Facebook;


var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();


builder.Services.AddHttpClient("ZarenUI").AddHeaderPropagation(o => o.Headers.Add("Cookie"));
builder.Services.AddHeaderPropagation(o => o.Headers.Add("Cookie"));
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddScoped<ZarenUI.SecurityService>();
builder.Services.AddScoped<AutoCompletesRepository>(); 
builder.Services.AddScoped<TransactionsRepository>();
builder.Services.AddScoped<PaymentConfigurationRepository>();
builder.Services.AddScoped<PaymentRequestModel>();
builder.Services.AddScoped<TransactionDetailsRepository>();
builder.Services.AddScoped<BookingTravellersRepository>();
builder.Services.AddScoped<BookingReservationsRepository>();
builder.Services.AddScoped<CountryRepository>();
builder.Services.AddScoped<AccountLikesRepository>();
builder.Services.AddScoped<AspNetUsersRepository>();
builder.Services.AddScoped<TokenHelper>(); 
builder.Services.AddHttpClient();
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.Configure<TourvisioAPISettings>(builder.Configuration.GetSection("TourVisioApi")); 
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<ISanTsgTourVisioService, SanTsgTourVisioService>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.Configure<ClientRateLimitOptions>(builder.Configuration.GetSection("ClientRateLimiting"));
builder.Services.Configure<ClientRateLimitPolicies>(builder.Configuration.GetSection("ClientRateLimitPolicies"));
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = FacebookDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = FacebookDefaults.AuthenticationScheme;
})
.AddFacebook(options =>
{
    options.AppId = builder.Configuration["Authentication:Facebook:AppId"];
    options.AppSecret = builder.Configuration["Authentication:Facebook:AppSecret"];
}).AddGoogle(options =>
{
    options.ClientId = builder.Configuration["Authentication:Google:ClientId"];
    options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
}); 


builder.Services.AddDbContext<ApplicationIdentityDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ZarenTravel"));
});
//builder.Services.AddIdentity<ApplicationUser, ApplicationRole>().AddEntityFrameworkStores<ApplicationIdentityDbContext>().AddDefaultTokenProviders();
builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();

builder.Services.AddControllers().AddOData(o =>
{
    var oDataBuilder = new ODataConventionModelBuilder();
    oDataBuilder.EntitySet<ApplicationUser>("ApplicationUsers");
    var usersType = oDataBuilder.StructuralTypes.First(x => x.ClrType == typeof(ApplicationUser));
    usersType.AddProperty(typeof(ApplicationUser).GetProperty(nameof(ApplicationUser.Password)));
    usersType.AddProperty(typeof(ApplicationUser).GetProperty(nameof(ApplicationUser.ConfirmPassword)));
    oDataBuilder.EntitySet<ApplicationRole>("ApplicationRoles");
    o.AddRouteComponents("odata/Identity", oDataBuilder.GetEdmModel()).Count().Filter().OrderBy().Expand().Select().SetMaxTop(null).TimeZone = TimeZoneInfo.Utc;
});
builder.Services.AddScoped<AuthenticationStateProvider, ZarenUI.ApplicationAuthenticationStateProvider>();
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(_ =>
{
    _.Password.RequiredLength = 5;
    _.Password.RequireNonAlphanumeric = true; 
    _.Password.RequireLowercase = true;
    _.Password.RequireUppercase = true;
    _.Password.RequireDigit = false; 
    _.User.RequireUniqueEmail = true;

}).AddEntityFrameworkStores<ApplicationIdentityDbContext>()
  .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(o => 
{
    o.ExpireTimeSpan = TimeSpan.FromSeconds(5);
    o.SlidingExpiration = true;
});
builder.Services.AddLocalization();

builder.Services.AddDistributedSqlServerCache(options =>
{
    options.ConnectionString = builder.Configuration.GetConnectionString("ZarenTravel"); 
    options.SchemaName = "dbo";
    options.TableName = "DistributedServerCache";
    options.DefaultSlidingExpiration = TimeSpan.FromMinutes(1000);
    options.ExpiredItemsDeletionInterval = TimeSpan.FromMinutes(2000);
  
});


var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseHeaderPropagation();
app.UseRequestLocalization(options => options
                                            .AddSupportedCultures("en", "es", "ar", "zh", "nl", "fr", "de", "it", "pt", "el", "ru", "tr")
                                            .AddSupportedUICultures("en", "es", "ar", "zh", "nl", "fr", "de", "it", "pt", "el", "ru", "tr")
                                            .SetDefaultCulture("tr"));
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.Services.CreateScope().ServiceProvider.GetRequiredService<ApplicationIdentityDbContext>().Database.Migrate();
app.Run();