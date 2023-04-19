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
    public class BookingDealsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public BookingDealsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(BookingDeals BookingDeals)
    {
        try
        {
            return connection.Insert(BookingDeals);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(BookingDeals BookingDeals)
    {
        try
        {
       return  connection.Update(BookingDeals);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(BookingDeals BookingDeals)
        {
            try
            {
            return  connection.Delete<BookingDeals>(BookingDeals);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<BookingDeals> GetAll(){
            try
            {
                return connection.Query<BookingDeals>("BookingDealsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BookingDeals> GetByBookingId(int BookingId){
            try
            {
                return connection.Query<BookingDeals>("BookingDealsGetByBookingId", new
                {
BookingId = BookingId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BookingDeals> GetByDealId(int DealId){
            try
            {
                return connection.Query<BookingDeals>("BookingDealsGetByDealId", new
                {
DealId = DealId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public BookingDeals GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<BookingDeals>("BookingDealsGetByID", new
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
