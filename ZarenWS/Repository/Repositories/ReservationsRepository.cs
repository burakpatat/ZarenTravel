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
    public class ReservationsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public ReservationsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Reservations Reservations)
    {
        try
        {
            return connection.Insert(Reservations);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Reservations Reservations)
    {
        try
        {
       return  connection.Update(Reservations);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Reservations Reservations)
        {
            try
            {
            return  connection.Delete<Reservations>(Reservations);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<Reservations> GetAll(){
            try
            {
                return connection.Query<Reservations>("ReservationsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Reservations> GetByApartID(int ApartID){
            try
            {
                return connection.Query<Reservations>("ReservationsGetByApartID", new
                {
ApartID = ApartID
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Reservations> GetByCustomerID(int CustomerID){
            try
            {
                return connection.Query<Reservations>("ReservationsGetByCustomerID", new
                {
CustomerID = CustomerID
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Reservations> GetByFinishDate(DateTime FinishDate){
            try
            {
                return connection.Query<Reservations>("ReservationsGetByFinishDate", new
                {
FinishDate = FinishDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Reservations GetByID(int ID){
            try
            {
                return connection.QueryFirstOrDefault<Reservations>("ReservationsGetByID", new
                {
ID = ID
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Reservations> GetByNotes(string Notes){
            try
            {
                return connection.Query<Reservations>("ReservationsGetByNotes", new
                {
Notes = Notes
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Reservations> GetByPaymentCompleted(bool PaymentCompleted){
            try
            {
                return connection.Query<Reservations>("ReservationsGetByPaymentCompleted", new
                {
PaymentCompleted = PaymentCompleted
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Reservations> GetByPaymentType(int PaymentType){
            try
            {
                return connection.Query<Reservations>("ReservationsGetByPaymentType", new
                {
PaymentType = PaymentType
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Reservations> GetByReferenceCode(string ReferenceCode){
            try
            {
                return connection.Query<Reservations>("ReservationsGetByReferenceCode", new
                {
ReferenceCode = ReferenceCode
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Reservations> GetByStartDate(DateTime StartDate){
            try
            {
                return connection.Query<Reservations>("ReservationsGetByStartDate", new
                {
StartDate = StartDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Reservations> GetByTotalPrice(decimal TotalPrice){
            try
            {
                return connection.Query<Reservations>("ReservationsGetByTotalPrice", new
                {
TotalPrice = TotalPrice
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Reservations> GetFinishDateBetween(DateTime FinishDateStart,DateTime FinishDateEnd){
            try
            {
                return connection.Query<Reservations>("ReservationsGetFinishDateBetween", new
                {
FinishDateStart = FinishDateStart
,FinishDateEnd = FinishDateEnd
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Reservations> GetStartDateBetween(DateTime StartDateStart,DateTime StartDateEnd){
            try
            {
                return connection.Query<Reservations>("ReservationsGetStartDateBetween", new
                {
StartDateStart = StartDateStart
,StartDateEnd = StartDateEnd
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
