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
    public class HotelOffersRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public HotelOffersRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(HotelOffers HotelOffers)
    {
        try
        {
            return connection.Insert(HotelOffers);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(HotelOffers HotelOffers)
    {
        try
        {
       return  connection.Update(HotelOffers);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(HotelOffers HotelOffers)
        {
            try
            {
            return  connection.Delete<HotelOffers>(HotelOffers);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<HotelOffers> GetAll(){
            try
            {
                return connection.Query<HotelOffers>("HotelOffersGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelOffers> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<HotelOffers>("HotelOffersGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelOffers> GetByApiId(int ApiId){
            try
            {
                return connection.Query<HotelOffers>("HotelOffersGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelOffers> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<HotelOffers>("HotelOffersGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelOffers> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<HotelOffers>("HotelOffersGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelOffers> GetByHotelId(int HotelId){
            try
            {
                return connection.Query<HotelOffers>("HotelOffersGetByHotelId", new
                {
HotelId = HotelId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public HotelOffers GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<HotelOffers>("HotelOffersGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelOffers> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<HotelOffers>("HotelOffersGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelOffers> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<HotelOffers>("HotelOffersGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelOffers> GetByOfferId(int OfferId){
            try
            {
                return connection.Query<HotelOffers>("HotelOffersGetByOfferId", new
                {
OfferId = OfferId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelOffers> GetBySystemId(int SystemId){
            try
            {
                return connection.Query<HotelOffers>("HotelOffersGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelOffers> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<HotelOffers>("HotelOffersGetCreatedDateBetween", new
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
