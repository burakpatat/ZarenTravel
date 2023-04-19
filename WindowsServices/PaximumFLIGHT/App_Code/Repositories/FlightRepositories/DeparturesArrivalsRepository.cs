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
    public class DeparturesArrivalsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public DeparturesArrivalsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(DeparturesArrivals DeparturesArrivals)
    {
        try
        {
            return connection.Insert(DeparturesArrivals);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(DeparturesArrivals DeparturesArrivals)
    {
        try
        {
       return  connection.Update(DeparturesArrivals);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(DeparturesArrivals DeparturesArrivals)
        {
            try
            {
            return  connection.Delete<DeparturesArrivals>(DeparturesArrivals);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<DeparturesArrivals> GetAll(){
            try
            {
                return connection.Query<DeparturesArrivals>("DeparturesArrivalsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<DeparturesArrivals> GetByAirPortsId(int AirPortsId){
            try
            {
                return connection.Query<DeparturesArrivals>("DeparturesArrivalsGetByAirPortsId", new
                {
AirPortsId = AirPortsId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<DeparturesArrivals> GetByApiId(int ApiId){
            try
            {
                return connection.Query<DeparturesArrivals>("DeparturesArrivalsGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<DeparturesArrivals> GetByCityId(int CityId){
            try
            {
                return connection.Query<DeparturesArrivals>("DeparturesArrivalsGetByCityId", new
                {
CityId = CityId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<DeparturesArrivals> GetByCountryId(int CountryId){
            try
            {
                return connection.Query<DeparturesArrivals>("DeparturesArrivalsGetByCountryId", new
                {
CountryId = CountryId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<DeparturesArrivals> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<DeparturesArrivals>("DeparturesArrivalsGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<DeparturesArrivals> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<DeparturesArrivals>("DeparturesArrivalsGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<DeparturesArrivals> GetByDate(DateTime Date){
            try
            {
                return connection.Query<DeparturesArrivals>("DeparturesArrivalsGetByDate", new
                {
Date = Date
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<DeparturesArrivals> GetByGeoLocationId(int GeoLocationId){
            try
            {
                return connection.Query<DeparturesArrivals>("DeparturesArrivalsGetByGeoLocationId", new
                {
GeoLocationId = GeoLocationId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public DeparturesArrivals GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<DeparturesArrivals>("DeparturesArrivalsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<DeparturesArrivals> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<DeparturesArrivals>("DeparturesArrivalsGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<DeparturesArrivals> GetBySystemId(string SystemId){
            try
            {
                return connection.Query<DeparturesArrivals>("DeparturesArrivalsGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<DeparturesArrivals> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<DeparturesArrivals>("DeparturesArrivalsGetCreatedDateBetween", new
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
public List<DeparturesArrivals> GetDateBetween(DateTime DateStart,DateTime DateEnd){
            try
            {
                return connection.Query<DeparturesArrivals>("DeparturesArrivalsGetDateBetween", new
                {
DateStart = DateStart
,DateEnd = DateEnd
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
