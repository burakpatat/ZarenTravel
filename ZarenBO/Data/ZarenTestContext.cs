using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using ZarenTravelBO.Models.zaren_test;

namespace ZarenTravelBO.Data
{
    public partial class zaren_testContext : DbContext
    {
        public zaren_testContext()
        {
        }

        public zaren_testContext(DbContextOptions<zaren_testContext> options) : base(options)
        {
        }

        partial void OnModelBuilding(ModelBuilder builder);

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ZarenTravelBO.Models.zaren_test.AgencyContractsConfigurationByHotel>().HasNoKey();

            builder.Entity<ZarenTravelBO.Models.zaren_test.AgencyCmsSectionType>()
              .HasOne(i => i.Agency)
              .WithMany(i => i.AgencyCmsSectionTypes)
              .HasForeignKey(i => i.AgencyId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_test.AgencyCmsSocialMediaUrl>()
              .HasOne(i => i.Agency)
              .WithMany(i => i.AgencyCmsSocialMediaUrls)
              .HasForeignKey(i => i.AgencyId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_test.AgencyCmsTheme>()
              .HasOne(i => i.Agency)
              .WithMany(i => i.AgencyCmsThemes)
              .HasForeignKey(i => i.AgencyId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_test.AgencyManager>()
              .HasOne(i => i.Agency)
              .WithMany(i => i.AgencyManagers)
              .HasForeignKey(i => i.AgencyId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_test.AgencyManager>()
              .HasOne(i => i.AgencyUser)
              .WithMany(i => i.AgencyManagers)
              .HasForeignKey(i => i.AgencyUserId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_test.AutoComplete>()
              .HasOne(i => i.AutoCompleteType)
              .WithMany(i => i.AutoCompletes)
              .HasForeignKey(i => i.Type)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_test.Board>()
              .HasOne(i => i.Agency)
              .WithMany(i => i.Boards)
              .HasForeignKey(i => i.AgencyId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_test.Board>()
              .HasOne(i => i.Language)
              .WithMany(i => i.Boards)
              .HasForeignKey(i => i.LanguageId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_test.CancellationPolicy>()
              .HasOne(i => i.Agency)
              .WithMany(i => i.CancellationPolicies)
              .HasForeignKey(i => i.AgencyId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_test.CancellationPolicy>()
              .HasOne(i => i.Language)
              .WithMany(i => i.CancellationPolicies)
              .HasForeignKey(i => i.LanguageId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_test.City>()
              .HasOne(i => i.Agency)
              .WithMany(i => i.Cities)
              .HasForeignKey(i => i.AgencyId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_test.City>()
              .HasOne(i => i.Language)
              .WithMany(i => i.Cities)
              .HasForeignKey(i => i.LanguageId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_test.Country>()
              .HasOne(i => i.Agency)
              .WithMany(i => i.Countries)
              .HasForeignKey(i => i.AgencyId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_test.Country>()
              .HasOne(i => i.Language)
              .WithMany(i => i.Countries)
              .HasForeignKey(i => i.LanguageId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_test.Currency1>()
              .HasOne(i => i.Agency)
              .WithMany(i => i.Currency1S)
              .HasForeignKey(i => i.AgencyId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_test.FacilitiesSelectedCategory>()
              .HasOne(i => i.Agency)
              .WithMany(i => i.FacilitiesSelectedCategories)
              .HasForeignKey(i => i.AgencyId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_test.FacilitiesSelectedCategory>()
              .HasOne(i => i.Language)
              .WithMany(i => i.FacilitiesSelectedCategories)
              .HasForeignKey(i => i.LanguageId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_test.HotelCategory>()
              .HasOne(i => i.Agency)
              .WithMany(i => i.HotelCategories)
              .HasForeignKey(i => i.AgencyId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_test.HotelCategory>()
              .HasOne(i => i.Language)
              .WithMany(i => i.HotelCategories)
              .HasForeignKey(i => i.LanguageId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_test.HotelOffer>()
              .HasOne(i => i.Agency)
              .WithMany(i => i.HotelOffers)
              .HasForeignKey(i => i.AgencyId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_test.HotelOffer>()
              .HasOne(i => i.Language)
              .WithMany(i => i.HotelOffers)
              .HasForeignKey(i => i.LanguageId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_test.HotelPaymentPlan>()
              .HasOne(i => i.Agency)
              .WithMany(i => i.HotelPaymentPlans)
              .HasForeignKey(i => i.AgencyId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_test.HotelPaymentPlan>()
              .HasOne(i => i.Language)
              .WithMany(i => i.HotelPaymentPlans)
              .HasForeignKey(i => i.LanguageId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_test.HotelTheme>()
              .HasOne(i => i.Agency)
              .WithMany(i => i.HotelThemes)
              .HasForeignKey(i => i.AgencyId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_test.HotelTheme>()
              .HasOne(i => i.Language)
              .WithMany(i => i.HotelThemes)
              .HasForeignKey(i => i.LanguageId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_test.HotelTheme>()
              .HasOne(i => i.Theme)
              .WithMany(i => i.HotelThemes)
              .HasForeignKey(i => i.ThemesId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_test.Information>()
              .HasOne(i => i.Agency)
              .WithMany(i => i.Informations)
              .HasForeignKey(i => i.AgencyId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_test.Information>()
              .HasOne(i => i.Language)
              .WithMany(i => i.Informations)
              .HasForeignKey(i => i.LanguageId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_test.Item>()
              .HasOne(i => i.Agency)
              .WithMany(i => i.Items)
              .HasForeignKey(i => i.AgencyId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_test.Item>()
              .HasOne(i => i.City)
              .WithMany(i => i.Items)
              .HasForeignKey(i => i.CityId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_test.Item>()
              .HasOne(i => i.Country)
              .WithMany(i => i.Items)
              .HasForeignKey(i => i.CoutryId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_test.Item>()
              .HasOne(i => i.Language)
              .WithMany(i => i.Items)
              .HasForeignKey(i => i.LanguageId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_test.Language>()
              .HasOne(i => i.Agency)
              .WithMany(i => i.Languages)
              .HasForeignKey(i => i.AgencyId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_test.RoomInfosMediaFile>()
              .HasOne(i => i.Agency)
              .WithMany(i => i.RoomInfosMediaFiles)
              .HasForeignKey(i => i.AgencyId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_test.RoomInfosMediaFile>()
              .HasOne(i => i.Language)
              .WithMany(i => i.RoomInfosMediaFiles)
              .HasForeignKey(i => i.LanguageId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_test.Theme>()
              .HasOne(i => i.Agency)
              .WithMany(i => i.Themes)
              .HasForeignKey(i => i.AgencyId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_test.Theme>()
              .HasOne(i => i.Language)
              .WithMany(i => i.Themes)
              .HasForeignKey(i => i.LanguageId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_test.Town>()
              .HasOne(i => i.Agency)
              .WithMany(i => i.Towns)
              .HasForeignKey(i => i.AgencyId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_test.Town>()
              .HasOne(i => i.Language)
              .WithMany(i => i.Towns)
              .HasForeignKey(i => i.LanguageId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_test.Village>()
              .HasOne(i => i.Agency)
              .WithMany(i => i.Villages)
              .HasForeignKey(i => i.AgencyId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<ZarenTravelBO.Models.zaren_test.Village>()
              .HasOne(i => i.Language)
              .WithMany(i => i.Villages)
              .HasForeignKey(i => i.LanguageId)
              .HasPrincipalKey(i => i.Id);
            this.OnModelBuilding(builder);
        }

        public DbSet<ZarenTravelBO.Models.zaren_test.Agency> Agencies { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.AgencyCmsDevice> AgencyCmsDevices { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.AgencyCmsSectionType> AgencyCmsSectionTypes { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.AgencyCmsSocialMediaUrl> AgencyCmsSocialMediaUrls { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.AgencyCmsTheme> AgencyCmsThemes { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.AgencyCommision> AgencyCommisions { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.AgencyContractsClosedTour> AgencyContractsClosedTours { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.AgencyContractsHotelCategory> AgencyContractsHotelCategories { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.AgencyContractsHotelInformation> AgencyContractsHotelInformations { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.AgencyContractsHotelInformationImage> AgencyContractsHotelInformationImages { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.AgencyContractsHotelsConfiguration> AgencyContractsHotelsConfigurations { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.AgencyContractsHotelsConfigurationDay> AgencyContractsHotelsConfigurationDays { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.AgencyContractsHotelsMenu> AgencyContractsHotelsMenus { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceBasicDatum> AgencyContractsInsuranceBasicData { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceSelectedLanguage> AgencyContractsInsuranceSelectedLanguages { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceSelectedProductType> AgencyContractsInsuranceSelectedProductTypes { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceType> AgencyContractsInsuranceTypes { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.AgencyCreditDeposit> AgencyCreditDeposits { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.AgencyManager> AgencyManagers { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteApiProductProvider> AgencyMicroSiteApiProductProviders { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteDesign> AgencyMicroSiteDesigns { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteDomainLanguageSetting> AgencyMicroSiteDomainLanguageSettings { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteDomain> AgencyMicroSiteDomains { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.AgencyMicroSitePaymentProvider> AgencyMicroSitePaymentProviders { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteProperty> AgencyMicroSiteProperties { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.AgencyMicroSite> AgencyMicroSites { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingPassengerDatum> AgencyMicroSiteSettingPassengerData { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsAccommodationSearchResult> AgencyMicroSiteSettingsAccommodationSearchResults { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsBookingProcess> AgencyMicroSiteSettingsBookingProcesses { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsBookingReplicatorMode> AgencyMicroSiteSettingsBookingReplicatorModes { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsEmailVoucher> AgencyMicroSiteSettingsEmailVouchers { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsEnableMultiDay> AgencyMicroSiteSettingsEnableMultiDays { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsGeneral> AgencyMicroSiteSettingsGenerals { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsHelpSupport> AgencyMicroSiteSettingsHelpSupports { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsInvoice> AgencyMicroSiteSettingsInvoices { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsOther> AgencyMicroSiteSettingsOthers { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsPaymetOption> AgencyMicroSiteSettingsPaymetOptions { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsRequestInvoice> AgencyMicroSiteSettingsRequestInvoices { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsRequiredPassenger> AgencyMicroSiteSettingsRequiredPassengers { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsSearchEngine> AgencyMicroSiteSettingsSearchEngines { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsSearchSetting> AgencyMicroSiteSettingsSearchSettings { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsSortType> AgencyMicroSiteSettingsSortTypes { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsTermsCondition> AgencyMicroSiteSettingsTermsConditions { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.AgencyMicroSitesSettingsEmailConfiguration> AgencyMicroSitesSettingsEmailConfigurations { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.AgencySupplementCommission> AgencySupplementCommissions { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.AgencyUser> AgencyUsers { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.ApiProduct> ApiProducts { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.ApiResult> ApiResults { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.AutoComplete> AutoCompletes { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.AutoCompleteType> AutoCompleteTypes { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.Board> Boards { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.CancellationPolicy> CancellationPolicies { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.City> Cities { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.Country> Countries { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.Country1> Country1S { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.Currency> Currencies { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.Currency1> Currency1S { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.Facility> Facilities { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.FacilitiesSelectedCategory> FacilitiesSelectedCategories { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.FacilityCategory> FacilityCategories { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.Geolocation> Geolocations { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.GiataInfo> GiataInfos { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.HotelBoard> HotelBoards { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.HotelCategory> HotelCategories { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.HotelOffer> HotelOffers { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.HotelPaymentPlan> HotelPaymentPlans { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.Hotel> Hotels { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.HotelSeason> HotelSeasons { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.HotelSelectedSeason> HotelSelectedSeasons { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.HotelTheme> HotelThemes { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.Information> Informations { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.Item> Items { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.Language> Languages { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.LimitType> LimitTypes { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.MediaFile> MediaFiles { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.OfferCancellationPolicy> OfferCancellationPolicies { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.OfferPriceBreakDown> OfferPriceBreakDowns { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.Offer> Offers { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.PassengerAmount> PassengerAmounts { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.PaymentPlanInfo> PaymentPlanInfos { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.PaymentType> PaymentTypes { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.PossibleQuery> PossibleQueries { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.Presentation> Presentations { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.PriceBreakDown> PriceBreakDowns { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.Price> Prices { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.ProductType> ProductTypes { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.Resource> Resources { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.RoomFacility> RoomFacilities { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.RoomInfoFacility> RoomInfoFacilities { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.RoomInfo> RoomInfos { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.RoomInfosMediaFile> RoomInfosMediaFiles { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.RoomMediaFile> RoomMediaFiles { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.RoomPresentation> RoomPresentations { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.Room> Rooms { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.SeasonMediaFile> SeasonMediaFiles { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.Season> Seasons { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.SeasonTextCategory> SeasonTextCategories { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.SeasonTheme> SeasonThemes { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.State> States { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.TextCategory> TextCategories { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.Theme> Themes { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.Town> Towns { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.Village> Villages { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.Resource1> Resource1S { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.Test> Tests { get; set; }

        public DbSet<ZarenTravelBO.Models.zaren_test.AgencyContractsConfigurationByHotel> AgencyContractsConfigurationByHotels { get; set; }
    }
}