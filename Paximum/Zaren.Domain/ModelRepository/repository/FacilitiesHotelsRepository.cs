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
using Microsoft.Extensions.Configuration;
public class FacilitiesHotelsRepository : IDisposable
{
    private SqlConnection connection;
    private readonly string strConnString;
    public FacilitiesHotelsRepository(IConfiguration configuration)
    {
        strConnString = configuration.GetSection("ConnectionString").Value;
        connection = new SqlConnection(strConnString);
    }
    public long Insert(FacilitiesHotels FacilitiesHotels)
    {
        try
        {
            return connection.Insert(FacilitiesHotels);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool Update(FacilitiesHotels FacilitiesHotels)
    {
        try
        {
            return connection.Update(FacilitiesHotels);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool Delete(FacilitiesHotels FacilitiesHotels)
    {
        try
        {
            return connection.Delete<FacilitiesHotels>(FacilitiesHotels);
        }
        catch (Exception)
        {
            return false;
        }
    }
    public List<FacilitiesHotels> GetAll()
    {
        try
        {
            return connection.Query<FacilitiesHotels>("FacilitiesHotelsGetAll", commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<FacilitiesHotels> GetByFacilityId(int FacilityId)
    {
        try
        {
            return connection.Query<FacilitiesHotels>("FacilitiesHotelsGetByFacilityId", new
            {
                FacilityId = FacilityId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<FacilitiesHotels> GetByHotelId(int HotelId)
    {
        try
        {
            return connection.Query<FacilitiesHotels>("FacilitiesHotelsGetByHotelId", new
            {
                HotelId = HotelId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<FacilitiesHotels> GetByHotelRoomId(int HotelRoomId)
    {
        try
        {
            return connection.Query<FacilitiesHotels>("FacilitiesHotelsGetByHotelRoomId", new
            {
                HotelRoomId = HotelRoomId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public FacilitiesHotels GetByID(int Id)
    {
        try
        {
            return connection.QueryFirstOrDefault<FacilitiesHotels>("FacilitiesHotelsGetByID", new
            {
                Id = Id
            }, commandType: CommandType.StoredProcedure);

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
