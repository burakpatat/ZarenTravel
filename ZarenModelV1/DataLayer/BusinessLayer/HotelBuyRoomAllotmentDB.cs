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
    public class HotelBuyRoomAllotmentDB
    {
        private string connectionString = "";
		
        /// <summary>
        /// The constructor for HotelBuyRoomAllotmentDB
        /// </summary>
        /// <param name="connectionString">The database connection string</param>
        public HotelBuyRoomAllotmentDB(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Inserts the given object
        /// </summary>
        /// <param name="dto">The object to be inserted</param>
        public void Insert(HotelBuyRoomAllotment dto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_INSERT_HotelBuyRoomAllotment", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = dto.Id;
cmd.Parameters.Add("@HotelBuyRoomId", SqlDbType.VarChar).Value = dto.HotelBuyRoomId;
cmd.Parameters.Add("@Day", SqlDbType.DateTime).Value = dto.Day;
cmd.Parameters.Add("@Allotment", SqlDbType.VarChar).Value = dto.Allotment;
cmd.Parameters.Add("@Release", SqlDbType.VarChar).Value = dto.Release;
cmd.Parameters.Add("@StopSales", SqlDbType.VarChar).Value = dto.StopSales;


                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Updates the specified record.
        /// </summary>
        /// <param name="dto">The object to be modified</param>
        public void Update(HotelBuyRoomAllotment dto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_UPDATE_HotelBuyRoomAllotment", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = dto.Id;
cmd.Parameters.Add("@HotelBuyRoomId", SqlDbType.VarChar).Value = dto.HotelBuyRoomId;
cmd.Parameters.Add("@Day", SqlDbType.DateTime).Value = dto.Day;
cmd.Parameters.Add("@Allotment", SqlDbType.VarChar).Value = dto.Allotment;
cmd.Parameters.Add("@Release", SqlDbType.VarChar).Value = dto.Release;
cmd.Parameters.Add("@StopSales", SqlDbType.VarChar).Value = dto.StopSales;


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
                SqlCommand cmd = new SqlCommand("AG_DELETE_HotelBuyRoomAllotment", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;


                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Gets the List of HotelBuyRoomAllotment
        /// </summary>
        /// <returns>The List of HotelBuyRoomAllotment</returns>
        public List<HotelBuyRoomAllotment> Select()
        {
            List<HotelBuyRoomAllotment> dtos = new List<HotelBuyRoomAllotment>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_SELECT_HotelBuyRoomAllotment", conn);
                cmd.CommandType = CommandType.StoredProcedure;

				var dataReader = cmd.ExecuteReader();
				while (dataReader.Read())
				{
					HotelBuyRoomAllotment dto1 = new HotelBuyRoomAllotment();
					dto1.Id = (dataReader["Id"] == System.DBNull.Value) ? string.Empty : dataReader["Id"].ToString();
dto1.HotelBuyRoomId = (dataReader["HotelBuyRoomId"] == System.DBNull.Value) ? string.Empty : dataReader["HotelBuyRoomId"].ToString();
dto1.Day = (dataReader["Day"] == System.DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dataReader["Day"].ToString());
dto1.Allotment = (dataReader["Allotment"] == System.DBNull.Value) ? string.Empty : dataReader["Allotment"].ToString();
dto1.Release = (dataReader["Release"] == System.DBNull.Value) ? string.Empty : dataReader["Release"].ToString();
dto1.StopSales = (dataReader["StopSales"] == System.DBNull.Value) ? string.Empty : dataReader["StopSales"].ToString();

					dtos.Add(dto1);
				}
            }
			
            return dtos;
        }
		
		
		
		
		/// <summary>
        /// Gets the List of HotelBuyRoomAllotment
        /// </summary>
		/// <param name="id">The key to delete the record</param>
        /// <returns>The HotelBuyRoomAllotment</returns>
        public HotelBuyRoomAllotment SelectById(string id)
        {
            HotelBuyRoomAllotment dto1 = new HotelBuyRoomAllotment();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_SELECTBYID_HotelBuyRoomAllotment", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;

				
				var dataReader = cmd.ExecuteReader();
				while (dataReader.Read())
				{
					dto1.Id = (dataReader["Id"] == System.DBNull.Value) ? string.Empty : dataReader["Id"].ToString();
dto1.HotelBuyRoomId = (dataReader["HotelBuyRoomId"] == System.DBNull.Value) ? string.Empty : dataReader["HotelBuyRoomId"].ToString();
dto1.Day = (dataReader["Day"] == System.DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dataReader["Day"].ToString());
dto1.Allotment = (dataReader["Allotment"] == System.DBNull.Value) ? string.Empty : dataReader["Allotment"].ToString();
dto1.Release = (dataReader["Release"] == System.DBNull.Value) ? string.Empty : dataReader["Release"].ToString();
dto1.StopSales = (dataReader["StopSales"] == System.DBNull.Value) ? string.Empty : dataReader["StopSales"].ToString();

				}
            }
			
            return dto1;
        }
    }
}
