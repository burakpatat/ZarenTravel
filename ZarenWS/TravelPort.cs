using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Timers;
using static System.Net.WebRequestMethods;

namespace Api
{
    public partial class TravelPort : ServiceBase
    {
        IDbConnection connection;


        public TravelPort()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {

            Timer timer = new Timer();
            timer.Interval = 60 * 1000; // 60 seconds 
            timer.Elapsed += new ElapsedEventHandler(this.OnTimer);
            timer.Start();
            // GetUserTimelineTweets();
        }
        public void OnTimer(object sender, ElapsedEventArgs args)
        {

        }
        protected override void OnStop()
        {
        }



        internal void TestStartupAndStop()
        {

            this.OnTimer(null, null);
            RunYourCode();
            this.OnStop();
        }
        public void RunYourCode()
        {

            RestClient client = new RestClient();
            // Create the Request
            RestRequest request = new RestRequest()
            {
                Resource = "https://api.travelport.com",
                Method = Method.Post
            };
            // Add the body to the request

            var GetArrivalAutocompleteRequest = new GetArrivalAutocompleteRequest();
            GetArrivalAutocompleteRequest.Query = "amk";
            var jsonData = JsonConvert.SerializeObject(GetArrivalAutocompleteRequest);
            request.AddStringBody(jsonData, DataFormat.Json);
            // Send the request

            RestResponse response = client.ExecutePost(request);
            var resss= response.Content;

            //do anything



        }



    }

    public class GetArrivalAutocompleteRequest
    {
        [JsonProperty("ProductType")]
        public int ProductType;

        [JsonProperty("Query")]
        public string Query;

        [JsonProperty("Culture")]
        public string Culture;
    }


    public class Body
    {
        [JsonProperty("items")]
        public List<Item> Items;
    }

    public class City
    {
        [JsonProperty("id")]
        public string Id;

        [JsonProperty("name")]
        public string Name;
    }

    public class Country
    {
        [JsonProperty("id")]
        public string Id;

        [JsonProperty("name")]
        public string Name;
    }

    public class Geolocation
    {
        [JsonProperty("longitude")]
        public string Longitude;

        [JsonProperty("latitude")]
        public string Latitude;
    }

    public class GiataInfo
    {
        [JsonProperty("hotelId")]
        public string HotelId;

        [JsonProperty("destinationId")]
        public string DestinationId;
    }

    public class Header
    {
        [JsonProperty("requestId")]
        public string RequestId;

        [JsonProperty("success")]
        public bool Success;

        [JsonProperty("messages")]
        public List<Messages> Messages;
    }

    public class Item
    {
        [JsonProperty("type")]
        public int Type;

        [JsonProperty("geolocation")]
        public Geolocation Geolocation;

        [JsonProperty("country")]
        public Country Country;

        [JsonProperty("state")]
        public State State;

        [JsonProperty("city")]
        public City City;

        [JsonProperty("giataInfo")]
        public GiataInfo GiataInfo;

        [JsonProperty("provider")]
        public int Provider;
    }

    public class Messages
    {
        [JsonProperty("id")]
        public int Id;

        [JsonProperty("code")]
        public string Code;

        [JsonProperty("messageType")]
        public int MessageType;

        [JsonProperty("message")]
        public string Message;
    }

    public class GetAutoCompleteResponse
    {
        [JsonProperty("header")]
        public Header Header;

        [JsonProperty("body")]
        public Body Body;
    }

    public class State
    {
        [JsonProperty("id")]
        public string Id;

        [JsonProperty("name")]
        public string Name;
    }


    
}
