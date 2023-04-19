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
    public class SegmentsServicesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public SegmentsServicesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(SegmentsServices SegmentsServices)
    {
        try
        {
            return connection.Insert(SegmentsServices);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(SegmentsServices SegmentsServices)
    {
        try
        {
       return  connection.Update(SegmentsServices);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(SegmentsServices SegmentsServices)
        {
            try
            {
            return  connection.Delete<SegmentsServices>(SegmentsServices);
            }
            catch (Exception)
            {
                return false;
            }
        }
 public void Dispose()
            {
                GC.SuppressFinalize(this);
            }
    }
