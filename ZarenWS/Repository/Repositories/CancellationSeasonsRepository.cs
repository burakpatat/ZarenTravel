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
    public class CancellationSeasonsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public CancellationSeasonsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(CancellationSeasons CancellationSeasons)
    {
        try
        {
            return connection.Insert(CancellationSeasons);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(CancellationSeasons CancellationSeasons)
    {
        try
        {
       return  connection.Update(CancellationSeasons);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(CancellationSeasons CancellationSeasons)
        {
            try
            {
            return  connection.Delete<CancellationSeasons>(CancellationSeasons);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<CancellationSeasons> GetAll(){
            try
            {
                return connection.Query<CancellationSeasons>("CancellationSeasonsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CancellationSeasons> GetByEndDate(DateTime EndDate){
            try
            {
                return connection.Query<CancellationSeasons>("CancellationSeasonsGetByEndDate", new
                {
EndDate = EndDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CancellationSeasons> GetByHotelId(int HotelId){
            try
            {
                return connection.Query<CancellationSeasons>("CancellationSeasonsGetByHotelId", new
                {
HotelId = HotelId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public CancellationSeasons GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<CancellationSeasons>("CancellationSeasonsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CancellationSeasons> GetByStartDate(DateTime StartDate){
            try
            {
                return connection.Query<CancellationSeasons>("CancellationSeasonsGetByStartDate", new
                {
StartDate = StartDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CancellationSeasons> GetEndDateBetween(DateTime EndDateStart,DateTime EndDateEnd){
            try
            {
                return connection.Query<CancellationSeasons>("CancellationSeasonsGetEndDateBetween", new
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
public List<CancellationSeasons> GetStartDateBetween(DateTime StartDateStart,DateTime StartDateEnd){
            try
            {
                return connection.Query<CancellationSeasons>("CancellationSeasonsGetStartDateBetween", new
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
