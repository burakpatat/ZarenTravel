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
    public class HotelRoomDailyPricesDB
    {
        private string connectionString = "";
		
        /// <summary>
        /// The constructor for HotelRoomDailyPricesDB
        /// </summary>
        /// <param name="connectionString">The database connection string</param>
        public HotelRoomDailyPricesDB(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Inserts the given object
        /// </summary>
        /// <param name="dto">The object to be inserted</param>
        public void Insert(HotelRoomDailyPrices dto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_INSERT_HotelRoomDailyPrices", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = dto.Id;
cmd.Parameters.Add("@BoardTypeId", SqlDbType.VarChar).Value = dto.BoardTypeId;
cmd.Parameters.Add("@HotelRoomId", SqlDbType.VarChar).Value = dto.HotelRoomId;
cmd.Parameters.Add("@Cost", SqlDbType.VarChar).Value = dto.Cost;
cmd.Parameters.Add("@Day", SqlDbType.DateTime).Value = dto.Day;
cmd.Parameters.Add("@StopSale", SqlDbType.VarChar).Value = dto.StopSale;


                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Updates the specified record.
        /// </summary>
        /// <param name="dto">The object to be modified</param>
        public void Update(HotelRoomDailyPrices dto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_UPDATE_HotelRoomDailyPrices", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = dto.Id;
cmd.Parameters.Add("@BoardTypeId", SqlDbType.VarChar).Value = dto.BoardTypeId;
cmd.Parameters.Add("@HotelRoomId", SqlDbType.VarChar).Value = dto.HotelRoomId;
cmd.Parameters.Add("@Cost", SqlDbType.VarChar).Value = dto.Cost;
cmd.Parameters.Add("@Day", SqlDbType.DateTime).Value = dto.Day;
cmd.Parameters.Add("@StopSale", SqlDbType.VarChar).Value = dto.StopSale;


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
                SqlCommand cmd = new SqlCommand("AG_DELETE_HotelRoomDailyPrices", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;


                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Gets the List of HotelRoomDailyPrices
        /// </summary>
        /// <returns>The List of HotelRoomDailyPrices</returns>
        public List<HotelRoomDailyPrices> Select()
        {
            List<HotelRoomDailyPrices> dtos = new List<HotelRoomDailyPrices>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_SELECT_HotelRoomDailyPrices", conn);
                cmd.CommandType = CommandType.StoredProcedure;

				var dataReader = cmd.ExecuteReader();
				while (dataReader.Read())
				{
					HotelRoomDailyPrices dto1 = new HotelRoomDailyPrices();
					dto1.Id = (dataReader["Id"] == System.DBNull.Value) ? string.Empty : dataReader["Id"].ToString();
dto1.BoardTypeId = (dataReader["BoardTypeId"] == System.DBNull.Value) ? string.Empty : dataReader["BoardTypeId"].ToString();
dto1.HotelRoomId = (dataReader["HotelRoomId"] == System.DBNull.Value) ? string.Empty : dataReader["HotelRoomId"].ToString();
dto1.Cost = (dataReader["Cost"] == System.DBNull.Value) ? string.Empty : dataReader["Cost"].ToString();
dto1.Day = (dataReader["Day"] == System.DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dataReader["Day"].ToString());
dto1.StopSale = (dataReader["StopSale"] == System.DBNull.Value) ? string.Empty : dataReader["StopSale"].ToString();

					dtos.Add(dto1);
				}
            }
			
            return dtos;
        }
		
		
		
		
		/// <summary>
        /// Gets the List of HotelRoomDailyPrices
        /// </summary>
		/// <param name="id">The key to delete the record</param>
        /// <returns>The HotelRoomDailyPrices</returns>
        public HotelRoomDailyPrices SelectById(string id)
        {
            HotelRoomDailyPrices dto1 = new HotelRoomDailyPrices();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_SELECTBYID_HotelRoomDailyPrices", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;

				
				var dataReader = cmd.ExecuteReader();
				while (dataReader.Read())
				{
					dto1.Id = (dataReader["Id"] == System.DBNull.Value) ? string.Empty : dataReader["Id"].ToString();
dto1.BoardTypeId = (dataReader["BoardTypeId"] == System.DBNull.Value) ? string.Empty : dataReader["BoardTypeId"].ToString();
dto1.HotelRoomId = (dataReader["HotelRoomId"] == System.DBNull.Value) ? string.Empty : dataReader["HotelRoomId"].ToString();
dto1.Cost = (dataReader["Cost"] == System.DBNull.Value) ? string.Empty : dataReader["Cost"].ToString();
dto1.Day = (dataReader["Day"] == System.DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dataReader["Day"].ToString());
dto1.StopSale = (dataReader["StopSale"] == System.DBNull.Value) ? string.Empty : dataReader["StopSale"].ToString();

				}
            }
			
            return dto1;
        }
    }
}
