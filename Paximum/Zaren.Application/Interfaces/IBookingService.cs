using Zaren.Domain.Booking;
using Zaren.Shared.BookingModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Zaren.Application.Services.Interfaces
{
    public interface IBookingService
    {
        string tokne { get; set; }

        Task<Root> BeginTransaction(string offerid, string currency, string culture);
        Task<string> CommitReservation(string transactid);
        Task<ReservationDetailDTO> FullBooking(string offerId, string currency, string culture, List<Domain.SetReservation.Traveller> manyt);
        Task<ReservationDetailDTO> GetReservationDetails(string reservationid);
        Task<string> SetReservation(Root ob, List<Domain.SetReservation.Traveller> manyt);
    }
}