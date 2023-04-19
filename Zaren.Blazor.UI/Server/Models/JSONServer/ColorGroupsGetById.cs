using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ZarenUI.Server.Models.JSONServer
{
    public partial class ColorGroupsGetById
    {
        public int Id { get; set; }

        public string HexCode { get; set; }

        public string RGBCode { get; set; }

        public string GroupList { get; set; }

        public double? BrightnessValue { get; set; }

        public bool? IsDark { get; set; }

        public string PossibleName { get; set; }

    }
}