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
    public class BookingsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public BookingsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Bookings Bookings)
    {
        try
        {
            return connection.Insert(Bookings);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Bookings Bookings)
    {
        try
        {
       return  connection.Update(Bookings);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Bookings Bookings)
        {
            try
            {
            return  connection.Delete<Bookings>(Bookings);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<Bookings> GetAll(){
            try
            {
                return connection.Query<Bookings>("BookingsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Bookings> GetByAdults(int Adults){
            try
            {
                return connection.Query<Bookings>("BookingsGetByAdults", new
                {
Adults = Adults
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Bookings> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<Bookings>("BookingsGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Bookings> GetByChildren(int Children){
            try
            {
                return connection.Query<Bookings>("BookingsGetByChildren", new
                {
Children = Children
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Bookings> GetByChildrenAges(string ChildrenAges){
            try
            {
                return connection.Query<Bookings>("BookingsGetByChildrenAges", new
                {
ChildrenAges = ChildrenAges
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Bookings> GetByClientAddress(string ClientAddress){
            try
            {
                return connection.Query<Bookings>("BookingsGetByClientAddress", new
                {
ClientAddress = ClientAddress
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Bookings> GetByClientContact(string ClientContact){
            try
            {
                return connection.Query<Bookings>("BookingsGetByClientContact", new
                {
ClientContact = ClientContact
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Bookings> GetByClientEmail(string ClientEmail){
            try
            {
                return connection.Query<Bookings>("BookingsGetByClientEmail", new
                {
ClientEmail = ClientEmail
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Bookings> GetByClientName(string ClientName){
            try
            {
                return connection.Query<Bookings>("BookingsGetByClientName", new
                {
ClientName = ClientName
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Bookings> GetByClientNotes(string ClientNotes){
            try
            {
                return connection.Query<Bookings>("BookingsGetByClientNotes", new
                {
ClientNotes = ClientNotes
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Bookings> GetByClientSurname(string ClientSurname){
            try
            {
                return connection.Query<Bookings>("BookingsGetByClientSurname", new
                {
ClientSurname = ClientSurname
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Bookings> GetByClientTitle(string ClientTitle){
            try
            {
                return connection.Query<Bookings>("BookingsGetByClientTitle", new
                {
ClientTitle = ClientTitle
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Bookings> GetByDateBooked(DateTime DateBooked){
            try
            {
                return connection.Query<Bookings>("BookingsGetByDateBooked", new
                {
DateBooked = DateBooked
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Bookings> GetByFromDate(DateTime FromDate){
            try
            {
                return connection.Query<Bookings>("BookingsGetByFromDate", new
                {
FromDate = FromDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Bookings> GetByHotelId(int HotelId){
            try
            {
                return connection.Query<Bookings>("BookingsGetByHotelId", new
                {
HotelId = HotelId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Bookings GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Bookings>("BookingsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Bookings> GetByInfants(int Infants){
            try
            {
                return connection.Query<Bookings>("BookingsGetByInfants", new
                {
Infants = Infants
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Bookings> GetByNights(int Nights){
            try
            {
                return connection.Query<Bookings>("BookingsGetByNights", new
                {
Nights = Nights
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Bookings> GetByNumRooms(int NumRooms){
            try
            {
                return connection.Query<Bookings>("BookingsGetByNumRooms", new
                {
NumRooms = NumRooms
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Bookings> GetByPaidStatus(int PaidStatus){
            try
            {
                return connection.Query<Bookings>("BookingsGetByPaidStatus", new
                {
PaidStatus = PaidStatus
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Bookings> GetByProviderId(int ProviderId){
            try
            {
                return connection.Query<Bookings>("BookingsGetByProviderId", new
                {
ProviderId = ProviderId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Bookings> GetByReference(string Reference){
            try
            {
                return connection.Query<Bookings>("BookingsGetByReference", new
                {
Reference = Reference
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Bookings> GetByStatus(int Status){
            try
            {
                return connection.Query<Bookings>("BookingsGetByStatus", new
                {
Status = Status
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Bookings> GetByToDate(DateTime ToDate){
            try
            {
                return connection.Query<Bookings>("BookingsGetByToDate", new
                {
ToDate = ToDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Bookings> GetByTotalCost(decimal TotalCost){
            try
            {
                return connection.Query<Bookings>("BookingsGetByTotalCost", new
                {
TotalCost = TotalCost
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Bookings> GetByTotalPrice(decimal TotalPrice){
            try
            {
                return connection.Query<Bookings>("BookingsGetByTotalPrice", new
                {
TotalPrice = TotalPrice
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Bookings> GetDateBookedBetween(DateTime DateBookedStart,DateTime DateBookedEnd){
            try
            {
                return connection.Query<Bookings>("BookingsGetDateBookedBetween", new
                {
DateBookedStart = DateBookedStart
,DateBookedEnd = DateBookedEnd
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Bookings> GetFromDateBetween(DateTime FromDateStart,DateTime FromDateEnd){
            try
            {
                return connection.Query<Bookings>("BookingsGetFromDateBetween", new
                {
FromDateStart = FromDateStart
,FromDateEnd = FromDateEnd
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Bookings> GetToDateBetween(DateTime ToDateStart,DateTime ToDateEnd){
            try
            {
                return connection.Query<Bookings>("BookingsGetToDateBetween", new
                {
ToDateStart = ToDateStart
,ToDateEnd = ToDateEnd
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
