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
    public class SegmentsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public SegmentsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Segments Segments)
    {
        try
        {
            return connection.Insert(Segments);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Segments Segments)
    {
        try
        {
       return  connection.Update(Segments);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Segments Segments)
        {
            try
            {
            return  connection.Delete<Segments>(Segments);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<Segments> GetAll(){
            try
            {
                return connection.Query<Segments>("SegmentsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Segments> GetByAirCraft(string AirCraft){
            try
            {
                return connection.Query<Segments>("SegmentsGetByAirCraft", new
                {
AirCraft = AirCraft
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Segments> GetByAirLinesId(int AirLinesId){
            try
            {
                return connection.Query<Segments>("SegmentsGetByAirLinesId", new
                {
AirLinesId = AirLinesId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Segments> GetByApiId(int ApiId){
            try
            {
                return connection.Query<Segments>("SegmentsGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Segments> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<Segments>("SegmentsGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Segments> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<Segments>("SegmentsGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Segments> GetByDeparturesArrivalsId(int DeparturesArrivalsId){
            try
            {
                return connection.Query<Segments>("SegmentsGetByDeparturesArrivalsId", new
                {
DeparturesArrivalsId = DeparturesArrivalsId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Segments> GetByDuration(int Duration){
            try
            {
                return connection.Query<Segments>("SegmentsGetByDuration", new
                {
Duration = Duration
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Segments> GetByFlightClassesId(int FlightClassesId){
            try
            {
                return connection.Query<Segments>("SegmentsGetByFlightClassesId", new
                {
FlightClassesId = FlightClassesId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Segments> GetByFlightNo(string FlightNo){
            try
            {
                return connection.Query<Segments>("SegmentsGetByFlightNo", new
                {
FlightNo = FlightNo
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Segments GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Segments>("SegmentsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Segments> GetByItemsId(int ItemsId){
            try
            {
                return connection.Query<Segments>("SegmentsGetByItemsId", new
                {
ItemsId = ItemsId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Segments> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<Segments>("SegmentsGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Segments> GetByPnlName(string PnlName){
            try
            {
                return connection.Query<Segments>("SegmentsGetByPnlName", new
                {
PnlName = PnlName
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Segments> GetBySystemId(string SystemId){
            try
            {
                return connection.Query<Segments>("SegmentsGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Segments> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<Segments>("SegmentsGetCreatedDateBetween", new
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
