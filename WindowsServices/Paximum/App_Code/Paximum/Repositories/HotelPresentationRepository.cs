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
    public class HotelPresentationRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public HotelPresentationRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(HotelPresentation HotelPresentation)
    {
        try
        {
            return connection.Insert(HotelPresentation);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(HotelPresentation HotelPresentation)
    {
        try
        {
       return  connection.Update(HotelPresentation);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(HotelPresentation HotelPresentation)
        {
            try
            {
            return  connection.Delete<HotelPresentation>(HotelPresentation);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<HotelPresentation> GetAll(){
            try
            {
                return connection.Query<HotelPresentation>("HotelPresentationGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelPresentation> GetByApiId(int ApiId){
            try
            {
                return connection.Query<HotelPresentation>("HotelPresentationGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelPresentation> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<HotelPresentation>("HotelPresentationGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelPresentation> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<HotelPresentation>("HotelPresentationGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public HotelPresentation GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<HotelPresentation>("HotelPresentationGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelPresentation> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<HotelPresentation>("HotelPresentationGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelPresentation> GetByText(string Text){
            try
            {
                return connection.Query<HotelPresentation>("HotelPresentationGetByText", new
                {
Text = Text
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelPresentation> GetByTextType(int TextType){
            try
            {
                return connection.Query<HotelPresentation>("HotelPresentationGetByTextType", new
                {
TextType = TextType
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelPresentation> GetByType(int Type){
            try
            {
                return connection.Query<HotelPresentation>("HotelPresentationGetByType", new
                {
Type = Type
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelPresentation> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<HotelPresentation>("HotelPresentationGetCreatedDateBetween", new
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
