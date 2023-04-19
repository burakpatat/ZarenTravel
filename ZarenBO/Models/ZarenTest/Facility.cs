using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravelBO.Models.zaren_test
{
    [Table("Facilities", Schema = "dbo")]
    public partial class Facility
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Note { get; set; }

        public bool? IsPriced { get; set; }

        public string SystemId { get; set; }

        public int? ApiId { get; set; }

        public int? AgencyId { get; set; }

        public int? MicroSiteId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public int? UpdatedBy { get; set; }

        public int? LanguageId { get; set; }

        public int? FacilityCategoryId { get; set; }

        public bool? Highlighted { get; set; }

        public int? HotelId { get; set; }

        public string Unit { get; set; }

        public int? SeasonId { get; set; }

        public int? Type { get; set; }

    }
}