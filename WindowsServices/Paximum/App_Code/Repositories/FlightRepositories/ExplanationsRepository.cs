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
    public class ExplanationsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public ExplanationsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Explanations Explanations)
    {
        try
        {
            return connection.Insert(Explanations);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Explanations Explanations)
    {
        try
        {
       return  connection.Update(Explanations);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Explanations Explanations)
        {
            try
            {
            return  connection.Delete<Explanations>(Explanations);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<Explanations> GetAll(){
            try
            {
                return connection.Query<Explanations>("ExplanationsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Explanations> GetByApiId(int ApiId){
            try
            {
                return connection.Query<Explanations>("ExplanationsGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Explanations> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<Explanations>("ExplanationsGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Explanations> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<Explanations>("ExplanationsGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Explanations GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Explanations>("ExplanationsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Explanations> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<Explanations>("ExplanationsGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Explanations> GetBySystemId(string SystemId){
            try
            {
                return connection.Query<Explanations>("ExplanationsGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Explanations> GetByText(string Text){
            try
            {
                return connection.Query<Explanations>("ExplanationsGetByText", new
                {
Text = Text
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Explanations> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<Explanations>("ExplanationsGetCreatedDateBetween", new
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
