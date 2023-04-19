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
    public class PageTypesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public PageTypesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(PageTypes PageTypes)
    {
        try
        {
            return connection.Insert(PageTypes);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(PageTypes PageTypes)
    {
        try
        {
       return  connection.Update(PageTypes);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(PageTypes PageTypes)
        {
            try
            {
            return  connection.Delete<PageTypes>(PageTypes);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<PageTypes> GetAll(){
            try
            {
                return connection.Query<PageTypes>("PageTypesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public PageTypes GetByID(int ID){
            try
            {
                return connection.QueryFirstOrDefault<PageTypes>("PageTypesGetByID", new
                {
ID = ID
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PageTypes> GetByName(string Name){
            try
            {
                return connection.Query<PageTypes>("PageTypesGetByName", new
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
