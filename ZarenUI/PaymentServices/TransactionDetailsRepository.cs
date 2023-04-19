using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Dapper.Contrib.Extensions;
using Model.Concrete;

public class TransactionDetailsRepository : IDisposable
{
    private SqlConnection connection;

    private readonly string strConnString;
    public TransactionDetailsRepository(IConfiguration configuration)
    {
        strConnString = configuration.GetConnectionString("ZarenTravel");
        connection = new SqlConnection(strConnString);
    }
    public long Insert(TransactionDetails TransactionDetails)
	{
		try
		{
			return SqlMapperExtensions.Insert<TransactionDetails>((IDbConnection)connection, TransactionDetails, (IDbTransaction)null, (int?)null);
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public bool Update(TransactionDetails TransactionDetails)
	{
		try
		{
			return SqlMapperExtensions.Update<TransactionDetails>((IDbConnection)connection, TransactionDetails, (IDbTransaction)null, (int?)null);
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public bool Delete(TransactionDetails TransactionDetails)
	{
		try
		{
			return SqlMapperExtensions.Delete<TransactionDetails>((IDbConnection)connection, TransactionDetails, (IDbTransaction)null, (int?)null);
		}
		catch (Exception)
		{
			return false;
		}
	}

	public List<TransactionDetails> GetAll()
	{
		try
		{
			SqlConnection sqlConnection = connection;
			CommandType? commandType = CommandType.StoredProcedure;
			return SqlMapper.Query<TransactionDetails>((IDbConnection)sqlConnection, "TransactionDetailsGetAll", (object)null, (IDbTransaction)null, true, (int?)null, commandType).ToList();
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public List<TransactionDetails> GetByCardHolderNameSurname(string CardHolderNameSurname)
	{
		try
		{
			SqlConnection sqlConnection = connection;
			var anon = new { CardHolderNameSurname };
			CommandType? commandType = CommandType.StoredProcedure;
			return SqlMapper.Query<TransactionDetails>((IDbConnection)sqlConnection, "TransactionDetailsGetByCardHolderNameSurname", (object)anon, (IDbTransaction)null, true, (int?)null, commandType).ToList();
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public List<TransactionDetails> GetByCardNumber(string CardNumber)
	{
		try
		{
			SqlConnection sqlConnection = connection;
			var anon = new { CardNumber };
			CommandType? commandType = CommandType.StoredProcedure;
			return SqlMapper.Query<TransactionDetails>((IDbConnection)sqlConnection, "TransactionDetailsGetByCardNumber", (object)anon, (IDbTransaction)null, true, (int?)null, commandType).ToList();
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public TransactionDetails GetByID(int Id)
	{
		try
		{
			SqlConnection sqlConnection = connection;
			var anon = new { Id };
			CommandType? commandType = CommandType.StoredProcedure;
			return SqlMapper.QueryFirstOrDefault<TransactionDetails>((IDbConnection)sqlConnection, "TransactionDetailsGetByID", (object)anon, (IDbTransaction)null, (int?)null, commandType);
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public List<TransactionDetails> GetByIP(string IP)
	{
		try
		{
			SqlConnection sqlConnection = connection;
			var anon = new { IP };
			CommandType? commandType = CommandType.StoredProcedure;
			return SqlMapper.Query<TransactionDetails>((IDbConnection)sqlConnection, "TransactionDetailsGetByIP", (object)anon, (IDbTransaction)null, true, (int?)null, commandType).ToList();
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public List<TransactionDetails> GetByTransactionId(int TransactionId)
	{
		try
		{
			SqlConnection sqlConnection = connection;
			var anon = new { TransactionId };
			CommandType? commandType = CommandType.StoredProcedure;
			return SqlMapper.Query<TransactionDetails>((IDbConnection)sqlConnection, "TransactionDetailsGetByTransactionId", (object)anon, (IDbTransaction)null, true, (int?)null, commandType).ToList();
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public List<TransactionDetails> GetByUserAgent(string UserAgent)
	{
		try
		{
			SqlConnection sqlConnection = connection;
			var anon = new { UserAgent };
			CommandType? commandType = CommandType.StoredProcedure;
			return SqlMapper.Query<TransactionDetails>((IDbConnection)sqlConnection, "TransactionDetailsGetByUserAgent", (object)anon, (IDbTransaction)null, true, (int?)null, commandType).ToList();
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
