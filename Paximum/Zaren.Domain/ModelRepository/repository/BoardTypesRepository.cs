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
using Microsoft.Extensions.Configuration;
    public class BoardTypesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public BoardTypesRepository(IConfiguration configuration)
        {
             strConnString = configuration.GetSection("ConnectionString").Value;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(BoardTypes BoardTypes)
    {
        try
        {
            return connection.Insert(BoardTypes);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(BoardTypes BoardTypes)
    {
        try
        {
       return  connection.Update(BoardTypes);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(BoardTypes BoardTypes)
        {
            try
            {
            return  connection.Delete<BoardTypes>(BoardTypes);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<BoardTypes> GetAll(){
            try
            {
                return connection.Query<BoardTypes>("BoardTypesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public BoardTypes GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<BoardTypes>("BoardTypesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BoardTypes> GetByName(string Name){
            try
            {
                return connection.Query<BoardTypes>("BoardTypesGetByName", new
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
