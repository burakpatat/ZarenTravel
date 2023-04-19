
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Web;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using Radzen;

namespace ZarenUI.Client
{
    public partial class ConnectorService
    {
        private readonly HttpClient httpClient;
        private readonly Uri baseUri;
        private readonly NavigationManager navigationManager;

        public ConnectorService(NavigationManager navigationManager, HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;

            this.navigationManager = navigationManager;
            this.baseUri = new Uri($"{navigationManager.BaseUri}odata/Connector/");
        }


        public async System.Threading.Tasks.Task ExportColorGroupsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/colorgroups/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/colorgroups/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportColorGroupsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/colorgroups/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/colorgroups/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetColorGroups(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.ColorGroup>> GetColorGroups(Query query)
        {
            return await GetColorGroups(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.ColorGroup>> GetColorGroups(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"ColorGroups");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetColorGroups(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.ColorGroup>>(response);
        }

        partial void OnCreateColorGroup(HttpRequestMessage requestMessage);

        public async Task<ZarenUI.Server.Models.Connector.ColorGroup> CreateColorGroup(ZarenUI.Server.Models.Connector.ColorGroup colorGroup = default(ZarenUI.Server.Models.Connector.ColorGroup))
        {
            var uri = new Uri(baseUri, $"ColorGroups");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(colorGroup), Encoding.UTF8, "application/json");

            OnCreateColorGroup(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ZarenUI.Server.Models.Connector.ColorGroup>(response);
        }

        partial void OnDeleteColorGroup(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteColorGroup(int id = default(int))
        {
            var uri = new Uri(baseUri, $"ColorGroups({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteColorGroup(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetColorGroupById(HttpRequestMessage requestMessage);

        public async Task<ZarenUI.Server.Models.Connector.ColorGroup> GetColorGroupById(string expand = default(string), int id = default(int))
        {
            var uri = new Uri(baseUri, $"ColorGroups({id})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetColorGroupById(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ZarenUI.Server.Models.Connector.ColorGroup>(response);
        }

        partial void OnUpdateColorGroup(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateColorGroup(int id = default(int), ZarenUI.Server.Models.Connector.ColorGroup colorGroup = default(ZarenUI.Server.Models.Connector.ColorGroup))
        {
            var uri = new Uri(baseUri, $"ColorGroups({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(colorGroup), Encoding.UTF8, "application/json");

            OnUpdateColorGroup(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportCountriesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/countries/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/countries/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportCountriesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/countries/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/countries/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetCountries(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.Country>> GetCountries(Query query)
        {
            return await GetCountries(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.Country>> GetCountries(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"Countries");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetCountries(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.Country>>(response);
        }

        partial void OnCreateCountry(HttpRequestMessage requestMessage);

        public async Task<ZarenUI.Server.Models.Connector.Country> CreateCountry(ZarenUI.Server.Models.Connector.Country country = default(ZarenUI.Server.Models.Connector.Country))
        {
            var uri = new Uri(baseUri, $"Countries");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(country), Encoding.UTF8, "application/json");

            OnCreateCountry(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ZarenUI.Server.Models.Connector.Country>(response);
        }

        partial void OnDeleteCountry(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteCountry(int id = default(int))
        {
            var uri = new Uri(baseUri, $"Countries({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteCountry(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetCountryById(HttpRequestMessage requestMessage);

        public async Task<ZarenUI.Server.Models.Connector.Country> GetCountryById(string expand = default(string), int id = default(int))
        {
            var uri = new Uri(baseUri, $"Countries({id})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetCountryById(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ZarenUI.Server.Models.Connector.Country>(response);
        }

        partial void OnUpdateCountry(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateCountry(int id = default(int), ZarenUI.Server.Models.Connector.Country country = default(ZarenUI.Server.Models.Connector.Country))
        {
            var uri = new Uri(baseUri, $"Countries({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(country), Encoding.UTF8, "application/json");

            OnUpdateCountry(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportCountryLanguagesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/countrylanguages/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/countrylanguages/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportCountryLanguagesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/countrylanguages/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/countrylanguages/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetCountryLanguages(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.CountryLanguage>> GetCountryLanguages(Query query)
        {
            return await GetCountryLanguages(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.CountryLanguage>> GetCountryLanguages(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"CountryLanguages");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetCountryLanguages(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.CountryLanguage>>(response);
        }

        partial void OnCreateCountryLanguage(HttpRequestMessage requestMessage);

        public async Task<ZarenUI.Server.Models.Connector.CountryLanguage> CreateCountryLanguage(ZarenUI.Server.Models.Connector.CountryLanguage countryLanguage = default(ZarenUI.Server.Models.Connector.CountryLanguage))
        {
            var uri = new Uri(baseUri, $"CountryLanguages");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(countryLanguage), Encoding.UTF8, "application/json");

            OnCreateCountryLanguage(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ZarenUI.Server.Models.Connector.CountryLanguage>(response);
        }

        partial void OnDeleteCountryLanguage(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteCountryLanguage(int id = default(int))
        {
            var uri = new Uri(baseUri, $"CountryLanguages({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteCountryLanguage(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetCountryLanguageById(HttpRequestMessage requestMessage);

        public async Task<ZarenUI.Server.Models.Connector.CountryLanguage> GetCountryLanguageById(string expand = default(string), int id = default(int))
        {
            var uri = new Uri(baseUri, $"CountryLanguages({id})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetCountryLanguageById(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ZarenUI.Server.Models.Connector.CountryLanguage>(response);
        }

        partial void OnUpdateCountryLanguage(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateCountryLanguage(int id = default(int), ZarenUI.Server.Models.Connector.CountryLanguage countryLanguage = default(ZarenUI.Server.Models.Connector.CountryLanguage))
        {
            var uri = new Uri(baseUri, $"CountryLanguages({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(countryLanguage), Encoding.UTF8, "application/json");

            OnUpdateCountryLanguage(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportDeviceGroupsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/devicegroups/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/devicegroups/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportDeviceGroupsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/devicegroups/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/devicegroups/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetDeviceGroups(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.DeviceGroup>> GetDeviceGroups(Query query)
        {
            return await GetDeviceGroups(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.DeviceGroup>> GetDeviceGroups(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"DeviceGroups");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetDeviceGroups(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.DeviceGroup>>(response);
        }

        partial void OnCreateDeviceGroup(HttpRequestMessage requestMessage);

        public async Task<ZarenUI.Server.Models.Connector.DeviceGroup> CreateDeviceGroup(ZarenUI.Server.Models.Connector.DeviceGroup deviceGroup = default(ZarenUI.Server.Models.Connector.DeviceGroup))
        {
            var uri = new Uri(baseUri, $"DeviceGroups");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(deviceGroup), Encoding.UTF8, "application/json");

            OnCreateDeviceGroup(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ZarenUI.Server.Models.Connector.DeviceGroup>(response);
        }

        partial void OnDeleteDeviceGroup(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteDeviceGroup(int id = default(int))
        {
            var uri = new Uri(baseUri, $"DeviceGroups({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteDeviceGroup(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetDeviceGroupById(HttpRequestMessage requestMessage);

        public async Task<ZarenUI.Server.Models.Connector.DeviceGroup> GetDeviceGroupById(string expand = default(string), int id = default(int))
        {
            var uri = new Uri(baseUri, $"DeviceGroups({id})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetDeviceGroupById(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ZarenUI.Server.Models.Connector.DeviceGroup>(response);
        }

        partial void OnUpdateDeviceGroup(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateDeviceGroup(int id = default(int), ZarenUI.Server.Models.Connector.DeviceGroup deviceGroup = default(ZarenUI.Server.Models.Connector.DeviceGroup))
        {
            var uri = new Uri(baseUri, $"DeviceGroups({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(deviceGroup), Encoding.UTF8, "application/json");

            OnUpdateDeviceGroup(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportDevicesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/devices/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/devices/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportDevicesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/devices/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/devices/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetDevices(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.Device>> GetDevices(Query query)
        {
            return await GetDevices(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.Device>> GetDevices(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"Devices");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetDevices(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.Device>>(response);
        }

        partial void OnCreateDevice(HttpRequestMessage requestMessage);

        public async Task<ZarenUI.Server.Models.Connector.Device> CreateDevice(ZarenUI.Server.Models.Connector.Device device = default(ZarenUI.Server.Models.Connector.Device))
        {
            var uri = new Uri(baseUri, $"Devices");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(device), Encoding.UTF8, "application/json");

            OnCreateDevice(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ZarenUI.Server.Models.Connector.Device>(response);
        }

        partial void OnDeleteDevice(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteDevice(int id = default(int))
        {
            var uri = new Uri(baseUri, $"Devices({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteDevice(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetDeviceById(HttpRequestMessage requestMessage);

        public async Task<ZarenUI.Server.Models.Connector.Device> GetDeviceById(string expand = default(string), int id = default(int))
        {
            var uri = new Uri(baseUri, $"Devices({id})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetDeviceById(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ZarenUI.Server.Models.Connector.Device>(response);
        }

        partial void OnUpdateDevice(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateDevice(int id = default(int), ZarenUI.Server.Models.Connector.Device device = default(ZarenUI.Server.Models.Connector.Device))
        {
            var uri = new Uri(baseUri, $"Devices({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(device), Encoding.UTF8, "application/json");

            OnUpdateDevice(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportDistributedServerCachesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/distributedservercaches/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/distributedservercaches/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportDistributedServerCachesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/distributedservercaches/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/distributedservercaches/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetDistributedServerCaches(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.DistributedServerCache>> GetDistributedServerCaches(Query query)
        {
            return await GetDistributedServerCaches(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.DistributedServerCache>> GetDistributedServerCaches(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"DistributedServerCaches");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetDistributedServerCaches(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.DistributedServerCache>>(response);
        }

        partial void OnCreateDistributedServerCache(HttpRequestMessage requestMessage);

        public async Task<ZarenUI.Server.Models.Connector.DistributedServerCache> CreateDistributedServerCache(ZarenUI.Server.Models.Connector.DistributedServerCache distributedServerCache = default(ZarenUI.Server.Models.Connector.DistributedServerCache))
        {
            var uri = new Uri(baseUri, $"DistributedServerCaches");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(distributedServerCache), Encoding.UTF8, "application/json");

            OnCreateDistributedServerCache(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ZarenUI.Server.Models.Connector.DistributedServerCache>(response);
        }

        partial void OnDeleteDistributedServerCache(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteDistributedServerCache(string id = default(string))
        {
            var uri = new Uri(baseUri, $"DistributedServerCaches('{HttpUtility.UrlEncode(id.Trim().Replace("'", "''"))}')");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteDistributedServerCache(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetDistributedServerCacheById(HttpRequestMessage requestMessage);

        public async Task<ZarenUI.Server.Models.Connector.DistributedServerCache> GetDistributedServerCacheById(string expand = default(string), string id = default(string))
        {
            var uri = new Uri(baseUri, $"DistributedServerCaches('{HttpUtility.UrlEncode(id.Trim().Replace("'", "''"))}')");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetDistributedServerCacheById(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ZarenUI.Server.Models.Connector.DistributedServerCache>(response);
        }

        partial void OnUpdateDistributedServerCache(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateDistributedServerCache(string id = default(string), ZarenUI.Server.Models.Connector.DistributedServerCache distributedServerCache = default(ZarenUI.Server.Models.Connector.DistributedServerCache))
        {
            var uri = new Uri(baseUri, $"DistributedServerCaches('{HttpUtility.UrlEncode(id.Trim().Replace("'", "''"))}')");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(distributedServerCache), Encoding.UTF8, "application/json");

            OnUpdateDistributedServerCache(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportFieldsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/fields/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/fields/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportFieldsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/fields/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/fields/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetFields(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.Field>> GetFields(Query query)
        {
            return await GetFields(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.Field>> GetFields(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"Fields");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetFields(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.Field>>(response);
        }

        partial void OnCreateField(HttpRequestMessage requestMessage);

        public async Task<ZarenUI.Server.Models.Connector.Field> CreateField(ZarenUI.Server.Models.Connector.Field field = default(ZarenUI.Server.Models.Connector.Field))
        {
            var uri = new Uri(baseUri, $"Fields");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(field), Encoding.UTF8, "application/json");

            OnCreateField(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ZarenUI.Server.Models.Connector.Field>(response);
        }

        partial void OnDeleteField(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteField(int id = default(int))
        {
            var uri = new Uri(baseUri, $"Fields({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteField(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetFieldById(HttpRequestMessage requestMessage);

        public async Task<ZarenUI.Server.Models.Connector.Field> GetFieldById(string expand = default(string), int id = default(int))
        {
            var uri = new Uri(baseUri, $"Fields({id})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetFieldById(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ZarenUI.Server.Models.Connector.Field>(response);
        }

        partial void OnUpdateField(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateField(int id = default(int), ZarenUI.Server.Models.Connector.Field field = default(ZarenUI.Server.Models.Connector.Field))
        {
            var uri = new Uri(baseUri, $"Fields({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(field), Encoding.UTF8, "application/json");

            OnUpdateField(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportProgrammingCategoriesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/programmingcategories/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/programmingcategories/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportProgrammingCategoriesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/programmingcategories/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/programmingcategories/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetProgrammingCategories(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.ProgrammingCategory>> GetProgrammingCategories(Query query)
        {
            return await GetProgrammingCategories(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.ProgrammingCategory>> GetProgrammingCategories(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"ProgrammingCategories");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetProgrammingCategories(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.ProgrammingCategory>>(response);
        }

        partial void OnCreateProgrammingCategory(HttpRequestMessage requestMessage);

        public async Task<ZarenUI.Server.Models.Connector.ProgrammingCategory> CreateProgrammingCategory(ZarenUI.Server.Models.Connector.ProgrammingCategory programmingCategory = default(ZarenUI.Server.Models.Connector.ProgrammingCategory))
        {
            var uri = new Uri(baseUri, $"ProgrammingCategories");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(programmingCategory), Encoding.UTF8, "application/json");

            OnCreateProgrammingCategory(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ZarenUI.Server.Models.Connector.ProgrammingCategory>(response);
        }

        partial void OnDeleteProgrammingCategory(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteProgrammingCategory(int id = default(int))
        {
            var uri = new Uri(baseUri, $"ProgrammingCategories({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteProgrammingCategory(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetProgrammingCategoryById(HttpRequestMessage requestMessage);

        public async Task<ZarenUI.Server.Models.Connector.ProgrammingCategory> GetProgrammingCategoryById(string expand = default(string), int id = default(int))
        {
            var uri = new Uri(baseUri, $"ProgrammingCategories({id})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetProgrammingCategoryById(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ZarenUI.Server.Models.Connector.ProgrammingCategory>(response);
        }

        partial void OnUpdateProgrammingCategory(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateProgrammingCategory(int id = default(int), ZarenUI.Server.Models.Connector.ProgrammingCategory programmingCategory = default(ZarenUI.Server.Models.Connector.ProgrammingCategory))
        {
            var uri = new Uri(baseUri, $"ProgrammingCategories({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(programmingCategory), Encoding.UTF8, "application/json");

            OnUpdateProgrammingCategory(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportProgrammingCodesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/programmingcodes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/programmingcodes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportProgrammingCodesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/programmingcodes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/programmingcodes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetProgrammingCodes(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.ProgrammingCode>> GetProgrammingCodes(Query query)
        {
            return await GetProgrammingCodes(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.ProgrammingCode>> GetProgrammingCodes(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"ProgrammingCodes");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetProgrammingCodes(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.ProgrammingCode>>(response);
        }

        partial void OnCreateProgrammingCode(HttpRequestMessage requestMessage);

        public async Task<ZarenUI.Server.Models.Connector.ProgrammingCode> CreateProgrammingCode(ZarenUI.Server.Models.Connector.ProgrammingCode programmingCode = default(ZarenUI.Server.Models.Connector.ProgrammingCode))
        {
            var uri = new Uri(baseUri, $"ProgrammingCodes");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(programmingCode), Encoding.UTF8, "application/json");

            OnCreateProgrammingCode(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ZarenUI.Server.Models.Connector.ProgrammingCode>(response);
        }

        partial void OnDeleteProgrammingCode(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteProgrammingCode(int id = default(int))
        {
            var uri = new Uri(baseUri, $"ProgrammingCodes({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteProgrammingCode(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetProgrammingCodeById(HttpRequestMessage requestMessage);

        public async Task<ZarenUI.Server.Models.Connector.ProgrammingCode> GetProgrammingCodeById(string expand = default(string), int id = default(int))
        {
            var uri = new Uri(baseUri, $"ProgrammingCodes({id})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetProgrammingCodeById(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ZarenUI.Server.Models.Connector.ProgrammingCode>(response);
        }

        partial void OnUpdateProgrammingCode(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateProgrammingCode(int id = default(int), ZarenUI.Server.Models.Connector.ProgrammingCode programmingCode = default(ZarenUI.Server.Models.Connector.ProgrammingCode))
        {
            var uri = new Uri(baseUri, $"ProgrammingCodes({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(programmingCode), Encoding.UTF8, "application/json");

            OnUpdateProgrammingCode(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportProgrammingCodeTemplatesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/programmingcodetemplates/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/programmingcodetemplates/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportProgrammingCodeTemplatesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/programmingcodetemplates/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/programmingcodetemplates/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetProgrammingCodeTemplates(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.ProgrammingCodeTemplate>> GetProgrammingCodeTemplates(Query query)
        {
            return await GetProgrammingCodeTemplates(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.ProgrammingCodeTemplate>> GetProgrammingCodeTemplates(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"ProgrammingCodeTemplates");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetProgrammingCodeTemplates(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.ProgrammingCodeTemplate>>(response);
        }

        partial void OnCreateProgrammingCodeTemplate(HttpRequestMessage requestMessage);

        public async Task<ZarenUI.Server.Models.Connector.ProgrammingCodeTemplate> CreateProgrammingCodeTemplate(ZarenUI.Server.Models.Connector.ProgrammingCodeTemplate programmingCodeTemplate = default(ZarenUI.Server.Models.Connector.ProgrammingCodeTemplate))
        {
            var uri = new Uri(baseUri, $"ProgrammingCodeTemplates");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(programmingCodeTemplate), Encoding.UTF8, "application/json");

            OnCreateProgrammingCodeTemplate(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ZarenUI.Server.Models.Connector.ProgrammingCodeTemplate>(response);
        }

        partial void OnDeleteProgrammingCodeTemplate(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteProgrammingCodeTemplate(int id = default(int))
        {
            var uri = new Uri(baseUri, $"ProgrammingCodeTemplates({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteProgrammingCodeTemplate(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetProgrammingCodeTemplateById(HttpRequestMessage requestMessage);

        public async Task<ZarenUI.Server.Models.Connector.ProgrammingCodeTemplate> GetProgrammingCodeTemplateById(string expand = default(string), int id = default(int))
        {
            var uri = new Uri(baseUri, $"ProgrammingCodeTemplates({id})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetProgrammingCodeTemplateById(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ZarenUI.Server.Models.Connector.ProgrammingCodeTemplate>(response);
        }

        partial void OnUpdateProgrammingCodeTemplate(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateProgrammingCodeTemplate(int id = default(int), ZarenUI.Server.Models.Connector.ProgrammingCodeTemplate programmingCodeTemplate = default(ZarenUI.Server.Models.Connector.ProgrammingCodeTemplate))
        {
            var uri = new Uri(baseUri, $"ProgrammingCodeTemplates({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(programmingCodeTemplate), Encoding.UTF8, "application/json");

            OnUpdateProgrammingCodeTemplate(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportProgrammingTechnologiesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/programmingtechnologies/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/programmingtechnologies/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportProgrammingTechnologiesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/programmingtechnologies/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/programmingtechnologies/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetProgrammingTechnologies(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.ProgrammingTechnology>> GetProgrammingTechnologies(Query query)
        {
            return await GetProgrammingTechnologies(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.ProgrammingTechnology>> GetProgrammingTechnologies(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"ProgrammingTechnologies");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetProgrammingTechnologies(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.ProgrammingTechnology>>(response);
        }

        partial void OnCreateProgrammingTechnology(HttpRequestMessage requestMessage);

        public async Task<ZarenUI.Server.Models.Connector.ProgrammingTechnology> CreateProgrammingTechnology(ZarenUI.Server.Models.Connector.ProgrammingTechnology programmingTechnology = default(ZarenUI.Server.Models.Connector.ProgrammingTechnology))
        {
            var uri = new Uri(baseUri, $"ProgrammingTechnologies");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(programmingTechnology), Encoding.UTF8, "application/json");

            OnCreateProgrammingTechnology(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ZarenUI.Server.Models.Connector.ProgrammingTechnology>(response);
        }

        partial void OnDeleteProgrammingTechnology(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteProgrammingTechnology(int id = default(int))
        {
            var uri = new Uri(baseUri, $"ProgrammingTechnologies({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteProgrammingTechnology(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetProgrammingTechnologyById(HttpRequestMessage requestMessage);

        public async Task<ZarenUI.Server.Models.Connector.ProgrammingTechnology> GetProgrammingTechnologyById(string expand = default(string), int id = default(int))
        {
            var uri = new Uri(baseUri, $"ProgrammingTechnologies({id})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetProgrammingTechnologyById(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ZarenUI.Server.Models.Connector.ProgrammingTechnology>(response);
        }

        partial void OnUpdateProgrammingTechnology(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateProgrammingTechnology(int id = default(int), ZarenUI.Server.Models.Connector.ProgrammingTechnology programmingTechnology = default(ZarenUI.Server.Models.Connector.ProgrammingTechnology))
        {
            var uri = new Uri(baseUri, $"ProgrammingTechnologies({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(programmingTechnology), Encoding.UTF8, "application/json");

            OnUpdateProgrammingTechnology(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportProjectCategoriesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/projectcategories/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/projectcategories/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportProjectCategoriesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/projectcategories/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/projectcategories/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetProjectCategories(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.ProjectCategory>> GetProjectCategories(Query query)
        {
            return await GetProjectCategories(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.ProjectCategory>> GetProjectCategories(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"ProjectCategories");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetProjectCategories(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.ProjectCategory>>(response);
        }

        partial void OnCreateProjectCategory(HttpRequestMessage requestMessage);

        public async Task<ZarenUI.Server.Models.Connector.ProjectCategory> CreateProjectCategory(ZarenUI.Server.Models.Connector.ProjectCategory projectCategory = default(ZarenUI.Server.Models.Connector.ProjectCategory))
        {
            var uri = new Uri(baseUri, $"ProjectCategories");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(projectCategory), Encoding.UTF8, "application/json");

            OnCreateProjectCategory(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ZarenUI.Server.Models.Connector.ProjectCategory>(response);
        }

        partial void OnDeleteProjectCategory(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteProjectCategory(int id = default(int))
        {
            var uri = new Uri(baseUri, $"ProjectCategories({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteProjectCategory(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetProjectCategoryById(HttpRequestMessage requestMessage);

        public async Task<ZarenUI.Server.Models.Connector.ProjectCategory> GetProjectCategoryById(string expand = default(string), int id = default(int))
        {
            var uri = new Uri(baseUri, $"ProjectCategories({id})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetProjectCategoryById(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ZarenUI.Server.Models.Connector.ProjectCategory>(response);
        }

        partial void OnUpdateProjectCategory(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateProjectCategory(int id = default(int), ZarenUI.Server.Models.Connector.ProjectCategory projectCategory = default(ZarenUI.Server.Models.Connector.ProjectCategory))
        {
            var uri = new Uri(baseUri, $"ProjectCategories({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(projectCategory), Encoding.UTF8, "application/json");

            OnUpdateProjectCategory(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportProjectConfigurationKeyAndValuesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/projectconfigurationkeyandvalues/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/projectconfigurationkeyandvalues/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportProjectConfigurationKeyAndValuesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/projectconfigurationkeyandvalues/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/projectconfigurationkeyandvalues/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetProjectConfigurationKeyAndValues(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.ProjectConfigurationKeyAndValue>> GetProjectConfigurationKeyAndValues(Query query)
        {
            return await GetProjectConfigurationKeyAndValues(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.ProjectConfigurationKeyAndValue>> GetProjectConfigurationKeyAndValues(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"ProjectConfigurationKeyAndValues");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetProjectConfigurationKeyAndValues(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.ProjectConfigurationKeyAndValue>>(response);
        }

        partial void OnCreateProjectConfigurationKeyAndValue(HttpRequestMessage requestMessage);

        public async Task<ZarenUI.Server.Models.Connector.ProjectConfigurationKeyAndValue> CreateProjectConfigurationKeyAndValue(ZarenUI.Server.Models.Connector.ProjectConfigurationKeyAndValue projectConfigurationKeyAndValue = default(ZarenUI.Server.Models.Connector.ProjectConfigurationKeyAndValue))
        {
            var uri = new Uri(baseUri, $"ProjectConfigurationKeyAndValues");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(projectConfigurationKeyAndValue), Encoding.UTF8, "application/json");

            OnCreateProjectConfigurationKeyAndValue(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ZarenUI.Server.Models.Connector.ProjectConfigurationKeyAndValue>(response);
        }

        partial void OnDeleteProjectConfigurationKeyAndValue(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteProjectConfigurationKeyAndValue(int id = default(int))
        {
            var uri = new Uri(baseUri, $"ProjectConfigurationKeyAndValues({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteProjectConfigurationKeyAndValue(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetProjectConfigurationKeyAndValueById(HttpRequestMessage requestMessage);

        public async Task<ZarenUI.Server.Models.Connector.ProjectConfigurationKeyAndValue> GetProjectConfigurationKeyAndValueById(string expand = default(string), int id = default(int))
        {
            var uri = new Uri(baseUri, $"ProjectConfigurationKeyAndValues({id})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetProjectConfigurationKeyAndValueById(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ZarenUI.Server.Models.Connector.ProjectConfigurationKeyAndValue>(response);
        }

        partial void OnUpdateProjectConfigurationKeyAndValue(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateProjectConfigurationKeyAndValue(int id = default(int), ZarenUI.Server.Models.Connector.ProjectConfigurationKeyAndValue projectConfigurationKeyAndValue = default(ZarenUI.Server.Models.Connector.ProjectConfigurationKeyAndValue))
        {
            var uri = new Uri(baseUri, $"ProjectConfigurationKeyAndValues({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(projectConfigurationKeyAndValue), Encoding.UTF8, "application/json");

            OnUpdateProjectConfigurationKeyAndValue(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportProjectConfigurationsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/projectconfigurations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/projectconfigurations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportProjectConfigurationsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/projectconfigurations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/projectconfigurations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetProjectConfigurations(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.ProjectConfiguration>> GetProjectConfigurations(Query query)
        {
            return await GetProjectConfigurations(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.ProjectConfiguration>> GetProjectConfigurations(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"ProjectConfigurations");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetProjectConfigurations(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.ProjectConfiguration>>(response);
        }

        partial void OnCreateProjectConfiguration(HttpRequestMessage requestMessage);

        public async Task<ZarenUI.Server.Models.Connector.ProjectConfiguration> CreateProjectConfiguration(ZarenUI.Server.Models.Connector.ProjectConfiguration projectConfiguration = default(ZarenUI.Server.Models.Connector.ProjectConfiguration))
        {
            var uri = new Uri(baseUri, $"ProjectConfigurations");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(projectConfiguration), Encoding.UTF8, "application/json");

            OnCreateProjectConfiguration(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ZarenUI.Server.Models.Connector.ProjectConfiguration>(response);
        }

        partial void OnDeleteProjectConfiguration(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteProjectConfiguration(int id = default(int))
        {
            var uri = new Uri(baseUri, $"ProjectConfigurations({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteProjectConfiguration(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetProjectConfigurationById(HttpRequestMessage requestMessage);

        public async Task<ZarenUI.Server.Models.Connector.ProjectConfiguration> GetProjectConfigurationById(string expand = default(string), int id = default(int))
        {
            var uri = new Uri(baseUri, $"ProjectConfigurations({id})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetProjectConfigurationById(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ZarenUI.Server.Models.Connector.ProjectConfiguration>(response);
        }

        partial void OnUpdateProjectConfiguration(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateProjectConfiguration(int id = default(int), ZarenUI.Server.Models.Connector.ProjectConfiguration projectConfiguration = default(ZarenUI.Server.Models.Connector.ProjectConfiguration))
        {
            var uri = new Uri(baseUri, $"ProjectConfigurations({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(projectConfiguration), Encoding.UTF8, "application/json");

            OnUpdateProjectConfiguration(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportProjectFunctionGroupsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/projectfunctiongroups/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/projectfunctiongroups/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportProjectFunctionGroupsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/projectfunctiongroups/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/projectfunctiongroups/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetProjectFunctionGroups(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.ProjectFunctionGroup>> GetProjectFunctionGroups(Query query)
        {
            return await GetProjectFunctionGroups(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.ProjectFunctionGroup>> GetProjectFunctionGroups(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"ProjectFunctionGroups");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetProjectFunctionGroups(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.ProjectFunctionGroup>>(response);
        }

        partial void OnCreateProjectFunctionGroup(HttpRequestMessage requestMessage);

        public async Task<ZarenUI.Server.Models.Connector.ProjectFunctionGroup> CreateProjectFunctionGroup(ZarenUI.Server.Models.Connector.ProjectFunctionGroup projectFunctionGroup = default(ZarenUI.Server.Models.Connector.ProjectFunctionGroup))
        {
            var uri = new Uri(baseUri, $"ProjectFunctionGroups");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(projectFunctionGroup), Encoding.UTF8, "application/json");

            OnCreateProjectFunctionGroup(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ZarenUI.Server.Models.Connector.ProjectFunctionGroup>(response);
        }

        partial void OnDeleteProjectFunctionGroup(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteProjectFunctionGroup(int id = default(int))
        {
            var uri = new Uri(baseUri, $"ProjectFunctionGroups({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteProjectFunctionGroup(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetProjectFunctionGroupById(HttpRequestMessage requestMessage);

        public async Task<ZarenUI.Server.Models.Connector.ProjectFunctionGroup> GetProjectFunctionGroupById(string expand = default(string), int id = default(int))
        {
            var uri = new Uri(baseUri, $"ProjectFunctionGroups({id})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetProjectFunctionGroupById(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ZarenUI.Server.Models.Connector.ProjectFunctionGroup>(response);
        }

        partial void OnUpdateProjectFunctionGroup(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateProjectFunctionGroup(int id = default(int), ZarenUI.Server.Models.Connector.ProjectFunctionGroup projectFunctionGroup = default(ZarenUI.Server.Models.Connector.ProjectFunctionGroup))
        {
            var uri = new Uri(baseUri, $"ProjectFunctionGroups({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(projectFunctionGroup), Encoding.UTF8, "application/json");

            OnUpdateProjectFunctionGroup(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportProjectFunctionsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/projectfunctions/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/projectfunctions/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportProjectFunctionsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/projectfunctions/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/projectfunctions/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetProjectFunctions(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.ProjectFunction>> GetProjectFunctions(Query query)
        {
            return await GetProjectFunctions(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.ProjectFunction>> GetProjectFunctions(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"ProjectFunctions");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetProjectFunctions(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.ProjectFunction>>(response);
        }

        partial void OnCreateProjectFunction(HttpRequestMessage requestMessage);

        public async Task<ZarenUI.Server.Models.Connector.ProjectFunction> CreateProjectFunction(ZarenUI.Server.Models.Connector.ProjectFunction projectFunction = default(ZarenUI.Server.Models.Connector.ProjectFunction))
        {
            var uri = new Uri(baseUri, $"ProjectFunctions");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(projectFunction), Encoding.UTF8, "application/json");

            OnCreateProjectFunction(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ZarenUI.Server.Models.Connector.ProjectFunction>(response);
        }

        partial void OnDeleteProjectFunction(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteProjectFunction(int id = default(int))
        {
            var uri = new Uri(baseUri, $"ProjectFunctions({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteProjectFunction(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetProjectFunctionById(HttpRequestMessage requestMessage);

        public async Task<ZarenUI.Server.Models.Connector.ProjectFunction> GetProjectFunctionById(string expand = default(string), int id = default(int))
        {
            var uri = new Uri(baseUri, $"ProjectFunctions({id})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetProjectFunctionById(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ZarenUI.Server.Models.Connector.ProjectFunction>(response);
        }

        partial void OnUpdateProjectFunction(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateProjectFunction(int id = default(int), ZarenUI.Server.Models.Connector.ProjectFunction projectFunction = default(ZarenUI.Server.Models.Connector.ProjectFunction))
        {
            var uri = new Uri(baseUri, $"ProjectFunctions({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(projectFunction), Encoding.UTF8, "application/json");

            OnUpdateProjectFunction(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportProjectPageComponentElementsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/projectpagecomponentelements/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/projectpagecomponentelements/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportProjectPageComponentElementsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/projectpagecomponentelements/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/projectpagecomponentelements/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetProjectPageComponentElements(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.ProjectPageComponentElement>> GetProjectPageComponentElements(Query query)
        {
            return await GetProjectPageComponentElements(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.ProjectPageComponentElement>> GetProjectPageComponentElements(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"ProjectPageComponentElements");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetProjectPageComponentElements(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.ProjectPageComponentElement>>(response);
        }

        partial void OnCreateProjectPageComponentElement(HttpRequestMessage requestMessage);

        public async Task<ZarenUI.Server.Models.Connector.ProjectPageComponentElement> CreateProjectPageComponentElement(ZarenUI.Server.Models.Connector.ProjectPageComponentElement projectPageComponentElement = default(ZarenUI.Server.Models.Connector.ProjectPageComponentElement))
        {
            var uri = new Uri(baseUri, $"ProjectPageComponentElements");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(projectPageComponentElement), Encoding.UTF8, "application/json");

            OnCreateProjectPageComponentElement(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ZarenUI.Server.Models.Connector.ProjectPageComponentElement>(response);
        }

        partial void OnDeleteProjectPageComponentElement(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteProjectPageComponentElement(int id = default(int))
        {
            var uri = new Uri(baseUri, $"ProjectPageComponentElements({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteProjectPageComponentElement(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetProjectPageComponentElementById(HttpRequestMessage requestMessage);

        public async Task<ZarenUI.Server.Models.Connector.ProjectPageComponentElement> GetProjectPageComponentElementById(string expand = default(string), int id = default(int))
        {
            var uri = new Uri(baseUri, $"ProjectPageComponentElements({id})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetProjectPageComponentElementById(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ZarenUI.Server.Models.Connector.ProjectPageComponentElement>(response);
        }

        partial void OnUpdateProjectPageComponentElement(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateProjectPageComponentElement(int id = default(int), ZarenUI.Server.Models.Connector.ProjectPageComponentElement projectPageComponentElement = default(ZarenUI.Server.Models.Connector.ProjectPageComponentElement))
        {
            var uri = new Uri(baseUri, $"ProjectPageComponentElements({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(projectPageComponentElement), Encoding.UTF8, "application/json");

            OnUpdateProjectPageComponentElement(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportProjectPageComponentsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/projectpagecomponents/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/projectpagecomponents/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportProjectPageComponentsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/projectpagecomponents/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/projectpagecomponents/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetProjectPageComponents(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.ProjectPageComponent>> GetProjectPageComponents(Query query)
        {
            return await GetProjectPageComponents(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.ProjectPageComponent>> GetProjectPageComponents(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"ProjectPageComponents");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetProjectPageComponents(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.ProjectPageComponent>>(response);
        }

        partial void OnCreateProjectPageComponent(HttpRequestMessage requestMessage);

        public async Task<ZarenUI.Server.Models.Connector.ProjectPageComponent> CreateProjectPageComponent(ZarenUI.Server.Models.Connector.ProjectPageComponent projectPageComponent = default(ZarenUI.Server.Models.Connector.ProjectPageComponent))
        {
            var uri = new Uri(baseUri, $"ProjectPageComponents");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(projectPageComponent), Encoding.UTF8, "application/json");

            OnCreateProjectPageComponent(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ZarenUI.Server.Models.Connector.ProjectPageComponent>(response);
        }

        partial void OnDeleteProjectPageComponent(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteProjectPageComponent(int id = default(int))
        {
            var uri = new Uri(baseUri, $"ProjectPageComponents({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteProjectPageComponent(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetProjectPageComponentById(HttpRequestMessage requestMessage);

        public async Task<ZarenUI.Server.Models.Connector.ProjectPageComponent> GetProjectPageComponentById(string expand = default(string), int id = default(int))
        {
            var uri = new Uri(baseUri, $"ProjectPageComponents({id})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetProjectPageComponentById(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ZarenUI.Server.Models.Connector.ProjectPageComponent>(response);
        }

        partial void OnUpdateProjectPageComponent(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateProjectPageComponent(int id = default(int), ZarenUI.Server.Models.Connector.ProjectPageComponent projectPageComponent = default(ZarenUI.Server.Models.Connector.ProjectPageComponent))
        {
            var uri = new Uri(baseUri, $"ProjectPageComponents({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(projectPageComponent), Encoding.UTF8, "application/json");

            OnUpdateProjectPageComponent(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportProjectPagesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/projectpages/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/projectpages/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportProjectPagesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/projectpages/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/projectpages/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetProjectPages(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.ProjectPage>> GetProjectPages(Query query)
        {
            return await GetProjectPages(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.ProjectPage>> GetProjectPages(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"ProjectPages");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetProjectPages(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.ProjectPage>>(response);
        }

        partial void OnCreateProjectPage(HttpRequestMessage requestMessage);

        public async Task<ZarenUI.Server.Models.Connector.ProjectPage> CreateProjectPage(ZarenUI.Server.Models.Connector.ProjectPage projectPage = default(ZarenUI.Server.Models.Connector.ProjectPage))
        {
            var uri = new Uri(baseUri, $"ProjectPages");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(projectPage), Encoding.UTF8, "application/json");

            OnCreateProjectPage(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ZarenUI.Server.Models.Connector.ProjectPage>(response);
        }

        partial void OnDeleteProjectPage(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteProjectPage(int id = default(int))
        {
            var uri = new Uri(baseUri, $"ProjectPages({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteProjectPage(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetProjectPageById(HttpRequestMessage requestMessage);

        public async Task<ZarenUI.Server.Models.Connector.ProjectPage> GetProjectPageById(string expand = default(string), int id = default(int))
        {
            var uri = new Uri(baseUri, $"ProjectPages({id})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetProjectPageById(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ZarenUI.Server.Models.Connector.ProjectPage>(response);
        }

        partial void OnUpdateProjectPage(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateProjectPage(int id = default(int), ZarenUI.Server.Models.Connector.ProjectPage projectPage = default(ZarenUI.Server.Models.Connector.ProjectPage))
        {
            var uri = new Uri(baseUri, $"ProjectPages({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(projectPage), Encoding.UTF8, "application/json");

            OnUpdateProjectPage(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportProjectsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/projects/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/projects/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportProjectsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/projects/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/projects/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetProjects(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.Project>> GetProjects(Query query)
        {
            return await GetProjects(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.Project>> GetProjects(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"Projects");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetProjects(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.Project>>(response);
        }

        partial void OnCreateProject(HttpRequestMessage requestMessage);

        public async Task<ZarenUI.Server.Models.Connector.Project> CreateProject(ZarenUI.Server.Models.Connector.Project project = default(ZarenUI.Server.Models.Connector.Project))
        {
            var uri = new Uri(baseUri, $"Projects");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(project), Encoding.UTF8, "application/json");

            OnCreateProject(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ZarenUI.Server.Models.Connector.Project>(response);
        }

        partial void OnDeleteProject(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteProject(int id = default(int))
        {
            var uri = new Uri(baseUri, $"Projects({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteProject(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetProjectById(HttpRequestMessage requestMessage);

        public async Task<ZarenUI.Server.Models.Connector.Project> GetProjectById(string expand = default(string), int id = default(int))
        {
            var uri = new Uri(baseUri, $"Projects({id})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetProjectById(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ZarenUI.Server.Models.Connector.Project>(response);
        }

        partial void OnUpdateProject(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateProject(int id = default(int), ZarenUI.Server.Models.Connector.Project project = default(ZarenUI.Server.Models.Connector.Project))
        {
            var uri = new Uri(baseUri, $"Projects({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(project), Encoding.UTF8, "application/json");

            OnUpdateProject(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportProjectTableColumnsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/projecttablecolumns/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/projecttablecolumns/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportProjectTableColumnsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/projecttablecolumns/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/projecttablecolumns/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetProjectTableColumns(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.ProjectTableColumn>> GetProjectTableColumns(Query query)
        {
            return await GetProjectTableColumns(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.ProjectTableColumn>> GetProjectTableColumns(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"ProjectTableColumns");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetProjectTableColumns(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.ProjectTableColumn>>(response);
        }

        partial void OnCreateProjectTableColumn(HttpRequestMessage requestMessage);

        public async Task<ZarenUI.Server.Models.Connector.ProjectTableColumn> CreateProjectTableColumn(ZarenUI.Server.Models.Connector.ProjectTableColumn projectTableColumn = default(ZarenUI.Server.Models.Connector.ProjectTableColumn))
        {
            var uri = new Uri(baseUri, $"ProjectTableColumns");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(projectTableColumn), Encoding.UTF8, "application/json");

            OnCreateProjectTableColumn(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ZarenUI.Server.Models.Connector.ProjectTableColumn>(response);
        }

        partial void OnDeleteProjectTableColumn(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteProjectTableColumn(int id = default(int))
        {
            var uri = new Uri(baseUri, $"ProjectTableColumns({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteProjectTableColumn(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetProjectTableColumnById(HttpRequestMessage requestMessage);

        public async Task<ZarenUI.Server.Models.Connector.ProjectTableColumn> GetProjectTableColumnById(string expand = default(string), int id = default(int))
        {
            var uri = new Uri(baseUri, $"ProjectTableColumns({id})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetProjectTableColumnById(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ZarenUI.Server.Models.Connector.ProjectTableColumn>(response);
        }

        partial void OnUpdateProjectTableColumn(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateProjectTableColumn(int id = default(int), ZarenUI.Server.Models.Connector.ProjectTableColumn projectTableColumn = default(ZarenUI.Server.Models.Connector.ProjectTableColumn))
        {
            var uri = new Uri(baseUri, $"ProjectTableColumns({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(projectTableColumn), Encoding.UTF8, "application/json");

            OnUpdateProjectTableColumn(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportProjectTablesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/projecttables/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/projecttables/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportProjectTablesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/projecttables/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/projecttables/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetProjectTables(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.ProjectTable>> GetProjectTables(Query query)
        {
            return await GetProjectTables(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.ProjectTable>> GetProjectTables(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"ProjectTables");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetProjectTables(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.ProjectTable>>(response);
        }

        partial void OnCreateProjectTable(HttpRequestMessage requestMessage);

        public async Task<ZarenUI.Server.Models.Connector.ProjectTable> CreateProjectTable(ZarenUI.Server.Models.Connector.ProjectTable projectTable = default(ZarenUI.Server.Models.Connector.ProjectTable))
        {
            var uri = new Uri(baseUri, $"ProjectTables");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(projectTable), Encoding.UTF8, "application/json");

            OnCreateProjectTable(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ZarenUI.Server.Models.Connector.ProjectTable>(response);
        }

        partial void OnDeleteProjectTable(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteProjectTable(int id = default(int))
        {
            var uri = new Uri(baseUri, $"ProjectTables({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteProjectTable(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetProjectTableById(HttpRequestMessage requestMessage);

        public async Task<ZarenUI.Server.Models.Connector.ProjectTable> GetProjectTableById(string expand = default(string), int id = default(int))
        {
            var uri = new Uri(baseUri, $"ProjectTables({id})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetProjectTableById(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ZarenUI.Server.Models.Connector.ProjectTable>(response);
        }

        partial void OnUpdateProjectTable(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateProjectTable(int id = default(int), ZarenUI.Server.Models.Connector.ProjectTable projectTable = default(ZarenUI.Server.Models.Connector.ProjectTable))
        {
            var uri = new Uri(baseUri, $"ProjectTables({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(projectTable), Encoding.UTF8, "application/json");

            OnUpdateProjectTable(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportReferenceWebSitesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/referencewebsites/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/referencewebsites/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportReferenceWebSitesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/referencewebsites/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/referencewebsites/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetReferenceWebSites(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.ReferenceWebSite>> GetReferenceWebSites(Query query)
        {
            return await GetReferenceWebSites(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.ReferenceWebSite>> GetReferenceWebSites(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"ReferenceWebSites");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetReferenceWebSites(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.ReferenceWebSite>>(response);
        }

        partial void OnCreateReferenceWebSite(HttpRequestMessage requestMessage);

        public async Task<ZarenUI.Server.Models.Connector.ReferenceWebSite> CreateReferenceWebSite(ZarenUI.Server.Models.Connector.ReferenceWebSite referenceWebSite = default(ZarenUI.Server.Models.Connector.ReferenceWebSite))
        {
            var uri = new Uri(baseUri, $"ReferenceWebSites");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(referenceWebSite), Encoding.UTF8, "application/json");

            OnCreateReferenceWebSite(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ZarenUI.Server.Models.Connector.ReferenceWebSite>(response);
        }

        partial void OnDeleteReferenceWebSite(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteReferenceWebSite(int id = default(int))
        {
            var uri = new Uri(baseUri, $"ReferenceWebSites({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteReferenceWebSite(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetReferenceWebSiteById(HttpRequestMessage requestMessage);

        public async Task<ZarenUI.Server.Models.Connector.ReferenceWebSite> GetReferenceWebSiteById(string expand = default(string), int id = default(int))
        {
            var uri = new Uri(baseUri, $"ReferenceWebSites({id})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetReferenceWebSiteById(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ZarenUI.Server.Models.Connector.ReferenceWebSite>(response);
        }

        partial void OnUpdateReferenceWebSite(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateReferenceWebSite(int id = default(int), ZarenUI.Server.Models.Connector.ReferenceWebSite referenceWebSite = default(ZarenUI.Server.Models.Connector.ReferenceWebSite))
        {
            var uri = new Uri(baseUri, $"ReferenceWebSites({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(referenceWebSite), Encoding.UTF8, "application/json");

            OnUpdateReferenceWebSite(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportSchemesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/schemes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/schemes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportSchemesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/schemes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/schemes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetSchemes(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.Scheme>> GetSchemes(Query query)
        {
            return await GetSchemes(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.Scheme>> GetSchemes(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"Schemes");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetSchemes(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.Scheme>>(response);
        }

        partial void OnCreateScheme(HttpRequestMessage requestMessage);

        public async Task<ZarenUI.Server.Models.Connector.Scheme> CreateScheme(ZarenUI.Server.Models.Connector.Scheme scheme = default(ZarenUI.Server.Models.Connector.Scheme))
        {
            var uri = new Uri(baseUri, $"Schemes");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(scheme), Encoding.UTF8, "application/json");

            OnCreateScheme(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ZarenUI.Server.Models.Connector.Scheme>(response);
        }

        partial void OnDeleteScheme(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteScheme(int id = default(int))
        {
            var uri = new Uri(baseUri, $"Schemes({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteScheme(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetSchemeById(HttpRequestMessage requestMessage);

        public async Task<ZarenUI.Server.Models.Connector.Scheme> GetSchemeById(string expand = default(string), int id = default(int))
        {
            var uri = new Uri(baseUri, $"Schemes({id})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetSchemeById(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ZarenUI.Server.Models.Connector.Scheme>(response);
        }

        partial void OnUpdateScheme(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateScheme(int id = default(int), ZarenUI.Server.Models.Connector.Scheme scheme = default(ZarenUI.Server.Models.Connector.Scheme))
        {
            var uri = new Uri(baseUri, $"Schemes({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(scheme), Encoding.UTF8, "application/json");

            OnUpdateScheme(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportTablesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/tables/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/tables/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTablesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/tables/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/tables/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetTables(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.Table>> GetTables(Query query)
        {
            return await GetTables(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.Table>> GetTables(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"Tables");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTables(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.Table>>(response);
        }

        partial void OnCreateTable(HttpRequestMessage requestMessage);

        public async Task<ZarenUI.Server.Models.Connector.Table> CreateTable(ZarenUI.Server.Models.Connector.Table table = default(ZarenUI.Server.Models.Connector.Table))
        {
            var uri = new Uri(baseUri, $"Tables");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(table), Encoding.UTF8, "application/json");

            OnCreateTable(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ZarenUI.Server.Models.Connector.Table>(response);
        }

        partial void OnDeleteTable(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteTable(int id = default(int))
        {
            var uri = new Uri(baseUri, $"Tables({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTable(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetTableById(HttpRequestMessage requestMessage);

        public async Task<ZarenUI.Server.Models.Connector.Table> GetTableById(string expand = default(string), int id = default(int))
        {
            var uri = new Uri(baseUri, $"Tables({id})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTableById(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<ZarenUI.Server.Models.Connector.Table>(response);
        }

        partial void OnUpdateTable(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateTable(int id = default(int), ZarenUI.Server.Models.Connector.Table table = default(ZarenUI.Server.Models.Connector.Table))
        {
            var uri = new Uri(baseUri, $"Tables({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(table), Encoding.UTF8, "application/json");

            OnUpdateTable(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportDesignSchemesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/designschemes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/designschemes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportDesignSchemesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/designschemes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/designschemes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetDesignSchemes(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.DesignScheme>> GetDesignSchemes(Query query)
        {
            return await GetDesignSchemes(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.DesignScheme>> GetDesignSchemes(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"DesignSchemes");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetDesignSchemes(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<ZarenUI.Server.Models.Connector.DesignScheme>>(response);
        }
    }
}