using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirlesikOdemeTest.Core.Models.APIModels
{
    public class LoginRequest
    {
        public string ApiKey { get; set; }
        public string lang { get; set; }
        public string email { get; set; }
    }
}
