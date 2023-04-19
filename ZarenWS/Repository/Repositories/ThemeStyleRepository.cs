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
    public class ThemeStyleRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public ThemeStyleRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(ThemeStyle ThemeStyle)
    {
        try
        {
            return connection.Insert(ThemeStyle);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(ThemeStyle ThemeStyle)
    {
        try
        {
       return  connection.Update(ThemeStyle);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(ThemeStyle ThemeStyle)
        {
            try
            {
            return  connection.Delete<ThemeStyle>(ThemeStyle);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<ThemeStyle> GetAll(){
            try
            {
                return connection.Query<ThemeStyle>("ThemeStyleGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public ThemeStyle GetByID(int ID){
            try
            {
                return connection.QueryFirstOrDefault<ThemeStyle>("ThemeStyleGetByID", new
                {
ID = ID
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<ThemeStyle> GetByName(string Name){
            try
            {
                return connection.Query<ThemeStyle>("ThemeStyleGetByName", new
                {
Name = Name
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<ThemeStyle> GetByPath(string Path){
            try
            {
                return connection.Query<ThemeStyle>("ThemeStyleGetByPath", new
                {
Path = Path
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<ThemeStyle> GetByProperty(string Property){
            try
            {
                return connection.Query<ThemeStyle>("ThemeStyleGetByProperty", new
                {
Property = Property
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
