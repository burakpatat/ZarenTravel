using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCrawler.Paximum.App_Code.Paximum.Response
{
    public class HotelSeasons
    {
        public int Id { get; set; }
        public string SystemId { get; set; }
        public int LanguageId { get; set; }
        public int ApiId { get; set; }
        public string Name { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public int HotelId { get; set; }
        public int Type { get; set; }


    }
}
