using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class LogPermissionsGetByCanClassList
    {
        public int ID { get; set; }

        public int? UserID { get; set; }

        public DateTime? ChangeDate { get; set; }

        public int? DatabaseTables { get; set; }

        public int? CanInsert { get; set; }

        public int? CanUpdate { get; set; }

        public int? CanGetOne { get; set; }

        public int? CanGetList { get; set; }

        public int? CanDelete { get; set; }

        public int? CanView { get; set; }

        public int? CanClassInit { get; set; }

        public int? CanClassInsert { get; set; }

        public int? CanClassList { get; set; }

        public int? CanClassUpdate { get; set; }

        public int? Products { get; set; }

        public string Note { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyDate { get; set; }

    }
}