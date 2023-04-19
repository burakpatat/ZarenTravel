using Dapper.Contrib.Extensions;
using Dapper;
using Model.Concrete;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class DatesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public DatesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
        public long Insert(Dates Dates)
        {
            try
            {
                return connection.Insert(Dates);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update(Dates Dates)
        {
            try
            {
                return connection.Update(Dates);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Delete(Dates Dates)
        {
            try
            {
                return connection.Delete<Dates>(Dates);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<Dates> GetAll()
        {
            try
            {
                return connection.Query<Dates>("DatesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Dates GetByID(int Id)
        {
            try
            {
                return connection.QueryFirstOrDefault<Dates>("DatesGetByID", new
                {
                    Id = Id
                }, commandType: CommandType.StoredProcedure);

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

