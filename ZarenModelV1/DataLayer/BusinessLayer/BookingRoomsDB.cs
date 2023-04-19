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
    public class BookingRoomsDB
    {
        private string connectionString = "";
		
        /// <summary>
        /// The constructor for BookingRoomsDB
        /// </summary>
        /// <param name="connectionString">The database connection string</param>
        public BookingRoomsDB(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Inserts the given object
        /// </summary>
        /// <param name="dto">The object to be inserted</param>
        public void Insert(BookingRooms dto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_INSERT_BookingRooms", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = dto.Id;
cmd.Parameters.Add("@BookingId", SqlDbType.VarChar).Value = dto.BookingId;
cmd.Parameters.Add("@HotelRoomId", SqlDbType.VarChar).Value = dto.HotelRoomId;
cmd.Parameters.Add("@BoardTypeId", SqlDbType.VarChar).Value = dto.BoardTypeId;
cmd.Parameters.Add("@Cost", SqlDbType.VarChar).Value = dto.Cost;
cmd.Parameters.Add("@Price", SqlDbType.VarChar).Value = dto.Price;


                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Updates the specified record.
        /// </summary>
        /// <param name="dto">The object to be modified</param>
        public void Update(BookingRooms dto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_UPDATE_BookingRooms", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = dto.Id;
cmd.Parameters.Add("@BookingId", SqlDbType.VarChar).Value = dto.BookingId;
cmd.Parameters.Add("@HotelRoomId", SqlDbType.VarChar).Value = dto.HotelRoomId;
cmd.Parameters.Add("@BoardTypeId", SqlDbType.VarChar).Value = dto.BoardTypeId;
cmd.Parameters.Add("@Cost", SqlDbType.VarChar).Value = dto.Cost;
cmd.Parameters.Add("@Price", SqlDbType.VarChar).Value = dto.Price;


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
                SqlCommand cmd = new SqlCommand("AG_DELETE_BookingRooms", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;


                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Gets the List of BookingRooms
        /// </summary>
        /// <returns>The List of BookingRooms</returns>
        public List<BookingRooms> Select()
        {
            List<BookingRooms> dtos = new List<BookingRooms>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_SELECT_BookingRooms", conn);
                cmd.CommandType = CommandType.StoredProcedure;

				var dataReader = cmd.ExecuteReader();
				while (dataReader.Read())
				{
					BookingRooms dto1 = new BookingRooms();
					dto1.Id = (dataReader["Id"] == System.DBNull.Value) ? string.Empty : dataReader["Id"].ToString();
dto1.BookingId = (dataReader["BookingId"] == System.DBNull.Value) ? string.Empty : dataReader["BookingId"].ToString();
dto1.HotelRoomId = (dataReader["HotelRoomId"] == System.DBNull.Value) ? string.Empty : dataReader["HotelRoomId"].ToString();
dto1.BoardTypeId = (dataReader["BoardTypeId"] == System.DBNull.Value) ? string.Empty : dataReader["BoardTypeId"].ToString();
dto1.Cost = (dataReader["Cost"] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dataReader["Cost"].ToString());
dto1.Price = (dataReader["Price"] == System.DBNull.Value) ? string.Empty : dataReader["Price"].ToString();

					dtos.Add(dto1);
				}
            }
			
            return dtos;
        }
		
		
		
		
		/// <summary>
        /// Gets the List of BookingRooms
        /// </summary>
		/// <param name="id">The key to delete the record</param>
        /// <returns>The BookingRooms</returns>
        public BookingRooms SelectById(string id)
        {
            BookingRooms dto1 = new BookingRooms();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_SELECTBYID_BookingRooms", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;

				
				var dataReader = cmd.ExecuteReader();
				while (dataReader.Read())
				{
					dto1.Id = (dataReader["Id"] == System.DBNull.Value) ? string.Empty : dataReader["Id"].ToString();
dto1.BookingId = (dataReader["BookingId"] == System.DBNull.Value) ? string.Empty : dataReader["BookingId"].ToString();
dto1.HotelRoomId = (dataReader["HotelRoomId"] == System.DBNull.Value) ? string.Empty : dataReader["HotelRoomId"].ToString();
dto1.BoardTypeId = (dataReader["BoardTypeId"] == System.DBNull.Value) ? string.Empty : dataReader["BoardTypeId"].ToString();
dto1.Cost = (dataReader["Cost"] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dataReader["Cost"].ToString());
dto1.Price = (dataReader["Price"] == System.DBNull.Value) ? string.Empty : dataReader["Price"].ToString();

				}
            }
			
            return dto1;
        }
    }
}
