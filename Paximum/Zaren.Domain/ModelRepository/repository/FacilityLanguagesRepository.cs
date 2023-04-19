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
    public class FacilityLanguagesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public FacilityLanguagesRepository(IConfiguration configuration)
        {
             strConnString = configuration.GetSection("ConnectionString").Value;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(FacilityLanguages FacilityLanguages)
    {
        try
        {
            return connection.Insert(FacilityLanguages);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(FacilityLanguages FacilityLanguages)
    {
        try
        {
       return  connection.Update(FacilityLanguages);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(FacilityLanguages FacilityLanguages)
        {
            try
            {
            return  connection.Delete<FacilityLanguages>(FacilityLanguages);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<FacilityLanguages> GetAll(){
            try
            {
                return connection.Query<FacilityLanguages>("FacilityLanguagesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FacilityLanguages> GetByFacilityId(int FacilityId){
            try
            {
                return connection.Query<FacilityLanguages>("FacilityLanguagesGetByFacilityId", new
                {
FacilityId = FacilityId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public FacilityLanguages GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<FacilityLanguages>("FacilityLanguagesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FacilityLanguages> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<FacilityLanguages>("FacilityLanguagesGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FacilityLanguages> GetByName(string Name){
            try
            {
                return connection.Query<FacilityLanguages>("FacilityLanguagesGetByName", new
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
