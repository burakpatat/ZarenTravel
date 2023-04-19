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
    public class HeaderColorRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public HeaderColorRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(HeaderColor HeaderColor)
    {
        try
        {
            return connection.Insert(HeaderColor);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(HeaderColor HeaderColor)
    {
        try
        {
       return  connection.Update(HeaderColor);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(HeaderColor HeaderColor)
        {
            try
            {
            return  connection.Delete<HeaderColor>(HeaderColor);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<HeaderColor> GetAll(){
            try
            {
                return connection.Query<HeaderColor>("HeaderColorGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HeaderColor> GetByColor(string Color){
            try
            {
                return connection.Query<HeaderColor>("HeaderColorGetByColor", new
                {
Color = Color
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public HeaderColor GetByID(int ID){
            try
            {
                return connection.QueryFirstOrDefault<HeaderColor>("HeaderColorGetByID", new
                {
ID = ID
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HeaderColor> GetByName(string Name){
            try
            {
                return connection.Query<HeaderColor>("HeaderColorGetByName", new
                {
Name = Name
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HeaderColor> GetByPath(string Path){
            try
            {
                return connection.Query<HeaderColor>("HeaderColorGetByPath", new
                {
Path = Path
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
