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
    public class AuthorizationTemplateRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AuthorizationTemplateRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(AuthorizationTemplate AuthorizationTemplate)
    {
        try
        {
            return connection.Insert(AuthorizationTemplate);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(AuthorizationTemplate AuthorizationTemplate)
    {
        try
        {
       return  connection.Update(AuthorizationTemplate);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(AuthorizationTemplate AuthorizationTemplate)
        {
            try
            {
            return  connection.Delete<AuthorizationTemplate>(AuthorizationTemplate);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<AuthorizationTemplate> GetAll(){
            try
            {
                return connection.Query<AuthorizationTemplate>("AuthorizationTemplateGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AuthorizationTemplate> GetByCanDetail(int CanDetail){
            try
            {
                return connection.Query<AuthorizationTemplate>("AuthorizationTemplateGetByCanDetail", new
                {
CanDetail = CanDetail
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AuthorizationTemplate> GetByCanList(int CanList){
            try
            {
                return connection.Query<AuthorizationTemplate>("AuthorizationTemplateGetByCanList", new
                {
CanList = CanList
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AuthorizationTemplate> GetByCanRemove(int CanRemove){
            try
            {
                return connection.Query<AuthorizationTemplate>("AuthorizationTemplateGetByCanRemove", new
                {
CanRemove = CanRemove
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AuthorizationTemplate> GetByDatabaseTables(int DatabaseTables){
            try
            {
                return connection.Query<AuthorizationTemplate>("AuthorizationTemplateGetByDatabaseTables", new
                {
DatabaseTables = DatabaseTables
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AuthorizationTemplate> GetByDepartments(int Departments){
            try
            {
                return connection.Query<AuthorizationTemplate>("AuthorizationTemplateGetByDepartments", new
                {
Departments = Departments
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public AuthorizationTemplate GetByID(int ID){
            try
            {
                return connection.QueryFirstOrDefault<AuthorizationTemplate>("AuthorizationTemplateGetByID", new
                {
ID = ID
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AuthorizationTemplate> GetByOnLeftMenu(int OnLeftMenu){
            try
            {
                return connection.Query<AuthorizationTemplate>("AuthorizationTemplateGetByOnLeftMenu", new
                {
OnLeftMenu = OnLeftMenu
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AuthorizationTemplate> GetByProducts(int Products){
            try
            {
                return connection.Query<AuthorizationTemplate>("AuthorizationTemplateGetByProducts", new
                {
Products = Products
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AuthorizationTemplate> GetByUsers(int Users){
            try
            {
                return connection.Query<AuthorizationTemplate>("AuthorizationTemplateGetByUsers", new
                {
Users = Users
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
