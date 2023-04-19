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
using Microsoft.Extensions.Configuration;
    public class DealsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public DealsRepository(IConfiguration configuration)
        {
             strConnString = configuration.GetSection("ConnectionString").Value;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Deals Deals)
    {
        try
        {
            return connection.Insert(Deals);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Deals Deals)
    {
        try
        {
       return  connection.Update(Deals);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Deals Deals)
        {
            try
            {
            return  connection.Delete<Deals>(Deals);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<Deals> GetAll(){
            try
            {
                return connection.Query<Deals>("DealsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Deals> GetByBoardTypeId(int BoardTypeId){
            try
            {
                return connection.Query<Deals>("DealsGetByBoardTypeId", new
                {
BoardTypeId = BoardTypeId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Deals> GetByDealTypeId(int DealTypeId){
            try
            {
                return connection.Query<Deals>("DealsGetByDealTypeId", new
                {
DealTypeId = DealTypeId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Deals> GetByDiscount(decimal Discount){
            try
            {
                return connection.Query<Deals>("DealsGetByDiscount", new
                {
Discount = Discount
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Deals> GetByEndDate(DateTime EndDate){
            try
            {
                return connection.Query<Deals>("DealsGetByEndDate", new
                {
EndDate = EndDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Deals> GetByFreeNights(int FreeNights){
            try
            {
                return connection.Query<Deals>("DealsGetByFreeNights", new
                {
FreeNights = FreeNights
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Deals> GetByHotelRoomId(int HotelRoomId){
            try
            {
                return connection.Query<Deals>("DealsGetByHotelRoomId", new
                {
HotelRoomId = HotelRoomId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Deals GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Deals>("DealsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Deals> GetByRelease(int Release){
            try
            {
                return connection.Query<Deals>("DealsGetByRelease", new
                {
Release = Release
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Deals> GetByStartDate(DateTime StartDate){
            try
            {
                return connection.Query<Deals>("DealsGetByStartDate", new
                {
StartDate = StartDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Deals> GetEndDateBetween(DateTime EndDateStart,DateTime EndDateEnd){
            try
            {
                return connection.Query<Deals>("DealsGetEndDateBetween", new
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
public List<Deals> GetStartDateBetween(DateTime StartDateStart,DateTime StartDateEnd){
            try
            {
                return connection.Query<Deals>("DealsGetStartDateBetween", new
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
