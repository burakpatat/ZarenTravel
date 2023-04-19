using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("DatatableCMSInputType", Schema = "dbo")]
    public partial class DatatableCmsInputType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Name { get; set; }

        public ICollection<DatabaseColumn> DatabaseColumns { get; set; }

    }
}