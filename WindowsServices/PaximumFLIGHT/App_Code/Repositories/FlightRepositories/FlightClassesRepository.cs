using System;
using System.Linq;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;
using Model.Concrete;
using Dapper.Contrib.Extensions;
public class FlightClassesRepository : IDisposable
{
    private SqlConnection connection;
    private readonly string strConnString;
    public FlightClassesRepository()
    {
        strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
        connection = new SqlConnection(strConnString);
    }
    public long Insert(FlightClasses FlightClasses)
    {
        try
        {
            return connection.Insert(FlightClasses);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool Update(FlightClasses FlightClasses)
    {
        try
        {
            return connection.Update(FlightClasses);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool Delete(FlightClasses FlightClasses)
    {
        try
        {
            return connection.Delete<FlightClasses>(FlightClasses);
        }
        catch (Exception)
        {
            return false;
        }
    }
    public List<FlightClasses> GetAll()
    {
        try
        {
            return connection.Query<FlightClasses>("FlightClassesGetAll", commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<FlightClasses> GetByApiId(int ApiId)
    {
        try
        {
            return connection.Query<FlightClasses>("FlightClassesGetByApiId", new
            {
                ApiId = ApiId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<FlightClasses> GetByCode(string Code)
    {
        try
        {
            return connection.Query<FlightClasses>("FlightClassesGetByCode", new
            {
                Code = Code
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<FlightClasses> GetByCreatedBy(int CreatedBy)
    {
        try
        {
            return connection.Query<FlightClasses>("FlightClassesGetByCreatedBy", new
            {
                CreatedBy = CreatedBy
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<FlightClasses> GetByCreatedDate(DateTime CreatedDate)
    {
        try
        {
            return connection.Query<FlightClasses>("FlightClassesGetByCreatedDate", new
            {
                CreatedDate = CreatedDate
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<FlightClasses> GetByFlightOffersId(int FlightOffersId)
    {
        try
        {
            return connection.Query<FlightClasses>("FlightClassesGetByFlightOffersId", new
            {
                FlightOffersId = FlightOffersId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public FlightClasses GetByID(int Id)
    {
        try
        {
            return connection.QueryFirstOrDefault<FlightClasses>("FlightClassesGetByID", new
            {
                Id = Id
            }, commandType: CommandType.StoredProcedure);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<FlightClasses> GetByLanguageId(int LanguageId)
    {
        try
        {
            return connection.Query<FlightClasses>("FlightClassesGetByLanguageId", new
            {
                LanguageId = LanguageId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<FlightClasses> GetByName(string Name)
    {
        try
        {
            return connection.Query<FlightClasses>("FlightClassesGetByName", new
            {
                Name = Name
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<FlightClasses> GetByNameAndCode(string Name, string code)
    {
        try
        {
            return connection.Query<FlightClasses>("FlightClassesGetByNameAndCode", new
            {
                Name = Name,
                Code = code
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<FlightClasses> GetByOffersId(int OffersId)
    {
        try
        {
            return connection.Query<FlightClasses>("FlightClassesGetByOffersId", new
            {
                OffersId = OffersId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<FlightClasses> GetBySystemId(string SystemId)
    {
        try
        {
            return connection.Query<FlightClasses>("FlightClassesGetBySystemId", new
            {
                SystemId = SystemId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<FlightClasses> GetByType(int Type)
    {
        try
        {
            return connection.Query<FlightClasses>("FlightClassesGetByType", new
            {
                Type = Type
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<FlightClasses> GetCreatedDateBetween(DateTime CreatedDateStart, DateTime CreatedDateEnd)
    {
        try
        {
            return connection.Query<FlightClasses>("FlightClassesGetCreatedDateBetween", new
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
