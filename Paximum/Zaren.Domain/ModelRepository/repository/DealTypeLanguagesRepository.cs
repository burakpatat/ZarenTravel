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
using Microsoft.Extensions.Configuration;
    public class DealTypeLanguagesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public DealTypeLanguagesRepository(IConfiguration configuration)
        {
             strConnString = configuration.GetSection("ConnectionString").Value;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(DealTypeLanguages DealTypeLanguages)
    {
        try
        {
            return connection.Insert(DealTypeLanguages);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(DealTypeLanguages DealTypeLanguages)
    {
        try
        {
       return  connection.Update(DealTypeLanguages);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(DealTypeLanguages DealTypeLanguages)
        {
            try
            {
            return  connection.Delete<DealTypeLanguages>(DealTypeLanguages);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<DealTypeLanguages> GetAll(){
            try
            {
                return connection.Query<DealTypeLanguages>("DealTypeLanguagesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<DealTypeLanguages> GetByDealTypeId(int DealTypeId){
            try
            {
                return connection.Query<DealTypeLanguages>("DealTypeLanguagesGetByDealTypeId", new
                {
DealTypeId = DealTypeId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<DealTypeLanguages> GetByDescription(string Description){
            try
            {
                return connection.Query<DealTypeLanguages>("DealTypeLanguagesGetByDescription", new
                {
Description = Description
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public DealTypeLanguages GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<DealTypeLanguages>("DealTypeLanguagesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<DealTypeLanguages> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<DealTypeLanguages>("DealTypeLanguagesGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<DealTypeLanguages> GetByName(string Name){
            try
            {
                return connection.Query<DealTypeLanguages>("DealTypeLanguagesGetByName", new
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
