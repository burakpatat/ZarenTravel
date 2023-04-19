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
    public class AgencyMicroSiteSettingsSortTypeRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AgencyMicroSiteSettingsSortTypeRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(AgencyMicroSiteSettingsSortType AgencyMicroSiteSettingsSortType)
    {
        try
        {
            return connection.Insert(AgencyMicroSiteSettingsSortType);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(AgencyMicroSiteSettingsSortType AgencyMicroSiteSettingsSortType)
    {
        try
        {
       return  connection.Update(AgencyMicroSiteSettingsSortType);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(AgencyMicroSiteSettingsSortType AgencyMicroSiteSettingsSortType)
        {
            try
            {
            return  connection.Delete<AgencyMicroSiteSettingsSortType>(AgencyMicroSiteSettingsSortType);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<AgencyMicroSiteSettingsSortType> GetAll(){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsSortType>("AgencyMicroSiteSettingsSortTypeGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public AgencyMicroSiteSettingsSortType GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<AgencyMicroSiteSettingsSortType>("AgencyMicroSiteSettingsSortTypeGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsSortType> GetBySortByName(string SortByName){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsSortType>("AgencyMicroSiteSettingsSortTypeGetBySortByName", new
                {
SortByName = SortByName
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
