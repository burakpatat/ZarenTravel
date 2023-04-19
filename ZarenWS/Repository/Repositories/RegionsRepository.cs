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
    public class RegionsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public RegionsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Regions Regions)
    {
        try
        {
            return connection.Insert(Regions);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Regions Regions)
    {
        try
        {
       return  connection.Update(Regions);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Regions Regions)
        {
            try
            {
            return  connection.Delete<Regions>(Regions);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<Regions> GetAll(){
            try
            {
                return connection.Query<Regions>("RegionsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Regions> GetByCountryId(int CountryId){
            try
            {
                return connection.Query<Regions>("RegionsGetByCountryId", new
                {
CountryId = CountryId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Regions GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Regions>("RegionsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Regions> GetByLatLongBounds(string LatLongBounds){
            try
            {
                return connection.Query<Regions>("RegionsGetByLatLongBounds", new
                {
LatLongBounds = LatLongBounds
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Regions> GetByName(string Name){
            try
            {
                return connection.Query<Regions>("RegionsGetByName", new
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
