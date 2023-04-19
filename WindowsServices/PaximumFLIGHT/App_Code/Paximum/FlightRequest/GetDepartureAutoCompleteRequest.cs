using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCrawler.Paximum.App_Code.Paximum.FlightRequest
{
    public class GetDepartureAutoCompleteRequest
    {

        public int ProductType { get; set; }//1,2,3
        public string Query { get; set; }
        public string Culture { get; set; }
    }
}
