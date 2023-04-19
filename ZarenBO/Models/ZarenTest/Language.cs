using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravelBO.Models.zaren_test
{
    [Table("Language", Schema = "dbo")]
    public partial class Language
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string ShortCode { get; set; }

        public string Tr { get; set; }

        public string En { get; set; }

        public string De { get; set; }

        public string Fr { get; set; }

        public string Es { get; set; }

        public string It { get; set; }

        public int? AgencyId { get; set; }

        public ICollection<Board> Boards { get; set; }

        public ICollection<CancellationPolicy> CancellationPolicies { get; set; }

        public ICollection<City> Cities { get; set; }

        public ICollection<Country> Countries { get; set; }

        public ICollection<FacilitiesSelectedCategory> FacilitiesSelectedCategories { get; set; }

        public ICollection<HotelCategory> HotelCategories { get; set; }

        public ICollection<HotelOffer> HotelOffers { get; set; }

        public ICollection<HotelPaymentPlan> HotelPaymentPlans { get; set; }

        public ICollection<HotelTheme> HotelThemes { get; set; }

        public ICollection<Information> Informations { get; set; }

        public ICollection<Item> Items { get; set; }

        public Agency Agency { get; set; }

        public ICollection<RoomInfosMediaFile> RoomInfosMediaFiles { get; set; }

        public ICollection<Theme> Themes { get; set; }

        public ICollection<Town> Towns { get; set; }

        public ICollection<Village> Villages { get; set; }

    }
}