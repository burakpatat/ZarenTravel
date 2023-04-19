using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Zaren.Application.Services.Interfaces;
using Zaren.Data;
using System.Net.Http;
using System.Threading.Tasks;


 
    public class AuthenticationService :IAuthenticationService
    { 
        public async Task<string> Login()
        {
            var user = new
            {
                Agency = "PXM25520",
                User = "USR1",
                Password = "zaren!23"
            };
            var client = new HttpClient();
            var content = JsonConvert.SerializeObject(user);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            var req =  client.PostAsync("http://service.stage.paximum.com/v2/api/authenticationservice/login", byteContent).Result;
            //var cont = JsonConvert.DeserializeObject<dynamic>(req);
            var contents = await req.Content.ReadAsStringAsync();
            var obj = JsonConvert.DeserializeObject<dynamic>(contents);
            var t= obj.body.token;
            return t;

        }
    }
 
