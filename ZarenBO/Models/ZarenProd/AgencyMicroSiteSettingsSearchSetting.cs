using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravelBO.Models.zaren_prod
{
    [Table("AgencyMicroSiteSettingsSearchSettings", Schema = "dbo")]
    public partial class AgencyMicroSiteSettingsSearchSetting
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? AgencyId { get; set; }

        public int? MicroSiteId { get; set; }

        public bool? SearchBoxDropdownMenuFormatAutoComplete { get; set; }

        public bool? ShowThemesHomePageSlidingFormat { get; set; }

        public bool? AskForDepartureLocationHolidayPackage { get; set; }

        public bool? InAccommodationSearchEngineAllowSearchHotelName { get; set; }

        public bool? InAccommodationSearchEngineAllowSearchInterestPoint { get; set; }

        public int? AgencyMicroSiteSettingsAccommodationSortType { get; set; }

        public int? AgencyMicroSiteSettingsTicketSortType { get; set; }

        public int? SelectTransportSortType { get; set; }

        public int? SelectHolidayPackageSortType { get; set; }

        public int? AccommodationSearchResults { get; set; }

        public int? TicketSearchResultsUseThisViewResult { get; set; }

        public bool? SameListOriginsListDestinations { get; set; }

        public int? AgencyMicroSiteSettingEnableMultiDay { get; set; }

        public bool? EnableRequestActivities { get; set; }

        public bool? B2BUsersSeeProvidersQuotingService { get; set; }

        public bool? DonotShowTourProviderB2BUsers { get; set; }

        public bool? DonotShowTourProviderB2CUsers { get; set; }

        public bool? ShowLocationSearchbox { get; set; }

        public Agency Agency { get; set; }

        public AgencyMicroSite AgencyMicroSite { get; set; }

    }
}