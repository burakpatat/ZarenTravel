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
    public class CitiesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public CitiesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Cities Cities)
    {
        try
        {
            return connection.Insert(Cities);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Cities Cities)
    {
        try
        {
       return  connection.Update(Cities);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Cities Cities)
        {
            try
            {
            return  connection.Delete<Cities>(Cities);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<Cities> GetAll(){
            try
            {
                return connection.Query<Cities>("CitiesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Cities> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<Cities>("CitiesGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Cities> GetByApiId(int ApiId){
            try
            {
                return connection.Query<Cities>("CitiesGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Cities> GetByCityId(int CityId){
            try
            {
                return connection.Query<Cities>("CitiesGetByCityId", new
                {
CityId = CityId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Cities> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<Cities>("CitiesGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Cities> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<Cities>("CitiesGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Cities GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Cities>("CitiesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Cities> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<Cities>("CitiesGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Cities> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<Cities>("CitiesGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Cities> GetByName(string Name){
            try
            {
                return connection.Query<Cities>("CitiesGetByName", new
                {
Name = Name
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Cities> GetBySystemId(int SystemId){
            try
            {
                return connection.Query<Cities>("CitiesGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Cities> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<Cities>("CitiesGetCreatedDateBetween", new
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
