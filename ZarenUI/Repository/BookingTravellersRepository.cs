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
    public class BookingTravellersRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public BookingTravellersRepository(IConfiguration configuration)
        {
             strConnString = configuration.GetConnectionString("ZarenTravel");
            connection = new SqlConnection(strConnString);
        }
  public long Insert(BookingTravellers BookingTravellers)
    {
        try
        {
            return connection.Insert(BookingTravellers);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(BookingTravellers BookingTravellers)
    {
        try
        {
       return  connection.Update(BookingTravellers);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(BookingTravellers BookingTravellers)
        {
            try
            {
            return  connection.Delete<BookingTravellers>(BookingTravellers);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<BookingTravellers> GetAll(){
            try
            {
                return connection.Query<BookingTravellers>("BookingTravellersGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BookingTravellers> GetBirthDateBetween(DateTime BirthDateStart,DateTime BirthDateEnd){
            try
            {
                return connection.Query<BookingTravellers>("BookingTravellersGetBirthDateBetween", new
                {
BirthDateStart = BirthDateStart
,BirthDateEnd = BirthDateEnd
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BookingTravellers> GetByBirthDate(DateTime BirthDate){
            try
            {
                return connection.Query<BookingTravellers>("BookingTravellersGetByBirthDate", new
                {
BirthDate = BirthDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BookingTravellers> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<BookingTravellers>("BookingTravellersGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BookingTravellers> GetByEmail(string Email){
            try
            {
                return connection.Query<BookingTravellers>("BookingTravellersGetByEmail", new
                {
Email = Email
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BookingTravellers> GetByFirstName(string FirstName){
            try
            {
                return connection.Query<BookingTravellers>("BookingTravellersGetByFirstName", new
                {
FirstName = FirstName
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BookingTravellers> GetByGender(int Gender){
            try
            {
                return connection.Query<BookingTravellers>("BookingTravellersGetByGender", new
                {
Gender = Gender
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public BookingTravellers GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<BookingTravellers>("BookingTravellersGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BookingTravellers> GetByLastName(string LastName){
            try
            {
                return connection.Query<BookingTravellers>("BookingTravellersGetByLastName", new
                {
LastName = LastName
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BookingTravellers> GetByPrice(double Price){
            try
            {
                return connection.Query<BookingTravellers>("BookingTravellersGetByPrice", new
                {
Price = Price
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BookingTravellers> GetByReservationNumber(string ReservationNumber){
            try
            {
                return connection.Query<BookingTravellers>("BookingTravellersGetByReservationNumber", new
                {
ReservationNumber = ReservationNumber
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BookingTravellers> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<BookingTravellers>("BookingTravellersGetCreatedDateBetween", new
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
 public void Dispose()
            {
                GC.SuppressFinalize(this);
            }
    }
