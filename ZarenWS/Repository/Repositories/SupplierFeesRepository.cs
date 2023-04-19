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
    public class SupplierFeesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public SupplierFeesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(SupplierFees SupplierFees)
    {
        try
        {
            return connection.Insert(SupplierFees);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(SupplierFees SupplierFees)
    {
        try
        {
       return  connection.Update(SupplierFees);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(SupplierFees SupplierFees)
        {
            try
            {
            return  connection.Delete<SupplierFees>(SupplierFees);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<SupplierFees> GetAll(){
            try
            {
                return connection.Query<SupplierFees>("SupplierFeesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SupplierFees> GetByAmount(int Amount){
            try
            {
                return connection.Query<SupplierFees>("SupplierFeesGetByAmount", new
                {
Amount = Amount
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SupplierFees> GetByByPercentage(bool ByPercentage){
            try
            {
                return connection.Query<SupplierFees>("SupplierFeesGetByByPercentage", new
                {
ByPercentage = ByPercentage
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SupplierFees> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<SupplierFees>("SupplierFeesGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SupplierFees> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<SupplierFees>("SupplierFeesGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SupplierFees> GetByCurrencyId(int CurrencyId){
            try
            {
                return connection.Query<SupplierFees>("SupplierFeesGetByCurrencyId", new
                {
CurrencyId = CurrencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public SupplierFees GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<SupplierFees>("SupplierFeesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SupplierFees> GetByProductId(int ProductId){
            try
            {
                return connection.Query<SupplierFees>("SupplierFeesGetByProductId", new
                {
ProductId = ProductId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SupplierFees> GetBySupplierId(int SupplierId){
            try
            {
                return connection.Query<SupplierFees>("SupplierFeesGetBySupplierId", new
                {
SupplierId = SupplierId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SupplierFees> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<SupplierFees>("SupplierFeesGetCreatedDateBetween", new
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
