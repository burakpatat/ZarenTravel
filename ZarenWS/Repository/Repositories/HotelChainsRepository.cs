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
    public class HotelChainsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public HotelChainsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(HotelChains HotelChains)
    {
        try
        {
            return connection.Insert(HotelChains);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(HotelChains HotelChains)
    {
        try
        {
       return  connection.Update(HotelChains);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(HotelChains HotelChains)
        {
            try
            {
            return  connection.Delete<HotelChains>(HotelChains);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<HotelChains> GetAll(){
            try
            {
                return connection.Query<HotelChains>("HotelChainsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public HotelChains GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<HotelChains>("HotelChainsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelChains> GetByName(string Name){
            try
            {
                return connection.Query<HotelChains>("HotelChainsGetByName", new
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
