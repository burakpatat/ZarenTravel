using System;
using System.Linq;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Model.Concrete;
using Dapper.Contrib.Extensions;
public class DatabaseColumnsRepository : IDisposable
{
    private SqlConnection connection;
    public DatabaseColumnsRepository(SqlConnection sqlConnection)
    {
        connection = sqlConnection;
    }
    public long Insert(DatabaseColumns DatabaseColumns)
    {
        try
        {
            return connection.Insert(DatabaseColumns);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool Update(DatabaseColumns DatabaseColumns)
    {
        try
        {
            return connection.Update(DatabaseColumns);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool Delete(DatabaseColumns DatabaseColumns)
    {
        try
        {
            return connection.Delete<DatabaseColumns>(DatabaseColumns);
        }
        catch (Exception ex)
        {
            throw ex;
            return false;
        }
    }
    public List<DatabaseColumns> ByTable(int TableID)
    {
        try
        {
            return connection.Query<DatabaseColumns>("DatabaseColumnsByTable", new
            {
                TableID = TableID
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<DatabaseColumns> ByTableName(string TableName)
    {
        try
        {
            var list = new List<DatabaseColumns>();
            foreach (var item in new DatabaseHelper().GetAllTableColumns(connection.ConnectionString, TableName))
            {
                list.Add(new DatabaseColumns()
                {
                    TableName = item.TableName,
                    ColumnName = item.ColumnName,
                    DbType = item.DbType,
                    HasDefaultValue = item.HasDefaultValue,
                    IsNullable = item.IsNullable == true,
                    IsPrimary = item.IsNullable == false,
                    IsRequired = !item.IsNullable,
                    JsonName = item.ColumnName.ClearTextFilterForJson(),
                    MaxLength = item.MaxLength.ToInt32(),
                    TableOrder = item.TableOrder.ToInt32(),
                });
            }

            return list;


            return connection.Query<DatabaseColumns>("DatabaseColumnsByTableName", new
            {
                TableName = TableName
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<DatabaseColumns> RemoveByNullTable()
    {
        try
        {
            return connection.Query<DatabaseColumns>("DatabaseColumnsRemoveByNullTable", new
            {
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<DatabaseColumns> GetOne(int ID)
    {
        try
        {
            return connection.Query<DatabaseColumns>("DatabaseColumnsGetOne", new
            {
                ID = ID
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DatabaseColumns GetByID(int ID)
    {
        try
        {
            return connection.QueryFirstOrDefault<DatabaseColumns>("DatabaseColumnsGetByID", new
            {
                ID = ID
            }, commandType: CommandType.StoredProcedure);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<DatabaseColumns> GetAll()
    {
        try
        {
            var list = new List<DatabaseColumns>();
            foreach (var item in new DatabaseHelper().GetAllTableColumns(connection.ConnectionString, ""))
            {
                list.Add(new DatabaseColumns()
                {
                    ColumnName = item.ColumnName,
                    DbType = item.DbType,
                    HasDefaultValue = item.HasDefaultValue,
                    IsNullable = item.IsNullable == true,
                    IsPrimary = item.IsNullable == false,
                    IsRequired = !item.IsNullable,
                    JsonName = item.ColumnName.ClearTextFilterForJson(),
                    MaxLength = item.MaxLength.ToInt32(),
                    TableOrder = item.TableOrder.ToInt32()
                });
            }

            return list;
        }
        catch
        {
            var list = new List<DatabaseColumns>();
            foreach (var item in new DatabaseHelper().GetAllTableColumns(connection.ConnectionString))
            {
                list.Add(new DatabaseColumns()
                {
                    ColumnName = item.ColumnName,
                    DbType = item.DbType,
                    HasDefaultValue = item.HasDefaultValue,
                    IsNullable = item.IsNullable == true,
                    IsPrimary = item.IsNullable == false,
                    IsRequired = !item.IsNullable,
                    JsonName = item.ColumnName.ClearTextFilterForJson(),
                    MaxLength = item.MaxLength.ToInt32(),
                    TableOrder = item.TableOrder.ToInt32()
                });
            }

            return list;
        }
    }
    public List<DatabaseColumns> GetAllProcedure()
    {
        try
        {
            return connection.Query<DatabaseColumns>("select SPECIFIC_NAME as TableName from INFORMATION_SCHEMA.PARAMETERS group by SPECIFIC_NAME", commandType: CommandType.Text).ToList();

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
