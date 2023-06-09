﻿using System;
using Core.Entities;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
    [Table("DatatableCMSInputType")]
    public class DatatableCMSInputType : IEntity
    {
        private int _ID;
        [Key]
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
    }
}
