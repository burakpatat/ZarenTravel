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
public class HotelRoomsWithRoomOffersRepository : IDisposable
{
    private SqlConnection connection;
    private readonly string strConnString;
    public HotelRoomsWithRoomOffersRepository()
    {
        strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
        connection = new SqlConnection(strConnString);
    }
    public long Insert(HotelRoomsWithRoomOffers HotelRoomsWithRoomOffers)
    {
        try
        {
            return connection.Insert(HotelRoomsWithRoomOffers);
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
