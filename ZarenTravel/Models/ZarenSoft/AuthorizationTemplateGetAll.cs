using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class AuthorizationTemplateGetAll
    {
        public int ID { get; set; }

        public int? Products { get; set; }

        public int? Users { get; set; }

        public int? DatabaseTables { get; set; }

        public int? CanInsert { get; set; }

        public int? CanUpdate { get; set; }

        public int? CanDetail { get; set; }

        public int? CanList { get; set; }

        public int? CanDelete { get; set; }

        public int? CanRemove { get; set; }

        public int? OnLeftMenu { get; set; }

        public int? Departments { get; set; }

    }
}