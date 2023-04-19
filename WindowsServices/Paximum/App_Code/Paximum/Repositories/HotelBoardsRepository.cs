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
    public class HotelBoardsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public HotelBoardsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(HotelBoards HotelBoards)
    {
        try
        {
            return connection.Insert(HotelBoards);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(HotelBoards HotelBoards)
    {
        try
        {
       return  connection.Update(HotelBoards);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(HotelBoards HotelBoards)
        {
            try
            {
            return  connection.Delete<HotelBoards>(HotelBoards);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<HotelBoards> GetAll(){
            try
            {
                return connection.Query<HotelBoards>("HotelBoardsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelBoards> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<HotelBoards>("HotelBoardsGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelBoards> GetByApiId(int ApiId){
            try
            {
                return connection.Query<HotelBoards>("HotelBoardsGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelBoards> GetByBoardsId(int BoardsId){
            try
            {
                return connection.Query<HotelBoards>("HotelBoardsGetByBoardsId", new
                {
BoardsId = BoardsId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelBoards> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<HotelBoards>("HotelBoardsGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelBoards> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<HotelBoards>("HotelBoardsGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelBoards> GetByHotelId(int HotelId){
            try
            {
                return connection.Query<HotelBoards>("HotelBoardsGetByHotelId", new
                {
HotelId = HotelId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public HotelBoards GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<HotelBoards>("HotelBoardsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelBoards> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<HotelBoards>("HotelBoardsGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelBoards> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<HotelBoards>("HotelBoardsGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelBoards> GetBySystemId(int SystemId){
            try
            {
                return connection.Query<HotelBoards>("HotelBoardsGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelBoards> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<HotelBoards>("HotelBoardsGetCreatedDateBetween", new
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
