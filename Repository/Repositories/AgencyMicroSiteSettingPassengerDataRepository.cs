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
    public class AgencyMicroSiteSettingPassengerDataRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AgencyMicroSiteSettingPassengerDataRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(AgencyMicroSiteSettingPassengerData AgencyMicroSiteSettingPassengerData)
    {
        try
        {
            return connection.Insert(AgencyMicroSiteSettingPassengerData);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(AgencyMicroSiteSettingPassengerData AgencyMicroSiteSettingPassengerData)
    {
        try
        {
       return  connection.Update(AgencyMicroSiteSettingPassengerData);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(AgencyMicroSiteSettingPassengerData AgencyMicroSiteSettingPassengerData)
        {
            try
            {
            return  connection.Delete<AgencyMicroSiteSettingPassengerData>(AgencyMicroSiteSettingPassengerData);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<AgencyMicroSiteSettingPassengerData> GetAll(){
            try
            {
                return connection.Query<AgencyMicroSiteSettingPassengerData>("AgencyMicroSiteSettingPassengerDataGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingPassengerData> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<AgencyMicroSiteSettingPassengerData>("AgencyMicroSiteSettingPassengerDataGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingPassengerData> GetByExcludeMiss(bool ExcludeMiss){
            try
            {
                return connection.Query<AgencyMicroSiteSettingPassengerData>("AgencyMicroSiteSettingPassengerDataGetByExcludeMiss", new
                {
ExcludeMiss = ExcludeMiss
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingPassengerData> GetByExcludeMrs(bool ExcludeMrs){
            try
            {
                return connection.Query<AgencyMicroSiteSettingPassengerData>("AgencyMicroSiteSettingPassengerDataGetByExcludeMrs", new
                {
ExcludeMrs = ExcludeMrs
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingPassengerData> GetByExcludeNie(bool ExcludeNie){
            try
            {
                return connection.Query<AgencyMicroSiteSettingPassengerData>("AgencyMicroSiteSettingPassengerDataGetByExcludeNie", new
                {
ExcludeNie = ExcludeNie
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public AgencyMicroSiteSettingPassengerData GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<AgencyMicroSiteSettingPassengerData>("AgencyMicroSiteSettingPassengerDataGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingPassengerData> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<AgencyMicroSiteSettingPassengerData>("AgencyMicroSiteSettingPassengerDataGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingPassengerData> GetByRequiredPassengerData(int RequiredPassengerData){
            try
            {
                return connection.Query<AgencyMicroSiteSettingPassengerData>("AgencyMicroSiteSettingPassengerDataGetByRequiredPassengerData", new
                {
RequiredPassengerData = RequiredPassengerData
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingPassengerData> GetBySearchCustomer(bool SearchCustomer){
            try
            {
                return connection.Query<AgencyMicroSiteSettingPassengerData>("AgencyMicroSiteSettingPassengerDataGetBySearchCustomer", new
                {
SearchCustomer = SearchCustomer
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
