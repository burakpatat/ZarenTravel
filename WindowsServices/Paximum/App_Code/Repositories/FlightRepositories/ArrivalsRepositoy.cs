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
public class ArrivalsRepositoy : IDisposable
{
    private SqlConnection connection;
    private readonly string strConnString;
    public ArrivalsRepositoy()
    {
        strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
        connection = new SqlConnection(strConnString);
    }
    public long Insert(Arrivals DeparturesArrivals)
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
    public bool Update(Arrivals DeparturesArrivals)
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
    public bool Delete(Arrivals DeparturesArrivals)
    {
        try
        {
            return connection.Delete<Arrivals>(DeparturesArrivals);
        }
        catch (Exception)
        {
            return false;
        }
    }
    public List<Arrivals> GetAll()
    {
        try
        {
            return connection.Query<Arrivals>("DeparturesArrivalsGetAll", commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Arrivals> GetByAirPortsId(int AirPortsId)
    {
        try
        {
            return connection.Query<Arrivals>("DeparturesArrivalsGetByAirPortsId", new
            {
                AirPortsId = AirPortsId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Arrivals> GetByApiId(int ApiId)
    {
        try
        {
            return connection.Query<Arrivals>("DeparturesArrivalsGetByApiId", new
            {
                ApiId = ApiId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Arrivals> GetByCityId(int CityId)
    {
        try
        {
            return connection.Query<Arrivals>("DeparturesArrivalsGetByCityId", new
            {
                CityId = CityId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Arrivals> GetByCountryId(int CountryId)
    {
        try
        {
            return connection.Query<Arrivals>("DeparturesArrivalsGetByCountryId", new
            {
                CountryId = CountryId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Arrivals> GetByCreatedBy(int CreatedBy)
    {
        try
        {
            return connection.Query<Arrivals>("DeparturesArrivalsGetByCreatedBy", new
            {
                CreatedBy = CreatedBy
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Arrivals> GetByCreatedDate(DateTime CreatedDate)
    {
        try
        {
            return connection.Query<Arrivals>("DeparturesArrivalsGetByCreatedDate", new
            {
                CreatedDate = CreatedDate
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Arrivals> GetByDate(DateTime Date)
    {
        try
        {
            return connection.Query<Arrivals>("DeparturesArrivalsGetByDate", new
            {
                Date = Date
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Arrivals> GetByGeoLocationId(int GeoLocationId)
    {
        try
        {
            return connection.Query<Arrivals>("DeparturesArrivalsGetByGeoLocationId", new
            {
                GeoLocationId = GeoLocationId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public Arrivals GetByID(int Id)
    {
        try
        {
            return connection.QueryFirstOrDefault<Arrivals>("DeparturesArrivalsGetByID", new
            {
                Id = Id
            }, commandType: CommandType.StoredProcedure);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Arrivals> GetByLanguageId(int LanguageId)
    {
        try
        {
            return connection.Query<Arrivals>("DeparturesArrivalsGetByLanguageId", new
            {
                LanguageId = LanguageId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Arrivals> GetBySystemId(string SystemId)
    {
        try
        {
            return connection.Query<Arrivals>("DeparturesArrivalsGetBySystemId", new
            {   
                SystemId = SystemId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Arrivals> GetCreatedDateBetween(DateTime CreatedDateStart, DateTime CreatedDateEnd)
    {
        try
        {
            return connection.Query<Arrivals>("DeparturesArrivalsGetCreatedDateBetween", new
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
    public List<Arrivals> GetDateBetween(DateTime DateStart, DateTime DateEnd)
    {
        try
        {
            return connection.Query<Arrivals>("DeparturesArrivalsGetDateBetween", new
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
