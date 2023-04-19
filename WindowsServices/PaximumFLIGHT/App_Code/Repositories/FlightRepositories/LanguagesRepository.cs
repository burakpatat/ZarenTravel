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
    public class LanguagesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public LanguagesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Languages Languages)
    {
        try
        {
            return connection.Insert(Languages);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Languages Languages)
    {
        try
        {
       return  connection.Update(Languages);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Languages Languages)
        {
            try
            {
            return  connection.Delete<Languages>(Languages);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<Languages> GetAll(){
            try
            {
                return connection.Query<Languages>("LanguagesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Languages> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<Languages>("LanguagesGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Languages> GetByApiId(int ApiId){
            try
            {
                return connection.Query<Languages>("LanguagesGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Languages> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<Languages>("LanguagesGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Languages> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<Languages>("LanguagesGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Languages> GetByDe(string De){
            try
            {
                return connection.Query<Languages>("LanguagesGetByDe", new
                {
De = De
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Languages> GetByEn(string En){
            try
            {
                return connection.Query<Languages>("LanguagesGetByEn", new
                {
En = En
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Languages> GetByEs(string Es){
            try
            {
                return connection.Query<Languages>("LanguagesGetByEs", new
                {
Es = Es
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Languages> GetByFr(string Fr){
            try
            {
                return connection.Query<Languages>("LanguagesGetByFr", new
                {
Fr = Fr
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Languages GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Languages>("LanguagesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Languages> GetByIt(string It){
            try
            {
                return connection.Query<Languages>("LanguagesGetByIt", new
                {
It = It
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Languages> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<Languages>("LanguagesGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Languages> GetByShortCode(string ShortCode){
            try
            {
                return connection.Query<Languages>("LanguagesGetByShortCode", new
                {
ShortCode = ShortCode
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Languages> GetBySystemId(string SystemId){
            try
            {
                return connection.Query<Languages>("LanguagesGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Languages> GetByTr(string Tr){
            try
            {
                return connection.Query<Languages>("LanguagesGetByTr", new
                {
Tr = Tr
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Languages> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<Languages>("LanguagesGetCreatedDateBetween", new
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
