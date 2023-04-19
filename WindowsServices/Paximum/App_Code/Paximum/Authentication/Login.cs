using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCrawler.Authentication
{
   

    public class LoginRequest
    {
        public string Agency { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
    }


    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Agency
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("registerCode")]
        public string RegisterCode { get; set; }
    }

    public class Body
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("expiresOn")]
        public DateTime ExpiresOn { get; set; }

        [JsonProperty("tokenId")]
        public int TokenId { get; set; }

        [JsonProperty("userInfo")]
        public UserInfo UserInfo { get; set; }
    }

    public class MainAgency
    {
    }

    public class Market
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("favicon")]
        public string Favicon { get; set; }
    }

    public class Office
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Operator
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }
    }

    public class LoginResponse
    {
        [JsonProperty("body")]
        public Body Body { get; set; }
    }

    public class UserInfo
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("mainAgency")]
        public MainAgency MainAgency { get; set; }

        [JsonProperty("agency")]
        public Agency Agency { get; set; }

        [JsonProperty("office")]
        public Office Office { get; set; }

        [JsonProperty("operator")]
        public Operator Operator { get; set; }

        [JsonProperty("market")]
        public Market Market { get; set; }
    }


}
