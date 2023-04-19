using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paximum.Request
{


    public class GetOfferDetailRequest
    {
        public List<string> offerIds { get; set; }
        public string currency { get; set; }
        public bool getProductInfo { get; set; }
    }

}
