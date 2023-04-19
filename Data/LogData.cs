using Dapper;
using log4net;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

public class LoggerData
{
    ILog logger;
    private SqlConnection connection;
    public LoggerData(string ConnectionString)
    {
        connection = new SqlConnection(ConnectionString);
    }

    public async Task Insert(LogModel LogData)
    {
        try
        {
            await Task.Run(() =>
            {
                connection.Query<LogModel>("LogInsert", LogData, commandType: CommandType.StoredProcedure);
            });
        }
        catch (Exception ex)
        {
        }
    }
}

