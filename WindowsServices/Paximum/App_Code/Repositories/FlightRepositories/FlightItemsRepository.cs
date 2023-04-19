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
public class FlightItemsRepository : IDisposable
{
    private SqlConnection connection;
    private readonly string strConnString;
    public FlightItemsRepository()
    {
        strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
        connection = new SqlConnection(strConnString);
    }
    public long Insert(FlightItems FlightItems)
    {
        try
        {
            return connection.Insert(FlightItems);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool Update(FlightItems FlightItems)
    {
        try
        {
            return connection.Update(FlightItems);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool Delete(FlightItems FlightItems)
    {
        try
        {
            return connection.Delete<FlightItems>(FlightItems);
        }
        catch (Exception)
        {
            return false;
        }
    }
    public List<FlightItems> GetAll()
    {
        try
        {
            return connection.Query<FlightItems>("FlightItemsGetAll", commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<FlightItems> GetByAirLinesId(int AirLinesId)
    {
        try
        {
            return connection.Query<FlightItems>("FlightItemsGetByAirLinesId", new
            {
                AirLinesId = AirLinesId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<FlightItems> GetByAirPortsId(int AirPortsId)
    {
        try
        {
            return connection.Query<FlightItems>("FlightItemsGetByAirPortsId", new
            {
                AirPortsId = AirPortsId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<FlightItems> GetByApiId(int ApiId)
    {
        try
        {
            return connection.Query<FlightItems>("FlightItemsGetByApiId", new
            {
                ApiId = ApiId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<FlightItems> GetByCityId(int CityId)
    {
        try
        {
            return connection.Query<FlightItems>("FlightItemsGetByCityId", new
            {
                CityId = CityId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<FlightItems> GetByCreatedBy(int CreatedBy)
    {
        try
        {
            return connection.Query<FlightItems>("FlightItemsGetByCreatedBy", new
            {
                CreatedBy = CreatedBy
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<FlightItems> GetByCreatedDate(DateTime CreatedDate)
    {
        try
        {
            return connection.Query<FlightItems>("FlightItemsGetByCreatedDate", new
            {
                CreatedDate = CreatedDate
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<FlightItems> GetByDayChange(int DayChange)
    {
        try
        {
            return connection.Query<FlightItems>("FlightItemsGetByDayChange", new
            {
                DayChange = DayChange
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    //public List<FlightItems> GetByDeparturesDeparturesArrivalsId(int DeparturesDeparturesArrivalsId)
    //{
    //    try
    //    {
    //        return connection.Query<FlightItems>("FlightItemsGetByDeparturesDeparturesArrivalsId", new
    //        {
    //            DeparturesDeparturesArrivalsId = DeparturesDeparturesArrivalsId
    //        }, commandType: CommandType.StoredProcedure).ToList();

    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}
    public List<FlightItems> GetByDuration(int Duration)
    {
        try
        {
            return connection.Query<FlightItems>("FlightItemsGetByDuration", new
            {
                Duration = Duration
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<FlightItems> GetByFlightClassesId(int FlightClassesId)
    {
        try
        {
            return connection.Query<FlightItems>("FlightItemsGetByFlightClassesId", new
            {
                FlightClassesId = FlightClassesId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<FlightItems> GetByFlightDate(DateTime FlightDate)
    {
        try
        {
            return connection.Query<FlightItems>("FlightItemsGetByFlightDate", new
            {
                FlightDate = FlightDate
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<FlightItems> GetByFlightNo(string FlightNo)
    {
        try
        {
            return connection.Query<FlightItems>("FlightItemsGetByFlightNo", new
            {
                FlightNo = FlightNo
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<FlightItems> GetByFlightsId(int FlightsId)
    {
        try
        {
            return connection.Query<FlightItems>("FlightItemsGetByFlightsId", new
            {
                FlightsId = FlightsId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<FlightItems> GetByFlightType(int FlightType)
    {
        try
        {
            return connection.Query<FlightItems>("FlightItemsGetByFlightType", new
            {
                FlightType = FlightType
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public FlightItems GetByID(int Id)
    {
        try
        {
            return connection.QueryFirstOrDefault<FlightItems>("FlightItemsGetByID", new
            {
                Id = Id
            }, commandType: CommandType.StoredProcedure);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<FlightItems> GetByLanguageId(int LanguageId)
    {
        try
        {
            return connection.Query<FlightItems>("FlightItemsGetByLanguageId", new
            {
                LanguageId = LanguageId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<FlightItems> GetByMarketingAirlines(int MarketingAirlines)
    {
        try
        {
            return connection.Query<FlightItems>("FlightItemsGetByMarketingAirlines", new
            {
                MarketingAirlines = MarketingAirlines
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<FlightItems> GetByPnlName(string PnlName)
    {
        try
        {
            return connection.Query<FlightItems>("FlightItemsGetByPnlName", new
            {
                PnlName = PnlName
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<FlightItems> GetByRoute(int Route)
    {
        try
        {
            return connection.Query<FlightItems>("FlightItemsGetByRoute", new
            {
                Route = Route
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<FlightItems> GetBySegmentNumber(int SegmentNumber)
    {
        try
        {
            return connection.Query<FlightItems>("FlightItemsGetBySegmentNumber", new
            {
                SegmentNumber = SegmentNumber
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<FlightItems> GetByStopCount(int StopCount)
    {
        try
        {
            return connection.Query<FlightItems>("FlightItemsGetByStopCount", new
            {
                StopCount = StopCount
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<FlightItems> GetBySystemId(string SystemId)
    {
        try
        {
            return connection.Query<FlightItems>("FlightItemsGetBySystemId", new
            {
                SystemId = SystemId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<FlightItems> GetCreatedDateBetween(DateTime CreatedDateStart, DateTime CreatedDateEnd)
    {
        try
        {
            return connection.Query<FlightItems>("FlightItemsGetCreatedDateBetween", new
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
    public List<FlightItems> GetFlightDateBetween(DateTime FlightDateStart, DateTime FlightDateEnd)
    {
        try
        {
            return connection.Query<FlightItems>("FlightItemsGetFlightDateBetween", new
            {
                FlightDateStart = FlightDateStart
,
                FlightDateEnd = FlightDateEnd
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
