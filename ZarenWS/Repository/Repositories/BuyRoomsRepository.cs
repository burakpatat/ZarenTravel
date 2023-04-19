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
    public class BuyRoomsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public BuyRoomsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(BuyRooms BuyRooms)
    {
        try
        {
            return connection.Insert(BuyRooms);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(BuyRooms BuyRooms)
    {
        try
        {
       return  connection.Update(BuyRooms);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(BuyRooms BuyRooms)
        {
            try
            {
            return  connection.Delete<BuyRooms>(BuyRooms);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<BuyRooms> GetAll(){
            try
            {
                return connection.Query<BuyRooms>("BuyRoomsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BuyRooms> GetByDescription(string Description){
            try
            {
                return connection.Query<BuyRooms>("BuyRoomsGetByDescription", new
                {
Description = Description
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public BuyRooms GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<BuyRooms>("BuyRoomsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BuyRooms> GetByMaxAdults(int MaxAdults){
            try
            {
                return connection.Query<BuyRooms>("BuyRoomsGetByMaxAdults", new
                {
MaxAdults = MaxAdults
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BuyRooms> GetByMaxAllotment(int MaxAllotment){
            try
            {
                return connection.Query<BuyRooms>("BuyRoomsGetByMaxAllotment", new
                {
MaxAllotment = MaxAllotment
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BuyRooms> GetByMaxChildren(int MaxChildren){
            try
            {
                return connection.Query<BuyRooms>("BuyRoomsGetByMaxChildren", new
                {
MaxChildren = MaxChildren
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BuyRooms> GetByMaxInfants(int MaxInfants){
            try
            {
                return connection.Query<BuyRooms>("BuyRoomsGetByMaxInfants", new
                {
MaxInfants = MaxInfants
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BuyRooms> GetByName(string Name){
            try
            {
                return connection.Query<BuyRooms>("BuyRoomsGetByName", new
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
