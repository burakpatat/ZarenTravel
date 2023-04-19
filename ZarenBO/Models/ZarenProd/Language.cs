using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravelBO.Models.zaren_prod
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

        public Agency Agency { get; set; }

    }
}