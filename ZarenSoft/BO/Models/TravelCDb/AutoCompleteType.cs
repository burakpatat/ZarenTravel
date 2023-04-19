using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travel.Models.TravelCDb
{
    [Table("AutoCompleteTypes", Schema = "dbo")]
    public partial class AutoCompleteType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ConcurrencyCheck]
        public string Name { get; set; }

        public ICollection<AutoComplete> AutoCompletes { get; set; }

    }
}