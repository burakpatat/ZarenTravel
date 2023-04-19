using DataLayer.BusinessLayer;
using DataLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DataLayer
{
    public class DataBase
    {
        private static string connectionString = "";
		
		#region PrivateProperties
		
/// <summary>
/// AgenciesDB
/// </summary>
private static AgenciesDB _agencies;


/// <summary>
/// BoardTypeLanguagesDB
/// </summary>
private static BoardTypeLanguagesDB _boardTypeLanguages;


/// <summary>
/// BoardTypesDB
/// </summary>
private static BoardTypesDB _boardTypes;


/// <summary>
/// BookingDealsDB
/// </summary>
private static BookingDealsDB _bookingDeals;


/// <summary>
/// BookingRoomsDB
/// </summary>
private static BookingRoomsDB _bookingRooms;


/// <summary>
/// BookingsDB
/// </summary>
private static BookingsDB _bookings;


/// <summary>
/// BuyRoomsDB
/// </summary>
private static BuyRoomsDB _buyRooms;


/// <summary>
/// CancelationLanguagesDB
/// </summary>
private static CancelationLanguagesDB _cancelationLanguages;


/// <summary>
/// CancellationRulesDB
/// </summary>
private static CancellationRulesDB _cancellationRules;


/// <summary>
/// CancellationSeasonsDB
/// </summary>
private static CancellationSeasonsDB _cancellationSeasons;


/// <summary>
/// CitiesDB
/// </summary>
private static CitiesDB _cities;


/// <summary>
/// ContactsDB
/// </summary>
private static ContactsDB _contacts;


/// <summary>
/// CountriesDB
/// </summary>
private static CountriesDB _countries;


/// <summary>
/// DealsDB
/// </summary>
private static DealsDB _deals;


/// <summary>
/// DealTypeLanguagesDB
/// </summary>
private static DealTypeLanguagesDB _dealTypeLanguages;


/// <summary>
/// DealTypesDB
/// </summary>
private static DealTypesDB _dealTypes;


/// <summary>
/// FacilitiesDB
/// </summary>
private static FacilitiesDB _facilities;


/// <summary>
/// FacilitiesHotelsDB
/// </summary>
private static FacilitiesHotelsDB _facilitiesHotels;


/// <summary>
/// FacilityLanguagesDB
/// </summary>
private static FacilityLanguagesDB _facilityLanguages;


/// <summary>
/// HotelAgencyMarkupsDB
/// </summary>
private static HotelAgencyMarkupsDB _hotelAgencyMarkups;


/// <summary>
/// HotelBuyRoomAllotmentDB
/// </summary>
private static HotelBuyRoomAllotmentDB _hotelBuyRoomAllotment;


/// <summary>
/// HotelBuyRoomsDB
/// </summary>
private static HotelBuyRoomsDB _hotelBuyRooms;


/// <summary>
/// HotelChainsDB
/// </summary>
private static HotelChainsDB _hotelChains;


/// <summary>
/// HotelDescriptionsDB
/// </summary>
private static HotelDescriptionsDB _hotelDescriptions;


/// <summary>
/// HotelPhotoLanguagesDB
/// </summary>
private static HotelPhotoLanguagesDB _hotelPhotoLanguages;


/// <summary>
/// HotelPhotosDB
/// </summary>
private static HotelPhotosDB _hotelPhotos;


/// <summary>
/// HotelRoomDailyPricesDB
/// </summary>
private static HotelRoomDailyPricesDB _hotelRoomDailyPrices;


/// <summary>
/// HotelRoomLanguagesDB
/// </summary>
private static HotelRoomLanguagesDB _hotelRoomLanguages;


/// <summary>
/// HotelRoomsDB
/// </summary>
private static HotelRoomsDB _hotelRooms;


/// <summary>
/// HotelsDB
/// </summary>
private static HotelsDB _hotels;


/// <summary>
/// HotelTypeLanguagesDB
/// </summary>
private static HotelTypeLanguagesDB _hotelTypeLanguages;


/// <summary>
/// HotelTypesDB
/// </summary>
private static HotelTypesDB _hotelTypes;


/// <summary>
/// LanguagesDB
/// </summary>
private static LanguagesDB _languages;


/// <summary>
/// ProvidersDB
/// </summary>
private static ProvidersDB _providers;


/// <summary>
/// RegionsDB
/// </summary>
private static RegionsDB _regions;


/// <summary>
/// RoomsDB
/// </summary>
private static RoomsDB _rooms;


/// <summary>
/// ZonesDB
/// </summary>
private static ZonesDB _zones;


/// <summary>
/// ZonesCitiesDB
/// </summary>
private static ZonesCitiesDB _zonesCities;


		#endregion
		
        static DataBase()
        {
            connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        }
        
		#region PublicProperties
		
/// <summary>
/// AgenciesDB
/// </summary>
public static AgenciesDB AgenciesDB
{
    get
    {
        if (_agencies == null)
        {
            _agencies = new AgenciesDB(connectionString);
        }
        return _agencies;
    }
}


/// <summary>
/// BoardTypeLanguagesDB
/// </summary>
public static BoardTypeLanguagesDB BoardTypeLanguagesDB
{
    get
    {
        if (_boardTypeLanguages == null)
        {
            _boardTypeLanguages = new BoardTypeLanguagesDB(connectionString);
        }
        return _boardTypeLanguages;
    }
}


/// <summary>
/// BoardTypesDB
/// </summary>
public static BoardTypesDB BoardTypesDB
{
    get
    {
        if (_boardTypes == null)
        {
            _boardTypes = new BoardTypesDB(connectionString);
        }
        return _boardTypes;
    }
}


/// <summary>
/// BookingDealsDB
/// </summary>
public static BookingDealsDB BookingDealsDB
{
    get
    {
        if (_bookingDeals == null)
        {
            _bookingDeals = new BookingDealsDB(connectionString);
        }
        return _bookingDeals;
    }
}


/// <summary>
/// BookingRoomsDB
/// </summary>
public static BookingRoomsDB BookingRoomsDB
{
    get
    {
        if (_bookingRooms == null)
        {
            _bookingRooms = new BookingRoomsDB(connectionString);
        }
        return _bookingRooms;
    }
}


/// <summary>
/// BookingsDB
/// </summary>
public static BookingsDB BookingsDB
{
    get
    {
        if (_bookings == null)
        {
            _bookings = new BookingsDB(connectionString);
        }
        return _bookings;
    }
}


/// <summary>
/// BuyRoomsDB
/// </summary>
public static BuyRoomsDB BuyRoomsDB
{
    get
    {
        if (_buyRooms == null)
        {
            _buyRooms = new BuyRoomsDB(connectionString);
        }
        return _buyRooms;
    }
}


/// <summary>
/// CancelationLanguagesDB
/// </summary>
public static CancelationLanguagesDB CancelationLanguagesDB
{
    get
    {
        if (_cancelationLanguages == null)
        {
            _cancelationLanguages = new CancelationLanguagesDB(connectionString);
        }
        return _cancelationLanguages;
    }
}


/// <summary>
/// CancellationRulesDB
/// </summary>
public static CancellationRulesDB CancellationRulesDB
{
    get
    {
        if (_cancellationRules == null)
        {
            _cancellationRules = new CancellationRulesDB(connectionString);
        }
        return _cancellationRules;
    }
}


/// <summary>
/// CancellationSeasonsDB
/// </summary>
public static CancellationSeasonsDB CancellationSeasonsDB
{
    get
    {
        if (_cancellationSeasons == null)
        {
            _cancellationSeasons = new CancellationSeasonsDB(connectionString);
        }
        return _cancellationSeasons;
    }
}


/// <summary>
/// CitiesDB
/// </summary>
public static CitiesDB CitiesDB
{
    get
    {
        if (_cities == null)
        {
            _cities = new CitiesDB(connectionString);
        }
        return _cities;
    }
}


/// <summary>
/// ContactsDB
/// </summary>
public static ContactsDB ContactsDB
{
    get
    {
        if (_contacts == null)
        {
            _contacts = new ContactsDB(connectionString);
        }
        return _contacts;
    }
}


/// <summary>
/// CountriesDB
/// </summary>
public static CountriesDB CountriesDB
{
    get
    {
        if (_countries == null)
        {
            _countries = new CountriesDB(connectionString);
        }
        return _countries;
    }
}


/// <summary>
/// DealsDB
/// </summary>
public static DealsDB DealsDB
{
    get
    {
        if (_deals == null)
        {
            _deals = new DealsDB(connectionString);
        }
        return _deals;
    }
}


/// <summary>
/// DealTypeLanguagesDB
/// </summary>
public static DealTypeLanguagesDB DealTypeLanguagesDB
{
    get
    {
        if (_dealTypeLanguages == null)
        {
            _dealTypeLanguages = new DealTypeLanguagesDB(connectionString);
        }
        return _dealTypeLanguages;
    }
}


/// <summary>
/// DealTypesDB
/// </summary>
public static DealTypesDB DealTypesDB
{
    get
    {
        if (_dealTypes == null)
        {
            _dealTypes = new DealTypesDB(connectionString);
        }
        return _dealTypes;
    }
}


/// <summary>
/// FacilitiesDB
/// </summary>
public static FacilitiesDB FacilitiesDB
{
    get
    {
        if (_facilities == null)
        {
            _facilities = new FacilitiesDB(connectionString);
        }
        return _facilities;
    }
}


/// <summary>
/// FacilitiesHotelsDB
/// </summary>
public static FacilitiesHotelsDB FacilitiesHotelsDB
{
    get
    {
        if (_facilitiesHotels == null)
        {
            _facilitiesHotels = new FacilitiesHotelsDB(connectionString);
        }
        return _facilitiesHotels;
    }
}


/// <summary>
/// FacilityLanguagesDB
/// </summary>
public static FacilityLanguagesDB FacilityLanguagesDB
{
    get
    {
        if (_facilityLanguages == null)
        {
            _facilityLanguages = new FacilityLanguagesDB(connectionString);
        }
        return _facilityLanguages;
    }
}


/// <summary>
/// HotelAgencyMarkupsDB
/// </summary>
public static HotelAgencyMarkupsDB HotelAgencyMarkupsDB
{
    get
    {
        if (_hotelAgencyMarkups == null)
        {
            _hotelAgencyMarkups = new HotelAgencyMarkupsDB(connectionString);
        }
        return _hotelAgencyMarkups;
    }
}


/// <summary>
/// HotelBuyRoomAllotmentDB
/// </summary>
public static HotelBuyRoomAllotmentDB HotelBuyRoomAllotmentDB
{
    get
    {
        if (_hotelBuyRoomAllotment == null)
        {
            _hotelBuyRoomAllotment = new HotelBuyRoomAllotmentDB(connectionString);
        }
        return _hotelBuyRoomAllotment;
    }
}


/// <summary>
/// HotelBuyRoomsDB
/// </summary>
public static HotelBuyRoomsDB HotelBuyRoomsDB
{
    get
    {
        if (_hotelBuyRooms == null)
        {
            _hotelBuyRooms = new HotelBuyRoomsDB(connectionString);
        }
        return _hotelBuyRooms;
    }
}


/// <summary>
/// HotelChainsDB
/// </summary>
public static HotelChainsDB HotelChainsDB
{
    get
    {
        if (_hotelChains == null)
        {
            _hotelChains = new HotelChainsDB(connectionString);
        }
        return _hotelChains;
    }
}


/// <summary>
/// HotelDescriptionsDB
/// </summary>
public static HotelDescriptionsDB HotelDescriptionsDB
{
    get
    {
        if (_hotelDescriptions == null)
        {
            _hotelDescriptions = new HotelDescriptionsDB(connectionString);
        }
        return _hotelDescriptions;
    }
}


/// <summary>
/// HotelPhotoLanguagesDB
/// </summary>
public static HotelPhotoLanguagesDB HotelPhotoLanguagesDB
{
    get
    {
        if (_hotelPhotoLanguages == null)
        {
            _hotelPhotoLanguages = new HotelPhotoLanguagesDB(connectionString);
        }
        return _hotelPhotoLanguages;
    }
}


/// <summary>
/// HotelPhotosDB
/// </summary>
public static HotelPhotosDB HotelPhotosDB
{
    get
    {
        if (_hotelPhotos == null)
        {
            _hotelPhotos = new HotelPhotosDB(connectionString);
        }
        return _hotelPhotos;
    }
}


/// <summary>
/// HotelRoomDailyPricesDB
/// </summary>
public static HotelRoomDailyPricesDB HotelRoomDailyPricesDB
{
    get
    {
        if (_hotelRoomDailyPrices == null)
        {
            _hotelRoomDailyPrices = new HotelRoomDailyPricesDB(connectionString);
        }
        return _hotelRoomDailyPrices;
    }
}


/// <summary>
/// HotelRoomLanguagesDB
/// </summary>
public static HotelRoomLanguagesDB HotelRoomLanguagesDB
{
    get
    {
        if (_hotelRoomLanguages == null)
        {
            _hotelRoomLanguages = new HotelRoomLanguagesDB(connectionString);
        }
        return _hotelRoomLanguages;
    }
}


/// <summary>
/// HotelRoomsDB
/// </summary>
public static HotelRoomsDB HotelRoomsDB
{
    get
    {
        if (_hotelRooms == null)
        {
            _hotelRooms = new HotelRoomsDB(connectionString);
        }
        return _hotelRooms;
    }
}


/// <summary>
/// HotelsDB
/// </summary>
public static HotelsDB HotelsDB
{
    get
    {
        if (_hotels == null)
        {
            _hotels = new HotelsDB(connectionString);
        }
        return _hotels;
    }
}


/// <summary>
/// HotelTypeLanguagesDB
/// </summary>
public static HotelTypeLanguagesDB HotelTypeLanguagesDB
{
    get
    {
        if (_hotelTypeLanguages == null)
        {
            _hotelTypeLanguages = new HotelTypeLanguagesDB(connectionString);
        }
        return _hotelTypeLanguages;
    }
}


/// <summary>
/// HotelTypesDB
/// </summary>
public static HotelTypesDB HotelTypesDB
{
    get
    {
        if (_hotelTypes == null)
        {
            _hotelTypes = new HotelTypesDB(connectionString);
        }
        return _hotelTypes;
    }
}


/// <summary>
/// LanguagesDB
/// </summary>
public static LanguagesDB LanguagesDB
{
    get
    {
        if (_languages == null)
        {
            _languages = new LanguagesDB(connectionString);
        }
        return _languages;
    }
}


/// <summary>
/// ProvidersDB
/// </summary>
public static ProvidersDB ProvidersDB
{
    get
    {
        if (_providers == null)
        {
            _providers = new ProvidersDB(connectionString);
        }
        return _providers;
    }
}


/// <summary>
/// RegionsDB
/// </summary>
public static RegionsDB RegionsDB
{
    get
    {
        if (_regions == null)
        {
            _regions = new RegionsDB(connectionString);
        }
        return _regions;
    }
}


/// <summary>
/// RoomsDB
/// </summary>
public static RoomsDB RoomsDB
{
    get
    {
        if (_rooms == null)
        {
            _rooms = new RoomsDB(connectionString);
        }
        return _rooms;
    }
}


/// <summary>
/// ZonesDB
/// </summary>
public static ZonesDB ZonesDB
{
    get
    {
        if (_zones == null)
        {
            _zones = new ZonesDB(connectionString);
        }
        return _zones;
    }
}


/// <summary>
/// ZonesCitiesDB
/// </summary>
public static ZonesCitiesDB ZonesCitiesDB
{
    get
    {
        if (_zonesCities == null)
        {
            _zonesCities = new ZonesCitiesDB(connectionString);
        }
        return _zonesCities;
    }
}


		#endregion
    }
}
