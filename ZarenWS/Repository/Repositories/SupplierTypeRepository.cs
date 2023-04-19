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
    public class SupplierTypeRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public SupplierTypeRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(SupplierType SupplierType)
    {
        try
        {
            return connection.Insert(SupplierType);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(SupplierType SupplierType)
    {
        try
        {
       return  connection.Update(SupplierType);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(SupplierType SupplierType)
        {
            try
            {
            return  connection.Delete<SupplierType>(SupplierType);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<SupplierType> GetAll(){
            try
            {
                return connection.Query<SupplierType>("SupplierTypeGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public SupplierType GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<SupplierType>("SupplierTypeGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SupplierType> GetByName(string Name){
            try
            {
                return connection.Query<SupplierType>("SupplierTypeGetByName", new
                {
Name = Name
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
