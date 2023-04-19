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
    public class CountriesDB
    {
        private string connectionString = "";
		
        /// <summary>
        /// The constructor for CountriesDB
        /// </summary>
        /// <param name="connectionString">The database connection string</param>
        public CountriesDB(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Inserts the given object
        /// </summary>
        /// <param name="dto">The object to be inserted</param>
        public void Insert(Countries dto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_INSERT_Countries", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = dto.Id;
cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = dto.Name;
cmd.Parameters.Add("@LatLongBounds", SqlDbType.VarChar).Value = dto.LatLongBounds;


                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Updates the specified record.
        /// </summary>
        /// <param name="dto">The object to be modified</param>
        public void Update(Countries dto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_UPDATE_Countries", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = dto.Id;
cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = dto.Name;
cmd.Parameters.Add("@LatLongBounds", SqlDbType.VarChar).Value = dto.LatLongBounds;


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
                SqlCommand cmd = new SqlCommand("AG_DELETE_Countries", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;


                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Gets the List of Countries
        /// </summary>
        /// <returns>The List of Countries</returns>
        public List<Countries> Select()
        {
            List<Countries> dtos = new List<Countries>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_SELECT_Countries", conn);
                cmd.CommandType = CommandType.StoredProcedure;

				var dataReader = cmd.ExecuteReader();
				while (dataReader.Read())
				{
					Countries dto1 = new Countries();
					dto1.Id = (dataReader["Id"] == System.DBNull.Value) ? string.Empty : dataReader["Id"].ToString();
dto1.Name = (dataReader["Name"] == System.DBNull.Value) ? string.Empty : dataReader["Name"].ToString();
dto1.LatLongBounds = (dataReader["LatLongBounds"] == System.DBNull.Value) ? string.Empty : dataReader["LatLongBounds"].ToString();

					dtos.Add(dto1);
				}
            }
			
            return dtos;
        }
		
		
		
		
		/// <summary>
        /// Gets the List of Countries
        /// </summary>
		/// <param name="id">The key to delete the record</param>
        /// <returns>The Countries</returns>
        public Countries SelectById(string id)
        {
            Countries dto1 = new Countries();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_SELECTBYID_Countries", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;

				
				var dataReader = cmd.ExecuteReader();
				while (dataReader.Read())
				{
					dto1.Id = (dataReader["Id"] == System.DBNull.Value) ? string.Empty : dataReader["Id"].ToString();
dto1.Name = (dataReader["Name"] == System.DBNull.Value) ? string.Empty : dataReader["Name"].ToString();
dto1.LatLongBounds = (dataReader["LatLongBounds"] == System.DBNull.Value) ? string.Empty : dataReader["LatLongBounds"].ToString();

				}
            }
			
            return dto1;
        }
    }
}
