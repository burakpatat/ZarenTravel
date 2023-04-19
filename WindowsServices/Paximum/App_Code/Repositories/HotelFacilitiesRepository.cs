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
    public class HotelFacilitiesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public HotelFacilitiesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(HotelFacilities HotelFacilities)
    {
        try
        {
            return connection.Insert(HotelFacilities);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(HotelFacilities HotelFacilities)
    {
        try
        {
       return  connection.Update(HotelFacilities);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(HotelFacilities HotelFacilities)
        {
            try
            {
            return  connection.Delete<HotelFacilities>(HotelFacilities);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<HotelFacilities> GetAll(){
            try
            {
                return connection.Query<HotelFacilities>("HotelFacilitiesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelFacilities> GetByApiId(int ApiId){
            try
            {
                return connection.Query<HotelFacilities>("HotelFacilitiesGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelFacilities> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<HotelFacilities>("HotelFacilitiesGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelFacilities> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<HotelFacilities>("HotelFacilitiesGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelFacilities> GetByHighlighted(bool Highlighted){
            try
            {
                return connection.Query<HotelFacilities>("HotelFacilitiesGetByHighlighted", new
                {
Highlighted = Highlighted
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public HotelFacilities GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<HotelFacilities>("HotelFacilitiesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelFacilities> GetByIsPriced(int IsPriced){
            try
            {
                return connection.Query<HotelFacilities>("HotelFacilitiesGetByIsPriced", new
                {
IsPriced = IsPriced
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelFacilities> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<HotelFacilities>("HotelFacilitiesGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelFacilities> GetByName(string Name){
            try
            {
                return connection.Query<HotelFacilities>("HotelFacilitiesGetByName", new
                {
Name = Name
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelFacilities> GetByNote(string Note){
            try
            {
                return connection.Query<HotelFacilities>("HotelFacilitiesGetByNote", new
                {
Note = Note
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelFacilities> GetBySystemId(string SystemId){
            try
            {
                return connection.Query<HotelFacilities>("HotelFacilitiesGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelFacilities> GetByType(int Type){
            try
            {
                return connection.Query<HotelFacilities>("HotelFacilitiesGetByType", new
                {
Type = Type
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelFacilities> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<HotelFacilities>("HotelFacilitiesGetCreatedDateBetween", new
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
