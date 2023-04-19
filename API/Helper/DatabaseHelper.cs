using Dapper;
using Model.Concrete;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Table = Model.Concrete.Table;

public class DatabaseHelper : IDisposable
{
    private System.Data.SqlClient.SqlConnection connection;
    private readonly string _environment;
    private const string _prodEnvironment = "PROD";
    private readonly string _MethodPath;
    private readonly string _Type;
    private readonly string _strConnString;

    public DatabaseHelper()
    {
        _environment = MyConfiguration.Configuration.GetSection("Env").Value;
        _strConnString = MyConfiguration.Configuration.GetSection("ConnectionString").Value;
        _MethodPath = MyConfiguration.Configuration.GetSection("MethodPath").Value;
        _Type = MyConfiguration.Configuration.GetSection("Type").Value;
    }
    public List<Table> GetDatabaseTablesAndColumnsInASqlServer(string strConnString)
    {
        try
        {
            connection = new SqlConnection(strConnString);
            return connection.Query<Table>("select Table_Name as TableName from INFORMATION_SCHEMA.COLUMNS where TABLE_SCHEMA='dbo' and  Table_Name not in (select name from sys.all_views where  object_id>0 ) group by Table_Name", commandType: CommandType.Text).Where(a => a.TableName != "__EFMigrationsHistory" && a.TableName != "DistributedServerCache" && a.TableName != "SqlCatchLogs").OrderByDescending(a => a.TableOrder).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public async Task<List<Table>> GetAllTablesAsync(string strConnString)
    {
        try
        {
            connection = new SqlConnection(strConnString);
            var list = (await connection.QueryAsync<Table>("select Table_Name as TableName from INFORMATION_SCHEMA.COLUMNS where TABLE_SCHEMA='dbo' and  Table_Name not in (select name from sys.all_views where  object_id>0 ) group by Table_Name", commandType: CommandType.Text)).Where(a => a.TableName != "__EFMigrationsHistory" && a.TableName != "DistributedServerCache" && a.TableName != "SqlCatchLogs").OrderByDescending(a => a.TableOrder).ToList();
            return list;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public List<Table> GetAllTables(string strConnString)
    {
        try
        {
            connection = new SqlConnection(strConnString);
            var list = connection.Query<Table>("select Table_Name as TableName from INFORMATION_SCHEMA.COLUMNS where TABLE_SCHEMA='dbo' and  Table_Name not in (select name from sys.all_views where  object_id>0 ) group by Table_Name", commandType: CommandType.Text).Where(a => a.TableName != "__EFMigrationsHistory" && a.TableName != "DistributedServerCache" && a.TableName != "SqlCatchLogs").OrderByDescending(a => a.TableOrder).ToList();
            return list;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public string GenerateProcedure(string strConnString, RequestMethod RequestMethod)
    {
        try
        {
            int response = 0;
            connection = new SqlConnection(strConnString);

            IEnumerable<string> commandStrings = Regex.Split(GenerateProcedureQuery(RequestMethod), @"^\s*GO\s*$",
                   RegexOptions.Multiline | RegexOptions.IgnoreCase);
            connection.Open();
            foreach (string commandString in commandStrings.Where(commandString => commandString.Trim() != ""))
            {
                using (var command = new SqlCommand(commandString, connection))
                {
                    response = command.ExecuteNonQuery();
                }
            }
            connection.Close();
            return response.ToJson();
        }
        catch (Exception ex)
        {
            return ex.ToJson();
        }

    }

    public string GenerateProcedureQuery(RequestMethod RequestMethod)
    {
        //Create a new StringBuilder object
        StringBuilder sb = new StringBuilder();
        StringBuilder sbParams = new StringBuilder();
        sb.AppendLine("create PROCEDURE [dbo].[_" + RequestMethod.Method.Name + "]");

        foreach (var item in RequestMethod.Method.Request)
        {
            if (!item.Parameter_Name.StartsWith("@"))
            {
                sbParams.Append("@" + item.Parameter_Name.Split('=')[0] + " " + item.DbType.ToDbNvarcharType(item.MaxLength?.ToInt32()) + ",");
            }
            else
            {
                sbParams.Append(item.Parameter_Name.Split('=')[0] + " " + item.DbType.ToDbNvarcharType(item.MaxLength?.ToInt32()) + ",");
            }
        }

        sb.AppendLine(sbParams.ToString().TrimEnd(','));
        sb.AppendLine("AS");
        sb.AppendLine("BEGIN TRY  ");
        sb.AppendLine(RequestMethod.Method.Query);
        sb.AppendLine("END TRY  ");
        sb.AppendLine("BEGIN CATCH  ");
        sb.AppendLine("END CATCH; ");
        sb.AppendLine("SET ANSI_NULLS ON");
        return sb.ToString();
    }



    String DynamicTablePager(string table, int PageSize = 50, int PageNum = 1, string orderColumn = "Id", bool orderByIsDecending = true)
    {
        //Create a new StringBuilder object
        StringBuilder sb = new StringBuilder();

        sb.AppendLine(" WITH LIST ");
        sb.AppendLine("AS");
        sb.AppendLine("(");
        sb.AppendLine("SELECT  *");
        sb.AppendLine("  FROM " + table + "");
        sb.AppendLine("), ");
        sb.AppendLine("LISTCOUNT ");
        sb.AppendLine("AS ");
        sb.AppendLine("(");
        sb.AppendLine("    SELECT COUNT(*) AS TotalRows FROM LIST");
        sb.AppendLine(")");
        sb.AppendLine("SELECT *");
        sb.AppendLine("FROM LIST");
        sb.AppendLine("CROSS JOIN LISTCOUNT");
        if (orderColumn != "")
            sb.AppendLine(" order by " + orderColumn);
        if (orderByIsDecending)
            sb.AppendLine(" desc ");
        sb.AppendLine("OFFSET (" + PageNum + " - 1) * " + PageSize + " ROWS");
        sb.AppendLine("FETCH NEXT " + PageSize + " ROWS ONLY;");
        return sb.ToString();
    }
    public List<Table> GetAllProcedures(string TableName, string connectionString)
    {
        try
        {
            var connection = new SqlConnection(connectionString);


            var query = ("SELECT SCHEMA_NAME(schema_id) as [Schema], name as TableName, name as ProcedureName, object_id as ObjectId ,(select definition from sys.all_sql_modules where object_id=pp.object_id ) as Query FROM sys.procedures as pp order by name");
            var _listFrom = connection.Query<Table>(query).ToList();
            if (TableName == "0")
            {
                return _listFrom;
            }
            else
            {
                return _listFrom.Where(a => a.TableName.StartsWith(TableName)).ToList();
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<object> GetResultWithQuery(string strConnString, string query)
    {
        try
        {
            connection = new SqlConnection(strConnString);
            var result = connection.Query<object>(query, commandType: CommandType.Text).ToList();
            return result;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public object GetResultWithQueryFirstOrDefault(string strConnString, string query)
    {
        try
        {
            connection = new SqlConnection(strConnString);
            return connection.QueryFirstOrDefault<object>(query, commandType: CommandType.Text);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public int GetCount(string strConnString, string query)
    {
        try
        {
            connection = new SqlConnection(strConnString);
            return connection.ExecuteScalar<int>(query);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public List<DatabaseColumns> GetColumnsByTableWithDetail(string strConnString, string TableName)
    {
        List<DatabaseColumns> list = new List<DatabaseColumns>();


        foreach (var item in GetColumnsByTable(strConnString, TableName))
        {


        }





        return list.ToList();

    }
    public List<SchemeTableColumns> GetColumnsByTable(string strConnString, string TableName)
    {
        try
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT sch.name AS SchemaName,tables.name AS TableName ,sc.name AS ColumnName,  t.name + ");
            sb.AppendLine("    CASE ");
            sb.AppendLine("        WHEN t.name IN ('char', 'varchar', 'nchar', 'nvarchar', 'binary', 'varbinary') ");
            sb.AppendLine("            THEN '('+CASE WHEN sc.max_length = -1 THEN 'MAX' ELSE CONVERT(varchar(4),CASE WHEN t.name IN ('nchar', 'nvarchar') THEN sc.max_length/2 ELSE sc.max_length END) END + ')' ");
            sb.AppendLine("        WHEN t.name IN ('decimal', 'numeric')");
            sb.AppendLine("            THEN '(' + CONVERT(varchar(4), sc.precision)+', ' + CONVERT(varchar(4), sc.Scale) + ')'");
            sb.AppendLine("        WHEN t.name IN ('time', 'datetime2', 'datetimeoffset') ");
            sb.AppendLine("            THEN N'(' + CAST(ODBCSCALE(sc.system_type_id, sc.scale) AS national character varying(36)) + N')' ");
            sb.AppendLine("        ELSE '' ");
            sb.AppendLine("    END AS DbTypeWithMaxLengt ");
            sb.AppendLine("  ,t.name AS DbType  ,CASE WHEN sc.is_nullable = 1 THEN 1 ELSE 0 END AS IsNullable,CASE WHEN sc.is_nullable = 1 THEN 0 ELSE 1 END AS IsRequired ");
            sb.AppendLine("    ,sc.is_identity IsPrimary ,COLUMNPROPERTY(sc.object_id, sc.name, 'ordinal') AS TableOrder ,COLUMNPROPERTY(sc.object_id, sc.name, 'charmaxlen') AS [MaxLength]     ");
            sb.AppendLine("    ,CONVERT(tinyint, CASE -- int/decimal/numeric/real/float/money  ");
            sb.AppendLine("        WHEN sc.system_type_id IN (48, 52, 56, 59, 60, 62, 106, 108, 122, 127) THEN sc.precision  ");
            sb.AppendLine("        END) AS IsNumber ");
            sb.AppendLine("    ,CONVERT(int, CASE -- datetime/smalldatetime  ");
            sb.AppendLine("        WHEN sc.system_type_id IN (40, 41, 42, 43, 58, 61) THEN NULL  ");
            sb.AppendLine("        ELSE ODBCSCALE(sc.system_type_id, sc.scale) ");
            sb.AppendLine("        END) AS IsDecimal         ");
            sb.AppendLine("    ,CONVERT(smallint, CASE -- datetime/smalldatetime  ");
            sb.AppendLine("        WHEN sc.system_type_id IN (40, 41, 42, 43, 58, 61) ");
            sb.AppendLine("        THEN ODBCSCALE(sc.system_type_id, sc.scale) ");
            sb.AppendLine("    END) AS IsDatetime ,sm.text AS DefaultValue FROM sys.columns AS sc ");
            sb.AppendLine(" INNER JOIN sys.objects AS o ON o.object_id = sc.object_id ");
            sb.AppendLine("INNER JOIN sys.tables AS tables ON sc.object_id = tables.object_id ");
            sb.AppendLine("INNER JOIN sys.schemas AS sch ON sch.schema_id = tables.schema_id ");
            sb.AppendLine("LEFT JOIN sys.computed_columns AS col ON col.object_id = sc.object_id AND col.column_id = sc.column_id ");
            sb.AppendLine("INNER JOIN sys.types AS t ON sc.user_type_id = t.user_type_id ");
            sb.AppendLine("LEFT JOIN sys.syscomments AS sm ON sm.id = sc.default_object_id");
            sb.AppendLine("LEFT JOIN sys.default_constraints AS dc  ");
            sb.AppendLine("    ON dc.parent_object_id = tables.object_id  ");
            sb.AppendLine("    AND dc.parent_column_id = sc.object_id     ");
            sb.AppendLine("LEFT JOIN ");
            sb.AppendLine("    (");
            sb.AppendLine("            SELECt ");
            sb.AppendLine("                    1 AS tbl_id");
            sb.AppendLine("                ,sch.name AS table_schema");
            sb.AppendLine("                ,tables.name AS table_name ");
            sb.AppendLine("                ,sch.schema_id ");
            sb.AppendLine("                ,tables.object_id ");
            sb.AppendLine("            FROM sys.tables AS tables -- ON sc.object_id = tables.object_id ");
            sb.AppendLine("            INNER JOIN sys.schemas AS sch ON sch.schema_id = tables.schema_id ");
            sb.AppendLine("            INNER JOIN sys.extended_properties AS xp ON xp.major_id = tables.object_id AND xp.minor_id = 0 ");
            sb.AppendLine("            AND xp.name = 'microsoft_database_tools_support' ");
            sb.AppendLine("            GROUP BY sch.schema_id, sch.name, tables.object_id, tables.name ");
            sb.AppendLine("    ) AS systemTables ");
            sb.AppendLine("    ON systemTables.schema_id = sch.schema_id  ");
            sb.AppendLine("    AND systemTables.object_id = tables.object_id  ");
            sb.AppendLine("");
            sb.AppendLine("WHERE (1=1) -- 12'846");
            sb.AppendLine("AND tables.is_ms_shipped = 0 -- 12'839 ");
            sb.AppendLine("AND systemTables.tbl_id IS NULL ");


            connection = new SqlConnection(strConnString);
            var list = connection.Query<SchemeTableColumns>(sb.ToString(), commandType: CommandType.Text).ToList();
            if (TableName != null && TableName != "")
                list = list.Where(a => a.TableName == TableName).ToList();
            return list.OrderByDescending(a => a.IsPrimary).ThenBy(a => a.TableOrder).ToList();
        }
        catch
        {
            return null;
        }
    }
    public List<SqlColumn> GetAllColumnsForDB(string strConnString, string TableName)
    {
        try
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SELECT ");
            sb.AppendLine(" OBJECT_Name( c.object_id) as TableName,");
            sb.AppendLine("    c.name 'ColumnName',");
            sb.AppendLine("    t.Name 'DbType',");
            sb.AppendLine("    c.max_length 'MaxLength' ,");
            sb.AppendLine("  OBJECT_Name(c.default_object_id) as DefaultValue,");
            sb.AppendLine("    c.is_nullable as IsNullable,");
            sb.AppendLine("    ISNULL(is_primary_key, 0) 'IsPrimary',");
            sb.AppendLine(" i.type_desc as IndexDesc,");
            sb.AppendLine(" i.name as IndexName, c.column_id as TableOrder");
            sb.AppendLine("FROM    ");
            sb.AppendLine("    sys.columns c");
            sb.AppendLine("INNER JOIN ");
            sb.AppendLine("    sys.types t ON c.user_type_id = t.user_type_id");
            sb.AppendLine("LEFT OUTER JOIN ");
            sb.AppendLine("    sys.index_columns ic ON ic.object_id = c.object_id AND ic.column_id = c.column_id");
            sb.AppendLine("LEFT OUTER JOIN ");
            sb.AppendLine("    sys.indexes i ON ic.object_id = i.object_id AND ic.index_id = i.index_id");
            connection = new SqlConnection(strConnString);
            var list = connection.Query<SqlColumn>(sb.ToString(), commandType: CommandType.Text).ToList();

            return list.OrderByDescending(a => a.IsPrimary).ThenBy(a => a.TableName).ToList();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public string GetAllColumnsWithoutPrimary(string strConnString, string TableName)
    {
        //Create a new StringBuilder object
        StringBuilder sb = new StringBuilder();

        sb.AppendLine("SELECT COLUMN_NAME");
        sb.AppendLine("FROM INFORMATION_SCHEMA.COLUMNS ");
        sb.AppendLine("JOIN sysobjects ON TABLE_NAME = name");
        sb.AppendLine("WHERE TABLE_NAME = " + TableName);
        sb.AppendLine("AND COLUMN_NAME NOT IN (");
        sb.AppendLine("    SELECT name ");
        sb.AppendLine("    FROM syscolumns ");
        sb.AppendLine("    WHERE [id] IN (SELECT [id] ");
        sb.AppendLine("        FROM sysobjects ");
        sb.AppendLine("        WHERE [name] = " + TableName + ")");
        sb.AppendLine("        AND colid IN (SELECT SIK.colid ");
        sb.AppendLine("        FROM sysindexkeys SIK ");
        sb.AppendLine("        JOIN sysobjects SO ON SIK.[id] = SO.[id]  ");
        sb.AppendLine("        WHERE SIK.indid = 1");
        sb.AppendLine("            AND SO.[name] = " + TableName + "))");


        connection = new SqlConnection(strConnString);
        var list = connection.Query<object>(sb.ToString(), commandType: CommandType.Text);

        return list.ToJson();
    }

    public List<DatabaseColumns> GetAllColumnsWithProperty(string strConnString, string TableName)
    {
        try
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SELECT ");
            sb.AppendLine(" OBJECT_Name( c.object_id) as TableName,");
            sb.AppendLine("    c.name 'ColumnName',");
            sb.AppendLine("    t.Name 'DbType',");
            sb.AppendLine("    c.max_length 'MaxLength' ,");
            sb.AppendLine("  OBJECT_Name(c.default_object_id) as DefaultValue,");
            sb.AppendLine("    c.is_nullable as IsNullable,");
            sb.AppendLine("    ISNULL(is_primary_key, 0) 'IsPrimary',");
            sb.AppendLine(" i.type_desc as IndexDesc,");
            sb.AppendLine(" i.name as IndexName, c.column_id as TableOrder");
            sb.AppendLine("FROM    ");
            sb.AppendLine("    sys.columns c");
            sb.AppendLine("INNER JOIN ");
            sb.AppendLine("    sys.types t ON c.user_type_id = t.user_type_id");
            sb.AppendLine("LEFT OUTER JOIN ");
            sb.AppendLine("    sys.index_columns ic ON ic.object_id = c.object_id AND ic.column_id = c.column_id");
            sb.AppendLine("LEFT OUTER JOIN ");
            sb.AppendLine("    sys.indexes i ON ic.object_id = i.object_id AND ic.index_id = i.index_id");

            if (TableName != "")
                sb.AppendLine(" where c.object_id = OBJECT_ID('" + TableName + "')");
            connection = new SqlConnection(strConnString);
            return connection.Query<DatabaseColumns>(sb.ToString(), commandType: CommandType.Text).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<FKTables> GetTableFK(string strConnString, string TableName)
    {
        try
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("");
            sb.AppendLine("SELECT ");
            sb.AppendLine("  KCU1.CONSTRAINT_SCHEMA AS FK_CONSTRAINT_SCHEMA ");
            sb.AppendLine("    ,KCU1.CONSTRAINT_NAME AS FK_CONSTRAINT_NAME ");
            sb.AppendLine(" ,KCU1.TABLE_SCHEMA AS FK_TABLE_SCHEMA ");
            sb.AppendLine("    ,KCU1.TABLE_NAME AS FK_TABLE_NAME ");
            sb.AppendLine("    ,KCU1.COLUMN_NAME AS FK_COLUMN_NAME ");
            sb.AppendLine("    ,KCU1.ORDINAL_POSITION AS FK_ORDINAL_POSITION ");
            sb.AppendLine("    ,KCU2.CONSTRAINT_SCHEMA AS REFERENCED_CONSTRAINT_SCHEMA ");
            sb.AppendLine(" ,KCU2.CONSTRAINT_NAME AS REFERENCED_CONSTRAINT_NAME ");
            sb.AppendLine("    ,KCU2.TABLE_SCHEMA AS REFERENCED_TABLE_SCHEMA ");
            sb.AppendLine(" ,KCU2.TABLE_NAME AS REFERENCED_TABLE_NAME ");
            sb.AppendLine("    ,KCU2.COLUMN_NAME AS REFERENCED_COLUMN_NAME ");
            sb.AppendLine("    ,KCU2.ORDINAL_POSITION AS REFERENCED_ORDINAL_POSITION ");
            sb.AppendLine("INTO #tForeignKey ");
            sb.AppendLine("FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS AS RC ");
            sb.AppendLine("");
            sb.AppendLine("INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS KCU1 ");
            sb.AppendLine("    ON KCU1.CONSTRAINT_CATALOG = RC.CONSTRAINT_CATALOG  ");
            sb.AppendLine("    AND KCU1.CONSTRAINT_SCHEMA = RC.CONSTRAINT_SCHEMA ");
            sb.AppendLine("    AND KCU1.CONSTRAINT_NAME = RC.CONSTRAINT_NAME ");
            sb.AppendLine("");
            sb.AppendLine("INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS KCU2 ");
            sb.AppendLine("    ON KCU2.CONSTRAINT_CATALOG = RC.UNIQUE_CONSTRAINT_CATALOG  ");
            sb.AppendLine("    AND KCU2.CONSTRAINT_SCHEMA = RC.UNIQUE_CONSTRAINT_SCHEMA ");
            sb.AppendLine("    AND KCU2.CONSTRAINT_NAME = RC.UNIQUE_CONSTRAINT_NAME ");
            sb.AppendLine("    AND KCU2.ORDINAL_POSITION = KCU1.ORDINAL_POSITION ");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("SELECT ");
            sb.AppendLine("  FK_CONSTRAINT_SCHEMA ");
            sb.AppendLine(" ,FK_CONSTRAINT_NAME ");
            sb.AppendLine(" ,FK_TABLE_SCHEMA ");
            sb.AppendLine(" ,FK_TABLE_NAME ");
            sb.AppendLine(" ,REFERENCED_TABLE_SCHEMA");
            sb.AppendLine(" ,REFERENCED_TABLE_NAME");
            sb.AppendLine("");
            sb.AppendLine(" ,tAllFkColumns.FK_COLUMNS ,");
            sb.AppendLine("  tAllReferencedColumns.REFERENCED_COLUMNS ");
            sb.AppendLine(" ");
            sb.AppendLine(" ,N'ALTER TABLE ' + QUOTENAME(fk.FK_TABLE_SCHEMA)+ N'.' + QUOTENAME(fk.FK_TABLE_NAME) + N' ");
            sb.AppendLine("ADD CONSTRAINT ' + QUOTENAME(fk.FK_CONSTRAINT_NAME) + N' ");
            sb.AppendLine("FOREIGN KEY(' + tAllFkColumns.FK_COLUMNS + N') ");
            sb.AppendLine("REFERENCES ' + QUOTENAME(REFERENCED_TABLE_SCHEMA) + N'.' + QUOTENAME(REFERENCED_TABLE_NAME) ");
            sb.AppendLine("+ N' (' + tAllReferencedColumns.REFERENCED_COLUMNS  + N'); ' ");
            sb.AppendLine(" AS SqlCreateFK ");
            sb.AppendLine("FROM #tForeignKey AS fk ");
            sb.AppendLine("");
            sb.AppendLine("OUTER APPLY ");
            sb.AppendLine(" (");
            sb.AppendLine("     SELECT ");
            sb.AppendLine("         STUFF");
            sb.AppendLine("         (");
            sb.AppendLine("             (");
            sb.AppendLine("                 SELECT ");
            sb.AppendLine("                     N', ' + QUOTENAME(SourceTable.FK_COLUMN_NAME) AS[text()]");
            sb.AppendLine("                 FROM #tForeignKey AS SourceTable ");
            sb.AppendLine("                 WHERE SourceTable.FK_CONSTRAINT_SCHEMA = fk.FK_CONSTRAINT_SCHEMA ");
            sb.AppendLine("                 AND SourceTable.FK_CONSTRAINT_NAME = fk.FK_CONSTRAINT_NAME ");
            sb.AppendLine("                 ORDER BY SourceTable.FK_ORDINAL_POSITION ");
            sb.AppendLine("                 FOR XML PATH(''), TYPE ");
            sb.AppendLine("             ).value('.', 'nvarchar(MAX)')");
            sb.AppendLine("             , 1, 2,''");
            sb.AppendLine("         ) AS FK_COLUMNS ");
            sb.AppendLine(" ) AS tAllFkColumns ");
            sb.AppendLine("");
            sb.AppendLine("OUTER APPLY ");
            sb.AppendLine(" (");
            sb.AppendLine("     SELECT ");
            sb.AppendLine("         STUFF");
            sb.AppendLine("         (");
            sb.AppendLine("             (");
            sb.AppendLine("                 SELECT ");
            sb.AppendLine("                     N', ' + QUOTENAME(tReferencedTable.REFERENCED_COLUMN_NAME) AS[text()] ");
            sb.AppendLine("                 FROM #tForeignKey AS tReferencedTable ");
            sb.AppendLine("                 WHERE tReferencedTable.FK_CONSTRAINT_SCHEMA = fk.FK_CONSTRAINT_SCHEMA ");
            sb.AppendLine("                 AND tReferencedTable.FK_CONSTRAINT_NAME  = fk.FK_CONSTRAINT_NAME  ");
            sb.AppendLine("                 ORDER BY tReferencedTable.REFERENCED_ORDINAL_POSITION ");
            sb.AppendLine("                 FOR XML PATH(''), TYPE ");
            sb.AppendLine("             ).value('.', 'nvarchar(MAX)')");
            sb.AppendLine("             , 1, 2,''");
            sb.AppendLine("         ) AS REFERENCED_COLUMNS ");
            sb.AppendLine("");
            sb.AppendLine(" ) AS tAllReferencedColumns ");
            sb.AppendLine("");
            sb.AppendLine("WHERE (1=1) ");
            sb.AppendLine("");
            sb.AppendLine("GROUP BY ");
            sb.AppendLine("  FK_CONSTRAINT_SCHEMA");
            sb.AppendLine(" ,FK_CONSTRAINT_NAME ");
            sb.AppendLine(" ,FK_TABLE_SCHEMA ");
            sb.AppendLine(" ,FK_TABLE_NAME");
            sb.AppendLine(" ,REFERENCED_CONSTRAINT_SCHEMA");
            sb.AppendLine(" ,REFERENCED_CONSTRAINT_NAME");
            sb.AppendLine(" ,REFERENCED_TABLE_SCHEMA ");
            sb.AppendLine(" ,REFERENCED_TABLE_NAME");
            sb.AppendLine(" ,tAllFkColumns.FK_COLUMNS ");
            sb.AppendLine(" ,tAllReferencedColumns.REFERENCED_COLUMNS ");
            sb.AppendLine("");
            connection = new SqlConnection(strConnString);
            return connection.Query<FKTables>(sb.ToString(), commandType: CommandType.Text).ToList().Where(a => a.REFERENCED_TABLE_NAME == TableName).ToList();

        }
        catch (Exception ex)
        {
            throw new Exception(TableName);
        }
    }


    public List<Table> GenerateQuery(string query, string strConnString)
    {
        try
        {
            if (strConnString == "")
                strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString.ToString();

            connection = new SqlConnection(strConnString);
            return connection.Query<Table>(query, commandType: CommandType.Text).ToList();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public List<dynamic> GetRoleQuery(string query, string strConnString)
    {
        try
        {
            if (strConnString == "")
                strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString.ToString();

            connection = new SqlConnection(strConnString);
            return connection.Query<dynamic>(query, commandType: CommandType.Text).ToList();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public List<Table> GetProcedureNamesForTable(string strConnString, string TableName)
    {
        try
        {
            if (strConnString == "")
                strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString.ToString();

            connection = new SqlConnection(strConnString);
            var list = connection.Query<Table>("SELECT name as TableName, object_id as ObjectId ,(select definition from sys.all_sql_modules where object_id=pp.object_id ) as Query FROM sys.procedures as pp order by name", commandType: CommandType.Text).ToList().Where(a => a.TableName.StartsWith(TableName)).ToList();
            return list;

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public List<ResponseParams> GetResponseParamsForProcedure(string strConnString, string ProcedureName)
    {
        try
        {
            connection = new SqlConnection(strConnString);
            var list = connection.Query<ResponseParams>("SELECT name  as ColumnName, system_type_name as DbType, is_identity_column as IsPrimary, column_ordinal as TableOrder, max_length as [MaxLength], is_nullable as IsNullable, is_updateable as IsUpdatable FROM sys.dm_exec_describe_first_result_set(N'EXEC " + ProcedureName + "', NULL, 0) where  name is not null; ", commandType: CommandType.Text).ToList();
            return list;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<RequestParams> GetRequestParamsForProcedure(string strConnString, string ProcedureName)
    {
        try
        {

            connection = new SqlConnection(strConnString);
            var list = connection.Query<RequestParams>("select  SPECIFIC_SCHEMA as [Schema], SPECIFIC_NAME as TableName, ORDINAL_POSITION as TableOrder, PARAMETER_NAME as ColumnName, Data_Type as DbType, CHARACTER_MAXIMUM_LENGTH as [MaxLength] from INFORMATION_SCHEMA.PARAMETERS where SPECIFIC_NAME='" + ProcedureName + "'", commandType: CommandType.Text).ToList();
            return list;

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
