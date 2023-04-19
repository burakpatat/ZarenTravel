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
    public class SupplierSellingDestinationsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public SupplierSellingDestinationsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(SupplierSellingDestinations SupplierSellingDestinations)
    {
        try
        {
            return connection.Insert(SupplierSellingDestinations);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(SupplierSellingDestinations SupplierSellingDestinations)
    {
        try
        {
       return  connection.Update(SupplierSellingDestinations);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(SupplierSellingDestinations SupplierSellingDestinations)
        {
            try
            {
            return  connection.Delete<SupplierSellingDestinations>(SupplierSellingDestinations);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<SupplierSellingDestinations> GetAll(){
            try
            {
                return connection.Query<SupplierSellingDestinations>("SupplierSellingDestinationsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SupplierSellingDestinations> GetByCity(int City){
            try
            {
                return connection.Query<SupplierSellingDestinations>("SupplierSellingDestinationsGetByCity", new
                {
City = City
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SupplierSellingDestinations> GetByCountry(int Country){
            try
            {
                return connection.Query<SupplierSellingDestinations>("SupplierSellingDestinationsGetByCountry", new
                {
Country = Country
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SupplierSellingDestinations> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<SupplierSellingDestinations>("SupplierSellingDestinationsGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SupplierSellingDestinations> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<SupplierSellingDestinations>("SupplierSellingDestinationsGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public SupplierSellingDestinations GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<SupplierSellingDestinations>("SupplierSellingDestinationsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SupplierSellingDestinations> GetBySupplierId(int SupplierId){
            try
            {
                return connection.Query<SupplierSellingDestinations>("SupplierSellingDestinationsGetBySupplierId", new
                {
SupplierId = SupplierId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SupplierSellingDestinations> GetByTableOrder(int TableOrder){
            try
            {
                return connection.Query<SupplierSellingDestinations>("SupplierSellingDestinationsGetByTableOrder", new
                {
TableOrder = TableOrder
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SupplierSellingDestinations> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<SupplierSellingDestinations>("SupplierSellingDestinationsGetCreatedDateBetween", new
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
