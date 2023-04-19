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
    public class UserPreferencesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public UserPreferencesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(UserPreferences UserPreferences)
    {
        try
        {
            return connection.Insert(UserPreferences);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(UserPreferences UserPreferences)
    {
        try
        {
       return  connection.Update(UserPreferences);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(UserPreferences UserPreferences)
        {
            try
            {
            return  connection.Delete<UserPreferences>(UserPreferences);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<UserPreferences> GetAll(){
            try
            {
                return connection.Query<UserPreferences>("UserPreferencesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<UserPreferences> GetByHeaderColor(int HeaderColor){
            try
            {
                return connection.Query<UserPreferences>("UserPreferencesGetByHeaderColor", new
                {
HeaderColor = HeaderColor
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public UserPreferences GetByID(int ID){
            try
            {
                return connection.QueryFirstOrDefault<UserPreferences>("UserPreferencesGetByID", new
                {
ID = ID
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<UserPreferences> GetByProducts(int Products){
            try
            {
                return connection.Query<UserPreferences>("UserPreferencesGetByProducts", new
                {
Products = Products
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<UserPreferences> GetBySideBarColor(int SideBarColor){
            try
            {
                return connection.Query<UserPreferences>("UserPreferencesGetBySideBarColor", new
                {
SideBarColor = SideBarColor
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<UserPreferences> GetByThemeStyle(int ThemeStyle){
            try
            {
                return connection.Query<UserPreferences>("UserPreferencesGetByThemeStyle", new
                {
ThemeStyle = ThemeStyle
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<UserPreferences> GetByUserID(int UserID){
            try
            {
                return connection.Query<UserPreferences>("UserPreferencesGetByUserID", new
                {
UserID = UserID
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
