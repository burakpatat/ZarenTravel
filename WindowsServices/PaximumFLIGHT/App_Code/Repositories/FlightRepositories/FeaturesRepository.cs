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
    public class FeaturesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public FeaturesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Features Features)
    {
        try
        {
            return connection.Insert(Features);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Features Features)
    {
        try
        {
       return  connection.Update(Features);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Features Features)
        {
            try
            {
            return  connection.Delete<Features>(Features);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<Features> GetAll(){
            try
            {
                return connection.Query<Features>("FeaturesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Features> GetByApiId(int ApiId){
            try
            {
                return connection.Query<Features>("FeaturesGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Features> GetByCommercialName(string CommercialName){
            try
            {
                return connection.Query<Features>("FeaturesGetByCommercialName", new
                {
CommercialName = CommercialName
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Features> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<Features>("FeaturesGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Features> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<Features>("FeaturesGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Features> GetByFlightBrandsId(int FlightBrandsId){
            try
            {
                return connection.Query<Features>("FeaturesGetByFlightBrandsId", new
                {
FlightBrandsId = FlightBrandsId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Features GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Features>("FeaturesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Features> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<Features>("FeaturesGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Features> GetByPricingTypeId(int PricingTypeId){
            try
            {
                return connection.Query<Features>("FeaturesGetByPricingTypeId", new
                {
PricingTypeId = PricingTypeId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Features> GetByServiceGroupId(int ServiceGroupId){
            try
            {
                return connection.Query<Features>("FeaturesGetByServiceGroupId", new
                {
ServiceGroupId = ServiceGroupId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Features> GetBySystemId(string SystemId){
            try
            {
                return connection.Query<Features>("FeaturesGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Features> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<Features>("FeaturesGetCreatedDateBetween", new
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
