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
    public class PaymentTypesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public PaymentTypesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(PaymentTypes PaymentTypes)
    {
        try
        {
            return connection.Insert(PaymentTypes);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(PaymentTypes PaymentTypes)
    {
        try
        {
       return  connection.Update(PaymentTypes);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(PaymentTypes PaymentTypes)
        {
            try
            {
            return  connection.Delete<PaymentTypes>(PaymentTypes);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<PaymentTypes> GetAll(){
            try
            {
                return connection.Query<PaymentTypes>("PaymentTypesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PaymentTypes> GetByForDeferredB2B(bool ForDeferredB2B){
            try
            {
                return connection.Query<PaymentTypes>("PaymentTypesGetByForDeferredB2B", new
                {
ForDeferredB2B = ForDeferredB2B
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PaymentTypes> GetByForDeferredB2C(bool ForDeferredB2C){
            try
            {
                return connection.Query<PaymentTypes>("PaymentTypesGetByForDeferredB2C", new
                {
ForDeferredB2C = ForDeferredB2C
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public PaymentTypes GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<PaymentTypes>("PaymentTypesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PaymentTypes> GetByName(string Name){
            try
            {
                return connection.Query<PaymentTypes>("PaymentTypesGetByName", new
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
