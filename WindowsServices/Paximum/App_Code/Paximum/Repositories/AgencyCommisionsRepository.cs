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
    public class AgencyCommisionsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AgencyCommisionsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(AgencyCommisions AgencyCommisions)
    {
        try
        {
            return connection.Insert(AgencyCommisions);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(AgencyCommisions AgencyCommisions)
    {
        try
        {
       return  connection.Update(AgencyCommisions);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(AgencyCommisions AgencyCommisions)
        {
            try
            {
            return  connection.Delete<AgencyCommisions>(AgencyCommisions);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<AgencyCommisions> GetAll(){
            try
            {
                return connection.Query<AgencyCommisions>("AgencyCommisionsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyCommisions> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<AgencyCommisions>("AgencyCommisionsGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyCommisions> GetByAmount(decimal Amount){
            try
            {
                return connection.Query<AgencyCommisions>("AgencyCommisionsGetByAmount", new
                {
Amount = Amount
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyCommisions> GetByApiId(int ApiId){
            try
            {
                return connection.Query<AgencyCommisions>("AgencyCommisionsGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyCommisions> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<AgencyCommisions>("AgencyCommisionsGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyCommisions> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<AgencyCommisions>("AgencyCommisionsGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyCommisions> GetByCurrency(string Currency){
            try
            {
                return connection.Query<AgencyCommisions>("AgencyCommisionsGetByCurrency", new
                {
Currency = Currency
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public AgencyCommisions GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<AgencyCommisions>("AgencyCommisionsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyCommisions> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<AgencyCommisions>("AgencyCommisionsGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyCommisions> GetByPercents(int? Percents){
            try
            {
                return connection.Query<AgencyCommisions>("AgencyCommisionsGetByPercents", new
                {
Percents = Percents
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyCommisions> GetBySystemId(int SystemId){
            try
            {
                return connection.Query<AgencyCommisions>("AgencyCommisionsGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyCommisions> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<AgencyCommisions>("AgencyCommisionsGetCreatedDateBetween", new
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
