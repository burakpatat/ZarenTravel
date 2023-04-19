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
    public class HotelAgencyMarkupsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public HotelAgencyMarkupsRepository(IConfiguration configuration)
        {
             strConnString = configuration.GetSection("ConnectionString").Value;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(HotelAgencyMarkups HotelAgencyMarkups)
    {
        try
        {
            return connection.Insert(HotelAgencyMarkups);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(HotelAgencyMarkups HotelAgencyMarkups)
    {
        try
        {
       return  connection.Update(HotelAgencyMarkups);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(HotelAgencyMarkups HotelAgencyMarkups)
        {
            try
            {
            return  connection.Delete<HotelAgencyMarkups>(HotelAgencyMarkups);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<HotelAgencyMarkups> GetAll(){
            try
            {
                return connection.Query<HotelAgencyMarkups>("HotelAgencyMarkupsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelAgencyMarkups> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<HotelAgencyMarkups>("HotelAgencyMarkupsGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelAgencyMarkups> GetByEndDate(DateTime EndDate){
            try
            {
                return connection.Query<HotelAgencyMarkups>("HotelAgencyMarkupsGetByEndDate", new
                {
EndDate = EndDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelAgencyMarkups> GetByHotelId(int HotelId){
            try
            {
                return connection.Query<HotelAgencyMarkups>("HotelAgencyMarkupsGetByHotelId", new
                {
HotelId = HotelId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public HotelAgencyMarkups GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<HotelAgencyMarkups>("HotelAgencyMarkupsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelAgencyMarkups> GetByMarkUp(decimal MarkUp){
            try
            {
                return connection.Query<HotelAgencyMarkups>("HotelAgencyMarkupsGetByMarkUp", new
                {
MarkUp = MarkUp
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelAgencyMarkups> GetByStartDate(DateTime StartDate){
            try
            {
                return connection.Query<HotelAgencyMarkups>("HotelAgencyMarkupsGetByStartDate", new
                {
StartDate = StartDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelAgencyMarkups> GetEndDateBetween(DateTime EndDateStart,DateTime EndDateEnd){
            try
            {
                return connection.Query<HotelAgencyMarkups>("HotelAgencyMarkupsGetEndDateBetween", new
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
public List<HotelAgencyMarkups> GetStartDateBetween(DateTime StartDateStart,DateTime StartDateEnd){
            try
            {
                return connection.Query<HotelAgencyMarkups>("HotelAgencyMarkupsGetStartDateBetween", new
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
