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
    public class LanguageRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public LanguageRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Language Language)
    {
        try
        {
            return connection.Insert(Language);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Language Language)
    {
        try
        {
       return  connection.Update(Language);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Language Language)
        {
            try
            {
            return  connection.Delete<Language>(Language);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<Language> GetAll(){
            try
            {
                return connection.Query<Language>("LanguageGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Language> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<Language>("LanguageGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Language> GetByDe(string De){
            try
            {
                return connection.Query<Language>("LanguageGetByDe", new
                {
De = De
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Language> GetByEn(string En){
            try
            {
                return connection.Query<Language>("LanguageGetByEn", new
                {
En = En
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Language> GetByEs(string Es){
            try
            {
                return connection.Query<Language>("LanguageGetByEs", new
                {
Es = Es
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Language> GetByFr(string Fr){
            try
            {
                return connection.Query<Language>("LanguageGetByFr", new
                {
Fr = Fr
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Language GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Language>("LanguageGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Language> GetByIt(string It){
            try
            {
                return connection.Query<Language>("LanguageGetByIt", new
                {
It = It
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Language> GetByShortCode(string ShortCode){
            try
            {
                return connection.Query<Language>("LanguageGetByShortCode", new
                {
ShortCode = ShortCode
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Language> GetByTr(string Tr){
            try
            {
                return connection.Query<Language>("LanguageGetByTr", new
                {
Tr = Tr
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
