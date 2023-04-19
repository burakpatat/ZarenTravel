using System;
using System.Collections.Generic;
using Core.Entities;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{

    public class DatabaseTableMerge 
    {

        private string _TableName;
        public string TableName
        {
            get { return _TableName; }
            set { _TableName = value; }
        }
 
        private bool _AddedFromTo;
        public bool AddedFromTo
        {
            get { return _AddedFromTo; }
            set { _AddedFromTo = value; }
        }
        private bool _AddedToFrom;
        public bool AddedToFrom
        {
            get { return _AddedToFrom; }
            set { _AddedToFrom = value; }
        }
        public List<DatabaseTableAndColumns> TableAndColumns { get; set; }

        public List<DatabaseTableAndColumns> RequestParamFromDB { get; set; }

        public List<DatabaseTableAndColumns> ResponseParamFromDB { get; set; }
        public List<DatabaseTableColumn> ColumnList { get; set; }

        public List<DatabaseTableColumn> RequestParam { get; set; }

        public List<DatabaseTableColumn> ResponseParam { get; set; }
    }
}
