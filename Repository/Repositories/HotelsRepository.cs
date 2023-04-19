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
    public class HotelsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public HotelsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Hotels Hotels)
    {
        try
        {
            return connection.Insert(Hotels);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Hotels Hotels)
    {
        try
        {
       return  connection.Update(Hotels);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Hotels Hotels)
        {
            try
            {
            return  connection.Delete<Hotels>(Hotels);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<Hotels> GetAll(){
            try
            {
                return connection.Query<Hotels>("HotelsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Hotels> GetByApiId(int ApiId){
            try
            {
                return connection.Query<Hotels>("HotelsGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Hotels> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<Hotels>("HotelsGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Hotels> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<Hotels>("HotelsGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Hotels> GetByFaxNumber(string FaxNumber){
            try
            {
                return connection.Query<Hotels>("HotelsGetByFaxNumber", new
                {
FaxNumber = FaxNumber
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Hotels> GetByGiataId(string GiataId){
            try
            {
                return connection.Query<Hotels>("HotelsGetByGiataId", new
                {
GiataId = GiataId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Hotels> GetByHomePage(string HomePage){
            try
            {
                return connection.Query<Hotels>("HotelsGetByHomePage", new
                {
HomePage = HomePage
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Hotels GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Hotels>("HotelsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Hotels> GetByName(string Name){
            try
            {
                return connection.Query<Hotels>("HotelsGetByName", new
                {
Name = Name
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Hotels> GetByPhoneNumber(string PhoneNumber){
            try
            {
                return connection.Query<Hotels>("HotelsGetByPhoneNumber", new
                {
PhoneNumber = PhoneNumber
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Hotels> GetByProvider(string Provider){
            try
            {
                return connection.Query<Hotels>("HotelsGetByProvider", new
                {
Provider = Provider
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Hotels> GetByRating(double Rating){
            try
            {
                return connection.Query<Hotels>("HotelsGetByRating", new
                {
Rating = Rating
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Hotels> GetByStars(double Stars){
            try
            {
                return connection.Query<Hotels>("HotelsGetByStars", new
                {
Stars = Stars
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Hotels> GetByStatu(int Statu){
            try
            {
                return connection.Query<Hotels>("HotelsGetByStatu", new
                {
Statu = Statu
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Hotels> GetByStopSaleGuaranteed(int StopSaleGuaranteed){
            try
            {
                return connection.Query<Hotels>("HotelsGetByStopSaleGuaranteed", new
                {
StopSaleGuaranteed = StopSaleGuaranteed
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Hotels> GetByStopSaleStandart(int StopSaleStandart){
            try
            {
                return connection.Query<Hotels>("HotelsGetByStopSaleStandart", new
                {
StopSaleStandart = StopSaleStandart
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Hotels> GetBySystemId(string SystemId){
            try
            {
                return connection.Query<Hotels>("HotelsGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Hotels> GetByThumbnail(string Thumbnail){
            try
            {
                return connection.Query<Hotels>("HotelsGetByThumbnail", new
                {
Thumbnail = Thumbnail
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Hotels> GetByThumbnailFull(string ThumbnailFull){
            try
            {
                return connection.Query<Hotels>("HotelsGetByThumbnailFull", new
                {
ThumbnailFull = ThumbnailFull
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Hotels> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<Hotels>("HotelsGetCreatedDateBetween", new
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
