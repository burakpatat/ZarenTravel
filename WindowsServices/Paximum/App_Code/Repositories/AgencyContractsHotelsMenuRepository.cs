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
    public class AgencyContractsHotelsMenuRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AgencyContractsHotelsMenuRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(AgencyContractsHotelsMenu AgencyContractsHotelsMenu)
    {
        try
        {
            return connection.Insert(AgencyContractsHotelsMenu);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(AgencyContractsHotelsMenu AgencyContractsHotelsMenu)
    {
        try
        {
       return  connection.Update(AgencyContractsHotelsMenu);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(AgencyContractsHotelsMenu AgencyContractsHotelsMenu)
        {
            try
            {
            return  connection.Delete<AgencyContractsHotelsMenu>(AgencyContractsHotelsMenu);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<AgencyContractsHotelsMenu> GetAll(){
            try
            {
                return connection.Query<AgencyContractsHotelsMenu>("AgencyContractsHotelsMenuGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public AgencyContractsHotelsMenu GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<AgencyContractsHotelsMenu>("AgencyContractsHotelsMenuGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsHotelsMenu> GetByName(string Name){
            try
            {
                return connection.Query<AgencyContractsHotelsMenu>("AgencyContractsHotelsMenuGetByName", new
                {
Name = Name
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
