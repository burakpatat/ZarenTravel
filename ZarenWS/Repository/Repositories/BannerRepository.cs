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
    public class BannerRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public BannerRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Banner Banner)
    {
        try
        {
            return connection.Insert(Banner);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Banner Banner)
    {
        try
        {
       return  connection.Update(Banner);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Banner Banner)
        {
            try
            {
            return  connection.Delete<Banner>(Banner);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<Banner> GetAll(){
            try
            {
                return connection.Query<Banner>("BannerGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Banner GetByID(int ID){
            try
            {
                return connection.QueryFirstOrDefault<Banner>("BannerGetByID", new
                {
ID = ID
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Banner> GetByImagePath(string ImagePath){
            try
            {
                return connection.Query<Banner>("BannerGetByImagePath", new
                {
ImagePath = ImagePath
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Banner> GetByLanguageID(int LanguageID){
            try
            {
                return connection.Query<Banner>("BannerGetByLanguageID", new
                {
LanguageID = LanguageID
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Banner> GetByMobileImagePath(string MobileImagePath){
            try
            {
                return connection.Query<Banner>("BannerGetByMobileImagePath", new
                {
MobileImagePath = MobileImagePath
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Banner> GetByTableOrder(int TableOrder){
            try
            {
                return connection.Query<Banner>("BannerGetByTableOrder", new
                {
TableOrder = TableOrder
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Banner> GetByText(string Text){
            try
            {
                return connection.Query<Banner>("BannerGetByText", new
                {
Text = Text
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Banner> GetByText2(string Text2){
            try
            {
                return connection.Query<Banner>("BannerGetByText2", new
                {
Text2 = Text2
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Banner> GetByText3(string Text3){
            try
            {
                return connection.Query<Banner>("BannerGetByText3", new
                {
Text3 = Text3
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
