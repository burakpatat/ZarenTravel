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
    public class AgencyManagerRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AgencyManagerRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(AgencyManager AgencyManager)
    {
        try
        {
            return connection.Insert(AgencyManager);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(AgencyManager AgencyManager)
    {
        try
        {
       return  connection.Update(AgencyManager);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(AgencyManager AgencyManager)
        {
            try
            {
            return  connection.Delete<AgencyManager>(AgencyManager);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<AgencyManager> GetAll(){
            try
            {
                return connection.Query<AgencyManager>("AgencyManagerGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public AgencyManager GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<AgencyManager>("AgencyManagerGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyManager> GetByMicrositeId(int MicrositeId){
            try
            {
                return connection.Query<AgencyManager>("AgencyManagerGetByMicrositeId", new
                {
MicrositeId = MicrositeId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyManager> GetByStatu(int Statu){
            try
            {
                return connection.Query<AgencyManager>("AgencyManagerGetByStatu", new
                {
Statu = Statu
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyManager> GetByUserId(int UserId){
            try
            {
                return connection.Query<AgencyManager>("AgencyManagerGetByUserId", new
                {
UserId = UserId
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
