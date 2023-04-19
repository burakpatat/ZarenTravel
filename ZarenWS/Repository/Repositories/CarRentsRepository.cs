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
    public class CarRentsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public CarRentsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(CarRents CarRents)
    {
        try
        {
            return connection.Insert(CarRents);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(CarRents CarRents)
    {
        try
        {
       return  connection.Update(CarRents);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(CarRents CarRents)
        {
            try
            {
            return  connection.Delete<CarRents>(CarRents);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<CarRents> GetAll(){
            try
            {
                return connection.Query<CarRents>("CarRentsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CarRents> GetByAirportIdPickUp(int AirportIdPickUp){
            try
            {
                return connection.Query<CarRents>("CarRentsGetByAirportIdPickUp", new
                {
AirportIdPickUp = AirportIdPickUp
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CarRents> GetByAirportIdReturn(int AirportIdReturn){
            try
            {
                return connection.Query<CarRents>("CarRentsGetByAirportIdReturn", new
                {
AirportIdReturn = AirportIdReturn
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CarRents> GetByCaReActive(bool CaReActive){
            try
            {
                return connection.Query<CarRents>("CarRentsGetByCaReActive", new
                {
CaReActive = CaReActive
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CarRents> GetByCaReBookDate(DateTime CaReBookDate){
            try
            {
                return connection.Query<CarRents>("CarRentsGetByCaReBookDate", new
                {
CaReBookDate = CaReBookDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CarRents> GetByCaRePickUpDate(DateTime CaRePickUpDate){
            try
            {
                return connection.Query<CarRents>("CarRentsGetByCaRePickUpDate", new
                {
CaRePickUpDate = CaRePickUpDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CarRents> GetByCaReRate(decimal CaReRate){
            try
            {
                return connection.Query<CarRents>("CarRentsGetByCaReRate", new
                {
CaReRate = CaReRate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CarRents> GetByCaReReturnDate(DateTime CaReReturnDate){
            try
            {
                return connection.Query<CarRents>("CarRentsGetByCaReReturnDate", new
                {
CaReReturnDate = CaReReturnDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CarRents> GetByCaReTax(decimal CaReTax){
            try
            {
                return connection.Query<CarRents>("CarRentsGetByCaReTax", new
                {
CaReTax = CaReTax
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CarRents> GetByCaReTimestamp(DateTime CaReTimestamp){
            try
            {
                return connection.Query<CarRents>("CarRentsGetByCaReTimestamp", new
                {
CaReTimestamp = CaReTimestamp
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CarRents> GetByCaRtId(int CaRtId){
            try
            {
                return connection.Query<CarRents>("CarRentsGetByCaRtId", new
                {
CaRtId = CaRtId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CarRents> GetByCaTyId(int CaTyId){
            try
            {
                return connection.Query<CarRents>("CarRentsGetByCaTyId", new
                {
CaTyId = CaTyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CarRents> GetByCurrencyId(int CurrencyId){
            try
            {
                return connection.Query<CarRents>("CarRentsGetByCurrencyId", new
                {
CurrencyId = CurrencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public CarRents GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<CarRents>("CarRentsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CarRents> GetByPNRId(int PNRId){
            try
            {
                return connection.Query<CarRents>("CarRentsGetByPNRId", new
                {
PNRId = PNRId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CarRents> GetCaReBookDateBetween(DateTime CaReBookDateStart,DateTime CaReBookDateEnd){
            try
            {
                return connection.Query<CarRents>("CarRentsGetCaReBookDateBetween", new
                {
CaReBookDateStart = CaReBookDateStart
,CaReBookDateEnd = CaReBookDateEnd
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CarRents> GetCaRePickUpDateBetween(DateTime CaRePickUpDateStart,DateTime CaRePickUpDateEnd){
            try
            {
                return connection.Query<CarRents>("CarRentsGetCaRePickUpDateBetween", new
                {
CaRePickUpDateStart = CaRePickUpDateStart
,CaRePickUpDateEnd = CaRePickUpDateEnd
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CarRents> GetCaReReturnDateBetween(DateTime CaReReturnDateStart,DateTime CaReReturnDateEnd){
            try
            {
                return connection.Query<CarRents>("CarRentsGetCaReReturnDateBetween", new
                {
CaReReturnDateStart = CaReReturnDateStart
,CaReReturnDateEnd = CaReReturnDateEnd
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CarRents> GetCaReTimestampBetween(DateTime CaReTimestampStart,DateTime CaReTimestampEnd){
            try
            {
                return connection.Query<CarRents>("CarRentsGetCaReTimestampBetween", new
                {
CaReTimestampStart = CaReTimestampStart
,CaReTimestampEnd = CaReTimestampEnd
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
