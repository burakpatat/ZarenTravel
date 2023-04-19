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
    public class CitiesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public CitiesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Cities Cities)
    {
        try
        {
            return connection.Insert(Cities);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Cities Cities)
    {
        try
        {
       return  connection.Update(Cities);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Cities Cities)
        {
            try
            {
            return  connection.Delete<Cities>(Cities);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<Cities> GetAll(){
            try
            {
                return connection.Query<Cities>("CitiesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Cities GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Cities>("CitiesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Cities> GetByLatitude(decimal Latitude){
            try
            {
                return connection.Query<Cities>("CitiesGetByLatitude", new
                {
Latitude = Latitude
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Cities> GetByLongitude(decimal Longitude){
            try
            {
                return connection.Query<Cities>("CitiesGetByLongitude", new
                {
Longitude = Longitude
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Cities> GetByName(string Name){
            try
            {
                return connection.Query<Cities>("CitiesGetByName", new
                {
Name = Name
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
