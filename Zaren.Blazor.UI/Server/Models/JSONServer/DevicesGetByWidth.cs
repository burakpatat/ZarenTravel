using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ZarenUI.Server.Models.JSONServer
{
    public partial class DevicesGetByWidth
    {
        public int Id { get; set; }

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

    }
}