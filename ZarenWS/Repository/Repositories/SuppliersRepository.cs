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
    public class SuppliersRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public SuppliersRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Suppliers Suppliers)
    {
        try
        {
            return connection.Insert(Suppliers);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Suppliers Suppliers)
    {
        try
        {
       return  connection.Update(Suppliers);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Suppliers Suppliers)
        {
            try
            {
            return  connection.Delete<Suppliers>(Suppliers);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<Suppliers> GetAll(){
            try
            {
                return connection.Query<Suppliers>("SuppliersGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Suppliers> GetByAcceptProducts(bool AcceptProducts){
            try
            {
                return connection.Query<Suppliers>("SuppliersGetByAcceptProducts", new
                {
AcceptProducts = AcceptProducts
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Suppliers> GetByAcceptReseller(bool AcceptReseller){
            try
            {
                return connection.Query<Suppliers>("SuppliersGetByAcceptReseller", new
                {
AcceptReseller = AcceptReseller
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Suppliers> GetByAcceptSupplier(bool AcceptSupplier){
            try
            {
                return connection.Query<Suppliers>("SuppliersGetByAcceptSupplier", new
                {
AcceptSupplier = AcceptSupplier
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Suppliers> GetByBriefDescription(string BriefDescription){
            try
            {
                return connection.Query<Suppliers>("SuppliersGetByBriefDescription", new
                {
BriefDescription = BriefDescription
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Suppliers> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<Suppliers>("SuppliersGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Suppliers> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<Suppliers>("SuppliersGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Suppliers GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Suppliers>("SuppliersGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Suppliers> GetByIsReseller(bool IsReseller){
            try
            {
                return connection.Query<Suppliers>("SuppliersGetByIsReseller", new
                {
IsReseller = IsReseller
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Suppliers> GetByIsSupplier(bool IsSupplier){
            try
            {
                return connection.Query<Suppliers>("SuppliersGetByIsSupplier", new
                {
IsSupplier = IsSupplier
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Suppliers> GetByLogo(string Logo){
            try
            {
                return connection.Query<Suppliers>("SuppliersGetByLogo", new
                {
Logo = Logo
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Suppliers> GetByName(string Name){
            try
            {
                return connection.Query<Suppliers>("SuppliersGetByName", new
                {
Name = Name
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Suppliers> GetBySourceMarketCountryId(int SourceMarketCountryId){
            try
            {
                return connection.Query<Suppliers>("SuppliersGetBySourceMarketCountryId", new
                {
SourceMarketCountryId = SourceMarketCountryId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Suppliers> GetBySupplierId(int SupplierId){
            try
            {
                return connection.Query<Suppliers>("SuppliersGetBySupplierId", new
                {
SupplierId = SupplierId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Suppliers> GetBySupplierTypeId(int SupplierTypeId){
            try
            {
                return connection.Query<Suppliers>("SuppliersGetBySupplierTypeId", new
                {
SupplierTypeId = SupplierTypeId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Suppliers> GetByWebsite(string Website){
            try
            {
                return connection.Query<Suppliers>("SuppliersGetByWebsite", new
                {
Website = Website
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Suppliers> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<Suppliers>("SuppliersGetCreatedDateBetween", new
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
