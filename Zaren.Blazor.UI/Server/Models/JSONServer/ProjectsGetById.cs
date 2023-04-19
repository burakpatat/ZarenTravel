using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ZarenUI.Server.Models.JSONServer
{
    public partial class ProjectsGetById
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Name { get; set; }

        public string Guid { get; set; }

        public string Tables { get; set; }

        public string Configuration { get; set; }

        public object TableGroups { get; set; }

        public object EnumLists { get; set; }

        public object Endpoints { get; set; }

        public object LanguageDefinations { get; set; }

        public object Lookups { get; set; }

        public object ConnectionSettings { get; set; }

        public string DatabaseSchemas { get; set; }

        public string RuleGroups { get; set; }

    }
}