﻿using static SanTsgHotelBooking.Shared.StaticDetails;

namespace SanTsgHotelBooking.Application.Models.Requests
{
    public class ApiRequest
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; } = null!;
        public object Data { get; set; }
        public string AccessToken { get; set; }
    }
}
