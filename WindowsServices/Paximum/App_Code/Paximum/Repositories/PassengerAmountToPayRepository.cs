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
public class PassengerAmountToPayRepository : IDisposable
{
    private SqlConnection connection;
    private readonly string strConnString;
    public PassengerAmountToPayRepository()
    {
        strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
        connection = new SqlConnection(strConnString);
    }
    public long Insert(PassengerAmounts PassengerAmounts)
    {
        try
        {
            return connection.Insert(PassengerAmounts);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool Update(PassengerAmounts PassengerAmounts)
    {
        try
        {
            return connection.Update(PassengerAmounts);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool Delete(PassengerAmounts PassengerAmounts)
    {
        try
        {
            return connection.Delete<PassengerAmounts>(PassengerAmounts);
        }
        catch (Exception)
        {
            return false;
        }
    }
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
