using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Dapper.Contrib.Extensions;
using Model.Concrete;

public class PaymentLogsRepository : IDisposable
{
	 
    private SqlConnection connection;

    private readonly string strConnString;
    public PaymentLogsRepository(IConfiguration configuration)
    {
        strConnString = configuration.GetConnectionString("ZarenTravel");
        connection = new SqlConnection(strConnString);
    }


    public long Insert(PaymentLogs PaymentLogs)
	{
		try
		{
			return SqlMapperExtensions.Insert<PaymentLogs>((IDbConnection)connection, PaymentLogs, (IDbTransaction)null, (int?)null);
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public bool Update(PaymentLogs PaymentLogs)
	{
		try
		{
			return SqlMapperExtensions.Update<PaymentLogs>((IDbConnection)connection, PaymentLogs, (IDbTransaction)null, (int?)null);
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public bool Delete(PaymentLogs PaymentLogs)
	{
		try
		{
			return SqlMapperExtensions.Delete<PaymentLogs>((IDbConnection)connection, PaymentLogs, (IDbTransaction)null, (int?)null);
		}
		catch (Exception)
		{
			return false;
		}
	}

	public List<PaymentLogs> GetAll()
	{
		try
		{
			SqlConnection sqlConnection = connection;
			CommandType? commandType = CommandType.StoredProcedure;
			return SqlMapper.Query<PaymentLogs>((IDbConnection)sqlConnection, "PaymentLogsGetAll", (object)null, (IDbTransaction)null, true, (int?)null, commandType).ToList();
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public PaymentLogs GetByID(int Id)
	{
		try
		{
			SqlConnection sqlConnection = connection;
			var anon = new { Id };
			CommandType? commandType = CommandType.StoredProcedure;
			return SqlMapper.QueryFirstOrDefault<PaymentLogs>((IDbConnection)sqlConnection, "PaymentLogsGetByID", (object)anon, (IDbTransaction)null, (int?)null, commandType);
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public List<PaymentLogs> GetByRequest(string Request)
	{
		try
		{
			SqlConnection sqlConnection = connection;
			var anon = new { Request };
			CommandType? commandType = CommandType.StoredProcedure;
			return SqlMapper.Query<PaymentLogs>((IDbConnection)sqlConnection, "PaymentLogsGetByRequest", (object)anon, (IDbTransaction)null, true, (int?)null, commandType).ToList();
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public List<PaymentLogs> GetByRequestDate(DateTime RequestDate)
	{
		try
		{
			SqlConnection sqlConnection = connection;
			var anon = new { RequestDate };
			CommandType? commandType = CommandType.StoredProcedure;
			return SqlMapper.Query<PaymentLogs>((IDbConnection)sqlConnection, "PaymentLogsGetByRequestDate", (object)anon, (IDbTransaction)null, true, (int?)null, commandType).ToList();
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public List<PaymentLogs> GetByResponse(string Response)
	{
		try
		{
			SqlConnection sqlConnection = connection;
			var anon = new { Response };
			CommandType? commandType = CommandType.StoredProcedure;
			return SqlMapper.Query<PaymentLogs>((IDbConnection)sqlConnection, "PaymentLogsGetByResponse", (object)anon, (IDbTransaction)null, true, (int?)null, commandType).ToList();
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public List<PaymentLogs> GetByResponseDate(DateTime ResponseDate)
	{
		try
		{
			SqlConnection sqlConnection = connection;
			var anon = new { ResponseDate };
			CommandType? commandType = CommandType.StoredProcedure;
			return SqlMapper.Query<PaymentLogs>((IDbConnection)sqlConnection, "PaymentLogsGetByResponseDate", (object)anon, (IDbTransaction)null, true, (int?)null, commandType).ToList();
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public List<PaymentLogs> GetByTransactionId(int TransactionId)
	{
		try
		{
			SqlConnection sqlConnection = connection;
			var anon = new { TransactionId };
			CommandType? commandType = CommandType.StoredProcedure;
			return SqlMapper.Query<PaymentLogs>((IDbConnection)sqlConnection, "PaymentLogsGetByTransactionId", (object)anon, (IDbTransaction)null, true, (int?)null, commandType).ToList();
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public List<PaymentLogs> GetRequestDateBetween(DateTime RequestDateStart, DateTime RequestDateEnd)
	{
		try
		{
			SqlConnection sqlConnection = connection;
			var anon = new { RequestDateStart, RequestDateEnd };
			CommandType? commandType = CommandType.StoredProcedure;
			return SqlMapper.Query<PaymentLogs>((IDbConnection)sqlConnection, "PaymentLogsGetRequestDateBetween", (object)anon, (IDbTransaction)null, true, (int?)null, commandType).ToList();
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public List<PaymentLogs> GetResponseDateBetween(DateTime ResponseDateStart, DateTime ResponseDateEnd)
	{
		try
		{
			SqlConnection sqlConnection = connection;
			var anon = new { ResponseDateStart, ResponseDateEnd };
			CommandType? commandType = CommandType.StoredProcedure;
			return SqlMapper.Query<PaymentLogs>((IDbConnection)sqlConnection, "PaymentLogsGetResponseDateBetween", (object)anon, (IDbTransaction)null, true, (int?)null, commandType).ToList();
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
