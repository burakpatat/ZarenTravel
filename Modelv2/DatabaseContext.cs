using Microsoft.EntityFrameworkCore;

namespace CoreWebApi.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Accommodation> Accommodation { get; set; }

public DbSet<AccommodationExtras> AccommodationExtras { get; set; }

public DbSet<Agency> Agency { get; set; }

public DbSet<AgencyGroup> AgencyGroup { get; set; }

public DbSet<AgentInformation> AgentInformation { get; set; }

public DbSet<Air> Air { get; set; }

public DbSet<AirExtras> AirExtras { get; set; }

public DbSet<Airline> Airline { get; set; }

public DbSet<Airport> Airport { get; set; }

public DbSet<AirSegments> AirSegments { get; set; }

public DbSet<Broker> Broker { get; set; }

public DbSet<carrent> carrent { get; set; }

public DbSet<CarRental> CarRental { get; set; }

public DbSet<CarType> CarType { get; set; }

public DbSet<Chain> Chain { get; set; }

public DbSet<City> City { get; set; }

public DbSet<Company> Company { get; set; }

public DbSet<CompanyCustomFields> CompanyCustomFields { get; set; }

public DbSet<CompanyDivisions> CompanyDivisions { get; set; }

public DbSet<CompanyGroup> CompanyGroup { get; set; }

public DbSet<Country> Country { get; set; }

public DbSet<Currency> Currency { get; set; }

public DbSet<CustomerInformation> CustomerInformation { get; set; }

public DbSet<ExchangeRates> ExchangeRates { get; set; }

public DbSet<ExtrasType> ExtrasType { get; set; }

public DbSet<FieldsType> FieldsType { get; set; }

public DbSet<GDS> GDS { get; set; }

public DbSet<Hotel> Hotel { get; set; }

public DbSet<HotelCodes> HotelCodes { get; set; }

public DbSet<IndustrySegment> IndustrySegment { get; set; }

public DbSet<Languages> Languages { get; set; }

public DbSet<Passenger> Passenger { get; set; }

public DbSet<PassengerInformation> PassengerInformation { get; set; }

public DbSet<PCC> PCC { get; set; }

public DbSet<PNR> PNR { get; set; }

public DbSet<PNRCustomFields> PNRCustomFields { get; set; }

public DbSet<ReservationInformation> ReservationInformation { get; set; }

public DbSet<RoomType> RoomType { get; set; }

public DbSet<SegmentInformation> SegmentInformation { get; set; }

public DbSet<Terminal> Terminal { get; set; }


    }
}