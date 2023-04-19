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
    public class HotelRoomsDB
    {
        private string connectionString = "";
		
        /// <summary>
        /// The constructor for HotelRoomsDB
        /// </summary>
        /// <param name="connectionString">The database connection string</param>
        public HotelRoomsDB(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Inserts the given object
        /// </summary>
        /// <param name="dto">The object to be inserted</param>
        public void Insert(HotelRooms dto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_INSERT_HotelRooms", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = dto.Id;
cmd.Parameters.Add("@HotelBuyRoomId", SqlDbType.VarChar).Value = dto.HotelBuyRoomId;
cmd.Parameters.Add("@RoomId", SqlDbType.VarChar).Value = dto.RoomId;
cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = dto.Name;
cmd.Parameters.Add("@Adults", SqlDbType.VarChar).Value = dto.Adults;
cmd.Parameters.Add("@Children", SqlDbType.VarChar).Value = dto.Children;
cmd.Parameters.Add("@Infants", SqlDbType.VarChar).Value = dto.Infants;


                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Updates the specified record.
        /// </summary>
        /// <param name="dto">The object to be modified</param>
        public void Update(HotelRooms dto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_UPDATE_HotelRooms", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = dto.Id;
cmd.Parameters.Add("@HotelBuyRoomId", SqlDbType.VarChar).Value = dto.HotelBuyRoomId;
cmd.Parameters.Add("@RoomId", SqlDbType.VarChar).Value = dto.RoomId;
cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = dto.Name;
cmd.Parameters.Add("@Adults", SqlDbType.VarChar).Value = dto.Adults;
cmd.Parameters.Add("@Children", SqlDbType.VarChar).Value = dto.Children;
cmd.Parameters.Add("@Infants", SqlDbType.VarChar).Value = dto.Infants;


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
                SqlCommand cmd = new SqlCommand("AG_DELETE_HotelRooms", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;


                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Gets the List of HotelRooms
        /// </summary>
        /// <returns>The List of HotelRooms</returns>
        public List<HotelRooms> Select()
        {
            List<HotelRooms> dtos = new List<HotelRooms>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_SELECT_HotelRooms", conn);
                cmd.CommandType = CommandType.StoredProcedure;

				var dataReader = cmd.ExecuteReader();
				while (dataReader.Read())
				{
					HotelRooms dto1 = new HotelRooms();
					dto1.Id = (dataReader["Id"] == System.DBNull.Value) ? string.Empty : dataReader["Id"].ToString();
dto1.HotelBuyRoomId = (dataReader["HotelBuyRoomId"] == System.DBNull.Value) ? string.Empty : dataReader["HotelBuyRoomId"].ToString();
dto1.RoomId = (dataReader["RoomId"] == System.DBNull.Value) ? string.Empty : dataReader["RoomId"].ToString();
dto1.Name = (dataReader["Name"] == System.DBNull.Value) ? string.Empty : dataReader["Name"].ToString();
dto1.Adults = (dataReader["Adults"] == System.DBNull.Value) ? string.Empty : dataReader["Adults"].ToString();
dto1.Children = (dataReader["Children"] == System.DBNull.Value) ? string.Empty : dataReader["Children"].ToString();
dto1.Infants = (dataReader["Infants"] == System.DBNull.Value) ? string.Empty : dataReader["Infants"].ToString();

					dtos.Add(dto1);
				}
            }
			
            return dtos;
        }
		
		
		
		
		/// <summary>
        /// Gets the List of HotelRooms
        /// </summary>
		/// <param name="id">The key to delete the record</param>
        /// <returns>The HotelRooms</returns>
        public HotelRooms SelectById(string id)
        {
            HotelRooms dto1 = new HotelRooms();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_SELECTBYID_HotelRooms", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;

				
				var dataReader = cmd.ExecuteReader();
				while (dataReader.Read())
				{
					dto1.Id = (dataReader["Id"] == System.DBNull.Value) ? string.Empty : dataReader["Id"].ToString();
dto1.HotelBuyRoomId = (dataReader["HotelBuyRoomId"] == System.DBNull.Value) ? string.Empty : dataReader["HotelBuyRoomId"].ToString();
dto1.RoomId = (dataReader["RoomId"] == System.DBNull.Value) ? string.Empty : dataReader["RoomId"].ToString();
dto1.Name = (dataReader["Name"] == System.DBNull.Value) ? string.Empty : dataReader["Name"].ToString();
dto1.Adults = (dataReader["Adults"] == System.DBNull.Value) ? string.Empty : dataReader["Adults"].ToString();
dto1.Children = (dataReader["Children"] == System.DBNull.Value) ? string.Empty : dataReader["Children"].ToString();
dto1.Infants = (dataReader["Infants"] == System.DBNull.Value) ? string.Empty : dataReader["Infants"].ToString();

				}
            }
			
            return dto1;
        }
    }
}
