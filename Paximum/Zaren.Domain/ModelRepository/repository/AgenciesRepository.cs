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
    public class AgenciesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AgenciesRepository(IConfiguration configuration)
        {
             strConnString = configuration.GetSection("ConnectionString").Value;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Agencies Agencies)
    {
        try
        {
            return connection.Insert(Agencies);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Agencies Agencies)
    {
        try
        {
       return  connection.Update(Agencies);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Agencies Agencies)
        {
            try
            {
            return  connection.Delete<Agencies>(Agencies);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<Agencies> GetAll(){
            try
            {
                return connection.Query<Agencies>("AgenciesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agencies> GetByAddress(string Address){
            try
            {
                return connection.Query<Agencies>("AgenciesGetByAddress", new
                {
Address = Address
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agencies> GetByComercialContactId(int ComercialContactId){
            try
            {
                return connection.Query<Agencies>("AgenciesGetByComercialContactId", new
                {
ComercialContactId = ComercialContactId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agencies> GetByFinanceContactId(int FinanceContactId){
            try
            {
                return connection.Query<Agencies>("AgenciesGetByFinanceContactId", new
                {
FinanceContactId = FinanceContactId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Agencies GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Agencies>("AgenciesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agencies> GetByMarkUp(decimal MarkUp){
            try
            {
                return connection.Query<Agencies>("AgenciesGetByMarkUp", new
                {
MarkUp = MarkUp
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agencies> GetByName(string Name){
            try
            {
                return connection.Query<Agencies>("AgenciesGetByName", new
                {
Name = Name
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agencies> GetByPaymentPolitics(string PaymentPolitics){
            try
            {
                return connection.Query<Agencies>("AgenciesGetByPaymentPolitics", new
                {
PaymentPolitics = PaymentPolitics
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agencies> GetByReservationContactId(int ReservationContactId){
            try
            {
                return connection.Query<Agencies>("AgenciesGetByReservationContactId", new
                {
ReservationContactId = ReservationContactId
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
