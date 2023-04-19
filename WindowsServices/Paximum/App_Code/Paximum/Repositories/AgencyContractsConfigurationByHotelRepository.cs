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
    public class AgencyContractsConfigurationByHotelRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AgencyContractsConfigurationByHotelRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(AgencyContractsConfigurationByHotel AgencyContractsConfigurationByHotel)
    {
        try
        {
            return connection.Insert(AgencyContractsConfigurationByHotel);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(AgencyContractsConfigurationByHotel AgencyContractsConfigurationByHotel)
    {
        try
        {
       return  connection.Update(AgencyContractsConfigurationByHotel);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(AgencyContractsConfigurationByHotel AgencyContractsConfigurationByHotel)
        {
            try
            {
            return  connection.Delete<AgencyContractsConfigurationByHotel>(AgencyContractsConfigurationByHotel);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<AgencyContractsConfigurationByHotel> GetAll(){
            try
            {
                return connection.Query<AgencyContractsConfigurationByHotel>("AgencyContractsConfigurationByHotelGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsConfigurationByHotel> GetByHotelConfigurationId(int HotelConfigurationId){
            try
            {
                return connection.Query<AgencyContractsConfigurationByHotel>("AgencyContractsConfigurationByHotelGetByHotelConfigurationId", new
                {
HotelConfigurationId = HotelConfigurationId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public AgencyContractsConfigurationByHotel GetByID(int MicroSiteId){
            try
            {
                return connection.QueryFirstOrDefault<AgencyContractsConfigurationByHotel>("AgencyContractsConfigurationByHotelGetByID", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsConfigurationByHotel> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<AgencyContractsConfigurationByHotel>("AgencyContractsConfigurationByHotelGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
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
