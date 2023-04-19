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
    public class ReservationDetailsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public ReservationDetailsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(ReservationDetails ReservationDetails)
    {
        try
        {
            return connection.Insert(ReservationDetails);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(ReservationDetails ReservationDetails)
    {
        try
        {
       return  connection.Update(ReservationDetails);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(ReservationDetails ReservationDetails)
        {
            try
            {
            return  connection.Delete<ReservationDetails>(ReservationDetails);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<ReservationDetails> GetAll(){
            try
            {
                return connection.Query<ReservationDetails>("ReservationDetailsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<ReservationDetails> GetByApartPrice(string ApartPrice){
            try
            {
                return connection.Query<ReservationDetails>("ReservationDetailsGetByApartPrice", new
                {
ApartPrice = ApartPrice
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public ReservationDetails GetByID(int ID){
            try
            {
                return connection.QueryFirstOrDefault<ReservationDetails>("ReservationDetailsGetByID", new
                {
ID = ID
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<ReservationDetails> GetByPropertID(int PropertID){
            try
            {
                return connection.Query<ReservationDetails>("ReservationDetailsGetByPropertID", new
                {
PropertID = PropertID
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<ReservationDetails> GetByPropertPrice(decimal PropertPrice){
            try
            {
                return connection.Query<ReservationDetails>("ReservationDetailsGetByPropertPrice", new
                {
PropertPrice = PropertPrice
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<ReservationDetails> GetByRezervationID(int RezervationID){
            try
            {
                return connection.Query<ReservationDetails>("ReservationDetailsGetByRezervationID", new
                {
RezervationID = RezervationID
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
