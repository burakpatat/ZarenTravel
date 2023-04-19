using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("ApiResults", Schema = "zaren")]
    public partial class ApiResult1
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string RequestData { get; set; }

        public string ResponseData { get; set; }

        public DateTime? RequestDate { get; set; }

        public DateTime? ResponseDate { get; set; }

        public string Currency { get; set; }

        public string CheckIn { get; set; }

        public string Nationality { get; set; }

        public int? ApiId { get; set; }

        public bool? IsSuccessfull { get; set; }

    }
}