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
    public class InvoiceTypesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public InvoiceTypesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(InvoiceTypes InvoiceTypes)
    {
        try
        {
            return connection.Insert(InvoiceTypes);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(InvoiceTypes InvoiceTypes)
    {
        try
        {
       return  connection.Update(InvoiceTypes);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(InvoiceTypes InvoiceTypes)
        {
            try
            {
            return  connection.Delete<InvoiceTypes>(InvoiceTypes);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<InvoiceTypes> GetAll(){
            try
            {
                return connection.Query<InvoiceTypes>("InvoiceTypesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public InvoiceTypes GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<InvoiceTypes>("InvoiceTypesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<InvoiceTypes> GetByName(string Name){
            try
            {
                return connection.Query<InvoiceTypes>("InvoiceTypesGetByName", new
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
