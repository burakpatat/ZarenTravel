using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("DatabaseTables", Schema = "dbo")]
    public partial class DatabaseTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string TableName { get; set; }

        public string DisplayName { get; set; }

        public bool? IsRouting { get; set; }

        public bool? HasMultiLanguage { get; set; }

        public string FrontPageName { get; set; }

        public bool? ForUser { get; set; }

        public int? CMSGridSize { get; set; }

        public string CMSLinkedTables { get; set; }

        public int? TableOrder { get; set; }

        public int? ParentTable { get; set; }

        public string CMSIcon { get; set; }

        public bool? CanGenerate { get; set; }

        public DateTime? CreateDate { get; set; }

        public ICollection<DatabaseColumn> DatabaseColumns { get; set; }

    }
}