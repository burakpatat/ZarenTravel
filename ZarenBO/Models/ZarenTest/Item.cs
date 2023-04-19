using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravelBO.Models.zaren_test
{
    [Table("Items", Schema = "dbo")]
    public partial class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? Type { get; set; }

        public int? GeolocationId { get; set; }

        public int? CoutryId { get; set; }

        public int? StateId { get; set; }

        public int? CityId { get; set; }

        public int? GiataInfoId { get; set; }

        public int? Provider { get; set; }

        public int? SystemId { get; set; }

        public int? ApiId { get; set; }

        public int? AgencyId { get; set; }

        public int? MicroSiteId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public int? UpdatedBy { get; set; }

        public int? LanguageId { get; set; }

        public Agency Agency { get; set; }

        public City City { get; set; }

        public Country Country { get; set; }

        public Language Language { get; set; }

    }
}