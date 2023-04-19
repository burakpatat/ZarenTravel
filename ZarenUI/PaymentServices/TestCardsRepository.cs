using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Dapper.Contrib.Extensions;
using Model.Concrete;

public class TestCardsRepository : IDisposable
{
    private SqlConnection connection;

    private readonly string strConnString;
    public TestCardsRepository(IConfiguration configuration)
    {
        strConnString = configuration.GetConnectionString("ZarenTravel");
        connection = new SqlConnection(strConnString);
    }


    public long Insert(TestCards TestCards)
	{
		try
		{
			return SqlMapperExtensions.Insert<TestCards>((IDbConnection)connection, TestCards, (IDbTransaction)null, (int?)null);
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public bool Update(TestCards TestCards)
	{
		try
		{
			return SqlMapperExtensions.Update<TestCards>((IDbConnection)connection, TestCards, (IDbTransaction)null, (int?)null);
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public bool Delete(TestCards TestCards)
	{
		try
		{
			return SqlMapperExtensions.Delete<TestCards>((IDbConnection)connection, TestCards, (IDbTransaction)null, (int?)null);
		}
		catch (Exception)
		{
			return false;
		}
	}

	public List<TestCards> GetAll()
	{
		try
		{
			SqlConnection sqlConnection = connection;
			CommandType? commandType = CommandType.StoredProcedure;
			return SqlMapper.Query<TestCards>((IDbConnection)sqlConnection, "TestCardsGetAll", (object)null, (IDbTransaction)null, true, (int?)null, commandType).ToList();
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public List<TestCards> GetByBankName(string BankName)
	{
		try
		{
			SqlConnection sqlConnection = connection;
			var anon = new { BankName };
			CommandType? commandType = CommandType.StoredProcedure;
			return SqlMapper.Query<TestCards>((IDbConnection)sqlConnection, "TestCardsGetByBankName", (object)anon, (IDbTransaction)null, true, (int?)null, commandType).ToList();
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public List<TestCards> GetByCardNo(string CardNo)
	{
		try
		{
			SqlConnection sqlConnection = connection;
			var anon = new { CardNo };
			CommandType? commandType = CommandType.StoredProcedure;
			return SqlMapper.Query<TestCards>((IDbConnection)sqlConnection, "TestCardsGetByCardNo", (object)anon, (IDbTransaction)null, true, (int?)null, commandType).ToList();
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public List<TestCards> GetByCardScheme(string CardScheme)
	{
		try
		{
			SqlConnection sqlConnection = connection;
			var anon = new { CardScheme };
			CommandType? commandType = CommandType.StoredProcedure;
			return SqlMapper.Query<TestCards>((IDbConnection)sqlConnection, "TestCardsGetByCardScheme", (object)anon, (IDbTransaction)null, true, (int?)null, commandType).ToList();
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public List<TestCards> GetByCardType(string CardType)
	{
		try
		{
			SqlConnection sqlConnection = connection;
			var anon = new { CardType };
			CommandType? commandType = CommandType.StoredProcedure;
			return SqlMapper.Query<TestCards>((IDbConnection)sqlConnection, "TestCardsGetByCardType", (object)anon, (IDbTransaction)null, true, (int?)null, commandType).ToList();
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public List<TestCards> GetByCVV(string CVV)
	{
		try
		{
			SqlConnection sqlConnection = connection;
			var anon = new { CVV };
			CommandType? commandType = CommandType.StoredProcedure;
			return SqlMapper.Query<TestCards>((IDbConnection)sqlConnection, "TestCardsGetByCVV", (object)anon, (IDbTransaction)null, true, (int?)null, commandType).ToList();
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public TestCards GetByID(int Id)
	{
		try
		{
			SqlConnection sqlConnection = connection;
			var anon = new { Id };
			CommandType? commandType = CommandType.StoredProcedure;
			return SqlMapper.QueryFirstOrDefault<TestCards>((IDbConnection)sqlConnection, "TestCardsGetByID", (object)anon, (IDbTransaction)null, (int?)null, commandType);
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public List<TestCards> GetByPaymentConfigurationId(int PaymentConfigurationId)
	{
		try
		{
			SqlConnection sqlConnection = connection;
			var anon = new { PaymentConfigurationId };
			CommandType? commandType = CommandType.StoredProcedure;
			return SqlMapper.Query<TestCards>((IDbConnection)sqlConnection, "TestCardsGetByPaymentConfigurationId", (object)anon, (IDbTransaction)null, true, (int?)null, commandType).ToList();
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public List<TestCards> GetByResponseType(string ResponseType)
	{
		try
		{
			SqlConnection sqlConnection = connection;
			var anon = new { ResponseType };
			CommandType? commandType = CommandType.StoredProcedure;
			return SqlMapper.Query<TestCards>((IDbConnection)sqlConnection, "TestCardsGetByResponseType", (object)anon, (IDbTransaction)null, true, (int?)null, commandType).ToList();
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public List<TestCards> GetByThreeDPassword(string ThreeDPassword)
	{
		try
		{
			SqlConnection sqlConnection = connection;
			var anon = new { ThreeDPassword };
			CommandType? commandType = CommandType.StoredProcedure;
			return SqlMapper.Query<TestCards>((IDbConnection)sqlConnection, "TestCardsGetByThreeDPassword", (object)anon, (IDbTransaction)null, true, (int?)null, commandType).ToList();
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public List<TestCards> GetByValidDate(string ValidDate)
	{
		try
		{
			SqlConnection sqlConnection = connection;
			var anon = new { ValidDate };
			CommandType? commandType = CommandType.StoredProcedure;
			return SqlMapper.Query<TestCards>((IDbConnection)sqlConnection, "TestCardsGetByValidDate", (object)anon, (IDbTransaction)null, true, (int?)null, commandType).ToList();
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
