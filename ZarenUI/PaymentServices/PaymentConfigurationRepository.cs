using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Dapper.Contrib.Extensions;
using Model.Concrete;

public class PaymentConfigurationRepository : IDisposable
{
	 
    private SqlConnection connection;

    private readonly string strConnString;
    public PaymentConfigurationRepository(IConfiguration configuration)
    {
        strConnString = configuration.GetConnectionString("ZarenTravel");
        connection = new SqlConnection(strConnString);
    }


    public long Insert(PaymentConfiguration PaymentConfiguration)
	{
		try
		{
			return SqlMapperExtensions.Insert<PaymentConfiguration>((IDbConnection)connection, PaymentConfiguration, (IDbTransaction)null, (int?)null);
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public bool Update(PaymentConfiguration PaymentConfiguration)
	{
		try
		{
			return SqlMapperExtensions.Update<PaymentConfiguration>((IDbConnection)connection, PaymentConfiguration, (IDbTransaction)null, (int?)null);
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public bool Delete(PaymentConfiguration PaymentConfiguration)
	{
		try
		{
			return SqlMapperExtensions.Delete<PaymentConfiguration>((IDbConnection)connection, PaymentConfiguration, (IDbTransaction)null, (int?)null);
		}
		catch (Exception)
		{
			return false;
		}
	}

	public List<PaymentConfiguration> GetAll()
	{
		try
		{
			SqlConnection sqlConnection = connection;
			CommandType? commandType = CommandType.StoredProcedure;
			return SqlMapper.Query<PaymentConfiguration>((IDbConnection)sqlConnection, "PaymentConfigurationGetAll", (object)null, (IDbTransaction)null, true, (int?)null, commandType).ToList();
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public List<PaymentConfiguration> GetByEmail(string Email)
	{
		try
		{
			SqlConnection sqlConnection = connection;
			var anon = new { Email };
			CommandType? commandType = CommandType.StoredProcedure;
			return SqlMapper.Query<PaymentConfiguration>((IDbConnection)sqlConnection, "PaymentConfigurationGetByEmail", (object)anon, (IDbTransaction)null, true, (int?)null, commandType).ToList();
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public PaymentConfiguration GetByID(int Id)
	{
		try
		{
			SqlConnection sqlConnection = connection;
			var anon = new { Id };
			CommandType? commandType = CommandType.StoredProcedure;
			return SqlMapper.QueryFirstOrDefault<PaymentConfiguration>((IDbConnection)sqlConnection, "PaymentConfigurationGetByID", (object)anon, (IDbTransaction)null, (int?)null, commandType);
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public List<PaymentConfiguration> GetByLanguage(string Language)
	{
		try
		{
			SqlConnection sqlConnection = connection;
			var anon = new { Language };
			CommandType? commandType = CommandType.StoredProcedure;
			return SqlMapper.Query<PaymentConfiguration>((IDbConnection)sqlConnection, "PaymentConfigurationGetByLanguage", (object)anon, (IDbTransaction)null, true, (int?)null, commandType).ToList();
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public List<PaymentConfiguration> GetByNoLimitTestCardNumber(string NoLimitTestCardNumber)
	{
		try
		{
			SqlConnection sqlConnection = connection;
			var anon = new { NoLimitTestCardNumber };
			CommandType? commandType = CommandType.StoredProcedure;
			return SqlMapper.Query<PaymentConfiguration>((IDbConnection)sqlConnection, "PaymentConfigurationGetByNoLimitTestCardNumber", (object)anon, (IDbTransaction)null, true, (int?)null, commandType).ToList();
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public List<PaymentConfiguration> GetByPassword(string Password)
	{
		try
		{
			SqlConnection sqlConnection = connection;
			var anon = new { Password };
			CommandType? commandType = CommandType.StoredProcedure;
			return SqlMapper.Query<PaymentConfiguration>((IDbConnection)sqlConnection, "PaymentConfigurationGetByPassword", (object)anon, (IDbTransaction)null, true, (int?)null, commandType).ToList();
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public List<PaymentConfiguration> GetByPaymentCompany(string PaymentCompany)
	{
		try
		{
			SqlConnection sqlConnection = connection;
			var anon = new { PaymentCompany };
			CommandType? commandType = CommandType.StoredProcedure;
			return SqlMapper.Query<PaymentConfiguration>((IDbConnection)sqlConnection, "PaymentConfigurationGetByPaymentCompany", (object)anon, (IDbTransaction)null, true, (int?)null, commandType).ToList();
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public List<PaymentConfiguration> GetByProdUrl(string ProdUrl)
	{
		try
		{
			SqlConnection sqlConnection = connection;
			var anon = new { ProdUrl };
			CommandType? commandType = CommandType.StoredProcedure;
			return SqlMapper.Query<PaymentConfiguration>((IDbConnection)sqlConnection, "PaymentConfigurationGetByProdUrl", (object)anon, (IDbTransaction)null, true, (int?)null, commandType).ToList();
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public List<PaymentConfiguration> GetBySuccessTestCardNumber(string SuccessTestCardNumber)
	{
		try
		{
			SqlConnection sqlConnection = connection;
			var anon = new { SuccessTestCardNumber };
			CommandType? commandType = CommandType.StoredProcedure;
			return SqlMapper.Query<PaymentConfiguration>((IDbConnection)sqlConnection, "PaymentConfigurationGetBySuccessTestCardNumber", (object)anon, (IDbTransaction)null, true, (int?)null, commandType).ToList();
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public List<PaymentConfiguration> GetByTestUrl(string TestUrl)
	{
		try
		{
			SqlConnection sqlConnection = connection;
			var anon = new { TestUrl };
			CommandType? commandType = CommandType.StoredProcedure;
			return SqlMapper.Query<PaymentConfiguration>((IDbConnection)sqlConnection, "PaymentConfigurationGetByTestUrl", (object)anon, (IDbTransaction)null, true, (int?)null, commandType).ToList();
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
