using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravelBO.Models.zaren_test
{
    [Table("PaymentTypes", Schema = "dbo")]
    public partial class PaymentType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public bool? ForDeferredB2B { get; set; }

        public bool? ForDeferredB2C { get; set; }

        public string SystemId { get; set; }

    }
}