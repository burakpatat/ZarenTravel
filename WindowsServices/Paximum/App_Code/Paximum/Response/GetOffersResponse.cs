using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paximum.Response.Offers
{




    public class GetOffersResponse
    {
        public Header header { get; set; }
        public Body body { get; set; }
    }

    public class Header
    {
        public string requestId { get; set; }
        public bool success { get; set; }
        public DateTime responseTime { get; set; }
        public Message[] messages { get; set; }
    }

    public class Message
    {
        public int id { get; set; }
        public string code { get; set; }
        public int messageType { get; set; }
        public string message { get; set; }
    }

    public class Body
    {
        public Offer[] offers { get; set; }
        public Information information { get; set; }
        public string productId { get; set; }
        public Roominfo[] roomInfos { get; set; }
    }

    public class Information
    {
        public int total { get; set; }
    }

    public class Offer
    {
        public int night { get; set; }
        public bool isAvailable { get; set; }
        public int availability { get; set; }
        public Room[] rooms { get; set; }
        public bool isRefundable { get; set; }
        public Cancellationpolicy[] cancellationPolicies { get; set; }
        public Pricebreakdown[] priceBreakdowns { get; set; }
        public DateTime expiresOn { get; set; }
        public string offerId { get; set; }
        public DateTime checkIn { get; set; }
        public Price price { get; set; }
        public bool ownOffer { get; set; }
        public int provider { get; set; }
    }

    public class Price
    {
        public float amount { get; set; }
        public string currency { get; set; }
    }

    public class Room
    {
        public string roomId { get; set; }
        public string roomName { get; set; }
        public string boardId { get; set; }
        public string boardName { get; set; }
        public Boardgroup[] boardGroups { get; set; }
        public int stopSaleGuaranteed { get; set; }
        public int stopSaleStandart { get; set; }
        public Traveller[] travellers { get; set; }
        public string roomInfoId { get; set; }
    }

    public class Boardgroup
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Traveller
    {
        public int type { get; set; }
        public int age { get; set; }
        public string nationality { get; set; }
        public int minAge { get; set; }
        public int maxAge { get; set; }
    }

    public class Cancellationpolicy
    {
        public DateTime dueDate { get; set; }
        public Price1 price { get; set; }
        public int provider { get; set; }
    }

    public class Price1
    {
        public float amount { get; set; }
        public string currency { get; set; }
    }

    public class Pricebreakdown
    {
        public int productType { get; set; }
        public Pricebreakdown1[] priceBreakdowns { get; set; }
    }

    public class Pricebreakdown1
    {
        public string roomNumber { get; set; }
        public DateTime date { get; set; }
        public Price2 price { get; set; }
    }

    public class Price2
    {
        public float amount { get; set; }
        public string currency { get; set; }
    }

    public class Roominfo
    {
        public object[] presentations { get; set; }
        public Facility[] facilities { get; set; }
        public Mediafile[] mediaFiles { get; set; }
        public string name { get; set; }
        public string id { get; set; }
    }

    public class Facility
    {
        public string name { get; set; }
    }

    public class Mediafile
    {
        public int fileType { get; set; }
        public string urlFull { get; set; }
    }

}
