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
            return connection.Update(Rooms);
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
            return connection.Delete<Rooms>(Rooms);
        }
        catch (Exception)
        {
            return false;
        }
    }
    public List<Rooms> GetAll()
    {
        try
        {
            return connection.Query<Rooms>("RoomsGetAll", commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Rooms> GetByAccomId(int AccomId)
    {
        try
        {
            return connection.Query<Rooms>("RoomsGetByAccomId", new
            {
                AccomId = AccomId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Rooms> GetByAccomName(string AccomName)
    {
        try
        {
            return connection.Query<Rooms>("RoomsGetByAccomName", new
            {
                AccomName = AccomName
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Rooms> GetByAgencyId(int AgencyId)
    {
        try
        {
            return connection.Query<Rooms>("RoomsGetByAgencyId", new
            {
                AgencyId = AgencyId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Rooms> GetByAllotment(int Allotment)
    {
        try
        {
            return connection.Query<Rooms>("RoomsGetByAllotment", new
            {
                Allotment = Allotment
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Rooms> GetByApiId(int ApiId)
    {
        try
        {
            return connection.Query<Rooms>("RoomsGetByApiId", new
            {
                ApiId = ApiId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Rooms> GetByOfferId(string OfferId)
    {
        try
        {
            return connection.Query<Rooms>("RoomsGetByOfferId", new
            {
                OfferId = OfferId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Rooms> GetByOfferIdandBoardName(string OfferId, string boardName)
    {
        try
        {
            return connection.Query<Rooms>("RoomsGetByOfferIdandBoardName", new
            {
                OfferId = OfferId,
                boardName = boardName
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Rooms> GetByBoardId(int BoardId)
    {
        try
        {
            return connection.Query<Rooms>("RoomsGetByBoardId", new
            {
                BoardId = BoardId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Rooms> GetByBoardName(string BoardName)
    {
        try
        {
            return connection.Query<Rooms>("RoomsGetByBoardName", new
            {
                BoardName = BoardName
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Rooms> GetByCode(string Code)
    {
        try
        {
            return connection.Query<Rooms>("RoomsGetByCode", new
            {
                Code = Code
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Rooms> GetByCreatedBy(int CreatedBy)
    {
        try
        {
            return connection.Query<Rooms>("RoomsGetByCreatedBy", new
            {
                CreatedBy = CreatedBy
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Rooms> GetByCreatedDate(DateTime CreatedDate)
    {
        try
        {
            return connection.Query<Rooms>("RoomsGetByCreatedDate", new
            {
                CreatedDate = CreatedDate
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public Rooms GetByID(int Id)
    {
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
    public List<Rooms> GetByLanguageId(int LanguageId)
    {
        try
        {
            return connection.Query<Rooms>("RoomsGetByLanguageId", new
            {
                LanguageId = LanguageId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Rooms> GetByMicroSiteId(int MicroSiteId)
    {
        try
        {
            return connection.Query<Rooms>("RoomsGetByMicroSiteId", new
            {
                MicroSiteId = MicroSiteId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Rooms> GetByName(string Name)
    {
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
    public List<Rooms> GetByPresentationId(int PresentationId)
    {
        try
        {
            return connection.Query<Rooms>("RoomsGetByPresentationId", new
            {
                PresentationId = PresentationId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Rooms> GetByPriceId(int PriceId)
    {
        try
        {
            return connection.Query<Rooms>("RoomsGetByPriceId", new
            {
                PriceId = PriceId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Rooms> GetByRoomFacilityId(int RoomFacilityId)
    {
        try
        {
            return connection.Query<Rooms>("RoomsGetByRoomFacilityId", new
            {
                RoomFacilityId = RoomFacilityId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Rooms> GetByRoomId(int RoomId)
    {
        try
        {
            return connection.Query<Rooms>("RoomsGetByRoomId", new
            {
                RoomId = RoomId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Rooms> GetByHotelIdandBoardName(int HotelId, string BoardName)
    {
        try
        {
            return connection.Query<Rooms>("RoomsGetByHotelIdandBoardName", new
            {
                HotelId = HotelId,
                BoardName= BoardName 
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Rooms> GetByRoomMediaFileId(int RoomMediaFileId)
    {
        try
        {
            return connection.Query<Rooms>("RoomsGetByRoomMediaFileId", new
            {
                RoomMediaFileId = RoomMediaFileId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Rooms> GetByStopSaleGuaranteed(int StopSaleGuaranteed)
    {
        try
        {
            return connection.Query<Rooms>("RoomsGetByStopSaleGuaranteed", new
            {
                StopSaleGuaranteed = StopSaleGuaranteed
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Rooms> GetByStopSaleStandart(int StopSaleStandart)
    {
        try
        {
            return connection.Query<Rooms>("RoomsGetByStopSaleStandart", new
            {
                StopSaleStandart = StopSaleStandart
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Rooms> GetBySystemId(string SystemId)
    {
        try
        {
            return connection.Query<Rooms>("RoomsGetBySystemId", new
            {
                SystemId = SystemId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Rooms> GetCreatedDateBetween(DateTime CreatedDateStart, DateTime CreatedDateEnd)
    {
        try
        {
            return connection.Query<Rooms>("RoomsGetCreatedDateBetween", new
            {
                CreatedDateStart = CreatedDateStart
,
                CreatedDateEnd = CreatedDateEnd
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
