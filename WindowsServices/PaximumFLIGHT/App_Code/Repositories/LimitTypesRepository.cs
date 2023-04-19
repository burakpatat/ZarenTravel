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
    public class LimitTypesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public LimitTypesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(LimitTypes LimitTypes)
    {
        try
        {
            return connection.Insert(LimitTypes);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(LimitTypes LimitTypes)
    {
        try
        {
       return  connection.Update(LimitTypes);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(LimitTypes LimitTypes)
        {
            try
            {
            return  connection.Delete<LimitTypes>(LimitTypes);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<LimitTypes> GetAll(){
            try
            {
                return connection.Query<LimitTypes>("LimitTypesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public LimitTypes GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<LimitTypes>("LimitTypesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<LimitTypes> GetByName(string Name){
            try
            {
                return connection.Query<LimitTypes>("LimitTypesGetByName", new
                {
Name = Name
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<LimitTypes> GetByPerPassengerCommision(bool PerPassengerCommision){
            try
            {
                return connection.Query<LimitTypes>("LimitTypesGetByPerPassengerCommision", new
                {
PerPassengerCommision = PerPassengerCommision
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
