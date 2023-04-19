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
    public class FacilitiesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public FacilitiesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Facilities Facilities)
    {
        try
        {
            return connection.Insert(Facilities);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Facilities Facilities)
    {
        try
        {
       return  connection.Update(Facilities);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Facilities Facilities)
        {
            try
            {
            return  connection.Delete<Facilities>(Facilities);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<Facilities> GetAll(){
            try
            {
                return connection.Query<Facilities>("FacilitiesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Facilities GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Facilities>("FacilitiesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Facilities> GetByName(string Name){
            try
            {
                return connection.Query<Facilities>("FacilitiesGetByName", new
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
