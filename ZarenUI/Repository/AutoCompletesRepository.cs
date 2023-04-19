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
using Newtonsoft.Json;
using Microsoft.Extensions.Caching.Distributed;

public class AutoCompletesRepository : IDisposable
{
    private SqlConnection connection;
    private readonly string strConnString;
    private IDistributedCache _cache;
    public AutoCompletesRepository(IConfiguration configuration, IDistributedCache cache)
    {
        strConnString = configuration.GetConnectionString("ZarenTravel");
        connection = new SqlConnection(strConnString);
        _cache = cache;
    }
    public long Insert(AutoCompletes AutoCompletes)
    {
        try
        {
            return connection.Insert(AutoCompletes);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool Update(AutoCompletes AutoCompletes)
    {
        try
        {
            return connection.Update(AutoCompletes);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool Delete(AutoCompletes AutoCompletes)
    {
        try
        {
            return connection.Delete<AutoCompletes>(AutoCompletes);
        }
        catch (Exception)
        {
            return false;
        }
    }
    public List<AutoCompletes> GetAll()
    {
        try
        {
            return connection.Query<AutoCompletes>("AutoCompletesGetAll", commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<AutoCompletes> GetByApiId(int ApiId)
    {
        try
        {
            return connection.Query<AutoCompletes>("AutoCompletesGetByApiId", new
            {
                ApiId = ApiId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public AutoCompletes GetByID(int Id)
    {
        try
        {
            return connection.QueryFirstOrDefault<AutoCompletes>("AutoCompletesGetByID", new
            {
                Id = Id
            }, commandType: CommandType.StoredProcedure);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<AutoCompletes> GetByLanguageId(int LanguageId)
    {
        try
        {
            return connection.Query<AutoCompletes>("AutoCompletesGetByLanguageId", new
            {
                LanguageId = LanguageId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<AutoCompletes> GetByName(string Name)
    {
        try
        {
            return connection.Query<AutoCompletes>("AutoCompletesGetByName", new
            {
                Name = Name
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<AutoCompletes> GetByNameForLike(string Name, int topCount)
    {
        try
        {
            return connection.Query<AutoCompletes>("AutoCompletesGetByNameForLike", new
            {
                Name = Name
,
                topCount = topCount
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<AutoCompletes> GetBySystemId(string SystemId)
    {
        try
        {
            return connection.Query<AutoCompletes>("AutoCompletesGetBySystemId", new
            {
                SystemId = SystemId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<AutoCompletes> GetBySystemType(string SystemType)
    {
        try
        {
            return connection.Query<AutoCompletes>("AutoCompletesGetBySystemType", new
            {
                SystemType = SystemType
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<AutoCompletes> GetByType(int Type)
    {
        try
        {
            return connection.Query<AutoCompletes>("AutoCompletesGetByType", new
            {
                Type = Type
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public List<AutoCompletes> GetAllByCache()
    {
        try
        {
            var encKey = "AutoCompletesGetAllByCache";
            if (_cache.GetString(encKey) == null)
            {
                var list = connection.Query<AutoCompletes>("AutoCompletesGetAll", commandType: CommandType.StoredProcedure).ToList();
                _cache.SetString(encKey, list.ToJson());
                return list;
            }
            else
            {
                var existingList = JsonConvert.DeserializeObject<List<AutoCompletes>>(_cache.GetString(encKey));
                return existingList;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public List<Languages> GetAllLanguagesByCache()
    {
        try
        {
            var encKey = "LanguagesGetAllByCache";
            if (_cache.GetString(encKey) == null)
            {
                var list = connection.Query<Languages>("LanguagesGetAll", commandType: CommandType.StoredProcedure).ToList();
                _cache.SetString(encKey, list.ToJson());
                return list;
            }
            else
            {
                var existingList = JsonConvert.DeserializeObject<List<Languages>>(_cache.GetString(encKey));
                return existingList;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public List<Currencies> GetAllCurrenciesByCache()
    {
        try
        {
            var encKey = "CurrenciesGetAllByCache";
            if (_cache.GetString(encKey) == null)
            {
                var list = connection.Query<Currencies>("CurrenciesGetAll", commandType: CommandType.StoredProcedure).ToList();
                _cache.SetString(encKey, list.ToJson());
                return list;
            }
            else
            {
                var existingList = JsonConvert.DeserializeObject<List<Currencies>>(_cache.GetString(encKey));
                return existingList;
            }
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
