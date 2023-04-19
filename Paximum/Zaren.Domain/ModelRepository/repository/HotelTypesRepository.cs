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
    public class HotelTypesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public HotelTypesRepository(IConfiguration configuration)
        {
             strConnString = configuration.GetSection("ConnectionString").Value;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(HotelTypes HotelTypes)
    {
        try
        {
            return connection.Insert(HotelTypes);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(HotelTypes HotelTypes)
    {
        try
        {
       return  connection.Update(HotelTypes);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(HotelTypes HotelTypes)
        {
            try
            {
            return  connection.Delete<HotelTypes>(HotelTypes);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<HotelTypes> GetAll(){
            try
            {
                return connection.Query<HotelTypes>("HotelTypesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public HotelTypes GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<HotelTypes>("HotelTypesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelTypes> GetByName(string Name){
            try
            {
                return connection.Query<HotelTypes>("HotelTypesGetByName", new
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
