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
    public class AutoCompleteTypesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AutoCompleteTypesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(AutoCompleteTypes AutoCompleteTypes)
    {
        try
        {
            return connection.Insert(AutoCompleteTypes);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(AutoCompleteTypes AutoCompleteTypes)
    {
        try
        {
       return  connection.Update(AutoCompleteTypes);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(AutoCompleteTypes AutoCompleteTypes)
        {
            try
            {
            return  connection.Delete<AutoCompleteTypes>(AutoCompleteTypes);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<AutoCompleteTypes> GetAll(){
            try
            {
                return connection.Query<AutoCompleteTypes>("AutoCompleteTypesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public AutoCompleteTypes GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<AutoCompleteTypes>("AutoCompleteTypesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AutoCompleteTypes> GetByName(string Name){
            try
            {
                return connection.Query<AutoCompleteTypes>("AutoCompleteTypesGetByName", new
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
