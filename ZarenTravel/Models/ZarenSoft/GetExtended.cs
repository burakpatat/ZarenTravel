using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class GetExtended
    {
        public string Schema { get; set; }

        public string TableName { get; set; }

        public string ColumnName { get; set; }

        public string type_desc { get; set; }

        public string Name { get; set; }

        public object Value { get; set; }

    }
}