using ApiCrawler.Authentication;
using Newtonsoft.Json;
using System.Configuration;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace ApiCrawler.Paximum.Service
{
    public class LoginService
    {
        public async Task<string> Login()
        {
            var Config = ConfigurationManager.AppSettings;
            
            var user = new LoginRequest()
            {
                Agency = Config["Agency"],
                User = Config["User"],
                Password = Config["Password"]
            };
            var client = new HttpClient();
            var content = JsonConvert.SerializeObject(user);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            var req = client.PostAsync(Config["ApiAuthenticationService"], byteContent).Result;
            var contents = await req.Content.ReadAsStringAsync();
            var obj = JsonConvert.DeserializeObject<LoginResponse>(contents);

            File.WriteAllText(ConfigurationManager.AppSettings["JsonBasePath"].ToString() + "\\JSON\\token.json", contents);

            var t = obj.Body.Token;
            return t;

        }
    }
}
