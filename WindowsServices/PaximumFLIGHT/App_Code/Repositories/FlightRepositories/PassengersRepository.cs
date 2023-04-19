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
    public class PassengersRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public PassengersRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Passengers Passengers)
    {
        try
        {
            return connection.Insert(Passengers);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Passengers Passengers)
    {
        try
        {
       return  connection.Update(Passengers);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Passengers Passengers)
        {
            try
            {
            return  connection.Delete<Passengers>(Passengers);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<Passengers> GetAll(){
            try
            {
                return connection.Query<Passengers>("PassengersGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Passengers> GetByAges(int Ages){
            try
            {
                return connection.Query<Passengers>("PassengersGetByAges", new
                {
Ages = Ages
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Passengers> GetByApiId(int ApiId){
            try
            {
                return connection.Query<Passengers>("PassengersGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Passengers> GetByCount(int Count){
            try
            {
                return connection.Query<Passengers>("PassengersGetByCount", new
                {
Count = Count
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Passengers> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<Passengers>("PassengersGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Passengers> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<Passengers>("PassengersGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Passengers GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Passengers>("PassengersGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Passengers> GetByItemsId(int ItemsId){
            try
            {
                return connection.Query<Passengers>("PassengersGetByItemsId", new
                {
ItemsId = ItemsId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Passengers> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<Passengers>("PassengersGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Passengers> GetByPassengerTypesId(int PassengerTypesId){
            try
            {
                return connection.Query<Passengers>("PassengersGetByPassengerTypesId", new
                {
PassengerTypesId = PassengerTypesId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Passengers> GetBySystemId(string SystemId){
            try
            {
                return connection.Query<Passengers>("PassengersGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Passengers> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<Passengers>("PassengersGetCreatedDateBetween", new
                {
CreatedDateStart = CreatedDateStart
,CreatedDateEnd = CreatedDateEnd
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
