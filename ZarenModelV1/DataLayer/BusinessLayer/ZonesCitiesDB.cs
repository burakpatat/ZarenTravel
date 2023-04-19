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
    public class ZonesCitiesDB
    {
        private string connectionString = "";
		
        /// <summary>
        /// The constructor for ZonesCitiesDB
        /// </summary>
        /// <param name="connectionString">The database connection string</param>
        public ZonesCitiesDB(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Inserts the given object
        /// </summary>
        /// <param name="dto">The object to be inserted</param>
        public void Insert(ZonesCities dto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_INSERT_ZonesCities", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = dto.Id;
cmd.Parameters.Add("@CityId", SqlDbType.VarChar).Value = dto.CityId;
cmd.Parameters.Add("@ZoneId", SqlDbType.VarChar).Value = dto.ZoneId;
cmd.Parameters.Add("@MainZone", SqlDbType.VarChar).Value = dto.MainZone;


                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Updates the specified record.
        /// </summary>
        /// <param name="dto">The object to be modified</param>
        public void Update(ZonesCities dto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_UPDATE_ZonesCities", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = dto.Id;
cmd.Parameters.Add("@CityId", SqlDbType.VarChar).Value = dto.CityId;
cmd.Parameters.Add("@ZoneId", SqlDbType.VarChar).Value = dto.ZoneId;
cmd.Parameters.Add("@MainZone", SqlDbType.VarChar).Value = dto.MainZone;


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
                SqlCommand cmd = new SqlCommand("AG_DELETE_ZonesCities", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;


                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Gets the List of ZonesCities
        /// </summary>
        /// <returns>The List of ZonesCities</returns>
        public List<ZonesCities> Select()
        {
            List<ZonesCities> dtos = new List<ZonesCities>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_SELECT_ZonesCities", conn);
                cmd.CommandType = CommandType.StoredProcedure;

				var dataReader = cmd.ExecuteReader();
				while (dataReader.Read())
				{
					ZonesCities dto1 = new ZonesCities();
					dto1.Id = (dataReader["Id"] == System.DBNull.Value) ? string.Empty : dataReader["Id"].ToString();
dto1.CityId = (dataReader["CityId"] == System.DBNull.Value) ? string.Empty : dataReader["CityId"].ToString();
dto1.ZoneId = (dataReader["ZoneId"] == System.DBNull.Value) ? string.Empty : dataReader["ZoneId"].ToString();
dto1.MainZone = (dataReader["MainZone"] == System.DBNull.Value) ? string.Empty : dataReader["MainZone"].ToString();

					dtos.Add(dto1);
				}
            }
			
            return dtos;
        }
		
		
		
		
		/// <summary>
        /// Gets the List of ZonesCities
        /// </summary>
		/// <param name="id">The key to delete the record</param>
        /// <returns>The ZonesCities</returns>
        public ZonesCities SelectById(string id)
        {
            ZonesCities dto1 = new ZonesCities();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_SELECTBYID_ZonesCities", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;

				
				var dataReader = cmd.ExecuteReader();
				while (dataReader.Read())
				{
					dto1.Id = (dataReader["Id"] == System.DBNull.Value) ? string.Empty : dataReader["Id"].ToString();
dto1.CityId = (dataReader["CityId"] == System.DBNull.Value) ? string.Empty : dataReader["CityId"].ToString();
dto1.ZoneId = (dataReader["ZoneId"] == System.DBNull.Value) ? string.Empty : dataReader["ZoneId"].ToString();
dto1.MainZone = (dataReader["MainZone"] == System.DBNull.Value) ? string.Empty : dataReader["MainZone"].ToString();

				}
            }
			
            return dto1;
        }
    }
}
