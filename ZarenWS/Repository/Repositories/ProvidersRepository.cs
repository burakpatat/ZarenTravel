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
    public class ProvidersRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public ProvidersRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Providers Providers)
    {
        try
        {
            return connection.Insert(Providers);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Providers Providers)
    {
        try
        {
       return  connection.Update(Providers);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Providers Providers)
        {
            try
            {
            return  connection.Delete<Providers>(Providers);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<Providers> GetAll(){
            try
            {
                return connection.Query<Providers>("ProvidersGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Providers> GetByAddress(string Address){
            try
            {
                return connection.Query<Providers>("ProvidersGetByAddress", new
                {
Address = Address
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Providers> GetByComercialContactId(int ComercialContactId){
            try
            {
                return connection.Query<Providers>("ProvidersGetByComercialContactId", new
                {
ComercialContactId = ComercialContactId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Providers> GetByFinanceContactId(int FinanceContactId){
            try
            {
                return connection.Query<Providers>("ProvidersGetByFinanceContactId", new
                {
FinanceContactId = FinanceContactId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Providers GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Providers>("ProvidersGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Providers> GetByName(string Name){
            try
            {
                return connection.Query<Providers>("ProvidersGetByName", new
                {
Name = Name
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Providers> GetByReservationContactId(int ReservationContactId){
            try
            {
                return connection.Query<Providers>("ProvidersGetByReservationContactId", new
                {
ReservationContactId = ReservationContactId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Providers> GetByWebsite(string Website){
            try
            {
                return connection.Query<Providers>("ProvidersGetByWebsite", new
                {
Website = Website
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
