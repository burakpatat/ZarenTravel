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
    public class ZonesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public ZonesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Zones Zones)
    {
        try
        {
            return connection.Insert(Zones);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Zones Zones)
    {
        try
        {
       return  connection.Update(Zones);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Zones Zones)
        {
            try
            {
            return  connection.Delete<Zones>(Zones);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<Zones> GetAll(){
            try
            {
                return connection.Query<Zones>("ZonesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Zones GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Zones>("ZonesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Zones> GetByLatLongBounds(string LatLongBounds){
            try
            {
                return connection.Query<Zones>("ZonesGetByLatLongBounds", new
                {
LatLongBounds = LatLongBounds
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Zones> GetByName(string Name){
            try
            {
                return connection.Query<Zones>("ZonesGetByName", new
                {
Name = Name
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Zones> GetByRegionId(int RegionId){
            try
            {
                return connection.Query<Zones>("ZonesGetByRegionId", new
                {
RegionId = RegionId
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
