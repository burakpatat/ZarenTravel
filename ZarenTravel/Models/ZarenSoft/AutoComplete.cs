using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("AutoCompletes", Schema = "dbo")]
    public partial class AutoComplete
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public int? Type { get; set; }

        public int? ApiId { get; set; }

        public string ApiSystemId { get; set; }

        public Api Api { get; set; }

        public AutoCompleteType AutoCompleteType { get; set; }

    }
}