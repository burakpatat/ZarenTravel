using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace WordyWell.Api.Helper
{
    public class ApiCall
    {
        private static string CallApi(string route, string jsonRequestModel, int requestType)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + "");
                var stringContent = new StringContent(jsonRequestModel, Encoding.UTF8, "application/json");
                client.Timeout = TimeSpan.FromMinutes(15);
                HttpResponseMessage response = new HttpResponseMessage();
                switch (requestType)
                {
                    case (int)RequestType.GET:
                        response = client.GetAsync(route).Result;
                        break;

                    case (int)RequestType.POST:
                        response = client.PostAsync(route, stringContent).Result;
                        break;

                    case (int)RequestType.PUT:
                        response = client.PutAsync(route, stringContent).Result;
                        break;

                    case (int)RequestType.DELETE:
                        response = client.DeleteAsync(route).Result;
                        break;
                }
                return response.Content.ReadAsStringAsync().Result;
            }
        }

        private static string CallApiNoToken(string route, string jsonRequestModel, int requestType)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.Timeout = TimeSpan.FromMinutes(15);

                var stringContent = new StringContent(jsonRequestModel, Encoding.UTF8, "application/json");

                HttpResponseMessage response = new HttpResponseMessage();
                switch (requestType)
                {
                    case (int)RequestType.GET:
                        response = client.GetAsync(route).Result;
                        break;

                    case (int)RequestType.POST:
                        response = client.PostAsync(route, stringContent).Result;
                        break;

                    case (int)RequestType.PUT:
                        response = client.PutAsync(route, stringContent).Result;
                        break;

                    case (int)RequestType.DELETE:
                        response = client.DeleteAsync(route).Result;
                        break;
                }
                return response.Content.ReadAsStringAsync().Result;
            }
        }

        private static string CallApiNoTokenWithParameter(string route, KeyValuePair<string, string>[] jsonRequestModel, int requestType)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.Timeout = TimeSpan.FromMinutes(15);

                //var stringContent = new StringContent(jsonRequestModel, Encoding.UTF8, "application/json");

                //var dataValues = new[] {
                //    new KeyValuePair<string, string>("name", "BOSS"),
                //    new KeyValuePair<string, string>("pass", "BosSToken_123")
                //};
                var stringContent = new FormUrlEncodedContent(jsonRequestModel);

                HttpResponseMessage response = new HttpResponseMessage();
                switch (requestType)
                {
                    case (int)RequestType.GET:
                        response = client.GetAsync(route).Result;
                        break;

                    case (int)RequestType.POST:
                        response = client.PostAsync(route, stringContent).Result;
                        break;

                    case (int)RequestType.PUT:
                        response = client.PutAsync(route, stringContent).Result;
                        break;

                    case (int)RequestType.DELETE:
                        response = client.DeleteAsync(route).Result;
                        break;
                }
                return response.Content.ReadAsStringAsync().Result;
            }
        }

        public static TResponse CallApi<TRequest, TResponse>(string route, TRequest requestModel, int requestType = (int)RequestType.POST, int? jsonDepth = null)
        {
            var responseJson = CallApi(route, JsonConvert.SerializeObject(requestModel, new JsonSerializerSettings
            {
                MaxDepth = jsonDepth
            }), requestType);
            return JsonConvert.DeserializeObject<TResponse>(responseJson);
        }

        public static TResponse CallApiNoToken<TRequest, TResponse>(string route, TRequest requestModel, int requestType = (int)RequestType.POST, int? jsonDepth = null)
        {
            var aa = JsonConvert.SerializeObject(requestModel, new JsonSerializerSettings
            {
                MaxDepth = jsonDepth
            });
            var responseJson = CallApiNoToken(route, aa, requestType);
            var bb = JsonConvert.DeserializeObject<TResponse>(responseJson);
            return bb;
        }

        public static TResponse CallApiNoTokenWithParameter<TResponse>(string route, KeyValuePair<string, string>[] requestModel, int requestType = (int)RequestType.POST, int? jsonDepth = null)
        {
            var responseJson = CallApiNoTokenWithParameter(route, requestModel, requestType);
            var bb = JsonConvert.DeserializeObject<TResponse>(responseJson);
            return bb;
        }

        public enum RequestType
        {
            GET = 0,
            POST = 1,
            PUT = 2,
            DELETE = 3,
        }
    }
}