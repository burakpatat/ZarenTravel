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
    public class DealTypesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public DealTypesRepository(IConfiguration configuration)
        {
             strConnString = configuration.GetSection("ConnectionString").Value;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(DealTypes DealTypes)
    {
        try
        {
            return connection.Insert(DealTypes);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(DealTypes DealTypes)
    {
        try
        {
       return  connection.Update(DealTypes);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(DealTypes DealTypes)
        {
            try
            {
            return  connection.Delete<DealTypes>(DealTypes);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<DealTypes> GetAll(){
            try
            {
                return connection.Query<DealTypes>("DealTypesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public DealTypes GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<DealTypes>("DealTypesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<DealTypes> GetByName(int Name){
            try
            {
                return connection.Query<DealTypes>("DealTypesGetByName", new
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
