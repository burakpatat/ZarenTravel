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
    public class AgencyContractsInsuranceTypeRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AgencyContractsInsuranceTypeRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(AgencyContractsInsuranceType AgencyContractsInsuranceType)
    {
        try
        {
            return connection.Insert(AgencyContractsInsuranceType);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(AgencyContractsInsuranceType AgencyContractsInsuranceType)
    {
        try
        {
       return  connection.Update(AgencyContractsInsuranceType);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(AgencyContractsInsuranceType AgencyContractsInsuranceType)
        {
            try
            {
            return  connection.Delete<AgencyContractsInsuranceType>(AgencyContractsInsuranceType);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<AgencyContractsInsuranceType> GetAll(){
            try
            {
                return connection.Query<AgencyContractsInsuranceType>("AgencyContractsInsuranceTypeGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public AgencyContractsInsuranceType GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<AgencyContractsInsuranceType>("AgencyContractsInsuranceTypeGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsInsuranceType> GetByName(string Name){
            try
            {
                return connection.Query<AgencyContractsInsuranceType>("AgencyContractsInsuranceTypeGetByName", new
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
