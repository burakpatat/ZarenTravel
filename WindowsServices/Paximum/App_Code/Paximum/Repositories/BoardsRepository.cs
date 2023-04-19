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
    public class BoardsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public BoardsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Boards Boards)
    {
        try
        {
            return connection.Insert(Boards);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Boards Boards)
    {
        try
        {
       return  connection.Update(Boards);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Boards Boards)
        {
            try
            {
            return  connection.Delete<Boards>(Boards);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<Boards> GetAll(){
            try
            {
                return connection.Query<Boards>("BoardsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Boards> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<Boards>("BoardsGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Boards> GetByApiId(int ApiId){
            try
            {
                return connection.Query<Boards>("BoardsGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Boards> GetById(int BoardsId){
            try
            {
                return connection.Query<Boards>("BoardsGetByBoardsId", new
                {
BoardsId = BoardsId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Boards> GetByCode(string Code){
            try
            {
                return connection.Query<Boards>("BoardsGetByCode", new
                {
Code = Code
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Boards> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<Boards>("BoardsGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Boards> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<Boards>("BoardsGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Boards GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Boards>("BoardsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Boards> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<Boards>("BoardsGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Boards> GetByMediaFilesId(int MediaFilesId){
            try
            {
                return connection.Query<Boards>("BoardsGetByMediaFilesId", new
                {
MediaFilesId = MediaFilesId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Boards> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<Boards>("BoardsGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Boards> GetByName(string Name){
            try
            {
                return connection.Query<Boards>("BoardsGetByName", new
                {
Name = Name
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Boards> GetByPresentationId(int PresentationId){
            try
            {
                return connection.Query<Boards>("BoardsGetByPresentationId", new
                {
PresentationId = PresentationId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Boards> GetBySystemId(int SystemId){
            try
            {
                return connection.Query<Boards>("BoardsGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Boards> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<Boards>("BoardsGetCreatedDateBetween", new
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
