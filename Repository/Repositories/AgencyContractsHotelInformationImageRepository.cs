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
    public class AgencyContractsHotelInformationImageRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AgencyContractsHotelInformationImageRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(AgencyContractsHotelInformationImage AgencyContractsHotelInformationImage)
    {
        try
        {
            return connection.Insert(AgencyContractsHotelInformationImage);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(AgencyContractsHotelInformationImage AgencyContractsHotelInformationImage)
    {
        try
        {
       return  connection.Update(AgencyContractsHotelInformationImage);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(AgencyContractsHotelInformationImage AgencyContractsHotelInformationImage)
        {
            try
            {
            return  connection.Delete<AgencyContractsHotelInformationImage>(AgencyContractsHotelInformationImage);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<AgencyContractsHotelInformationImage> GetAll(){
            try
            {
                return connection.Query<AgencyContractsHotelInformationImage>("AgencyContractsHotelInformationImageGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public AgencyContractsHotelInformationImage GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<AgencyContractsHotelInformationImage>("AgencyContractsHotelInformationImageGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsHotelInformationImage> GetByImagePath(string ImagePath){
            try
            {
                return connection.Query<AgencyContractsHotelInformationImage>("AgencyContractsHotelInformationImageGetByImagePath", new
                {
ImagePath = ImagePath
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsHotelInformationImage> GetByImageUrl(string ImageUrl){
            try
            {
                return connection.Query<AgencyContractsHotelInformationImage>("AgencyContractsHotelInformationImageGetByImageUrl", new
                {
ImageUrl = ImageUrl
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
