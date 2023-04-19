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
    public class FlightOffersRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public FlightOffersRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(FlightOffers FlightOffers)
    {
        try
        {
            return connection.Insert(FlightOffers);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(FlightOffers FlightOffers)
    {
        try
        {
       return  connection.Update(FlightOffers);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(FlightOffers FlightOffers)
        {
            try
            {
            return  connection.Delete<FlightOffers>(FlightOffers);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<FlightOffers> GetAll(){
            try
            {
                return connection.Query<FlightOffers>("FlightOffersGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FlightOffers> GetByApiId(int ApiId){
            try
            {
                return connection.Query<FlightOffers>("FlightOffersGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FlightOffers> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<FlightOffers>("FlightOffersGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FlightOffers> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<FlightOffers>("FlightOffersGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FlightOffers> GetByFlightBrandsId(int FlightBrandsId){
            try
            {
                return connection.Query<FlightOffers>("FlightOffersGetByFlightBrandsId", new
                {
FlightBrandsId = FlightBrandsId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FlightOffers> GetByFlightsId(int FlightsId){
            try
            {
                return connection.Query<FlightOffers>("FlightOffersGetByFlightsId", new
                {
FlightsId = FlightsId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public FlightOffers GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<FlightOffers>("FlightOffersGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FlightOffers> GetByIsPackageOffer(bool IsPackageOffer){
            try
            {
                return connection.Query<FlightOffers>("FlightOffersGetByIsPackageOffer", new
                {
IsPackageOffer = IsPackageOffer
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FlightOffers> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<FlightOffers>("FlightOffersGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FlightOffers> GetByPricesId(int PricesId){
            try
            {
                return connection.Query<FlightOffers>("FlightOffersGetByPricesId", new
                {
PricesId = PricesId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FlightOffers> GetByProvider(int Provider){
            try
            {
                return connection.Query<FlightOffers>("FlightOffersGetByProvider", new
                {
Provider = Provider
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FlightOffers> GetByRoute(int Route){
            try
            {
                return connection.Query<FlightOffers>("FlightOffersGetByRoute", new
                {
Route = Route
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FlightOffers> GetBySegmentNumber(int SegmentNumber){
            try
            {
                return connection.Query<FlightOffers>("FlightOffersGetBySegmentNumber", new
                {
SegmentNumber = SegmentNumber
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FlightOffers> GetBySystemId(string SystemId){
            try
            {
                return connection.Query<FlightOffers>("FlightOffersGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FlightOffers> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<FlightOffers>("FlightOffersGetCreatedDateBetween", new
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
