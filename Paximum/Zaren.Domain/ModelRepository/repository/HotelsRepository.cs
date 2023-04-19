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
public class HotelsRepository : IDisposable
{
    private SqlConnection connection;
    private readonly string strConnString;
    public HotelsRepository(IConfiguration configuration)
    {
        strConnString = configuration.GetSection("ConnectionString").Value;
        connection = new SqlConnection(strConnString);
    }
    public long Insert(Hotels Hotels)
    {
        try
        {
            return connection.Insert(Hotels);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool Update(Hotels Hotels)
    {
        try
        {
            return connection.Update(Hotels);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool Delete(Hotels Hotels)
    {
        try
        {
            return connection.Delete<Hotels>(Hotels);
        }
        catch (Exception)
        {
            return false;
        }
    }
    public List<Hotels> GetAll()
    {
        try
        {
            return connection.Query<Hotels>("HotelsGetAll", commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Hotels> GetByAddress(string Address)
    {
        try
        {
            return connection.Query<Hotels>("HotelsGetByAddress", new
            {
                Address = Address
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Hotels> GetByCityId(int CityId)
    {
        try
        {
            return connection.Query<Hotels>("HotelsGetByCityId", new
            {
                CityId = CityId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Hotels> GetByCommercialContactId(int CommercialContactId)
    {
        try
        {
            return connection.Query<Hotels>("HotelsGetByCommercialContactId", new
            {
                CommercialContactId = CommercialContactId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Hotels> GetByCountryId(int CountryId)
    {
        try
        {
            return connection.Query<Hotels>("HotelsGetByCountryId", new
            {
                CountryId = CountryId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Hotels> GetByFinanceContactId(int FinanceContactId)
    {
        try
        {
            return connection.Query<Hotels>("HotelsGetByFinanceContactId", new
            {
                FinanceContactId = FinanceContactId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Hotels> GetByHotelChainId(int HotelChainId)
    {
        try
        {
            return connection.Query<Hotels>("HotelsGetByHotelChainId", new
            {
                HotelChainId = HotelChainId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Hotels> GetByHotelTypeId(int HotelTypeId)
    {
        try
        {
            return connection.Query<Hotels>("HotelsGetByHotelTypeId", new
            {
                HotelTypeId = HotelTypeId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public Hotels GetByID(int Id)
    {
        try
        {
            return connection.QueryFirstOrDefault<Hotels>("HotelsGetByID", new
            {
                Id = Id
            }, commandType: CommandType.StoredProcedure);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Hotels> GetByLatitude(decimal Latitude)
    {
        try
        {
            return connection.Query<Hotels>("HotelsGetByLatitude", new
            {
                Latitude = Latitude
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Hotels> GetByLongitude(decimal Longitude)
    {
        try
        {
            return connection.Query<Hotels>("HotelsGetByLongitude", new
            {
                Longitude = Longitude
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Hotels> GetByName(string Name)
    {
        try
        {
            return connection.Query<Hotels>("HotelsGetByName", new
            {
                Name = Name
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Hotels> GetByNumberRooms(int NumberRooms)
    {
        try
        {
            return connection.Query<Hotels>("HotelsGetByNumberRooms", new
            {
                NumberRooms = NumberRooms
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Hotels> GetByRegionId(int RegionId)
    {
        try
        {
            return connection.Query<Hotels>("HotelsGetByRegionId", new
            {
                RegionId = RegionId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Hotels> GetByRelease(int Release)
    {
        try
        {
            return connection.Query<Hotels>("HotelsGetByRelease", new
            {
                Release = Release
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Hotels> GetByReservationContactId(int ReservationContactId)
    {
        try
        {
            return connection.Query<Hotels>("HotelsGetByReservationContactId", new
            {
                ReservationContactId = ReservationContactId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Hotels> GetByZipCode(string ZipCode)
    {
        try
        {
            return connection.Query<Hotels>("HotelsGetByZipCode", new
            {
                ZipCode = ZipCode
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Hotels> GetByZoneId(int ZoneId)
    {
        try
        {
            return connection.Query<Hotels>("HotelsGetByZoneId", new
            {
                ZoneId = ZoneId
            }, commandType: CommandType.StoredProcedure).ToList();

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
