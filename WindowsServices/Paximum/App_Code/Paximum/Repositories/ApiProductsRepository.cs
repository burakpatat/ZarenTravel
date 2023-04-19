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
    public class ApiProductsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public ApiProductsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(ApiProducts ApiProducts)
    {
        try
        {
            return connection.Insert(ApiProducts);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(ApiProducts ApiProducts)
    {
        try
        {
       return  connection.Update(ApiProducts);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(ApiProducts ApiProducts)
        {
            try
            {
            return  connection.Delete<ApiProducts>(ApiProducts);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<ApiProducts> GetAll(){
            try
            {
                return connection.Query<ApiProducts>("ApiProductsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<ApiProducts> GetByApiId(int ApiId){
            try
            {
                return connection.Query<ApiProducts>("ApiProductsGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public ApiProducts GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<ApiProducts>("ApiProductsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<ApiProducts> GetByProductType(int ProductType){
            try
            {
                return connection.Query<ApiProducts>("ApiProductsGetByProductType", new
                {
ProductType = ProductType
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
