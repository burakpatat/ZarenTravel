using DataLayer.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.BusinessLayer
{
    public class CancellationSeasonsDB
    {
        private string connectionString = "";
		
        /// <summary>
        /// The constructor for CancellationSeasonsDB
        /// </summary>
        /// <param name="connectionString">The database connection string</param>
        public CancellationSeasonsDB(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Inserts the given object
        /// </summary>
        /// <param name="dto">The object to be inserted</param>
        public void Insert(CancellationSeasons dto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_INSERT_CancellationSeasons", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = dto.Id;
cmd.Parameters.Add("@HotelId", SqlDbType.VarChar).Value = dto.HotelId;
cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = dto.StartDate;
cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = dto.EndDate;


                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Updates the specified record.
        /// </summary>
        /// <param name="dto">The object to be modified</param>
        public void Update(CancellationSeasons dto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_UPDATE_CancellationSeasons", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = dto.Id;
cmd.Parameters.Add("@HotelId", SqlDbType.VarChar).Value = dto.HotelId;
cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = dto.StartDate;
cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = dto.EndDate;


                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Deletes the record by the given id
        /// </summary>
        /// <param name="id">The key to delete the record</param>
        public void Delete(string id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_DELETE_CancellationSeasons", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;


                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Gets the List of CancellationSeasons
        /// </summary>
        /// <returns>The List of CancellationSeasons</returns>
        public List<CancellationSeasons> Select()
        {
            List<CancellationSeasons> dtos = new List<CancellationSeasons>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_SELECT_CancellationSeasons", conn);
                cmd.CommandType = CommandType.StoredProcedure;

				var dataReader = cmd.ExecuteReader();
				while (dataReader.Read())
				{
					CancellationSeasons dto1 = new CancellationSeasons();
					dto1.Id = (dataReader["Id"] == System.DBNull.Value) ? string.Empty : dataReader["Id"].ToString();
dto1.HotelId = (dataReader["HotelId"] == System.DBNull.Value) ? string.Empty : dataReader["HotelId"].ToString();
dto1.StartDate = (dataReader["StartDate"] == System.DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dataReader["StartDate"].ToString());
dto1.EndDate = (dataReader["EndDate"] == System.DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dataReader["EndDate"].ToString());

					dtos.Add(dto1);
				}
            }
			
            return dtos;
        }
		
		
		
		
		/// <summary>
        /// Gets the List of CancellationSeasons
        /// </summary>
		/// <param name="id">The key to delete the record</param>
        /// <returns>The CancellationSeasons</returns>
        public CancellationSeasons SelectById(string id)
        {
            CancellationSeasons dto1 = new CancellationSeasons();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_SELECTBYID_CancellationSeasons", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;

				
				var dataReader = cmd.ExecuteReader();
				while (dataReader.Read())
				{
					dto1.Id = (dataReader["Id"] == System.DBNull.Value) ? string.Empty : dataReader["Id"].ToString();
dto1.HotelId = (dataReader["HotelId"] == System.DBNull.Value) ? string.Empty : dataReader["HotelId"].ToString();
dto1.StartDate = (dataReader["StartDate"] == System.DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dataReader["StartDate"].ToString());
dto1.EndDate = (dataReader["EndDate"] == System.DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dataReader["EndDate"].ToString());

				}
            }
			
            return dto1;
        }
    }
}
