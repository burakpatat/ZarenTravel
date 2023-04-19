using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ZarenUI.Server.Models.JSONServer
{
    [Table("AuditDevices", Schema = "dbo")]
    public partial class AuditDevice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long LogID { get; set; }

        public int? Id { get; set; }

        public string DeviceName { get; set; }

        public int? DeviceGroupId { get; set; }

        public int? Width { get; set; }

        public int? Height { get; set; }

        public string Brand { get; set; }

        public string Img { get; set; }

        public bool? IsLandScape { get; set; }

        public string Resulation1x { get; set; }

        public string Resulation2x { get; set; }

        public string Resulation3x { get; set; }

        public string EventType { get; set; }

        public DateTime EventDate { get; set; }

        public string TriggeredBy { get; set; }

        public string TriggeredIP { get; set; }

    }
}