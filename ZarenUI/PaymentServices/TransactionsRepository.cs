using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Dapper.Contrib.Extensions;
using Model.Concrete;

public class TransactionsRepository : IDisposable
{
    private SqlConnection connection;

    private readonly string strConnString;
    public TransactionsRepository(IConfiguration configuration)
    {
        strConnString = configuration.GetConnectionString("ZarenTravel");
        connection = new SqlConnection(strConnString);
    }

    public long Insert(Transactions Transactions)
	{
		try
		{
			return SqlMapperExtensions.Insert<Transactions>((IDbConnection)connection, Transactions, (IDbTransaction)null, (int?)null);
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public bool Update(Transactions Transactions)
	{
		try
		{
			return SqlMapperExtensions.Update<Transactions>((IDbConnection)connection, Transactions, (IDbTransaction)null, (int?)null);
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public bool Delete(Transactions Transactions)
	{
		try
		{
			return SqlMapperExtensions.Delete<Transactions>((IDbConnection)connection, Transactions, (IDbTransaction)null, (int?)null);
		}
		catch (Exception)
		{
			return false;
		}
	}

	public List<Transactions> GetAll()
	{
		try
		{
			SqlConnection sqlConnection = connection;
			CommandType? commandType = CommandType.StoredProcedure;
			return SqlMapper.Query<Transactions>((IDbConnection)sqlConnection, "TransactionsGetAll", (object)null, (IDbTransaction)null, true, (int?)null, commandType).ToList();
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public List<Transactions> GetByCreatedDate(DateTime CreatedDate)
	{
		try
		{
			SqlConnection sqlConnection = connection;
			var anon = new { CreatedDate };
			CommandType? commandType = CommandType.StoredProcedure;
			return SqlMapper.Query<Transactions>((IDbConnection)sqlConnection, "TransactionsGetByCreatedDate", (object)anon, (IDbTransaction)null, true, (int?)null, commandType).ToList();
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public List<Transactions> GetByCurrency(int Currency)
	{
		try
		{
			SqlConnection sqlConnection = connection;
			var anon = new { Currency };
			CommandType? commandType = CommandType.StoredProcedure;
			return SqlMapper.Query<Transactions>((IDbConnection)sqlConnection, "TransactionsGetByCurrency", (object)anon, (IDbTransaction)null, true, (int?)null, commandType).ToList();
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public Transactions GetByID(int Id)
	{
		try
		{
			SqlConnection sqlConnection = connection;
			var anon = new { Id };
			CommandType? commandType = CommandType.StoredProcedure;
			return SqlMapper.QueryFirstOrDefault<Transactions>((IDbConnection)sqlConnection, "TransactionsGetByID", (object)anon, (IDbTransaction)null, (int?)null, commandType);
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public List<Transactions> GetByIdGuid(string IdGuid)
	{
		try
		{
			SqlConnection sqlConnection = connection;
			var anon = new { IdGuid };
			CommandType? commandType = CommandType.StoredProcedure;
			return SqlMapper.Query<Transactions>((IDbConnection)sqlConnection, "TransactionsGetByIdGuid", (object)anon, (IDbTransaction)null, true, (int?)null, commandType).ToList();
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public List<Transactions> GetByIs3D(bool Is3D)
	{
		try
		{
			SqlConnection sqlConnection = connection;
			var anon = new { Is3D };
			CommandType? commandType = CommandType.StoredProcedure;
			return SqlMapper.Query<Transactions>((IDbConnection)sqlConnection, "TransactionsGetByIs3D", (object)anon, (IDbTransaction)null, true, (int?)null, commandType).ToList();
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public List<Transactions> GetByIsSuccess(bool IsSuccess)
	{
		try
		{
			SqlConnection sqlConnection = connection;
			var anon = new { IsSuccess };
			CommandType? commandType = CommandType.StoredProcedure;
			return SqlMapper.Query<Transactions>((IDbConnection)sqlConnection, "TransactionsGetByIsSuccess", (object)anon, (IDbTransaction)null, true, (int?)null, commandType).ToList();
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public List<Transactions> GetByLanguage(string Language)
	{
		try
		{
			SqlConnection sqlConnection = connection;
			var anon = new { Language };
			CommandType? commandType = CommandType.StoredProcedure;
			return SqlMapper.Query<Transactions>((IDbConnection)sqlConnection, "TransactionsGetByLanguage", (object)anon, (IDbTransaction)null, true, (int?)null, commandType).ToList();
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public List<Transactions> GetByNameSurname(string NameSurname)
	{
		try
		{
			SqlConnection sqlConnection = connection;
			var anon = new { NameSurname };
			CommandType? commandType = CommandType.StoredProcedure;
			return SqlMapper.Query<Transactions>((IDbConnection)sqlConnection, "TransactionsGetByNameSurname", (object)anon, (IDbTransaction)null, true, (int?)null, commandType).ToList();
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public List<Transactions> GetByTotalAmount(decimal TotalAmount)
	{
		try
		{
			SqlConnection sqlConnection = connection;
			var anon = new { TotalAmount };
			CommandType? commandType = CommandType.StoredProcedure;
			return SqlMapper.Query<Transactions>((IDbConnection)sqlConnection, "TransactionsGetByTotalAmount", (object)anon, (IDbTransaction)null, true, (int?)null, commandType).ToList();
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public List<Transactions> GetByUserId(string UserId)
	{
		try
		{
			SqlConnection sqlConnection = connection;
			var anon = new { UserId };
			CommandType? commandType = CommandType.StoredProcedure;
			return SqlMapper.Query<Transactions>((IDbConnection)sqlConnection, "TransactionsGetByUserId", (object)anon, (IDbTransaction)null, true, (int?)null, commandType).ToList();
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public List<Transactions> GetCreatedDateBetween(DateTime CreatedDateStart, DateTime CreatedDateEnd)
	{
		try
		{
			SqlConnection sqlConnection = connection;
			var anon = new { CreatedDateStart, CreatedDateEnd };
			CommandType? commandType = CommandType.StoredProcedure;
			return SqlMapper.Query<Transactions>((IDbConnection)sqlConnection, "TransactionsGetCreatedDateBetween", (object)anon, (IDbTransaction)null, true, (int?)null, commandType).ToList();
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
