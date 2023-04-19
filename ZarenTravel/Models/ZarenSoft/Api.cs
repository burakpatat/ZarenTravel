using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("Api", Schema = "dbo")]
    public partial class Api
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string ApiName { get; set; }

        public string UserKey { get; set; }

        public string Password { get; set; }

        public ICollection<AutoComplete> AutoCompletes { get; set; }

    }
}