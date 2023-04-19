using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class ApiResultInsert
    {
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

        public int? ProductType { get; set; }

        public string LocationId { get; set; }

        public string Query { get; set; }

    }
}