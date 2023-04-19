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
    public class ExtensionsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public ExtensionsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Extensions Extensions)
    {
        try
        {
            return connection.Insert(Extensions);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Extensions Extensions)
    {
        try
        {
       return  connection.Update(Extensions);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Extensions Extensions)
        {
            try
            {
            return  connection.Delete<Extensions>(Extensions);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<Extensions> GetAll(){
            try
            {
                return connection.Query<Extensions>("ExtensionsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Extensions> GetByExtensionName(string ExtensionName){
            try
            {
                return connection.Query<Extensions>("ExtensionsGetByExtensionName", new
                {
ExtensionName = ExtensionName
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Extensions> GetByFilePath(string FilePath){
            try
            {
                return connection.Query<Extensions>("ExtensionsGetByFilePath", new
                {
FilePath = FilePath
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Extensions> GetByFileType(int FileType){
            try
            {
                return connection.Query<Extensions>("ExtensionsGetByFileType", new
                {
FileType = FileType
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Extensions GetByID(int ID){
            try
            {
                return connection.QueryFirstOrDefault<Extensions>("ExtensionsGetByID", new
                {
ID = ID
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Extensions> GetByIsRealName(bool IsRealName){
            try
            {
                return connection.Query<Extensions>("ExtensionsGetByIsRealName", new
                {
IsRealName = IsRealName
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Extensions> GetByKeyName(string KeyName){
            try
            {
                return connection.Query<Extensions>("ExtensionsGetByKeyName", new
                {
KeyName = KeyName
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
