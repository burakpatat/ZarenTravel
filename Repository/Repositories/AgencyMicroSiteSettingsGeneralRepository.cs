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
    public class AgencyMicroSiteSettingsGeneralRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AgencyMicroSiteSettingsGeneralRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(AgencyMicroSiteSettingsGeneral AgencyMicroSiteSettingsGeneral)
    {
        try
        {
            return connection.Insert(AgencyMicroSiteSettingsGeneral);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(AgencyMicroSiteSettingsGeneral AgencyMicroSiteSettingsGeneral)
    {
        try
        {
       return  connection.Update(AgencyMicroSiteSettingsGeneral);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(AgencyMicroSiteSettingsGeneral AgencyMicroSiteSettingsGeneral)
        {
            try
            {
            return  connection.Delete<AgencyMicroSiteSettingsGeneral>(AgencyMicroSiteSettingsGeneral);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<AgencyMicroSiteSettingsGeneral> GetAll(){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsGeneral>("AgencyMicroSiteSettingsGeneralGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsGeneral> GetByAgencyContractFile(string AgencyContractFile){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsGeneral>("AgencyMicroSiteSettingsGeneralGetByAgencyContractFile", new
                {
AgencyContractFile = AgencyContractFile
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsGeneral> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsGeneral>("AgencyMicroSiteSettingsGeneralGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsGeneral> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsGeneral>("AgencyMicroSiteSettingsGeneralGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsGeneral> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsGeneral>("AgencyMicroSiteSettingsGeneralGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsGeneral> GetByHasAgencyManagementFee(bool HasAgencyManagementFee){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsGeneral>("AgencyMicroSiteSettingsGeneralGetByHasAgencyManagementFee", new
                {
HasAgencyManagementFee = HasAgencyManagementFee
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public AgencyMicroSiteSettingsGeneral GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<AgencyMicroSiteSettingsGeneral>("AgencyMicroSiteSettingsGeneralGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsGeneral> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsGeneral>("AgencyMicroSiteSettingsGeneralGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsGeneral> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsGeneral>("AgencyMicroSiteSettingsGeneralGetCreatedDateBetween", new
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
