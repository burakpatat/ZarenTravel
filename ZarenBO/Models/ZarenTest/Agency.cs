using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravelBO.Models.zaren_test
{
    [Table("Agency", Schema = "dbo")]
    public partial class Agency
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? Statu { get; set; }

        public int? AgencyManager { get; set; }

        public string InvoiceName { get; set; }

        public string City { get; set; }

        public int? Country { get; set; }

        public string WhatsAppNo { get; set; }

        public string Email { get; set; }

        public double? Taxes { get; set; }

        public int? ExternalId { get; set; }

        public string Address { get; set; }

        public string Provience { get; set; }

        public string DocumentNumber { get; set; }

        public string ContactPersonName { get; set; }

        public string BillingEmails { get; set; }

        public string BusinessName { get; set; }

        public string PostalCode { get; set; }

        public string Region { get; set; }

        public string PhoneNo { get; set; }

        public string ContactPersonLastName { get; set; }

        public string ManagementGroup { get; set; }

        public string Remarks { get; set; }

        public string WinterHours { get; set; }

        public string SummerHours { get; set; }

        public int? InvoiceTypeId { get; set; }

        public bool? DeferredPaymentAllowed { get; set; }

        public int? DeferredPaymentDays { get; set; }

        public decimal? DeferredPaymentLimit { get; set; }

        public int? DeferredPaymentLimitCurrency { get; set; }

        public int? MinimumFirstPaymentAmount { get; set; }

        public bool? MinimumFirstPaymentIsByPercentage { get; set; }

        public string GDSIdentifierForGalileo { get; set; }

        public bool? HasCreditOrDepositPaymentAllowed { get; set; }

        public ICollection<AgencyCmsSectionType> AgencyCmsSectionTypes { get; set; }

        public ICollection<AgencyCmsSocialMediaUrl> AgencyCmsSocialMediaUrls { get; set; }

        public ICollection<AgencyCmsTheme> AgencyCmsThemes { get; set; }

        public ICollection<AgencyManager> AgencyManagers { get; set; }

        public ICollection<Board> Boards { get; set; }

        public ICollection<CancellationPolicy> CancellationPolicies { get; set; }

        public ICollection<City> Cities { get; set; }

        public ICollection<Country> Countries { get; set; }

        public ICollection<Currency1> Currency1S { get; set; }

        public ICollection<FacilitiesSelectedCategory> FacilitiesSelectedCategories { get; set; }

        public ICollection<HotelCategory> HotelCategories { get; set; }

        public ICollection<HotelOffer> HotelOffers { get; set; }

        public ICollection<HotelPaymentPlan> HotelPaymentPlans { get; set; }

        public ICollection<HotelTheme> HotelThemes { get; set; }

        public ICollection<Information> Informations { get; set; }

        public ICollection<Item> Items { get; set; }

        public ICollection<Language> Languages { get; set; }

        public ICollection<RoomInfosMediaFile> RoomInfosMediaFiles { get; set; }

        public ICollection<Theme> Themes { get; set; }

        public ICollection<Town> Towns { get; set; }

        public ICollection<Village> Villages { get; set; }

    }
}