using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Radzen;
using ZarenBlazorAdmin.Services;
using ZarenBlazorAdmin.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();

builder.Services.AddScoped<BrandsService>();
builder.Services.AddScoped<CategoriesService>();
builder.Services.AddScoped<CustomersService>();
builder.Services.AddScoped<Order_ItemsService>();
builder.Services.AddScoped<OrdersService>();
builder.Services.AddScoped<ProductsService>();
builder.Services.AddScoped<StaffsService>();
builder.Services.AddScoped<StocksService>();
builder.Services.AddScoped<StoresService>();
builder.Services.AddScoped<AgenciesService>();
builder.Services.AddScoped<BoardtypelanguagesService>();
builder.Services.AddScoped<BoardtypesService>();
builder.Services.AddScoped<BookingdealsService>();
builder.Services.AddScoped<BookingroomsService>();
builder.Services.AddScoped<BookingsService>();
builder.Services.AddScoped<BuyroomsService>();
builder.Services.AddScoped<CancelationlanguagesService>();
builder.Services.AddScoped<CancellationrulesService>();
builder.Services.AddScoped<CancellationseasonsService>();
builder.Services.AddScoped<CitiesService>();
builder.Services.AddScoped<ContactsService>();
builder.Services.AddScoped<CountriesService>();
builder.Services.AddScoped<DealsService>();
builder.Services.AddScoped<DealtypelanguagesService>();
builder.Services.AddScoped<DealtypesService>();
builder.Services.AddScoped<FacilitiesService>();
builder.Services.AddScoped<FacilitieshotelsService>();
builder.Services.AddScoped<FacilitylanguagesService>();
builder.Services.AddScoped<HotelagencymarkupsService>();
builder.Services.AddScoped<HotelbuyroomallotmentService>();
builder.Services.AddScoped<HotelbuyroomsService>();
builder.Services.AddScoped<HotelchainsService>();
builder.Services.AddScoped<ZonescitiesService>();
builder.Services.AddScoped<HoteldescriptionsService>();
builder.Services.AddScoped<HotelphotolanguagesService>();
builder.Services.AddScoped<HotelphotosService>();
builder.Services.AddScoped<HotelroomdailypricesService>();
builder.Services.AddScoped<HotelroomlanguagesService>();
builder.Services.AddScoped<HotelroomsService>();
builder.Services.AddScoped<HotelsService>();
builder.Services.AddScoped<HoteltypelanguagesService>();
builder.Services.AddScoped<HoteltypesService>();
builder.Services.AddScoped<LanguagesService>();
builder.Services.AddScoped<ProvidersService>();
builder.Services.AddScoped<RegionsService>();
builder.Services.AddScoped<RoomsService>();
builder.Services.AddScoped<ZonesService>();

builder.Services.AddDbContext<AppDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("conString"));
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

app.UseRouting();
app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();