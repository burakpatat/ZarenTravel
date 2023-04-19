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
    public class ZonesCitiesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public ZonesCitiesRepository(IConfiguration configuration)
        {
             strConnString = configuration.GetSection("ConnectionString").Value;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(ZonesCities ZonesCities)
    {
        try
        {
            return connection.Insert(ZonesCities);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(ZonesCities ZonesCities)
    {
        try
        {
       return  connection.Update(ZonesCities);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(ZonesCities ZonesCities)
        {
            try
            {
            return  connection.Delete<ZonesCities>(ZonesCities);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<ZonesCities> GetAll(){
            try
            {
                return connection.Query<ZonesCities>("ZonesCitiesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<ZonesCities> GetByCityId(int CityId){
            try
            {
                return connection.Query<ZonesCities>("ZonesCitiesGetByCityId", new
                {
CityId = CityId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public ZonesCities GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<ZonesCities>("ZonesCitiesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<ZonesCities> GetByMainZone(string MainZone){
            try
            {
                return connection.Query<ZonesCities>("ZonesCitiesGetByMainZone", new
                {
MainZone = MainZone
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<ZonesCities> GetByZoneId(int ZoneId){
            try
            {
                return connection.Query<ZonesCities>("ZonesCitiesGetByZoneId", new
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
