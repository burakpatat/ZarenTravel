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
    public class FacilitiesHotelsDB
    {
        private string connectionString = "";
		
        /// <summary>
        /// The constructor for FacilitiesHotelsDB
        /// </summary>
        /// <param name="connectionString">The database connection string</param>
        public FacilitiesHotelsDB(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Inserts the given object
        /// </summary>
        /// <param name="dto">The object to be inserted</param>
        public void Insert(FacilitiesHotels dto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_INSERT_FacilitiesHotels", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = dto.Id;
cmd.Parameters.Add("@HotelId", SqlDbType.VarChar).Value = dto.HotelId;
cmd.Parameters.Add("@HotelRoomId", SqlDbType.VarChar).Value = dto.HotelRoomId;
cmd.Parameters.Add("@FacilityId", SqlDbType.VarChar).Value = dto.FacilityId;


                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Updates the specified record.
        /// </summary>
        /// <param name="dto">The object to be modified</param>
        public void Update(FacilitiesHotels dto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_UPDATE_FacilitiesHotels", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = dto.Id;
cmd.Parameters.Add("@HotelId", SqlDbType.VarChar).Value = dto.HotelId;
cmd.Parameters.Add("@HotelRoomId", SqlDbType.VarChar).Value = dto.HotelRoomId;
cmd.Parameters.Add("@FacilityId", SqlDbType.VarChar).Value = dto.FacilityId;


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
                SqlCommand cmd = new SqlCommand("AG_DELETE_FacilitiesHotels", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;


                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Gets the List of FacilitiesHotels
        /// </summary>
        /// <returns>The List of FacilitiesHotels</returns>
        public List<FacilitiesHotels> Select()
        {
            List<FacilitiesHotels> dtos = new List<FacilitiesHotels>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_SELECT_FacilitiesHotels", conn);
                cmd.CommandType = CommandType.StoredProcedure;

				var dataReader = cmd.ExecuteReader();
				while (dataReader.Read())
				{
					FacilitiesHotels dto1 = new FacilitiesHotels();
					dto1.Id = (dataReader["Id"] == System.DBNull.Value) ? string.Empty : dataReader["Id"].ToString();
dto1.HotelId = (dataReader["HotelId"] == System.DBNull.Value) ? string.Empty : dataReader["HotelId"].ToString();
dto1.HotelRoomId = (dataReader["HotelRoomId"] == System.DBNull.Value) ? string.Empty : dataReader["HotelRoomId"].ToString();
dto1.FacilityId = (dataReader["FacilityId"] == System.DBNull.Value) ? string.Empty : dataReader["FacilityId"].ToString();

					dtos.Add(dto1);
				}
            }
			
            return dtos;
        }
		
		
		
		
		/// <summary>
        /// Gets the List of FacilitiesHotels
        /// </summary>
		/// <param name="id">The key to delete the record</param>
        /// <returns>The FacilitiesHotels</returns>
        public FacilitiesHotels SelectById(string id)
        {
            FacilitiesHotels dto1 = new FacilitiesHotels();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_SELECTBYID_FacilitiesHotels", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;

				
				var dataReader = cmd.ExecuteReader();
				while (dataReader.Read())
				{
					dto1.Id = (dataReader["Id"] == System.DBNull.Value) ? string.Empty : dataReader["Id"].ToString();
dto1.HotelId = (dataReader["HotelId"] == System.DBNull.Value) ? string.Empty : dataReader["HotelId"].ToString();
dto1.HotelRoomId = (dataReader["HotelRoomId"] == System.DBNull.Value) ? string.Empty : dataReader["HotelRoomId"].ToString();
dto1.FacilityId = (dataReader["FacilityId"] == System.DBNull.Value) ? string.Empty : dataReader["FacilityId"].ToString();

				}
            }
			
            return dto1;
        }
    }
}
