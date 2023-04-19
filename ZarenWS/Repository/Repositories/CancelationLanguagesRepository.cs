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
    public class CancelationLanguagesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public CancelationLanguagesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(CancelationLanguages CancelationLanguages)
    {
        try
        {
            return connection.Insert(CancelationLanguages);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(CancelationLanguages CancelationLanguages)
    {
        try
        {
       return  connection.Update(CancelationLanguages);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(CancelationLanguages CancelationLanguages)
        {
            try
            {
            return  connection.Delete<CancelationLanguages>(CancelationLanguages);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<CancelationLanguages> GetAll(){
            try
            {
                return connection.Query<CancelationLanguages>("CancelationLanguagesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CancelationLanguages> GetByCancelationRulesId(int CancelationRulesId){
            try
            {
                return connection.Query<CancelationLanguages>("CancelationLanguagesGetByCancelationRulesId", new
                {
CancelationRulesId = CancelationRulesId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CancelationLanguages> GetByDescription(string Description){
            try
            {
                return connection.Query<CancelationLanguages>("CancelationLanguagesGetByDescription", new
                {
Description = Description
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public CancelationLanguages GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<CancelationLanguages>("CancelationLanguagesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CancelationLanguages> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<CancelationLanguages>("CancelationLanguagesGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CancelationLanguages> GetByName(string Name){
            try
            {
                return connection.Query<CancelationLanguages>("CancelationLanguagesGetByName", new
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
