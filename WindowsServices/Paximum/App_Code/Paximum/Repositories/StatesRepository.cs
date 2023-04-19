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
    public class StatesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public StatesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(States States)
    {
        try
        {
            return connection.Insert(States);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(States States)
    {
        try
        {
       return  connection.Update(States);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(States States)
        {
            try
            {
            return  connection.Delete<States>(States);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<States> GetAll(){
            try
            {
                return connection.Query<States>("StatesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<States> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<States>("StatesGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<States> GetByApiId(int ApiId){
            try
            {
                return connection.Query<States>("StatesGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<States> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<States>("StatesGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<States> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<States>("StatesGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public States GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<States>("StatesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<States> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<States>("StatesGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<States> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<States>("StatesGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<States> GetByName(string Name){
            try
            {
                return connection.Query<States>("StatesGetByName", new
                {
Name = Name
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<States> GetByStateId(int StateId){
            try
            {
                return connection.Query<States>("StatesGetByStateId", new
                {
StateId = StateId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<States> GetBySystemId(string SystemId){
            try
            {
                return connection.Query<States>("StatesGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<States> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<States>("StatesGetCreatedDateBetween", new
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
