using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ZarenUI.Server.Models.JSONServer
{
    public partial class ProjectCategoryGetByCategoryName
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public int? ParentId { get; set; }

        public string SampleUrl { get; set; }

        public string CategoryNameTr { get; set; }

    }
}