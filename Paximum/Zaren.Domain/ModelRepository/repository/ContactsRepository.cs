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
    public class ContactsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public ContactsRepository(IConfiguration configuration)
        {
             strConnString = configuration.GetSection("ConnectionString").Value;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Contacts Contacts)
    {
        try
        {
            return connection.Insert(Contacts);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Contacts Contacts)
    {
        try
        {
       return  connection.Update(Contacts);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Contacts Contacts)
        {
            try
            {
            return  connection.Delete<Contacts>(Contacts);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<Contacts> GetAll(){
            try
            {
                return connection.Query<Contacts>("ContactsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Contacts> GetByEmail(string Email){
            try
            {
                return connection.Query<Contacts>("ContactsGetByEmail", new
                {
Email = Email
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Contacts> GetByFaxNumber(string FaxNumber){
            try
            {
                return connection.Query<Contacts>("ContactsGetByFaxNumber", new
                {
FaxNumber = FaxNumber
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Contacts GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Contacts>("ContactsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Contacts> GetByName(string Name){
            try
            {
                return connection.Query<Contacts>("ContactsGetByName", new
                {
Name = Name
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Contacts> GetByTelNumber(string TelNumber){
            try
            {
                return connection.Query<Contacts>("ContactsGetByTelNumber", new
                {
TelNumber = TelNumber
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
