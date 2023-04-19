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
    public class PNRsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public PNRsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(PNRs PNRs)
    {
        try
        {
            return connection.Insert(PNRs);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(PNRs PNRs)
    {
        try
        {
       return  connection.Update(PNRs);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(PNRs PNRs)
        {
            try
            {
            return  connection.Delete<PNRs>(PNRs);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<PNRs> GetAll(){
            try
            {
                return connection.Query<PNRs>("PNRsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PNRs> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<PNRs>("PNRsGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PNRs> GetByCompanyId(int CompanyId){
            try
            {
                return connection.Query<PNRs>("PNRsGetByCompanyId", new
                {
CompanyId = CompanyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public PNRs GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<PNRs>("PNRsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PNRs> GetByPassengerId(int PassengerId){
            try
            {
                return connection.Query<PNRs>("PNRsGetByPassengerId", new
                {
PassengerId = PassengerId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PNRs> GetByPCCId(int PCCId){
            try
            {
                return connection.Query<PNRs>("PNRsGetByPCCId", new
                {
PCCId = PCCId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PNRs> GetByPNRActive(bool PNRActive){
            try
            {
                return connection.Query<PNRs>("PNRsGetByPNRActive", new
                {
PNRActive = PNRActive
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PNRs> GetByPNRRecord(string PNRRecord){
            try
            {
                return connection.Query<PNRs>("PNRsGetByPNRRecord", new
                {
PNRRecord = PNRRecord
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PNRs> GetByPNRTimestamp(DateTime PNRTimestamp){
            try
            {
                return connection.Query<PNRs>("PNRsGetByPNRTimestamp", new
                {
PNRTimestamp = PNRTimestamp
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PNRs> GetPNRTimestampBetween(DateTime PNRTimestampStart,DateTime PNRTimestampEnd){
            try
            {
                return connection.Query<PNRs>("PNRsGetPNRTimestampBetween", new
                {
PNRTimestampStart = PNRTimestampStart
,PNRTimestampEnd = PNRTimestampEnd
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
