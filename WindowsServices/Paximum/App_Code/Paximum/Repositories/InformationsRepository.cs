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
    public class InformationsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public InformationsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Informations Informations)
    {
        try
        {
            return connection.Insert(Informations);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Informations Informations)
    {
        try
        {
       return  connection.Update(Informations);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Informations Informations)
        {
            try
            {
            return  connection.Delete<Informations>(Informations);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<Informations> GetAll(){
            try
            {
                return connection.Query<Informations>("InformationsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Informations> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<Informations>("InformationsGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Informations> GetByApiId(int ApiId){
            try
            {
                return connection.Query<Informations>("InformationsGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Informations> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<Informations>("InformationsGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Informations> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<Informations>("InformationsGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Informations GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Informations>("InformationsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Informations> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<Informations>("InformationsGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Informations> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<Informations>("InformationsGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Informations> GetByProductId(int ProductId){
            try
            {
                return connection.Query<Informations>("InformationsGetByProductId", new
                {
ProductId = ProductId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Informations> GetBySystemId(int SystemId){
            try
            {
                return connection.Query<Informations>("InformationsGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Informations> GetByTotal(int Total){
            try
            {
                return connection.Query<Informations>("InformationsGetByTotal", new
                {
Total = Total
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Informations> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<Informations>("InformationsGetCreatedDateBetween", new
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
