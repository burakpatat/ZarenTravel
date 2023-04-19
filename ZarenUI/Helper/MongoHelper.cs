using Amazon.Runtime.Internal.Util;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using SanTsgHotelBooking.Application.Models.GetProductInfoRequest;
using SanTsgHotelBooking.Application.Models.Requests;
using SanTsgHotelBooking.Application.Services.IServices;
using SanTsgHotelBooking.Shared.SettingsModels;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;

namespace ZarenUI.Helper
{
	public class MongoHelper
	{
		private readonly ISanTsgTourVisioService _sanTsgTourVisioService;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly IConfiguration _configuration;
		private IDistributedCache _cache;
		private readonly MongoClient _client;
		private readonly string _cookie;
		private readonly string _databaseName = "Zaren";
		private readonly string _collectionName = "Paximum";
		public MongoHelper(IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IDistributedCache cache)
		{
			_configuration = configuration;
			_httpContextAccessor = httpContextAccessor;
			_cache = cache;
			var connectionString = configuration.GetSection("MONGODB_URI");
			_client = new MongoClient(connectionString.Value);
			_cookie = _httpContextAccessor.HttpContext.Request.Cookies["ZtUser"];
		}

		public async Task Log<T>(T request, string collectionName = "")
		{
			if (collectionName == "")
				collectionName = _collectionName;

			var values = JsonConvert.DeserializeObject<Dictionary<string, object>>(request.ToJson());
			var objectId = ObjectId.GenerateNewId();

			values.Add("_id", objectId);
			values.Add("cookie", _cookie);
			values.Add("data", GetCollectionName(typeof(T)));
			BsonDocument document = new BsonDocument(values);
			var collection = _client.GetDatabase(_databaseName).GetCollection<BsonDocument>(collectionName);
			collection.InsertOneAsync(document);
		}

		private protected string GetCollectionName(Type documentType)
		{
			return ((BsonCollectionAttribute)documentType.GetCustomAttributes(
					typeof(BsonCollectionAttribute),
					true)
				.FirstOrDefault())?.CollectionName;
		}
	}
}
