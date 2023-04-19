using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("Contacts", Schema = "dbo")]
    public partial class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string TelNumber { get; set; }

        public string FaxNumber { get; set; }

        public string Email { get; set; }

        public ICollection<Agency> Agencies { get; set; }

        public ICollection<Agency> Agencies1 { get; set; }

        public ICollection<Agency> Agencies2 { get; set; }

        public ICollection<Hotel> Hotels { get; set; }

        public ICollection<Hotel> Hotels1 { get; set; }

        public ICollection<Hotel> Hotels2 { get; set; }

        public ICollection<Provider> Providers { get; set; }

        public ICollection<Provider> Providers1 { get; set; }

        public ICollection<Provider> Providers2 { get; set; }

        public ICollection<Hotel1> Hotel1S { get; set; }

        public ICollection<Hotel1> Hotel1S1 { get; set; }

        public ICollection<Hotel1> Hotel1S2 { get; set; }

    }
}