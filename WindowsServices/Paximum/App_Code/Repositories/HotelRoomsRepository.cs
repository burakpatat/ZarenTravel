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
public class HotelRoomsRepository : IDisposable
{
    private SqlConnection connection;
    private readonly string strConnString;
    public HotelRoomsRepository()
    {
        strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
        connection = new SqlConnection(strConnString);
    }
    public long Insert(HotelRooms HotelRooms)
    {
        try
        {
            return connection.Insert(HotelRooms);
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
