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
using Microsoft.Extensions.Configuration;
    public class Table_1Repository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public Table_1Repository(IConfiguration configuration)
        {
             strConnString = configuration.GetSection("ConnectionString").Value;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Table_1 Table_1)
    {
        try
        {
            return connection.Insert(Table_1);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Table_1 Table_1)
    {
        try
        {
       return  connection.Update(Table_1);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Table_1 Table_1)
        {
            try
            {
            return  connection.Delete<Table_1>(Table_1);
            }
            catch (Exception)
            {
                return false;
            }
        }
public Table_1 GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Table_1>("Table_1GetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

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
