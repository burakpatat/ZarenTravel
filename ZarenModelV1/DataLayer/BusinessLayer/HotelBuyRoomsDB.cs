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
    public class HotelBuyRoomsDB
    {
        private string connectionString = "";
		
        /// <summary>
        /// The constructor for HotelBuyRoomsDB
        /// </summary>
        /// <param name="connectionString">The database connection string</param>
        public HotelBuyRoomsDB(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Inserts the given object
        /// </summary>
        /// <param name="dto">The object to be inserted</param>
        public void Insert(HotelBuyRooms dto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_INSERT_HotelBuyRooms", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = dto.Id;
cmd.Parameters.Add("@HotelId", SqlDbType.VarChar).Value = dto.HotelId;
cmd.Parameters.Add("@BuyRoomId", SqlDbType.VarChar).Value = dto.BuyRoomId;


                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Updates the specified record.
        /// </summary>
        /// <param name="dto">The object to be modified</param>
        public void Update(HotelBuyRooms dto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_UPDATE_HotelBuyRooms", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = dto.Id;
cmd.Parameters.Add("@HotelId", SqlDbType.VarChar).Value = dto.HotelId;
cmd.Parameters.Add("@BuyRoomId", SqlDbType.VarChar).Value = dto.BuyRoomId;


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
                SqlCommand cmd = new SqlCommand("AG_DELETE_HotelBuyRooms", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;


                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Gets the List of HotelBuyRooms
        /// </summary>
        /// <returns>The List of HotelBuyRooms</returns>
        public List<HotelBuyRooms> Select()
        {
            List<HotelBuyRooms> dtos = new List<HotelBuyRooms>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_SELECT_HotelBuyRooms", conn);
                cmd.CommandType = CommandType.StoredProcedure;

				var dataReader = cmd.ExecuteReader();
				while (dataReader.Read())
				{
					HotelBuyRooms dto1 = new HotelBuyRooms();
					dto1.Id = (dataReader["Id"] == System.DBNull.Value) ? string.Empty : dataReader["Id"].ToString();
dto1.HotelId = (dataReader["HotelId"] == System.DBNull.Value) ? string.Empty : dataReader["HotelId"].ToString();
dto1.BuyRoomId = (dataReader["BuyRoomId"] == System.DBNull.Value) ? string.Empty : dataReader["BuyRoomId"].ToString();

					dtos.Add(dto1);
				}
            }
			
            return dtos;
        }
		
		
		
		
		/// <summary>
        /// Gets the List of HotelBuyRooms
        /// </summary>
		/// <param name="id">The key to delete the record</param>
        /// <returns>The HotelBuyRooms</returns>
        public HotelBuyRooms SelectById(string id)
        {
            HotelBuyRooms dto1 = new HotelBuyRooms();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_SELECTBYID_HotelBuyRooms", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;

				
				var dataReader = cmd.ExecuteReader();
				while (dataReader.Read())
				{
					dto1.Id = (dataReader["Id"] == System.DBNull.Value) ? string.Empty : dataReader["Id"].ToString();
dto1.HotelId = (dataReader["HotelId"] == System.DBNull.Value) ? string.Empty : dataReader["HotelId"].ToString();
dto1.BuyRoomId = (dataReader["BuyRoomId"] == System.DBNull.Value) ? string.Empty : dataReader["BuyRoomId"].ToString();

				}
            }
			
            return dto1;
        }
    }
}
