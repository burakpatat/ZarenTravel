using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paximum.Enums
{
    public class Cultures
    {
        [JsonProperty("FIELD1")]
        public string CountryName { get; set; }

        [JsonProperty("FIELD2")]
        public string CountryCode { get; set; }
    }
}
public enum ApiResponseTypes
{
    Season = 1,
    Rooms = 2,
    Boards = 3
}
public enum AutoCompleteTypes
{
    City = 1,
    Hotel = 2,
    Airport = 3,
    Town = 4,
    Vilage = 5,
    Excursion = 6,
    Category = 7,
    Country = 8,
    Transfer = 9,
    ExcursionPackage = 10,
    State = 11

}
public enum ApiType
{

    Paximum = 1,
    TravelPort = 2
}
//public enum PassengerTypes
//{
//    Adult = 1,
//    Child = 2,
//    Infant = 3,
//    Senior = 4,
//    Student = 5,
//    Young = 6,
//    Military = 7,
//    Teacher = 8
//}
public enum TravellerTypes
{
    Adult = 1,
    Child = 2,
    Infant = 3
}
public enum TravellerTitles
{
    Mr = 1,
    Ms = 2,
    Mrs = 3,
    Miss = 4,
    Child = 5,
    Infant = 6
}
public enum ProductTypes
{
    HolidayPackage = 1,
    Hotel = 2,
    Flight = 3,
    Excursion = 4,
    Transfer = 5,
    Tour = 6,
    Cruise = 7,
    Transport = 8,
    Ferry = 9,
    Visa = 10,
    AdditionalService = 11,
    Insurance = 12,
    Dynamic = 13,
    Renting = 14
}
public enum LocationTypes 
{
    Country=1,
    City=2, 
    Town=3,
    Village=4,
    Airport=5
}

