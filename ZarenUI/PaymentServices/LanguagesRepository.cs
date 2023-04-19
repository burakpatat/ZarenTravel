using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Dapper.Contrib.Extensions;
using Model.Concrete;

public class LanguagesRepository : IDisposable
{
	private SqlConnection connection;

	private readonly string strConnString; 
    public LanguagesRepository(IConfiguration configuration)
    {
        strConnString = configuration.GetConnectionString("ZarenTravel");
        connection = new SqlConnection(strConnString);
    }
  

	public long Insert(Languages Languages)
	{
		try
		{
			return SqlMapperExtensions.Insert<Languages>((IDbConnection)connection, Languages, (IDbTransaction)null, (int?)null);
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public bool Update(Languages Languages)
	{
		try
		{
			return SqlMapperExtensions.Update<Languages>((IDbConnection)connection, Languages, (IDbTransaction)null, (int?)null);
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public bool Delete(Languages Languages)
	{
		try
		{
			return SqlMapperExtensions.Delete<Languages>((IDbConnection)connection, Languages, (IDbTransaction)null, (int?)null);
		}
		catch (Exception)
		{
			return false;
		}
	}

	public List<Languages> GetAll()
	{
		try
		{
			SqlConnection sqlConnection = connection;
			CommandType? commandType = CommandType.StoredProcedure;
			return SqlMapper.Query<Languages>((IDbConnection)sqlConnection, "LanguagesGetAll", (object)null, (IDbTransaction)null, true, (int?)null, commandType).ToList();
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public Languages GetByID(int Id)
	{
		try
		{
			SqlConnection sqlConnection = connection;
			var anon = new { Id };
			CommandType? commandType = CommandType.StoredProcedure;
			return SqlMapper.QueryFirstOrDefault<Languages>((IDbConnection)sqlConnection, "LanguagesGetByID", (object)anon, (IDbTransaction)null, (int?)null, commandType);
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public List<Languages> GetByLanguageCode(string LanguageCode)
	{
		try
		{
			SqlConnection sqlConnection = connection;
			var anon = new { LanguageCode };
			CommandType? commandType = CommandType.StoredProcedure;
			return SqlMapper.Query<Languages>((IDbConnection)sqlConnection, "LanguagesGetByLanguageCode", (object)anon, (IDbTransaction)null, true, (int?)null, commandType).ToList();
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public List<Languages> GetByLanguageName(string LanguageName)
	{
		try
		{
			SqlConnection sqlConnection = connection;
			var anon = new { LanguageName };
			CommandType? commandType = CommandType.StoredProcedure;
			return SqlMapper.Query<Languages>((IDbConnection)sqlConnection, "LanguagesGetByLanguageName", (object)anon, (IDbTransaction)null, true, (int?)null, commandType).ToList();
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
