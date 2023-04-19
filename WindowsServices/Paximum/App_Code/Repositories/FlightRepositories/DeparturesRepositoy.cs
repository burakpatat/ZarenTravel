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
public class DeparturesRepository : IDisposable
{
    private SqlConnection connection;
    private readonly string strConnString;
    public DeparturesRepository()
    {
        strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
        connection = new SqlConnection(strConnString);
    }
    public long Insert( Departures DeparturesArrivals)
    {
        try
        {
            return connection.Insert(DeparturesArrivals);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool Update( Departures DeparturesArrivals)
    {
        try
        {
            return connection.Update(DeparturesArrivals);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool Delete( Departures DeparturesArrivals)
    {
        try
        {
            return connection.Delete<Departures>(DeparturesArrivals);
        }
        catch (Exception)
        {
            return false;
        }
    }
    public List<Departures> GetAll()
    {
        try
        {
            return connection.Query<Departures>("DeparturesArrivalsGetAll", commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Departures> GetByAirPortsId(int AirPortsId)
    {
        try
        {
            return connection.Query<Departures>("DeparturesArrivalsGetByAirPortsId", new
            {
                AirPortsId = AirPortsId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Departures> GetByApiId(int ApiId)
    {
        try
        {
            return connection.Query<Departures>("DeparturesArrivalsGetByApiId", new
            {
                ApiId = ApiId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Departures> GetByCityId(int CityId)
    {
        try
        {
            return connection.Query<Departures>("DeparturesArrivalsGetByCityId", new
            {
                CityId = CityId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Departures> GetByCountryId(int CountryId)
    {
        try
        {
            return connection.Query<Departures>("DeparturesArrivalsGetByCountryId", new
            {
                CountryId = CountryId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Departures> GetByCreatedBy(int CreatedBy)
    {
        try
        {
            return connection.Query<Departures>("DeparturesArrivalsGetByCreatedBy", new
            {
                CreatedBy = CreatedBy
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Departures> GetByCreatedDate(DateTime CreatedDate)
    {
        try
        {
            return connection.Query<Departures>("DeparturesArrivalsGetByCreatedDate", new
            {
                CreatedDate = CreatedDate
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Departures> GetByDate(DateTime Date)
    {
        try
        {
            return connection.Query<Departures>("DeparturesArrivalsGetByDate", new
            {
                Date = Date
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Departures> GetByGeoLocationId(int GeoLocationId)
    {
        try
        {
            return connection.Query<Departures>("DeparturesArrivalsGetByGeoLocationId", new
            {
                GeoLocationId = GeoLocationId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public  Departures GetByID(int Id)
    {
        try
        {
            return connection.QueryFirstOrDefault<Departures>("DeparturesArrivalsGetByID", new
            {
                Id = Id
            }, commandType: CommandType.StoredProcedure);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Departures> GetByLanguageId(int LanguageId)
    {
        try
        {
            return connection.Query<Departures>("DeparturesArrivalsGetByLanguageId", new
            {
                LanguageId = LanguageId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Departures> GetBySystemId(string SystemId)
    {
        try
        {
            return connection.Query<Departures>("DeparturesArrivalsGetBySystemId", new
            {
                SystemId = SystemId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Departures> GetCreatedDateBetween(DateTime CreatedDateStart, DateTime CreatedDateEnd)
    {
        try
        {
            return connection.Query<Departures>("DeparturesArrivalsGetCreatedDateBetween", new
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
    public List<Departures> GetDateBetween(DateTime DateStart, DateTime DateEnd)
    {
        try
        {
            return connection.Query<Departures>("DeparturesArrivalsGetDateBetween", new
            {
                DateStart = DateStart
,
                DateEnd = DateEnd
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
