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
    public class AgencyMicroSiteDesignRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AgencyMicroSiteDesignRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(AgencyMicroSiteDesign AgencyMicroSiteDesign)
    {
        try
        {
            return connection.Insert(AgencyMicroSiteDesign);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(AgencyMicroSiteDesign AgencyMicroSiteDesign)
    {
        try
        {
       return  connection.Update(AgencyMicroSiteDesign);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(AgencyMicroSiteDesign AgencyMicroSiteDesign)
        {
            try
            {
            return  connection.Delete<AgencyMicroSiteDesign>(AgencyMicroSiteDesign);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<AgencyMicroSiteDesign> GetAll(){
            try
            {
                return connection.Query<AgencyMicroSiteDesign>("AgencyMicroSiteDesignGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteDesign> GetByAgencyMicroSiteId(int AgencyMicroSiteId){
            try
            {
                return connection.Query<AgencyMicroSiteDesign>("AgencyMicroSiteDesignGetByAgencyMicroSiteId", new
                {
AgencyMicroSiteId = AgencyMicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteDesign> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<AgencyMicroSiteDesign>("AgencyMicroSiteDesignGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteDesign> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<AgencyMicroSiteDesign>("AgencyMicroSiteDesignGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public AgencyMicroSiteDesign GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<AgencyMicroSiteDesign>("AgencyMicroSiteDesignGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteDesign> GetByProductType(int ProductType){
            try
            {
                return connection.Query<AgencyMicroSiteDesign>("AgencyMicroSiteDesignGetByProductType", new
                {
ProductType = ProductType
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteDesign> GetByStatu(int Statu){
            try
            {
                return connection.Query<AgencyMicroSiteDesign>("AgencyMicroSiteDesignGetByStatu", new
                {
Statu = Statu
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteDesign> GetByTableOrder(int TableOrder){
            try
            {
                return connection.Query<AgencyMicroSiteDesign>("AgencyMicroSiteDesignGetByTableOrder", new
                {
TableOrder = TableOrder
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteDesign> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<AgencyMicroSiteDesign>("AgencyMicroSiteDesignGetCreatedDateBetween", new
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
