using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using Travel.Models.TravelCDb;

namespace Travel.Data
{
    public partial class TravelCDbContext : DbContext
    {
        public TravelCDbContext()
        {
        }

        public TravelCDbContext(DbContextOptions<TravelCDbContext> options) : base(options)
        {
        }

        partial void OnModelBuilding(ModelBuilder builder);

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Travel.Models.TravelCDb.Agency>()
              .HasOne(i => i.AgencyManager)
              .WithMany(i => i.Agencies)
              .HasForeignKey(i => i.AgencyManagerId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Travel.Models.TravelCDb.Agency>()
              .HasOne(i => i.Country)
              .WithMany(i => i.Agencies)
              .HasForeignKey(i => i.CountryId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Travel.Models.TravelCDb.Agency>()
              .HasOne(i => i.InvoiceType)
              .WithMany(i => i.Agencies)
              .HasForeignKey(i => i.InvoiceTypeId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Travel.Models.TravelCDb.Agency>()
              .HasOne(i => i.Statu1)
              .WithMany(i => i.Agencies)
              .HasForeignKey(i => i.Statu)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Travel.Models.TravelCDb.AgencyManager>()
              .HasOne(i => i.MicroSite)
              .WithMany(i => i.AgencyManagers)
              .HasForeignKey(i => i.MicrositeId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Travel.Models.TravelCDb.AgencyManager>()
              .HasOne(i => i.Statu1)
              .WithMany(i => i.AgencyManagers)
              .HasForeignKey(i => i.Statu)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Travel.Models.TravelCDb.AgencyManager>()
              .HasOne(i => i.AgencyUser)
              .WithMany(i => i.AgencyManagers)
              .HasForeignKey(i => i.UserId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Travel.Models.TravelCDb.AgencyUser>()
              .HasOne(i => i.Agency)
              .WithMany(i => i.AgencyUsers)
              .HasForeignKey(i => i.AgencyId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Travel.Models.TravelCDb.AgencyUser>()
              .HasOne(i => i.Country1)
              .WithMany(i => i.AgencyUsers)
              .HasForeignKey(i => i.Country)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Travel.Models.TravelCDb.AgencyUser>()
              .HasOne(i => i.Gender1)
              .WithMany(i => i.AgencyUsers)
              .HasForeignKey(i => i.Gender)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Travel.Models.TravelCDb.AgencyUser>()
              .HasOne(i => i.Currency)
              .WithMany(i => i.AgencyUsers)
              .HasForeignKey(i => i.ManagementFeeCurrencyId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Travel.Models.TravelCDb.AgencyUser>()
              .HasOne(i => i.Statu1)
              .WithMany(i => i.AgencyUsers)
              .HasForeignKey(i => i.Statu)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Travel.Models.TravelCDb.ApiProduct>()
              .HasOne(i => i.Api)
              .WithMany(i => i.ApiProducts)
              .HasForeignKey(i => i.ApiId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Travel.Models.TravelCDb.ApiProduct>()
              .HasOne(i => i.ProductType1)
              .WithMany(i => i.ApiProducts)
              .HasForeignKey(i => i.ProductType)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Travel.Models.TravelCDb.ApiResult>()
              .HasOne(i => i.ProductType1)
              .WithMany(i => i.ApiResults)
              .HasForeignKey(i => i.ProductType)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Travel.Models.TravelCDb.AutoComplete>()
              .HasOne(i => i.Api)
              .WithMany(i => i.AutoCompletes)
              .HasForeignKey(i => i.ApiId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Travel.Models.TravelCDb.AutoComplete>()
              .HasOne(i => i.AutoCompleteType)
              .WithMany(i => i.AutoCompletes)
              .HasForeignKey(i => i.Type)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Travel.Models.TravelCDb.City>()
              .HasOne(i => i.Country)
              .WithMany(i => i.Cities)
              .HasForeignKey(i => i.CountryId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Travel.Models.TravelCDb.Country>()
              .HasOne(i => i.Language)
              .WithMany(i => i.Countries)
              .HasForeignKey(i => i.DefaultLanguageId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Travel.Models.TravelCDb.Country>()
              .HasOne(i => i.MicroSiteCountriesFraudRisk)
              .WithMany(i => i.Countries)
              .HasForeignKey(i => i.HasFraudRiskId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Travel.Models.TravelCDb.Description>()
              .HasOne(i => i.Hotel)
              .WithMany(i => i.Descriptions)
              .HasForeignKey(i => i.HotelId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Travel.Models.TravelCDb.HotelCategory>()
              .HasOne(i => i.Api)
              .WithMany(i => i.HotelCategories)
              .HasForeignKey(i => i.ApiId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Travel.Models.TravelCDb.Hotel>()
              .HasOne(i => i.Agency)
              .WithMany(i => i.Hotels)
              .HasForeignKey(i => i.AgencyId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Travel.Models.TravelCDb.Hotel>()
              .HasOne(i => i.Api)
              .WithMany(i => i.Hotels)
              .HasForeignKey(i => i.ApiId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Travel.Models.TravelCDb.Hotel>()
              .HasOne(i => i.FraudRisk)
              .WithMany(i => i.Hotels)
              .HasForeignKey(i => i.FraudRiskId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Travel.Models.TravelCDb.Hotel>()
              .HasOne(i => i.ManuelRegistration)
              .WithMany(i => i.Hotels)
              .HasForeignKey(i => i.ManuelRegistrationId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Travel.Models.TravelCDb.Hotel>()
              .HasOne(i => i.MicroSite)
              .WithMany(i => i.Hotels)
              .HasForeignKey(i => i.MicroSiteId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Travel.Models.TravelCDb.Hotel>()
              .HasOne(i => i.Statu1)
              .WithMany(i => i.Hotels)
              .HasForeignKey(i => i.Statu)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Travel.Models.TravelCDb.MicroSiteApiProvider>()
              .HasOne(i => i.Agency)
              .WithMany(i => i.MicroSiteApiProviders)
              .HasForeignKey(i => i.AgencyId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Travel.Models.TravelCDb.MicroSiteApiProvider>()
              .HasOne(i => i.Api)
              .WithMany(i => i.MicroSiteApiProviders)
              .HasForeignKey(i => i.ApiId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Travel.Models.TravelCDb.MicroSiteApiProvider>()
              .HasOne(i => i.ApiProduct)
              .WithMany(i => i.MicroSiteApiProviders)
              .HasForeignKey(i => i.ApiProductId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Travel.Models.TravelCDb.MicroSiteApiProvider>()
              .HasOne(i => i.MicroSite)
              .WithMany(i => i.MicroSiteApiProviders)
              .HasForeignKey(i => i.MicroSiteId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Travel.Models.TravelCDb.MicrositeCountry>()
              .HasOne(i => i.Agency)
              .WithMany(i => i.MicrositeCountries)
              .HasForeignKey(i => i.AgencyId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Travel.Models.TravelCDb.MicrositeCountry>()
              .HasOne(i => i.MicroSite)
              .WithMany(i => i.MicrositeCountries)
              .HasForeignKey(i => i.MicroSiteId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Travel.Models.TravelCDb.MicroSiteInvoice>()
              .HasOne(i => i.Agency)
              .WithMany(i => i.MicroSiteInvoices)
              .HasForeignKey(i => i.AgencyId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Travel.Models.TravelCDb.MicroSiteInvoice>()
              .HasOne(i => i.City)
              .WithMany(i => i.MicroSiteInvoices)
              .HasForeignKey(i => i.CityId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Travel.Models.TravelCDb.MicroSiteInvoice>()
              .HasOne(i => i.Country)
              .WithMany(i => i.MicroSiteInvoices)
              .HasForeignKey(i => i.CountryId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Travel.Models.TravelCDb.MicroSiteInvoice>()
              .HasOne(i => i.MicroSite)
              .WithMany(i => i.MicroSiteInvoices)
              .HasForeignKey(i => i.MicroSiteId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Travel.Models.TravelCDb.RoomsSelectedHotel>()
              .HasOne(i => i.Hotel)
              .WithMany(i => i.RoomsSelectedHotels)
              .HasForeignKey(i => i.HotelId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Travel.Models.TravelCDb.RoomsSelectedHotel>()
              .HasOne(i => i.Room)
              .WithMany(i => i.RoomsSelectedHotels)
              .HasForeignKey(i => i.RoomId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Travel.Models.TravelCDb.AgencyUser>()
              .Property(p => p.CreatedDate)
              .HasDefaultValueSql(@"(getdate())");

            builder.Entity<Travel.Models.TravelCDb.AgencyUser>()
              .Property(p => p.UpdatedDate)
              .HasDefaultValueSql(@"(getdate())");
            this.OnModelBuilding(builder);
        }

        public DbSet<Travel.Models.TravelCDb.Agency> Agencies { get; set; }

        public DbSet<Travel.Models.TravelCDb.AgencyManager> AgencyManagers { get; set; }

        public DbSet<Travel.Models.TravelCDb.AgencyUser> AgencyUsers { get; set; }

        public DbSet<Travel.Models.TravelCDb.Api> Apis { get; set; }

        public DbSet<Travel.Models.TravelCDb.ApiProduct> ApiProducts { get; set; }

        public DbSet<Travel.Models.TravelCDb.ApiResult> ApiResults { get; set; }

        public DbSet<Travel.Models.TravelCDb.AutoComplete> AutoCompletes { get; set; }

        public DbSet<Travel.Models.TravelCDb.AutoCompleteType> AutoCompleteTypes { get; set; }

        public DbSet<Travel.Models.TravelCDb.City> Cities { get; set; }

        public DbSet<Travel.Models.TravelCDb.Country> Countries { get; set; }

        public DbSet<Travel.Models.TravelCDb.Currency> Currencies { get; set; }

        public DbSet<Travel.Models.TravelCDb.Description> Descriptions { get; set; }

        public DbSet<Travel.Models.TravelCDb.FraudRisk> FraudRisks { get; set; }

        public DbSet<Travel.Models.TravelCDb.Gender> Genders { get; set; }

        public DbSet<Travel.Models.TravelCDb.HotelCategory> HotelCategories { get; set; }

        public DbSet<Travel.Models.TravelCDb.HotelFacility> HotelFacilities { get; set; }

        public DbSet<Travel.Models.TravelCDb.HotelFacilityCategory> HotelFacilityCategories { get; set; }

        public DbSet<Travel.Models.TravelCDb.HotelPresentation> HotelPresentations { get; set; }

        public DbSet<Travel.Models.TravelCDb.Hotel> Hotels { get; set; }

        public DbSet<Travel.Models.TravelCDb.InvoiceType> InvoiceTypes { get; set; }

        public DbSet<Travel.Models.TravelCDb.ManuelRegistration> ManuelRegistrations { get; set; }

        public DbSet<Travel.Models.TravelCDb.MicroSiteApiProvider> MicroSiteApiProviders { get; set; }

        public DbSet<Travel.Models.TravelCDb.MicrositeCountry> MicrositeCountries { get; set; }

        public DbSet<Travel.Models.TravelCDb.MicroSiteCountriesFraudRisk> MicroSiteCountriesFraudRisks { get; set; }

        public DbSet<Travel.Models.TravelCDb.MicroSiteInvoice> MicroSiteInvoices { get; set; }

        public DbSet<Travel.Models.TravelCDb.MicroSite> MicroSites { get; set; }

        public DbSet<Travel.Models.TravelCDb.ProductType> ProductTypes { get; set; }

        public DbSet<Travel.Models.TravelCDb.Room> Rooms { get; set; }

        public DbSet<Travel.Models.TravelCDb.RoomsSelectedHotel> RoomsSelectedHotels { get; set; }

        public DbSet<Travel.Models.TravelCDb.Statu> Status { get; set; }

        public DbSet<Travel.Models.TravelCDb.Language> Languages { get; set; }
    }
}