using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class BookingsGetByPaidStatus
    {
        public int Id { get; set; }

        public int? HotelId { get; set; }

        public int? ProviderId { get; set; }

        public int? AgencyId { get; set; }

        public string Reference { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public DateTime? DateBooked { get; set; }

        public int? Nights { get; set; }

        public int? NumRooms { get; set; }

        public decimal? TotalCost { get; set; }

        public decimal? TotalPrice { get; set; }

        public int? Status { get; set; }

        public int? PaidStatus { get; set; }

        public string ClientTitle { get; set; }

        public string ClientName { get; set; }

        public string ClientSurname { get; set; }

        public string ClientEmail { get; set; }

        public string ClientNotes { get; set; }

        public string ClientAddress { get; set; }

        public string ClientContact { get; set; }

        public int? Adults { get; set; }

        public int? Children { get; set; }

        public int? Infants { get; set; }

        public string ChildrenAges { get; set; }

    }
}