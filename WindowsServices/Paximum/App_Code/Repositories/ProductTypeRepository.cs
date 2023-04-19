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
    public class ProductTypeRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public ProductTypeRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(ProductType ProductType)
    {
        try
        {
            return connection.Insert(ProductType);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(ProductType ProductType)
    {
        try
        {
       return  connection.Update(ProductType);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(ProductType ProductType)
        {
            try
            {
            return  connection.Delete<ProductType>(ProductType);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<ProductType> GetAll(){
            try
            {
                return connection.Query<ProductType>("ProductTypeGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<ProductType> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<ProductType>("ProductTypeGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<ProductType> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<ProductType>("ProductTypeGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<ProductType> GetByForMarketPlace(bool ForMarketPlace){
            try
            {
                return connection.Query<ProductType>("ProductTypeGetByForMarketPlace", new
                {
ForMarketPlace = ForMarketPlace
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public ProductType GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<ProductType>("ProductTypeGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<ProductType> GetByName(string Name){
            try
            {
                return connection.Query<ProductType>("ProductTypeGetByName", new
                {
Name = Name
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<ProductType> GetByTableOrder(int TableOrder){
            try
            {
                return connection.Query<ProductType>("ProductTypeGetByTableOrder", new
                {
TableOrder = TableOrder
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<ProductType> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<ProductType>("ProductTypeGetCreatedDateBetween", new
                {
CreatedDateStart = CreatedDateStart
,CreatedDateEnd = CreatedDateEnd
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
