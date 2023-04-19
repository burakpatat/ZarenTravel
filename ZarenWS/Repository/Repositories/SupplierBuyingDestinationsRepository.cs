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
    public class SupplierBuyingDestinationsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public SupplierBuyingDestinationsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(SupplierBuyingDestinations SupplierBuyingDestinations)
    {
        try
        {
            return connection.Insert(SupplierBuyingDestinations);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(SupplierBuyingDestinations SupplierBuyingDestinations)
    {
        try
        {
       return  connection.Update(SupplierBuyingDestinations);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(SupplierBuyingDestinations SupplierBuyingDestinations)
        {
            try
            {
            return  connection.Delete<SupplierBuyingDestinations>(SupplierBuyingDestinations);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<SupplierBuyingDestinations> GetAll(){
            try
            {
                return connection.Query<SupplierBuyingDestinations>("SupplierBuyingDestinationsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SupplierBuyingDestinations> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<SupplierBuyingDestinations>("SupplierBuyingDestinationsGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SupplierBuyingDestinations> GetByCity(int City){
            try
            {
                return connection.Query<SupplierBuyingDestinations>("SupplierBuyingDestinationsGetByCity", new
                {
City = City
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SupplierBuyingDestinations> GetByCountry(int Country){
            try
            {
                return connection.Query<SupplierBuyingDestinations>("SupplierBuyingDestinationsGetByCountry", new
                {
Country = Country
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SupplierBuyingDestinations> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<SupplierBuyingDestinations>("SupplierBuyingDestinationsGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SupplierBuyingDestinations> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<SupplierBuyingDestinations>("SupplierBuyingDestinationsGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public SupplierBuyingDestinations GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<SupplierBuyingDestinations>("SupplierBuyingDestinationsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SupplierBuyingDestinations> GetByTableOrder(int TableOrder){
            try
            {
                return connection.Query<SupplierBuyingDestinations>("SupplierBuyingDestinationsGetByTableOrder", new
                {
TableOrder = TableOrder
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SupplierBuyingDestinations> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<SupplierBuyingDestinations>("SupplierBuyingDestinationsGetCreatedDateBetween", new
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
