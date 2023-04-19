using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravelBO.Models.zaren_test
{
    [Table("AgencyCmsSectionTypes", Schema = "dbo")]
    public partial class AgencyCmsSectionType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public int? AgencyId { get; set; }

        public int? MicroSiteId { get; set; }

        public DateTime? UpdateBy { get; set; }

        public DateTime? CreatedBy { get; set; }

        public DateTime? Updated { get; set; }

        public DateTime? Created { get; set; }

        public Agency Agency { get; set; }

    }
}