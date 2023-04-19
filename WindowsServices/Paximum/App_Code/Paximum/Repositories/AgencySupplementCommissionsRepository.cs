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
    public class AgencySupplementCommissionsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AgencySupplementCommissionsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(AgencySupplementCommissions AgencySupplementCommissions)
    {
        try
        {
            return connection.Insert(AgencySupplementCommissions);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(AgencySupplementCommissions AgencySupplementCommissions)
    {
        try
        {
       return  connection.Update(AgencySupplementCommissions);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(AgencySupplementCommissions AgencySupplementCommissions)
        {
            try
            {
            return  connection.Delete<AgencySupplementCommissions>(AgencySupplementCommissions);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<AgencySupplementCommissions> GetAll(){
            try
            {
                return connection.Query<AgencySupplementCommissions>("AgencySupplementCommissionsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencySupplementCommissions> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<AgencySupplementCommissions>("AgencySupplementCommissionsGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencySupplementCommissions> GetByAmount(decimal Amount){
            try
            {
                return connection.Query<AgencySupplementCommissions>("AgencySupplementCommissionsGetByAmount", new
                {
Amount = Amount
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencySupplementCommissions> GetByApiId(int ApiId){
            try
            {
                return connection.Query<AgencySupplementCommissions>("AgencySupplementCommissionsGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencySupplementCommissions> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<AgencySupplementCommissions>("AgencySupplementCommissionsGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencySupplementCommissions> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<AgencySupplementCommissions>("AgencySupplementCommissionsGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencySupplementCommissions> GetByCurrency(string Currency){
            try
            {
                return connection.Query<AgencySupplementCommissions>("AgencySupplementCommissionsGetByCurrency", new
                {
Currency = Currency
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public AgencySupplementCommissions GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<AgencySupplementCommissions>("AgencySupplementCommissionsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencySupplementCommissions> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<AgencySupplementCommissions>("AgencySupplementCommissionsGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencySupplementCommissions> GetByPercents(int Percents){
            try
            {
                return connection.Query<AgencySupplementCommissions>("AgencySupplementCommissionsGetByPercents", new
                {
Percents = Percents
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencySupplementCommissions> GetBySystemId(int SystemId){
            try
            {
                return connection.Query<AgencySupplementCommissions>("AgencySupplementCommissionsGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencySupplementCommissions> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<AgencySupplementCommissions>("AgencySupplementCommissionsGetCreatedDateBetween", new
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
