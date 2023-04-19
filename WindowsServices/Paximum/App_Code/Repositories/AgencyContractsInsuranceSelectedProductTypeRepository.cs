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
    public class AgencyContractsInsuranceSelectedProductTypeRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AgencyContractsInsuranceSelectedProductTypeRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(AgencyContractsInsuranceSelectedProductType AgencyContractsInsuranceSelectedProductType)
    {
        try
        {
            return connection.Insert(AgencyContractsInsuranceSelectedProductType);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(AgencyContractsInsuranceSelectedProductType AgencyContractsInsuranceSelectedProductType)
    {
        try
        {
       return  connection.Update(AgencyContractsInsuranceSelectedProductType);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(AgencyContractsInsuranceSelectedProductType AgencyContractsInsuranceSelectedProductType)
        {
            try
            {
            return  connection.Delete<AgencyContractsInsuranceSelectedProductType>(AgencyContractsInsuranceSelectedProductType);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<AgencyContractsInsuranceSelectedProductType> GetAll(){
            try
            {
                return connection.Query<AgencyContractsInsuranceSelectedProductType>("AgencyContractsInsuranceSelectedProductTypeGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public AgencyContractsInsuranceSelectedProductType GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<AgencyContractsInsuranceSelectedProductType>("AgencyContractsInsuranceSelectedProductTypeGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsInsuranceSelectedProductType> GetByInsuranceId(int InsuranceId){
            try
            {
                return connection.Query<AgencyContractsInsuranceSelectedProductType>("AgencyContractsInsuranceSelectedProductTypeGetByInsuranceId", new
                {
InsuranceId = InsuranceId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsInsuranceSelectedProductType> GetByProductTypeId(int ProductTypeId){
            try
            {
                return connection.Query<AgencyContractsInsuranceSelectedProductType>("AgencyContractsInsuranceSelectedProductTypeGetByProductTypeId", new
                {
ProductTypeId = ProductTypeId
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
