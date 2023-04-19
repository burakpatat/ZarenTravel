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
    public class CurrenciesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public CurrenciesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Currencies Currencies)
    {
        try
        {
            return connection.Insert(Currencies);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Currencies Currencies)
    {
        try
        {
       return  connection.Update(Currencies);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Currencies Currencies)
        {
            try
            {
            return  connection.Delete<Currencies>(Currencies);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<Currencies> GetAll(){
            try
            {
                return connection.Query<Currencies>("CurrenciesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Currencies> GetByCountry(string Country){
            try
            {
                return connection.Query<Currencies>("CurrenciesGetByCountry", new
                {
Country = Country
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Currencies> GetByCurrencyCode(string CurrencyCode){
            try
            {
                return connection.Query<Currencies>("CurrenciesGetByCurrencyCode", new
                {
CurrencyCode = CurrencyCode
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Currencies GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Currencies>("CurrenciesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Currencies> GetByIsActive(bool IsActive){
            try
            {
                return connection.Query<Currencies>("CurrenciesGetByIsActive", new
                {
IsActive = IsActive
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Currencies> GetByName(string Name){
            try
            {
                return connection.Query<Currencies>("CurrenciesGetByName", new
                {
Name = Name
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Currencies> GetByNumber(string Number){
            try
            {
                return connection.Query<Currencies>("CurrenciesGetByNumber", new
                {
Number = Number
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
