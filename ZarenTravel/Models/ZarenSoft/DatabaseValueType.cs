using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("DatabaseValueTypes", Schema = "dbo")]
    public partial class DatabaseValueType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string FrontEndName { get; set; }

        public string SqlName { get; set; }

        public ICollection<DatabaseColumn> DatabaseColumns { get; set; }

    }
}