using System;
using System.Linq;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading.Tasks;
using Dapper;
using Model.Concrete;
using Dapper.Contrib.Extensions;
public class OffersRepository : IDisposable
{
    private SqlConnection connection;
    private readonly string strConnString;
    public OffersRepository()
    {
        strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
        connection = new SqlConnection(strConnString);
    }
    public long Insert(Offers Offers)
    {
        try
        {
            return connection.Insert(Offers);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool Update(Offers Offers)
    {
        try
        {
            return connection.Update(Offers);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool Delete(Offers Offers)
    {
        try
        {
            return connection.Delete<Offers>(Offers);
        }
        catch (Exception)
        {
            return false;
        }
    }
    public List<Offers> GetAll()
    {
        try
        {
            return connection.Query<Offers>("OffersGetAll", commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Offers> GetByAirPortTaxId(int AirPortTaxId)
    {
        try
        {
            return connection.Query<Offers>("OffersGetByAirPortTaxId", new
            {
                AirPortTaxId = AirPortTaxId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Offers> GetByApiId(int ApiId)
    {
        try
        {
            return connection.Query<Offers>("OffersGetByApiId", new
            {
                ApiId = ApiId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Offers> GetByCreatedBy(int CreatedBy)
    {
        try
        {
            return connection.Query<Offers>("OffersGetByCreatedBy", new
            {
                CreatedBy = CreatedBy
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Offers> GetByCreatedDate(DateTime CreatedDate)
    {
        try
        {
            return connection.Query<Offers>("OffersGetByCreatedDate", new
            {
                CreatedDate = CreatedDate
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Offers> GetByExpresOn(string ExpresOn)
    {
        try
        {
            return connection.Query<Offers>("OffersGetByExpresOn", new
            {
                ExpresOn = ExpresOn
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Offers> GetByFlightBrandsId(int FlightBrandsId)
    {
        try
        {
            return connection.Query<Offers>("OffersGetByFlightBrandsId", new
            {
                FlightBrandsId = FlightBrandsId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Offers> GetByFlightFeesId(int FlightFeesId)
    {
        try
        {
            return connection.Query<Offers>("OffersGetByFlightFeesId", new
            {
                FlightFeesId = FlightFeesId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Offers> GetByFlightProvidersId(int FlightProvidersId)
    {
        try
        {
            return connection.Query<Offers>("OffersGetByFlightProvidersId", new
            {
                FlightProvidersId = FlightProvidersId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Offers> GetByFlightsId(int FlightsId)
    {
        try
        {
            return connection.Query<Offers>("OffersGetByFlightsId", new
            {
                FlightsId = FlightsId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Offers> GetByHasBrand(bool HasBrand)
    {
        try
        {
            return connection.Query<Offers>("OffersGetByHasBrand", new
            {
                HasBrand = HasBrand
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public Offers GetByID(int Id)
    {
        try
        {
            return connection.QueryFirstOrDefault<Offers>("OffersGetByID", new
            {
                Id = Id
            }, commandType: CommandType.StoredProcedure);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Offers> GetByIsPackageOffer(bool IsPackageOffer)
    {
        try
        {
            return connection.Query<Offers>("OffersGetByIsPackageOffer", new
            {
                IsPackageOffer = IsPackageOffer
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Offers> GetByLanguageId(int LanguageId)
    {
        try
        {
            return connection.Query<Offers>("OffersGetByLanguageId", new
            {
                LanguageId = LanguageId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Offers> GetByOfferId(string OfferId)
    {
        try
        {
            return connection.Query<Offers>("OffersGetByOfferId", new
            {
                OfferId = OfferId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Offers> GetByPriceId(int PriceId)
    {
        try
        {
            return connection.Query<Offers>("OffersGetByPriceId", new
            {
                PriceId = PriceId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Offers> GetByProvider(int Provider)
    {
        try
        {
            return connection.Query<Offers>("OffersGetByProvider", new
            {
                Provider = Provider
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Offers> GetByReservableInfo(bool ReservableInfo)
    {
        try
        {
            return connection.Query<Offers>("OffersGetByReservableInfo", new
            {
                ReservableInfo = ReservableInfo
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Offers> GetByRoute(int Route)
    {
        try
        {
            return connection.Query<Offers>("OffersGetByRoute", new
            {
                Route = Route
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Offers> GetBySeatInfosId(int SeatInfosId)
    {
        try
        {
            return connection.Query<Offers>("OffersGetBySeatInfosId", new
            {
                SeatInfosId = SeatInfosId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Offers> GetBySegmentNumber(int SegmentNumber)
    {
        try
        {
            return connection.Query<Offers>("OffersGetBySegmentNumber", new
            {
                SegmentNumber = SegmentNumber
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Offers> GetByServiceFeesId(int ServiceFeesId)
    {
        try
        {
            return connection.Query<Offers>("OffersGetByServiceFeesId", new
            {
                ServiceFeesId = ServiceFeesId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Offers> GetBySingleAdultPrice(double SingleAdultPrice)
    {
        try
        {
            return connection.Query<Offers>("OffersGetBySingleAdultPrice", new
            {
                SingleAdultPrice = SingleAdultPrice
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Offers> GetBySingleAdultPriceCurrencyId(int SingleAdultPriceCurrencyId)
    {
        try
        {
            return connection.Query<Offers>("OffersGetBySingleAdultPriceCurrencyId", new
            {
                SingleAdultPriceCurrencyId = SingleAdultPriceCurrencyId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Offers> GetBySystemId(string SystemId)
    {
        try
        {
            return connection.Query<Offers>("OffersGetBySystemId", new
            {
                SystemId = SystemId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Offers> GetCreatedDateBetween(DateTime CreatedDateStart, DateTime CreatedDateEnd)
    {
        try
        {
            return connection.Query<Offers>("OffersGetCreatedDateBetween", new
            {
                CreatedDateStart = CreatedDateStart
,
                CreatedDateEnd = CreatedDateEnd
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
