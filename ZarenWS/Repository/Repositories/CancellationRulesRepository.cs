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
    public class CancellationRulesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public CancellationRulesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(CancellationRules CancellationRules)
    {
        try
        {
            return connection.Insert(CancellationRules);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(CancellationRules CancellationRules)
    {
        try
        {
       return  connection.Update(CancellationRules);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(CancellationRules CancellationRules)
        {
            try
            {
            return  connection.Delete<CancellationRules>(CancellationRules);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<CancellationRules> GetAll(){
            try
            {
                return connection.Query<CancellationRules>("CancellationRulesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CancellationRules> GetByCancellationSeasonId(int CancellationSeasonId){
            try
            {
                return connection.Query<CancellationRules>("CancellationRulesGetByCancellationSeasonId", new
                {
CancellationSeasonId = CancellationSeasonId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CancellationRules> GetByCost(decimal Cost){
            try
            {
                return connection.Query<CancellationRules>("CancellationRulesGetByCost", new
                {
Cost = Cost
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CancellationRules> GetByCostType(int CostType){
            try
            {
                return connection.Query<CancellationRules>("CancellationRulesGetByCostType", new
                {
CostType = CostType
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CancellationRules> GetByFromDays(int FromDays){
            try
            {
                return connection.Query<CancellationRules>("CancellationRulesGetByFromDays", new
                {
FromDays = FromDays
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public CancellationRules GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<CancellationRules>("CancellationRulesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CancellationRules> GetByToDays(int ToDays){
            try
            {
                return connection.Query<CancellationRules>("CancellationRulesGetByToDays", new
                {
ToDays = ToDays
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
