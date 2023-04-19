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
    public class CommissionsForDomainRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public CommissionsForDomainRepository(IConfiguration configuration)
        {
             strConnString = configuration.GetConnectionString("ZarenTravel");
            connection = new SqlConnection(strConnString);
        }
  public long Insert(CommissionsForDomain CommissionsForDomain)
    {
        try
        {
            return connection.Insert(CommissionsForDomain);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(CommissionsForDomain CommissionsForDomain)
    {
        try
        {
       return  connection.Update(CommissionsForDomain);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(CommissionsForDomain CommissionsForDomain)
        {
            try
            {
            return  connection.Delete<CommissionsForDomain>(CommissionsForDomain);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<CommissionsForDomain> GetAll(){
            try
            {
                return connection.Query<CommissionsForDomain>("CommissionsForDomainGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CommissionsForDomain> GetByAgentName(string AgentName){
            try
            {
                return connection.Query<CommissionsForDomain>("CommissionsForDomainGetByAgentName", new
                {
AgentName = AgentName
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CommissionsForDomain> GetByDomain(string Domain){
            try
            {
                return connection.Query<CommissionsForDomain>("CommissionsForDomainGetByDomain", new
                {
Domain = Domain
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CommissionsForDomain> GetByFlightCommission(decimal FlightCommission){
            try
            {
                return connection.Query<CommissionsForDomain>("CommissionsForDomainGetByFlightCommission", new
                {
FlightCommission = FlightCommission
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CommissionsForDomain> GetByHotelCommission(decimal HotelCommission){
            try
            {
                return connection.Query<CommissionsForDomain>("CommissionsForDomainGetByHotelCommission", new
                {
HotelCommission = HotelCommission
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public CommissionsForDomain GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<CommissionsForDomain>("CommissionsForDomainGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

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
