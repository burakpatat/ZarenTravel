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
    public class ProvienceRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public ProvienceRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Provience Provience)
    {
        try
        {
            return connection.Insert(Provience);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Provience Provience)
    {
        try
        {
       return  connection.Update(Provience);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Provience Provience)
        {
            try
            {
            return  connection.Delete<Provience>(Provience);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<Provience> GetAll(){
            try
            {
                return connection.Query<Provience>("ProvienceGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Provience> GetByCityID(int CityID){
            try
            {
                return connection.Query<Provience>("ProvienceGetByCityID", new
                {
CityID = CityID
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Provience GetByID(int ID){
            try
            {
                return connection.QueryFirstOrDefault<Provience>("ProvienceGetByID", new
                {
ID = ID
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Provience> GetByInformation(string Information){
            try
            {
                return connection.Query<Provience>("ProvienceGetByInformation", new
                {
Information = Information
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Provience> GetByListImage(string ListImage){
            try
            {
                return connection.Query<Provience>("ProvienceGetByListImage", new
                {
ListImage = ListImage
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Provience> GetByName(string Name){
            try
            {
                return connection.Query<Provience>("ProvienceGetByName", new
                {
Name = Name
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Provience> GetByStatu(int Statu){
            try
            {
                return connection.Query<Provience>("ProvienceGetByStatu", new
                {
Statu = Statu
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Provience> GetByTableOrder(int TableOrder){
            try
            {
                return connection.Query<Provience>("ProvienceGetByTableOrder", new
                {
TableOrder = TableOrder
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
