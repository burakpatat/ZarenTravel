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
    public class HotelDescriptionsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public HotelDescriptionsRepository(IConfiguration configuration)
        {
             strConnString = configuration.GetSection("ConnectionString").Value;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(HotelDescriptions HotelDescriptions)
    {
        try
        {
            return connection.Insert(HotelDescriptions);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(HotelDescriptions HotelDescriptions)
    {
        try
        {
       return  connection.Update(HotelDescriptions);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(HotelDescriptions HotelDescriptions)
        {
            try
            {
            return  connection.Delete<HotelDescriptions>(HotelDescriptions);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<HotelDescriptions> GetAll(){
            try
            {
                return connection.Query<HotelDescriptions>("HotelDescriptionsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelDescriptions> GetByDescription(string Description){
            try
            {
                return connection.Query<HotelDescriptions>("HotelDescriptionsGetByDescription", new
                {
Description = Description
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelDescriptions> GetByHotelId(int HotelId){
            try
            {
                return connection.Query<HotelDescriptions>("HotelDescriptionsGetByHotelId", new
                {
HotelId = HotelId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public HotelDescriptions GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<HotelDescriptions>("HotelDescriptionsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelDescriptions> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<HotelDescriptions>("HotelDescriptionsGetByLanguageId", new
                {
LanguageId = LanguageId
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
