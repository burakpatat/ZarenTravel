using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Dapper.Contrib.Extensions;
using Model.Concrete;

public class PageContentsRepository : IDisposable
{
    private SqlConnection connection;

    private readonly string strConnString;
    public PageContentsRepository(IConfiguration configuration)
    {
        strConnString = configuration.GetConnectionString("ZarenTravel");
        connection = new SqlConnection(strConnString);
    }

    public long Insert(PageContents PageContents)
	{
		try
		{
			return SqlMapperExtensions.Insert<PageContents>((IDbConnection)connection, PageContents, (IDbTransaction)null, (int?)null);
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public bool Update(PageContents PageContents)
	{
		try
		{
			return SqlMapperExtensions.Update<PageContents>((IDbConnection)connection, PageContents, (IDbTransaction)null, (int?)null);
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public bool Delete(PageContents PageContents)
	{
		try
		{
			return SqlMapperExtensions.Delete<PageContents>((IDbConnection)connection, PageContents, (IDbTransaction)null, (int?)null);
		}
		catch (Exception)
		{
			return false;
		}
	}

	public List<PageContents> GetAll()
	{
		try
		{
			SqlConnection sqlConnection = connection;
			CommandType? commandType = CommandType.StoredProcedure;
			return SqlMapper.Query<PageContents>((IDbConnection)sqlConnection, "PageContentsGetAll", (object)null, (IDbTransaction)null, true, (int?)null, commandType).ToList();
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public List<PageContents> GetByContents(string Contents)
	{
		try
		{
			SqlConnection sqlConnection = connection;
			var anon = new { Contents };
			CommandType? commandType = CommandType.StoredProcedure;
			return SqlMapper.Query<PageContents>((IDbConnection)sqlConnection, "PageContentsGetByContents", (object)anon, (IDbTransaction)null, true, (int?)null, commandType).ToList();
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public List<PageContents> GetByContentTitle(string ContentTitle)
	{
		try
		{
			SqlConnection sqlConnection = connection;
			var anon = new { ContentTitle };
			CommandType? commandType = CommandType.StoredProcedure;
			return SqlMapper.Query<PageContents>((IDbConnection)sqlConnection, "PageContentsGetByContentTitle", (object)anon, (IDbTransaction)null, true, (int?)null, commandType).ToList();
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public PageContents GetByID(int Id)
	{
		try
		{
			SqlConnection sqlConnection = connection;
			var anon = new { Id };
			CommandType? commandType = CommandType.StoredProcedure;
			return SqlMapper.QueryFirstOrDefault<PageContents>((IDbConnection)sqlConnection, "PageContentsGetByID", (object)anon, (IDbTransaction)null, (int?)null, commandType);
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
