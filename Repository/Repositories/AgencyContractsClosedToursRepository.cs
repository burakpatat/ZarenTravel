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
    public class AgencyContractsClosedToursRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AgencyContractsClosedToursRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(AgencyContractsClosedTours AgencyContractsClosedTours)
    {
        try
        {
            return connection.Insert(AgencyContractsClosedTours);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(AgencyContractsClosedTours AgencyContractsClosedTours)
    {
        try
        {
       return  connection.Update(AgencyContractsClosedTours);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(AgencyContractsClosedTours AgencyContractsClosedTours)
        {
            try
            {
            return  connection.Delete<AgencyContractsClosedTours>(AgencyContractsClosedTours);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<AgencyContractsClosedTours> GetAll(){
            try
            {
                return connection.Query<AgencyContractsClosedTours>("AgencyContractsClosedToursGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsClosedTours> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<AgencyContractsClosedTours>("AgencyContractsClosedToursGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsClosedTours> GetByCode(string Code){
            try
            {
                return connection.Query<AgencyContractsClosedTours>("AgencyContractsClosedToursGetByCode", new
                {
Code = Code
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsClosedTours> GetByContractaFrom(string ContractaFrom){
            try
            {
                return connection.Query<AgencyContractsClosedTours>("AgencyContractsClosedToursGetByContractaFrom", new
                {
ContractaFrom = ContractaFrom
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsClosedTours> GetByContractTo(string ContractTo){
            try
            {
                return connection.Query<AgencyContractsClosedTours>("AgencyContractsClosedToursGetByContractTo", new
                {
ContractTo = ContractTo
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsClosedTours> GetByCreator(string Creator){
            try
            {
                return connection.Query<AgencyContractsClosedTours>("AgencyContractsClosedToursGetByCreator", new
                {
Creator = Creator
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsClosedTours> GetByDateCreation(DateTime DateCreation){
            try
            {
                return connection.Query<AgencyContractsClosedTours>("AgencyContractsClosedToursGetByDateCreation", new
                {
DateCreation = DateCreation
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsClosedTours> GetByDestinations(string Destinations){
            try
            {
                return connection.Query<AgencyContractsClosedTours>("AgencyContractsClosedToursGetByDestinations", new
                {
Destinations = Destinations
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsClosedTours> GetByExtension(bool Extension){
            try
            {
                return connection.Query<AgencyContractsClosedTours>("AgencyContractsClosedToursGetByExtension", new
                {
Extension = Extension
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public AgencyContractsClosedTours GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<AgencyContractsClosedTours>("AgencyContractsClosedToursGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsClosedTours> GetByIsActive(bool IsActive){
            try
            {
                return connection.Query<AgencyContractsClosedTours>("AgencyContractsClosedToursGetByIsActive", new
                {
IsActive = IsActive
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsClosedTours> GetByIsSelect(bool IsSelect){
            try
            {
                return connection.Query<AgencyContractsClosedTours>("AgencyContractsClosedToursGetByIsSelect", new
                {
IsSelect = IsSelect
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsClosedTours> GetByMarketPlace(bool MarketPlace){
            try
            {
                return connection.Query<AgencyContractsClosedTours>("AgencyContractsClosedToursGetByMarketPlace", new
                {
MarketPlace = MarketPlace
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsClosedTours> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<AgencyContractsClosedTours>("AgencyContractsClosedToursGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsClosedTours> GetByNights(int Nights){
            try
            {
                return connection.Query<AgencyContractsClosedTours>("AgencyContractsClosedToursGetByNights", new
                {
Nights = Nights
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsClosedTours> GetByPro(bool Pro){
            try
            {
                return connection.Query<AgencyContractsClosedTours>("AgencyContractsClosedToursGetByPro", new
                {
Pro = Pro
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsClosedTours> GetBySupplier(string Supplier){
            try
            {
                return connection.Query<AgencyContractsClosedTours>("AgencyContractsClosedToursGetBySupplier", new
                {
Supplier = Supplier
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsClosedTours> GetByTourSupplierName(string TourSupplierName){
            try
            {
                return connection.Query<AgencyContractsClosedTours>("AgencyContractsClosedToursGetByTourSupplierName", new
                {
TourSupplierName = TourSupplierName
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsClosedTours> GetDateCreationBetween(DateTime DateCreationStart,DateTime DateCreationEnd){
            try
            {
                return connection.Query<AgencyContractsClosedTours>("AgencyContractsClosedToursGetDateCreationBetween", new
                {
DateCreationStart = DateCreationStart
,DateCreationEnd = DateCreationEnd
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
