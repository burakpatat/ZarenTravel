using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using ZarenTravelBO.Models.zaren_prod;

namespace ZarenTravelBO.Data
{
    public partial class zaren_prodContext : DbContext
    {
        public zaren_prodContext()
        {
        }

        public zaren_prodContext(DbContextOptions<zaren_prodContext> options) : base(options)
        {
        }

        partial void OnModelBuilding(ModelBuilder builder);

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ZarenTravelBO.Models.zaren_prod.AgencyContractsConfigurationByHotel>().HasNoKey();

            builder.Entity<ZarenTravelBO.Models.zaren_prod.Agency>()
              .HasOne(i => i.AgencyManager)
              .WithMany(i => i.Agencies)
              .HasForeignKey(i => i.AgencyManagerId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_prod.Agency>()
              .HasOne(i => i.Country1)
              .WithMany(i => i.Agencies)
              .HasForeignKey(i => i.Country)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_prod.Agency>()
              .HasOne(i => i.InvoiceType)
              .WithMany(i => i.Agencies)
              .HasForeignKey(i => i.InvoiceTypeId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_prod.AgencyCmsSocialMediaUrl>()
              .HasOne(i => i.Agency)
              .WithMany(i => i.AgencyCmsSocialMediaUrls)
              .HasForeignKey(i => i.AgencyId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_prod.AgencyCmsTheme>()
              .HasOne(i => i.Agency)
              .WithMany(i => i.AgencyCmsThemes)
              .HasForeignKey(i => i.AgencyId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_prod.AgencyManager>()
              .HasOne(i => i.AgencyMicroSite)
              .WithMany(i => i.AgencyManagers)
              .HasForeignKey(i => i.MicrositeId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteApiProductProvider>()
              .HasOne(i => i.Agency)
              .WithMany(i => i.AgencyMicroSiteApiProductProviders)
              .HasForeignKey(i => i.AgencyId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteApiProductProvider>()
              .HasOne(i => i.AgencyMicroSite)
              .WithMany(i => i.AgencyMicroSiteApiProductProviders)
              .HasForeignKey(i => i.MicroSiteId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteDesign>()
              .HasOne(i => i.Agency)
              .WithMany(i => i.AgencyMicroSiteDesigns)
              .HasForeignKey(i => i.AgencyId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteDomainLanguageSetting>()
              .HasOne(i => i.Agency)
              .WithMany(i => i.AgencyMicroSiteDomainLanguageSettings)
              .HasForeignKey(i => i.AgencyId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteDomainLanguageSetting>()
              .HasOne(i => i.AgencyMicroSite)
              .WithMany(i => i.AgencyMicroSiteDomainLanguageSettings)
              .HasForeignKey(i => i.MicroSiteId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteDomain>()
              .HasOne(i => i.Agency)
              .WithMany(i => i.AgencyMicroSiteDomains)
              .HasForeignKey(i => i.AgencyId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteDomain>()
              .HasOne(i => i.AgencyMicroSite)
              .WithMany(i => i.AgencyMicroSiteDomains)
              .HasForeignKey(i => i.MicroSiteId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_prod.AgencyMicroSitePaymentProvider>()
              .HasOne(i => i.Agency)
              .WithMany(i => i.AgencyMicroSitePaymentProviders)
              .HasForeignKey(i => i.AgencyId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_prod.AgencyMicroSitePaymentProvider>()
              .HasOne(i => i.AgencyMicroSite)
              .WithMany(i => i.AgencyMicroSitePaymentProviders)
              .HasForeignKey(i => i.MicroSiteId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteProperty>()
              .HasOne(i => i.Agency)
              .WithMany(i => i.AgencyMicroSiteProperties)
              .HasForeignKey(i => i.AgencyId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_prod.AgencyMicroSite>()
              .HasOne(i => i.Agency)
              .WithMany(i => i.AgencyMicroSites)
              .HasForeignKey(i => i.AgencyId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingPassengerDatum>()
              .HasOne(i => i.Agency)
              .WithMany(i => i.AgencyMicroSiteSettingPassengerData)
              .HasForeignKey(i => i.AgencyId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingPassengerDatum>()
              .HasOne(i => i.AgencyMicroSite)
              .WithMany(i => i.AgencyMicroSiteSettingPassengerData)
              .HasForeignKey(i => i.MicroSiteId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsBookingProcess>()
              .HasOne(i => i.Agency)
              .WithMany(i => i.AgencyMicroSiteSettingsBookingProcesses)
              .HasForeignKey(i => i.AgencyId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsBookingProcess>()
              .HasOne(i => i.AgencyMicroSite)
              .WithMany(i => i.AgencyMicroSiteSettingsBookingProcesses)
              .HasForeignKey(i => i.MicroSiteId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsEmailVoucher>()
              .HasOne(i => i.Agency)
              .WithMany(i => i.AgencyMicroSiteSettingsEmailVouchers)
              .HasForeignKey(i => i.AgencyId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsEmailVoucher>()
              .HasOne(i => i.AgencyMicroSite)
              .WithMany(i => i.AgencyMicroSiteSettingsEmailVouchers)
              .HasForeignKey(i => i.MicroSiteId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsGeneral>()
              .HasOne(i => i.Agency)
              .WithMany(i => i.AgencyMicroSiteSettingsGenerals)
              .HasForeignKey(i => i.AgencyId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsGeneral>()
              .HasOne(i => i.AgencyMicroSite)
              .WithMany(i => i.AgencyMicroSiteSettingsGenerals)
              .HasForeignKey(i => i.MicroSiteId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsHelpSupport>()
              .HasOne(i => i.Agency)
              .WithMany(i => i.AgencyMicroSiteSettingsHelpSupports)
              .HasForeignKey(i => i.AgencyId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsHelpSupport>()
              .HasOne(i => i.AgencyMicroSite)
              .WithMany(i => i.AgencyMicroSiteSettingsHelpSupports)
              .HasForeignKey(i => i.MicroSiteId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsInvoice>()
              .HasOne(i => i.Agency)
              .WithMany(i => i.AgencyMicroSiteSettingsInvoices)
              .HasForeignKey(i => i.AgencyId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsInvoice>()
              .HasOne(i => i.AgencyMicroSite)
              .WithMany(i => i.AgencyMicroSiteSettingsInvoices)
              .HasForeignKey(i => i.MicroSiteId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsOther>()
              .HasOne(i => i.Agency)
              .WithMany(i => i.AgencyMicroSiteSettingsOthers)
              .HasForeignKey(i => i.AgencyId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsOther>()
              .HasOne(i => i.AgencyMicroSite)
              .WithMany(i => i.AgencyMicroSiteSettingsOthers)
              .HasForeignKey(i => i.MicroSiteId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsSearchEngine>()
              .HasOne(i => i.Agency)
              .WithMany(i => i.AgencyMicroSiteSettingsSearchEngines)
              .HasForeignKey(i => i.AgencyId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsSearchEngine>()
              .HasOne(i => i.AgencyMicroSite)
              .WithMany(i => i.AgencyMicroSiteSettingsSearchEngines)
              .HasForeignKey(i => i.MicroSiteId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsSearchSetting>()
              .HasOne(i => i.Agency)
              .WithMany(i => i.AgencyMicroSiteSettingsSearchSettings)
              .HasForeignKey(i => i.AgencyId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsSearchSetting>()
              .HasOne(i => i.AgencyMicroSite)
              .WithMany(i => i.AgencyMicroSiteSettingsSearchSettings)
              .HasForeignKey(i => i.MicroSiteId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsTermsCondition>()
              .HasOne(i => i.Agency)
              .WithMany(i => i.AgencyMicroSiteSettingsTermsConditions)
              .HasForeignKey(i => i.AgencyId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsTermsCondition>()
              .HasOne(i => i.AgencyMicroSite)
              .WithMany(i => i.AgencyMicroSiteSettingsTermsConditions)
              .HasForeignKey(i => i.MicroSiteId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_prod.AgencyMicroSitesSettingsEmailConfiguration>()
              .HasOne(i => i.Agency)
              .WithMany(i => i.AgencyMicroSitesSettingsEmailConfigurations)
              .HasForeignKey(i => i.AgencyId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_prod.AgencyMicroSitesSettingsEmailConfiguration>()
              .HasOne(i => i.AgencyMicroSite)
              .WithMany(i => i.AgencyMicroSitesSettingsEmailConfigurations)
              .HasForeignKey(i => i.MicroSiteId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_prod.Language>()
              .HasOne(i => i.Agency)
              .WithMany(i => i.Languages)
              .HasForeignKey(i => i.AgencyId)
              .HasPrincipalKey(i => i.Id);
            this.OnModelBuilding(builder);
        }

        public DbSet<ZarenTravelBO.Models.zaren_prod.Agency> Agencies { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.AgencyCmsDevice> AgencyCmsDevices { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.AgencyCmsSectionType> AgencyCmsSectionTypes { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.AgencyCmsSocialMediaUrl> AgencyCmsSocialMediaUrls { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.AgencyCmsTheme> AgencyCmsThemes { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.AgencyContractsClosedTour> AgencyContractsClosedTours { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelCategory> AgencyContractsHotelCategories { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelInformation> AgencyContractsHotelInformations { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelInformationImage> AgencyContractsHotelInformationImages { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelsConfiguration> AgencyContractsHotelsConfigurations { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelsConfigurationDay> AgencyContractsHotelsConfigurationDays { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelsMenu> AgencyContractsHotelsMenus { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceBasicDatum> AgencyContractsInsuranceBasicData { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceSelectedLanguage> AgencyContractsInsuranceSelectedLanguages { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceSelectedProductType> AgencyContractsInsuranceSelectedProductTypes { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceType> AgencyContractsInsuranceTypes { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.AgencyCreditDeposit> AgencyCreditDeposits { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.AgencyManager> AgencyManagers { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteApiProductProvider> AgencyMicroSiteApiProductProviders { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteDesign> AgencyMicroSiteDesigns { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteDomainLanguageSetting> AgencyMicroSiteDomainLanguageSettings { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteDomain> AgencyMicroSiteDomains { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.AgencyMicroSitePaymentProvider> AgencyMicroSitePaymentProviders { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteProperty> AgencyMicroSiteProperties { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.AgencyMicroSite> AgencyMicroSites { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingPassengerDatum> AgencyMicroSiteSettingPassengerData { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsAccommodationSearchResult> AgencyMicroSiteSettingsAccommodationSearchResults { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsBookingProcess> AgencyMicroSiteSettingsBookingProcesses { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsBookingReplicatorMode> AgencyMicroSiteSettingsBookingReplicatorModes { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsEmailVoucher> AgencyMicroSiteSettingsEmailVouchers { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsEnableMultiDay> AgencyMicroSiteSettingsEnableMultiDays { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsGeneral> AgencyMicroSiteSettingsGenerals { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsHelpSupport> AgencyMicroSiteSettingsHelpSupports { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsInvoice> AgencyMicroSiteSettingsInvoices { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsOther> AgencyMicroSiteSettingsOthers { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsPaymetOption> AgencyMicroSiteSettingsPaymetOptions { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsRequestInvoice> AgencyMicroSiteSettingsRequestInvoices { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsRequiredPassenger> AgencyMicroSiteSettingsRequiredPassengers { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsSearchEngine> AgencyMicroSiteSettingsSearchEngines { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsSearchSetting> AgencyMicroSiteSettingsSearchSettings { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsSortType> AgencyMicroSiteSettingsSortTypes { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsTermsCondition> AgencyMicroSiteSettingsTermsConditions { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.AgencyMicroSitesSettingsEmailConfiguration> AgencyMicroSitesSettingsEmailConfigurations { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.AgencyUser> AgencyUsers { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.AirLine> AirLines { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.AirPort> AirPorts { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.AirPortTax> AirPortTaxes { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.ApiProduct> ApiProducts { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.ApiResult> ApiResults { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.Api> Apis { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.Arrival> Arrivals { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.AutoComplete> AutoCompletes { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.AutoCompleteType> AutoCompleteTypes { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.BaggageInformation> BaggageInformations { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.BaggageType> BaggageTypes { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.BaggageUnitType> BaggageUnitTypes { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.City> Cities { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.CityModel> CityModels { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.Country> Countries { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.Country1> Country1S { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.Currency> Currencies { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.Currency1> Currency1S { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.Date> Dates { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.Departure> Departures { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.Explanation> Explanations { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.Feature> Features { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.FlightBrand> FlightBrands { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.FlightClass> FlightClasses { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.FlightFee> FlightFees { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.FlightGeoLocation> FlightGeoLocations { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.FlightItem> FlightItems { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.FlightOffer> FlightOffers { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.FlightProvider> FlightProviders { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.Flight> Flights { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.Gender> Genders { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.GroupKey> GroupKeys { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.HotelCategory> HotelCategories { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.HotelFacility> HotelFacilities { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.HotelFacilityCategory> HotelFacilityCategories { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.HotelFacilityCategorySelectedFacility> HotelFacilityCategorySelectedFacilities { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.HotelPresentation> HotelPresentations { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.Hotel> Hotels { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.HotelSeasonMediaFile> HotelSeasonMediaFiles { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.HotelSeason> HotelSeasons { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.HotelSeasonSelectedTextCategory> HotelSeasonSelectedTextCategories { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.HotelSelectedCategory> HotelSelectedCategories { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.HotelTextCategory> HotelTextCategories { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.HotelTextCategoriesSelectedPresentation> HotelTextCategoriesSelectedPresentations { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.InsuranceSelectedLang> InsuranceSelectedLangs { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.InvoiceType> InvoiceTypes { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.Language> Languages { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.Language1> Language1S { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.LimitType> LimitTypes { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.Passenger> Passengers { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.PassengerType> PassengerTypes { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.PaymentType> PaymentTypes { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.PossibleQuery> PossibleQueries { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.PriceBreakDown> PriceBreakDowns { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.Price> Prices { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.ProductType> ProductTypes { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.SeatInfo> SeatInfos { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.Segment> Segments { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.ServiceFee> ServiceFees { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.Service> Services { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.Statu> Status { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_prod.AgencyContractsConfigurationByHotel> AgencyContractsConfigurationByHotels { get; set; }
    }
}