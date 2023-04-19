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
    public class RoomsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public RoomsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Rooms Rooms)
    {
        try
        {
            return connection.Insert(Rooms);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Rooms Rooms)
    {
        try
        {
       return  connection.Update(Rooms);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Rooms Rooms)
        {
            try
            {
            return  connection.Delete<Rooms>(Rooms);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<Rooms> GetAll(){
            try
            {
                return connection.Query<Rooms>("RoomsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Rooms> GetByAdults(int Adults){
            try
            {
                return connection.Query<Rooms>("RoomsGetByAdults", new
                {
Adults = Adults
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Rooms> GetByChildren(int Children){
            try
            {
                return connection.Query<Rooms>("RoomsGetByChildren", new
                {
Children = Children
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Rooms> GetByDescription(string Description){
            try
            {
                return connection.Query<Rooms>("RoomsGetByDescription", new
                {
Description = Description
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Rooms GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Rooms>("RoomsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Rooms> GetByInfants(int Infants){
            try
            {
                return connection.Query<Rooms>("RoomsGetByInfants", new
                {
Infants = Infants
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Rooms> GetByName(string Name){
            try
            {
                return connection.Query<Rooms>("RoomsGetByName", new
                {
Name = Name
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
