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
    public class HotelTypesDB
    {
        private string connectionString = "";
		
        /// <summary>
        /// The constructor for HotelTypesDB
        /// </summary>
        /// <param name="connectionString">The database connection string</param>
        public HotelTypesDB(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Inserts the given object
        /// </summary>
        /// <param name="dto">The object to be inserted</param>
        public void Insert(HotelTypes dto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_INSERT_HotelTypes", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = dto.Id;
cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = dto.Name;


                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Updates the specified record.
        /// </summary>
        /// <param name="dto">The object to be modified</param>
        public void Update(HotelTypes dto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_UPDATE_HotelTypes", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = dto.Id;
cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = dto.Name;


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
                SqlCommand cmd = new SqlCommand("AG_DELETE_HotelTypes", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;


                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Gets the List of HotelTypes
        /// </summary>
        /// <returns>The List of HotelTypes</returns>
        public List<HotelTypes> Select()
        {
            List<HotelTypes> dtos = new List<HotelTypes>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_SELECT_HotelTypes", conn);
                cmd.CommandType = CommandType.StoredProcedure;

				var dataReader = cmd.ExecuteReader();
				while (dataReader.Read())
				{
					HotelTypes dto1 = new HotelTypes();
					dto1.Id = (dataReader["Id"] == System.DBNull.Value) ? string.Empty : dataReader["Id"].ToString();
dto1.Name = (dataReader["Name"] == System.DBNull.Value) ? string.Empty : dataReader["Name"].ToString();

					dtos.Add(dto1);
				}
            }
			
            return dtos;
        }
		
		
		
		
		/// <summary>
        /// Gets the List of HotelTypes
        /// </summary>
		/// <param name="id">The key to delete the record</param>
        /// <returns>The HotelTypes</returns>
        public HotelTypes SelectById(string id)
        {
            HotelTypes dto1 = new HotelTypes();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_SELECTBYID_HotelTypes", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;

				
				var dataReader = cmd.ExecuteReader();
				while (dataReader.Read())
				{
					dto1.Id = (dataReader["Id"] == System.DBNull.Value) ? string.Empty : dataReader["Id"].ToString();
dto1.Name = (dataReader["Name"] == System.DBNull.Value) ? string.Empty : dataReader["Name"].ToString();

				}
            }
			
            return dto1;
        }
    }
}
