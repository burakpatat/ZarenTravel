using Microsoft.Extensions.Caching.Distributed;
using MongoDB.Driver;
using SanTsgHotelBooking.Application.Services.IServices;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.Filters;
using ActionExecutingContext = Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext;
using System.Net;

namespace ZarenUI.Helper
{
    [AttributeUsage(AttributeTargets.Method)]
    public class MongosAttribute: ActionFilterAttribute
    {
        private readonly ISanTsgTourVisioService _sanTsgTourVisioService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;
        private IDistributedCache _cache;
        private readonly MongoClient _client;
        private readonly string _databaseName = "Zaren";
        private readonly string _collectionName = "Paximum";
        private readonly string _cookie;

        private Type _model;
        public MongosAttribute(Type __model)
        {
            var connectionString = _configuration.GetSection("MONGODB_URI");
            _client = new MongoClient(connectionString.Value);
            _cookie = _httpContextAccessor.HttpContext.Request.Cookies["ZtUser"];

            _model = __model;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {

            var values = JsonConvert.DeserializeObject<Dictionary<string, object>>(context.HttpContext.Response.ToJson());
            var objectId = ObjectId.GenerateNewId();
            values.Add("_id", objectId);
            values.Add("cookie", _cookie);
            values.Add("data", context.ActionDescriptor.DisplayName);
            BsonDocument document = new BsonDocument(values);
            var collection = _client.GetDatabase(_databaseName).GetCollection<BsonDocument>(context.ActionDescriptor.DisplayName);
            collection.InsertOneAsync(document);

            base.OnActionExecuted(context);
        }

    }
}
