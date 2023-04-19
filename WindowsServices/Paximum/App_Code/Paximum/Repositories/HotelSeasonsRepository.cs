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
public class HotelSeasonsRepository : IDisposable
{
    private SqlConnection connection;
    private readonly string strConnString;
    public HotelSeasonsRepository()
    {
        strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
        connection = new SqlConnection(strConnString);
    }
    public long Insert(HotelSeasons HotelSeasons)
    {
        try
        {
            return connection.Insert(HotelSeasons);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public long SelectedInsert(HotelSelectedSeasons HotelSelectedSeasons)
    {
        try
        {
            return connection.Insert(HotelSelectedSeasons);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public HotelSelectedSeasons GetByHotelIdAndSeasonId(int HotelId, int SeasonId)
    {
        try
        {
            return connection.QueryFirstOrDefault<HotelSelectedSeasons>("select top 1 * from HotelSelectedSeasons where HotelId="+HotelId+" and SeasonId="+ SeasonId + "");

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool Update(HotelSeasons HotelSeasons)
    {
        try
        {
            return connection.Update(HotelSeasons);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool Delete(HotelSeasons HotelSeasons)
    {
        try
        {
            return connection.Delete<HotelSeasons>(HotelSeasons);
        }
        catch (Exception)
        {
            return false;
        }
    }
    public List<HotelSeasons> GetAll()
    {
        try
        {
            return connection.Query<HotelSeasons>("HotelSeasonsGetAll", commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<HotelSeasons> GetByAgencyId(int AgencyId)
    {
        try
        {
            return connection.Query<HotelSeasons>("HotelSeasonsGetByAgencyId", new
            {
                AgencyId = AgencyId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<HotelSeasons> GetByApiId(int ApiId)
    {
        try
        {
            return connection.Query<HotelSeasons>("HotelSeasonsGetByApiId", new
            {
                ApiId = ApiId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<HotelSeasons> GetByCreatedBy(int CreatedBy)
    {
        try
        {
            return connection.Query<HotelSeasons>("HotelSeasonsGetByCreatedBy", new
            {
                CreatedBy = CreatedBy
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<HotelSeasons> GetByCreatedDate(DateTime CreatedDate)
    {
        try
        {
            return connection.Query<HotelSeasons>("HotelSeasonsGetByCreatedDate", new
            {
                CreatedDate = CreatedDate
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<HotelSeasons> GetByHotelId(int HotelId)
    {
        try
        {
            return connection.Query<HotelSeasons>("HotelSeasonsGetByHotelId", new
            {
                HotelId = HotelId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public HotelSeasons GetByName(string    Name)
    {
        try
        {
            return connection.QueryFirstOrDefault<HotelSeasons>("HotelSeasonsGetByName", new
            {
                Name = Name
            }, commandType: CommandType.StoredProcedure);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public HotelSeasons GetByID(int Id)
    {
        try
        {
            return connection.QueryFirstOrDefault<HotelSeasons>("HotelSeasonsGetByID", new
            {
                Id = Id
            }, commandType: CommandType.StoredProcedure);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<HotelSeasons> GetByLanguageId(int LanguageId)
    {
        try
        {
            return connection.Query<HotelSeasons>("HotelSeasonsGetByLanguageId", new
            {
                LanguageId = LanguageId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<HotelSeasons> GetByMicroSiteId(int MicroSiteId)
    {
        try
        {
            return connection.Query<HotelSeasons>("HotelSeasonsGetByMicroSiteId", new
            {
                MicroSiteId = MicroSiteId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<HotelSeasons> GetBySeasonId(int SeasonId)
    {
        try
        {
            return connection.Query<HotelSeasons>("HotelSeasonsGetBySeasonId", new
            {
                SeasonId = SeasonId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<HotelSeasons> GetBySystemId(string SystemId)
    {
        try
        {
            return connection.Query<HotelSeasons>("HotelSeasonsGetBySystemId", new
            {
                SystemId = SystemId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<HotelSeasons> GetCreatedDateBetween(DateTime CreatedDateStart, DateTime CreatedDateEnd)
    {
        try
        {
            return connection.Query<HotelSeasons>("HotelSeasonsGetCreatedDateBetween", new
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
