using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("HotelFacilities", Schema = "zaren")]
    public partial class HotelFacility
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? ApiId { get; set; }

        public string SystemId { get; set; }

        public int? LanguageId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public int? UpdatedBy { get; set; }

        public string Name { get; set; }

        public string Note { get; set; }

        public int? IsPriced { get; set; }

        public bool? Highlighted { get; set; }

        public int? Type { get; set; }

    }
}