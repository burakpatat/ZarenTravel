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
    public class AgencyContractsHotelCategoriesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AgencyContractsHotelCategoriesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(AgencyContractsHotelCategories AgencyContractsHotelCategories)
    {
        try
        {
            return connection.Insert(AgencyContractsHotelCategories);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(AgencyContractsHotelCategories AgencyContractsHotelCategories)
    {
        try
        {
       return  connection.Update(AgencyContractsHotelCategories);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(AgencyContractsHotelCategories AgencyContractsHotelCategories)
        {
            try
            {
            return  connection.Delete<AgencyContractsHotelCategories>(AgencyContractsHotelCategories);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<AgencyContractsHotelCategories> GetAll(){
            try
            {
                return connection.Query<AgencyContractsHotelCategories>("AgencyContractsHotelCategoriesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public AgencyContractsHotelCategories GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<AgencyContractsHotelCategories>("AgencyContractsHotelCategoriesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsHotelCategories> GetByName(string Name){
            try
            {
                return connection.Query<AgencyContractsHotelCategories>("AgencyContractsHotelCategoriesGetByName", new
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
