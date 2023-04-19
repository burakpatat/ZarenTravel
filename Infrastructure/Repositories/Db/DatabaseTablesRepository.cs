using System;
using System.Linq;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using Model.Concrete;
using Dapper.Contrib.Extensions;
using Newtonsoft.Json;
using System.IO;
using System.Web;

public class DatabaseTablesRepository : IDisposable
{
    private SqlConnection connection;

    public DatabaseTablesRepository(SqlConnection _connection = null)
    {
        if (_connection == null)
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings[0].ConnectionString);
        else
            connection = _connection;
    }

    public long CreateDatabase(Table DatabaseTables)
    {
        try
        {
            var listDatabaseTables = JsonConvert.DeserializeObject<List<Table>>(File.ReadAllText(HttpContext.Current.Server.MapPath("~/Configuration/DatabaseTables.json")));
            if (listDatabaseTables != null)
            {
                listDatabaseTables.Add(DatabaseTables);
            }

            return connection.Insert(DatabaseTables);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public long ControlDatabase(Table DatabaseTables)
    {
        try
        {

            var listDatabaseTables = JsonConvert.DeserializeObject<List<Table>>(File.ReadAllText(HttpContext.Current.Server.MapPath("~/JsonServer/" + connection.Database + "/" + DatabaseTables.TableName + ".json")));
            if (listDatabaseTables != null)
            {
                listDatabaseTables.Add(DatabaseTables);
            }

            return connection.Insert(DatabaseTables);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public long Insert(Table DatabaseTables)
    {
        try
        {
            var listDatabaseTables = JsonConvert.DeserializeObject<List<Table>>(File.ReadAllText(HttpContext.Current.Server.MapPath("~/DatabaseDesign/DatabaseTables.json")));
            if (listDatabaseTables != null)
            {
                listDatabaseTables.Add(DatabaseTables);
            }

            return connection.Insert(DatabaseTables);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool Update(Table DatabaseTables)
    {
        try
        {
            return connection.Update(DatabaseTables);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool Delete(Table DatabaseTables)
    {
        try
        {
            return connection.Delete<Table>(DatabaseTables);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public Table GetByName(string TableName)
    {
        try
        {
            return new DatabaseHelper().GetAllTables(connection.ConnectionString).Where(a => a.TableName == TableName).FirstOrDefault();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Table> GetAll()
    {
        try
        {
            return new DatabaseHelper().GetAllTables(connection.ConnectionString);
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
