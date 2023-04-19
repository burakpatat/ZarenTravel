using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCrawler.Paximum.App_Code.Paximum.FlightResponse
{
    public class ApiFlightResult
    {
        public string RequestData { get; set; }
        public string ResponseData { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime ResponseDate { get; set; }
        public string Currency { get; set; }
        public string CheckIn { get; set; }
        public string Nationality { get; set; }
        public int ApiId { get; set; }
        public object IsSuccessfull { get; set; }
        public string LocationId { get; set; }
        public string Query { get; set; }
        public int ProductType { get; set; }
    }
}
