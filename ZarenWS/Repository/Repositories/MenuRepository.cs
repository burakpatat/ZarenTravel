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
    public class MenuRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public MenuRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Menu Menu)
    {
        try
        {
            return connection.Insert(Menu);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Menu Menu)
    {
        try
        {
       return  connection.Update(Menu);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Menu Menu)
        {
            try
            {
            return  connection.Delete<Menu>(Menu);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<Menu> GetAll(){
            try
            {
                return connection.Query<Menu>("MenuGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Menu> GetByColor(string Color){
            try
            {
                return connection.Query<Menu>("MenuGetByColor", new
                {
Color = Color
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Menu> GetByIcon(string Icon){
            try
            {
                return connection.Query<Menu>("MenuGetByIcon", new
                {
Icon = Icon
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Menu GetByID(int ID){
            try
            {
                return connection.QueryFirstOrDefault<Menu>("MenuGetByID", new
                {
ID = ID
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Menu> GetByTitle(string Title){
            try
            {
                return connection.Query<Menu>("MenuGetByTitle", new
                {
Title = Title
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Menu> GetByTitleArabic(string TitleArabic){
            try
            {
                return connection.Query<Menu>("MenuGetByTitleArabic", new
                {
TitleArabic = TitleArabic
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Menu> GetByTitleEng(string TitleEng){
            try
            {
                return connection.Query<Menu>("MenuGetByTitleEng", new
                {
TitleEng = TitleEng
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Menu> GetByUrl(string Url){
            try
            {
                return connection.Query<Menu>("MenuGetByUrl", new
                {
Url = Url
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
