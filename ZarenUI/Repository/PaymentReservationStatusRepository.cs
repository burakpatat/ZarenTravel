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
    public class PaymentReservationStatusRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public PaymentReservationStatusRepository(IConfiguration configuration)
        {
             strConnString = configuration.GetConnectionString("ZarenTravel");
            connection = new SqlConnection(strConnString);
        }
  public long Insert(PaymentReservationStatus PaymentReservationStatus)
    {
        try
        {
            return connection.Insert(PaymentReservationStatus);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(PaymentReservationStatus PaymentReservationStatus)
    {
        try
        {
       return  connection.Update(PaymentReservationStatus);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(PaymentReservationStatus PaymentReservationStatus)
        {
            try
            {
            return  connection.Delete<PaymentReservationStatus>(PaymentReservationStatus);
            }
            catch (Exception)
            {
                return false;
            }
        }
public PaymentReservationStatus GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<PaymentReservationStatus>("PaymentReservationStatusGetByID", new
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
