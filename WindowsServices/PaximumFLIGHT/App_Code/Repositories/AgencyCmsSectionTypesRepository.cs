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
    public class AgencyCmsSectionTypesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AgencyCmsSectionTypesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(AgencyCmsSectionTypes AgencyCmsSectionTypes)
    {
        try
        {
            return connection.Insert(AgencyCmsSectionTypes);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(AgencyCmsSectionTypes AgencyCmsSectionTypes)
    {
        try
        {
       return  connection.Update(AgencyCmsSectionTypes);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(AgencyCmsSectionTypes AgencyCmsSectionTypes)
        {
            try
            {
            return  connection.Delete<AgencyCmsSectionTypes>(AgencyCmsSectionTypes);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<AgencyCmsSectionTypes> GetAll(){
            try
            {
                return connection.Query<AgencyCmsSectionTypes>("AgencyCmsSectionTypesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public AgencyCmsSectionTypes GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<AgencyCmsSectionTypes>("AgencyCmsSectionTypesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyCmsSectionTypes> GetByName(string Name){
            try
            {
                return connection.Query<AgencyCmsSectionTypes>("AgencyCmsSectionTypesGetByName", new
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
