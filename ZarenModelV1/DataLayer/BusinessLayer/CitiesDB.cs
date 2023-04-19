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
    public class CitiesDB
    {
        private string connectionString = "";
		
        /// <summary>
        /// The constructor for CitiesDB
        /// </summary>
        /// <param name="connectionString">The database connection string</param>
        public CitiesDB(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Inserts the given object
        /// </summary>
        /// <param name="dto">The object to be inserted</param>
        public void Insert(Cities dto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_INSERT_Cities", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = dto.Id;
cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = dto.Name;
cmd.Parameters.Add("@Latitude", SqlDbType.VarChar).Value = dto.Latitude;
cmd.Parameters.Add("@Longitude", SqlDbType.VarChar).Value = dto.Longitude;


                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Updates the specified record.
        /// </summary>
        /// <param name="dto">The object to be modified</param>
        public void Update(Cities dto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_UPDATE_Cities", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = dto.Id;
cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = dto.Name;
cmd.Parameters.Add("@Latitude", SqlDbType.VarChar).Value = dto.Latitude;
cmd.Parameters.Add("@Longitude", SqlDbType.VarChar).Value = dto.Longitude;


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
                SqlCommand cmd = new SqlCommand("AG_DELETE_Cities", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;


                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Gets the List of Cities
        /// </summary>
        /// <returns>The List of Cities</returns>
        public List<Cities> Select()
        {
            List<Cities> dtos = new List<Cities>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_SELECT_Cities", conn);
                cmd.CommandType = CommandType.StoredProcedure;

				var dataReader = cmd.ExecuteReader();
				while (dataReader.Read())
				{
					Cities dto1 = new Cities();
					dto1.Id = (dataReader["Id"] == System.DBNull.Value) ? string.Empty : dataReader["Id"].ToString();
dto1.Name = (dataReader["Name"] == System.DBNull.Value) ? string.Empty : dataReader["Name"].ToString();
dto1.Latitude = (dataReader["Latitude"] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dataReader["Latitude"].ToString());
dto1.Longitude = (dataReader["Longitude"] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dataReader["Longitude"].ToString());

					dtos.Add(dto1);
				}
            }
			
            return dtos;
        }
		
		
		
		
		/// <summary>
        /// Gets the List of Cities
        /// </summary>
		/// <param name="id">The key to delete the record</param>
        /// <returns>The Cities</returns>
        public Cities SelectById(string id)
        {
            Cities dto1 = new Cities();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_SELECTBYID_Cities", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;

				
				var dataReader = cmd.ExecuteReader();
				while (dataReader.Read())
				{
					dto1.Id = (dataReader["Id"] == System.DBNull.Value) ? string.Empty : dataReader["Id"].ToString();
dto1.Name = (dataReader["Name"] == System.DBNull.Value) ? string.Empty : dataReader["Name"].ToString();
dto1.Latitude = (dataReader["Latitude"] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dataReader["Latitude"].ToString());
dto1.Longitude = (dataReader["Longitude"] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dataReader["Longitude"].ToString());

				}
            }
			
            return dto1;
        }
    }
}
