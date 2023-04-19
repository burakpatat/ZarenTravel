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
    public class ServicesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public ServicesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Services Services)
    {
        try
        {
            return connection.Insert(Services);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Services Services)
    {
        try
        {
       return  connection.Update(Services);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Services Services)
        {
            try
            {
            return  connection.Delete<Services>(Services);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<Services> GetAll(){
            try
            {
                return connection.Query<Services>("ServicesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Services> GetByApiId(int ApiId){
            try
            {
                return connection.Query<Services>("ServicesGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Services> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<Services>("ServicesGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Services> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<Services>("ServicesGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Services> GetByExplanationsId(int ExplanationsId){
            try
            {
                return connection.Query<Services>("ServicesGetByExplanationsId", new
                {
ExplanationsId = ExplanationsId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Services GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Services>("ServicesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Services> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<Services>("ServicesGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Services> GetByName(string Name){
            try
            {
                return connection.Query<Services>("ServicesGetByName", new
                {
Name = Name
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Services> GetByOffersId(int OffersId){
            try
            {
                return connection.Query<Services>("ServicesGetByOffersId", new
                {
OffersId = OffersId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Services> GetBySystemId(string SystemId){
            try
            {
                return connection.Query<Services>("ServicesGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Services> GetByThumbnail(string Thumbnail){
            try
            {
                return connection.Query<Services>("ServicesGetByThumbnail", new
                {
Thumbnail = Thumbnail
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Services> GetByThumbnailFull(string ThumbnailFull){
            try
            {
                return connection.Query<Services>("ServicesGetByThumbnailFull", new
                {
ThumbnailFull = ThumbnailFull
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Services> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<Services>("ServicesGetCreatedDateBetween", new
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
