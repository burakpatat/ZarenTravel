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
    public class SupplierProductTypeRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public SupplierProductTypeRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(SupplierProductType SupplierProductType)
    {
        try
        {
            return connection.Insert(SupplierProductType);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(SupplierProductType SupplierProductType)
    {
        try
        {
       return  connection.Update(SupplierProductType);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(SupplierProductType SupplierProductType)
        {
            try
            {
            return  connection.Delete<SupplierProductType>(SupplierProductType);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<SupplierProductType> GetAll(){
            try
            {
                return connection.Query<SupplierProductType>("SupplierProductTypeGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SupplierProductType> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<SupplierProductType>("SupplierProductTypeGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SupplierProductType> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<SupplierProductType>("SupplierProductTypeGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public SupplierProductType GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<SupplierProductType>("SupplierProductTypeGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SupplierProductType> GetByName(string Name){
            try
            {
                return connection.Query<SupplierProductType>("SupplierProductTypeGetByName", new
                {
Name = Name
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SupplierProductType> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<SupplierProductType>("SupplierProductTypeGetCreatedDateBetween", new
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
