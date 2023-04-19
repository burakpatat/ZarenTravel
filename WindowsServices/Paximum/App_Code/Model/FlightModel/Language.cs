using System;
using System.Collections.Generic;

namespace Model.FlightModels.Concrete
{
    public class Language
    {
        public int Id { get; set; }

        public string ShortCode { get; set; }

        public string Tr { get; set; }

        public string En { get; set; }

        public string De { get; set; }

        public string Fr { get; set; }

        public string Es { get; set; }

        public string It { get; set; }

        public int AgencyId { get; set; }
        public int ApiId { get; set; }
        public int LanguageId { get; set; }
        public string SystemId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }


    }
}