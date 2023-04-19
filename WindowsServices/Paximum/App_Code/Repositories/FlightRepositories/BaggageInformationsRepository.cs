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
    public class BaggageInformationsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public BaggageInformationsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(BaggageInformations BaggageInformations)
    {
        try
        {
            return connection.Insert(BaggageInformations);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(BaggageInformations BaggageInformations)
    {
        try
        {
       return  connection.Update(BaggageInformations);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(BaggageInformations BaggageInformations)
        {
            try
            {
            return  connection.Delete<BaggageInformations>(BaggageInformations);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<BaggageInformations> GetAll(){
            try
            {
                return connection.Query<BaggageInformations>("BaggageInformationsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BaggageInformations> GetByApiId(int ApiId){
            try
            {
                return connection.Query<BaggageInformations>("BaggageInformationsGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BaggageInformations> GetByBaggageTypesId(int BaggageTypesId){
            try
            {
                return connection.Query<BaggageInformations>("BaggageInformationsGetByBaggageTypesId", new
                {
BaggageTypesId = BaggageTypesId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BaggageInformations> GetByBaggageUnitTypesId(int BaggageUnitTypesId){
            try
            {
                return connection.Query<BaggageInformations>("BaggageInformationsGetByBaggageUnitTypesId", new
                {
BaggageUnitTypesId = BaggageUnitTypesId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BaggageInformations> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<BaggageInformations>("BaggageInformationsGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BaggageInformations> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<BaggageInformations>("BaggageInformationsGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BaggageInformations> GetByDescriptions(string Descriptions){
            try
            {
                return connection.Query<BaggageInformations>("BaggageInformationsGetByDescriptions", new
                {
Descriptions = Descriptions
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BaggageInformations> GetByFlightOffersId(int FlightOffersId){
            try
            {
                return connection.Query<BaggageInformations>("BaggageInformationsGetByFlightOffersId", new
                {
FlightOffersId = FlightOffersId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public BaggageInformations GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<BaggageInformations>("BaggageInformationsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BaggageInformations> GetByItemsId(int ItemsId){
            try
            {
                return connection.Query<BaggageInformations>("BaggageInformationsGetByItemsId", new
                {
ItemsId = ItemsId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BaggageInformations> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<BaggageInformations>("BaggageInformationsGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BaggageInformations> GetByOffersId(int OffersId){
            try
            {
                return connection.Query<BaggageInformations>("BaggageInformationsGetByOffersId", new
                {
OffersId = OffersId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BaggageInformations> GetByPassengerTypesId(int PassengerTypesId){
            try
            {
                return connection.Query<BaggageInformations>("BaggageInformationsGetByPassengerTypesId", new
                {
PassengerTypesId = PassengerTypesId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BaggageInformations> GetByPiece(int Piece){
            try
            {
                return connection.Query<BaggageInformations>("BaggageInformationsGetByPiece", new
                {
Piece = Piece
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BaggageInformations> GetBySegmentsId(int SegmentsId){
            try
            {
                return connection.Query<BaggageInformations>("BaggageInformationsGetBySegmentsId", new
                {
SegmentsId = SegmentsId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BaggageInformations> GetBySystemId(string SystemId){
            try
            {
                return connection.Query<BaggageInformations>("BaggageInformationsGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BaggageInformations> GetByWeight(int Weight){
            try
            {
                return connection.Query<BaggageInformations>("BaggageInformationsGetByWeight", new
                {
Weight = Weight
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BaggageInformations> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<BaggageInformations>("BaggageInformationsGetCreatedDateBetween", new
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
