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
    public class PriceBreakDownsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public PriceBreakDownsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(PriceBreakDowns PriceBreakDowns)
    {
        try
        {
            return connection.Insert(PriceBreakDowns);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(PriceBreakDowns PriceBreakDowns)
    {
        try
        {
       return  connection.Update(PriceBreakDowns);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(PriceBreakDowns PriceBreakDowns)
        {
            try
            {
            return  connection.Delete<PriceBreakDowns>(PriceBreakDowns);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<PriceBreakDowns> GetAll(){
            try
            {
                return connection.Query<PriceBreakDowns>("PriceBreakDownsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PriceBreakDowns> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<PriceBreakDowns>("PriceBreakDownsGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PriceBreakDowns> GetByApiId(int ApiId){
            try
            {
                return connection.Query<PriceBreakDowns>("PriceBreakDownsGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PriceBreakDowns> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<PriceBreakDowns>("PriceBreakDownsGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PriceBreakDowns> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<PriceBreakDowns>("PriceBreakDownsGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PriceBreakDowns> GetByDate(DateTime Date){
            try
            {
                return connection.Query<PriceBreakDowns>("PriceBreakDownsGetByDate", new
                {
Date = Date
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public PriceBreakDowns GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<PriceBreakDowns>("PriceBreakDownsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PriceBreakDowns> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<PriceBreakDowns>("PriceBreakDownsGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PriceBreakDowns> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<PriceBreakDowns>("PriceBreakDownsGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PriceBreakDowns> GetByPriceId(int PriceId){
            try
            {
                return connection.Query<PriceBreakDowns>("PriceBreakDownsGetByPriceId", new
                {
PriceId = PriceId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PriceBreakDowns> GetByProductTyoe(int ProductTyoe){
            try
            {
                return connection.Query<PriceBreakDowns>("PriceBreakDownsGetByProductTyoe", new
                {
ProductTyoe = ProductTyoe
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PriceBreakDowns> GetByRoomNumber(int RoomNumber){
            try
            {
                return connection.Query<PriceBreakDowns>("PriceBreakDownsGetByRoomNumber", new
                {
RoomNumber = RoomNumber
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PriceBreakDowns> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<PriceBreakDowns>("PriceBreakDownsGetCreatedDateBetween", new
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
public List<PriceBreakDowns> GetDateBetween(DateTime DateStart,DateTime DateEnd){
            try
            {
                return connection.Query<PriceBreakDowns>("PriceBreakDownsGetDateBetween", new
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
