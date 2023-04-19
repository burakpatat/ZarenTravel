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
    public class SupplierRegisteredProductsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public SupplierRegisteredProductsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(SupplierRegisteredProducts SupplierRegisteredProducts)
    {
        try
        {
            return connection.Insert(SupplierRegisteredProducts);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(SupplierRegisteredProducts SupplierRegisteredProducts)
    {
        try
        {
       return  connection.Update(SupplierRegisteredProducts);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(SupplierRegisteredProducts SupplierRegisteredProducts)
        {
            try
            {
            return  connection.Delete<SupplierRegisteredProducts>(SupplierRegisteredProducts);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<SupplierRegisteredProducts> GetAll(){
            try
            {
                return connection.Query<SupplierRegisteredProducts>("SupplierRegisteredProductsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SupplierRegisteredProducts> GetByContractInfo(string ContractInfo){
            try
            {
                return connection.Query<SupplierRegisteredProducts>("SupplierRegisteredProductsGetByContractInfo", new
                {
ContractInfo = ContractInfo
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SupplierRegisteredProducts> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<SupplierRegisteredProducts>("SupplierRegisteredProductsGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SupplierRegisteredProducts> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<SupplierRegisteredProducts>("SupplierRegisteredProductsGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SupplierRegisteredProducts> GetByFee(int Fee){
            try
            {
                return connection.Query<SupplierRegisteredProducts>("SupplierRegisteredProductsGetByFee", new
                {
Fee = Fee
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public SupplierRegisteredProducts GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<SupplierRegisteredProducts>("SupplierRegisteredProductsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SupplierRegisteredProducts> GetByProductTypeId(int ProductTypeId){
            try
            {
                return connection.Query<SupplierRegisteredProducts>("SupplierRegisteredProductsGetByProductTypeId", new
                {
ProductTypeId = ProductTypeId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SupplierRegisteredProducts> GetBySupplierId(int SupplierId){
            try
            {
                return connection.Query<SupplierRegisteredProducts>("SupplierRegisteredProductsGetBySupplierId", new
                {
SupplierId = SupplierId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SupplierRegisteredProducts> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<SupplierRegisteredProducts>("SupplierRegisteredProductsGetCreatedDateBetween", new
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
