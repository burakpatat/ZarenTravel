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
public class AirLinesRepository : IDisposable
{
    private SqlConnection connection;
    private readonly string strConnString;
    public AirLinesRepository()
    {
        strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
        connection = new SqlConnection(strConnString);
    }
    public long Insert(AirLines AirLines)
    {
        try
        {
            return connection.Insert(AirLines);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool Update(AirLines AirLines)
    {
        try
        {
            return connection.Update(AirLines);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool Delete(AirLines AirLines)
    {
        try
        {
            return connection.Delete(AirLines);
        }
        catch (Exception)
        {
            return false;
        }
    }
    public List<AirLines> GetAll()
    {
        try
        {
            return connection.Query<AirLines>("AirLinesGetAll", commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<AirLines> GetByApiId(int ApiId)
    {
        try
        {
            return connection.Query<AirLines>("AirLinesGetByApiId", new
            {
                ApiId = ApiId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<AirLines> GetByCreatedBy(int CreatedBy)
    {
        try
        {
            return connection.Query<AirLines>("AirLinesGetByCreatedBy", new
            {
                CreatedBy = CreatedBy
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<AirLines> GetByCreatedDate(DateTime CreatedDate)
    {
        try
        {
            return connection.Query<AirLines>("AirLinesGetByCreatedDate", new
            {
                CreatedDate = CreatedDate
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public AirLines GetByID(int Id)
    {
        try
        {
            return connection.QueryFirstOrDefault<AirLines>("AirLinesGetByID", new
            {
                Id = Id
            }, commandType: CommandType.StoredProcedure);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<AirLines> GetByInterNationalCode(string InterNationalCode)
    {
        try
        {
            return connection.Query<AirLines>("AirLinesGetByInterNationalCode", new
            {
                InterNationalCode = InterNationalCode
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<AirLines> AirLinesGetByInterNationalIsMarketing(string InterNationalCode,bool IsMarketing)
    {
        try
        {
            return connection.Query<AirLines>("AirLinesGetByInterNationalIsMarketing", new
            {
                InterNationalCode=InterNationalCode,
                IsMarketing = IsMarketing
            },
            commandType: CommandType.StoredProcedure).ToList();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<AirLines> GetByIsMarketing(bool IsMarketing)
    {
        try
        {
            return connection.Query<AirLines>("AirLinesGetByIsMarketing", new
            {
                IsMarketing = IsMarketing
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<AirLines> GetByItemsId(int ItemsId)
    {
        try
        {
            return connection.Query<AirLines>("AirLinesGetByItemsId", new
            {
                ItemsId = ItemsId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<AirLines> GetByLanguageId(int LanguageId)
    {
        try
        {
            return connection.Query<AirLines>("AirLinesGetByLanguageId", new
            {
                LanguageId = LanguageId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<AirLines> GetByLogo(string Logo)
    {
        try
        {
            return connection.Query<AirLines>("AirLinesGetByLogo", new
            {
                Logo = Logo
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<AirLines> GetByLogoFull(string LogoFull)
    {
        try
        {
            return connection.Query<AirLines>("AirLinesGetByLogoFull", new
            {
                LogoFull = LogoFull
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<AirLines> GetByName(string Name)
    {
        try
        {
            return connection.Query<AirLines>("AirLinesGetByName", new
            {
                Name = Name
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<AirLines> GetBySystemId(string SystemId)
    {
        try
        {
            return connection.Query<AirLines>("AirLinesGetBySystemId", new
            {
                SystemId = SystemId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<AirLines> GetByThumbnail(string Thumbnail)
    {
        try
        {
            return connection.Query<AirLines>("AirLinesGetByThumbnail", new
            {
                Thumbnail = Thumbnail
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<AirLines> GetByThumbnailFull(string ThumbnailFull)
    {
        try
        {
            return connection.Query<AirLines>("AirLinesGetByThumbnailFull", new
            {
                ThumbnailFull = ThumbnailFull
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<AirLines> GetCreatedDateBetween(DateTime CreatedDateStart, DateTime CreatedDateEnd)
    {
        try
        {
            return connection.Query<AirLines>("AirLinesGetCreatedDateBetween", new
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
