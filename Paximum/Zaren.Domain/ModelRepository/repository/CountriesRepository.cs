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
    public class CountriesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public CountriesRepository(IConfiguration configuration)
        {
             strConnString = configuration.GetSection("ConnectionString").Value;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Countries Countries)
    {
        try
        {
            return connection.Insert(Countries);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Countries Countries)
    {
        try
        {
       return  connection.Update(Countries);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Countries Countries)
        {
            try
            {
            return  connection.Delete<Countries>(Countries);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<Countries> GetAll(){
            try
            {
                return connection.Query<Countries>("CountriesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Countries GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Countries>("CountriesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Countries> GetByLatLongBounds(string LatLongBounds){
            try
            {
                return connection.Query<Countries>("CountriesGetByLatLongBounds", new
                {
LatLongBounds = LatLongBounds
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Countries> GetByName(string Name){
            try
            {
                return connection.Query<Countries>("CountriesGetByName", new
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
