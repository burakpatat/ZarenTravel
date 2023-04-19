using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security
{
    public class SecurityResponseModel
    {
        public bool fail { get; set; }
        public int statusCode { get; set; }
        public int count { get; set; }
        public SecurityResponseResultModel result { get; set; }
        public string responseCode { get; set; }
        public string responseMessage { get; set; }

    }
    public class SecurityResponseResultModel
    {
        public int userId { get; set; }
        public string token { get; set; }
    }
}
