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
    public class HotelSeasonsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public HotelSeasonsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(HotelSeasons HotelSeasons)
    {
        try
        {
            return connection.Insert(HotelSeasons);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(HotelSeasons HotelSeasons)
    {
        try
        {
       return  connection.Update(HotelSeasons);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(HotelSeasons HotelSeasons)
        {
            try
            {
            return  connection.Delete<HotelSeasons>(HotelSeasons);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<HotelSeasons> GetAll(){
            try
            {
                return connection.Query<HotelSeasons>("HotelSeasonsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelSeasons> GetBeginDateBetween(DateTime BeginDateStart,DateTime BeginDateEnd){
            try
            {
                return connection.Query<HotelSeasons>("HotelSeasonsGetBeginDateBetween", new
                {
BeginDateStart = BeginDateStart
,BeginDateEnd = BeginDateEnd
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelSeasons> GetByApiId(int ApiId){
            try
            {
                return connection.Query<HotelSeasons>("HotelSeasonsGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelSeasons> GetByBeginDate(DateTime BeginDate){
            try
            {
                return connection.Query<HotelSeasons>("HotelSeasonsGetByBeginDate", new
                {
BeginDate = BeginDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelSeasons> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<HotelSeasons>("HotelSeasonsGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelSeasons> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<HotelSeasons>("HotelSeasonsGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelSeasons> GetByEndDate(DateTime EndDate){
            try
            {
                return connection.Query<HotelSeasons>("HotelSeasonsGetByEndDate", new
                {
EndDate = EndDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelSeasons> GetByHotelId(int HotelId){
            try
            {
                return connection.Query<HotelSeasons>("HotelSeasonsGetByHotelId", new
                {
HotelId = HotelId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public HotelSeasons GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<HotelSeasons>("HotelSeasonsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelSeasons> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<HotelSeasons>("HotelSeasonsGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelSeasons> GetByName(string Name){
            try
            {
                return connection.Query<HotelSeasons>("HotelSeasonsGetByName", new
                {
Name = Name
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelSeasons> GetBySystemId(string SystemId){
            try
            {
                return connection.Query<HotelSeasons>("HotelSeasonsGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelSeasons> GetByType(int Type){
            try
            {
                return connection.Query<HotelSeasons>("HotelSeasonsGetByType", new
                {
Type = Type
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelSeasons> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<HotelSeasons>("HotelSeasonsGetCreatedDateBetween", new
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
public List<HotelSeasons> GetEndDateBetween(DateTime EndDateStart,DateTime EndDateEnd){
            try
            {
                return connection.Query<HotelSeasons>("HotelSeasonsGetEndDateBetween", new
                {
EndDateStart = EndDateStart
,EndDateEnd = EndDateEnd
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
