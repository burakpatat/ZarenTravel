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
    public class BoardTypeLanguagesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public BoardTypeLanguagesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(BoardTypeLanguages BoardTypeLanguages)
    {
        try
        {
            return connection.Insert(BoardTypeLanguages);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(BoardTypeLanguages BoardTypeLanguages)
    {
        try
        {
       return  connection.Update(BoardTypeLanguages);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(BoardTypeLanguages BoardTypeLanguages)
        {
            try
            {
            return  connection.Delete<BoardTypeLanguages>(BoardTypeLanguages);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<BoardTypeLanguages> GetAll(){
            try
            {
                return connection.Query<BoardTypeLanguages>("BoardTypeLanguagesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BoardTypeLanguages> GetByBoardTypeId(int BoardTypeId){
            try
            {
                return connection.Query<BoardTypeLanguages>("BoardTypeLanguagesGetByBoardTypeId", new
                {
BoardTypeId = BoardTypeId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public BoardTypeLanguages GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<BoardTypeLanguages>("BoardTypeLanguagesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BoardTypeLanguages> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<BoardTypeLanguages>("BoardTypeLanguagesGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BoardTypeLanguages> GetByName(string Name){
            try
            {
                return connection.Query<BoardTypeLanguages>("BoardTypeLanguagesGetByName", new
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
