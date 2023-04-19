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
    public class BookingReservationsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public BookingReservationsRepository(IConfiguration configuration)
        {
             strConnString = configuration.GetConnectionString("ZarenTravel");
            connection = new SqlConnection(strConnString);
        }
  public long Insert(BookingReservations BookingReservations)
    {
        try
        {
            return connection.Insert(BookingReservations);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(BookingReservations BookingReservations)
    {
        try
        {
       return  connection.Update(BookingReservations);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(BookingReservations BookingReservations)
        {
            try
            {
            return  connection.Delete<BookingReservations>(BookingReservations);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<BookingReservations> GetAll(){
            try
            {
                return connection.Query<BookingReservations>("BookingReservationsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BookingReservations> GetBeginDateBetween(DateTime BeginDateStart,DateTime BeginDateEnd){
            try
            {
                return connection.Query<BookingReservations>("BookingReservationsGetBeginDateBetween", new
                {
BeginDateStart = BeginDateStart
,BeginDateEnd = BeginDateEnd
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BookingReservations> GetByBeginDate(DateTime BeginDate){
            try
            {
                return connection.Query<BookingReservations>("BookingReservationsGetByBeginDate", new
                {
BeginDate = BeginDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    public List<BookingReservations> GetByCookie(string CookieId)
    {
        try
        {
            return connection.Query<BookingReservations>("BookingReservationsGetByCookieIdByOnBasketByOnExpireDate", new
            {
                CookieId = CookieId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
public List<BookingReservations> GetByCookieId(string CookieId){
            try
            {
                return connection.Query<BookingReservations>("BookingReservationsGetByCookieId", new
                {
CookieId = CookieId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BookingReservations> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<BookingReservations>("BookingReservationsGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BookingReservations> GetByCultureId(int CultureId){
            try
            {
                return connection.Query<BookingReservations>("BookingReservationsGetByCultureId", new
                {
CultureId = CultureId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BookingReservations> GetByCurrencyId(int CurrencyId){
            try
            {
                return connection.Query<BookingReservations>("BookingReservationsGetByCurrencyId", new
                {
CurrencyId = CurrencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BookingReservations> GetByEndDate(DateTime EndDate){
            try
            {
                return connection.Query<BookingReservations>("BookingReservationsGetByEndDate", new
                {
EndDate = EndDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BookingReservations> GetByExpireDate(DateTime ExpireDate){
            try
            {
                return connection.Query<BookingReservations>("BookingReservationsGetByExpireDate", new
                {
ExpireDate = ExpireDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BookingReservations> GetByGuid(string Guid){
            try
            {
                return connection.Query<BookingReservations>("BookingReservationsGetByGuid", new
                {
Guid = Guid
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BookingReservations> GetByHasPaid(int HasPaid){
            try
            {
                return connection.Query<BookingReservations>("BookingReservationsGetByHasPaid", new
                {
HasPaid = HasPaid
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public BookingReservations GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<BookingReservations>("BookingReservationsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BookingReservations> GetByNote(string Note){
            try
            {
                return connection.Query<BookingReservations>("BookingReservationsGetByNote", new
                {
Note = Note
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BookingReservations> GetByOfferId(string OfferId){
            try
            {
                return connection.Query<BookingReservations>("BookingReservationsGetByOfferId", new
                {
OfferId = OfferId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BookingReservations> GetByProductId(string ProductId){
            try
            {
                return connection.Query<BookingReservations>("BookingReservationsGetByProductId", new
                {
ProductId = ProductId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BookingReservations> GetByProductType(int ProductType){
            try
            {
                return connection.Query<BookingReservations>("BookingReservationsGetByProductType", new
                {
ProductType = ProductType
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BookingReservations> GetByReservationNumber(string ReservationNumber){
            try
            {
                return connection.Query<BookingReservations>("BookingReservationsGetByReservationNumber", new
                {
ReservationNumber = ReservationNumber
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BookingReservations> GetByTransactionId(string TransactionId){
            try
            {
                return connection.Query<BookingReservations>("BookingReservationsGetByTransactionId", new
                {
TransactionId = TransactionId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BookingReservations> GetByUserAgent(string UserAgent){
            try
            {
                return connection.Query<BookingReservations>("BookingReservationsGetByUserAgent", new
                {
UserAgent = UserAgent
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BookingReservations> GetByUserId(string UserId){
            try
            {
                return connection.Query<BookingReservations>("BookingReservationsGetByUserId", new
                {
UserId = UserId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BookingReservations> GetByUserIp(string UserIp){
            try
            {
                return connection.Query<BookingReservations>("BookingReservationsGetByUserIp", new
                {
UserIp = UserIp
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BookingReservations> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<BookingReservations>("BookingReservationsGetCreatedDateBetween", new
                {
CreatedDateStart = CreatedDateStart
,CreatedDateEnd = CreatedDateEnd
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BookingReservations> GetEndDateBetween(DateTime EndDateStart,DateTime EndDateEnd){
            try
            {
                return connection.Query<BookingReservations>("BookingReservationsGetEndDateBetween", new
                {
EndDateStart = EndDateStart
,EndDateEnd = EndDateEnd
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BookingReservations> GetExpireDateBetween(DateTime ExpireDateStart,DateTime ExpireDateEnd){
            try
            {
                return connection.Query<BookingReservations>("BookingReservationsGetExpireDateBetween", new
                {
ExpireDateStart = ExpireDateStart
,ExpireDateEnd = ExpireDateEnd
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
