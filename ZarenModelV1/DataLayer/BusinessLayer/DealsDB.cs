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
    public class DealsDB
    {
        private string connectionString = "";
		
        /// <summary>
        /// The constructor for DealsDB
        /// </summary>
        /// <param name="connectionString">The database connection string</param>
        public DealsDB(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Inserts the given object
        /// </summary>
        /// <param name="dto">The object to be inserted</param>
        public void Insert(Deals dto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_INSERT_Deals", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = dto.Id;
cmd.Parameters.Add("@HotelRoomId", SqlDbType.VarChar).Value = dto.HotelRoomId;
cmd.Parameters.Add("@BoardTypeId", SqlDbType.VarChar).Value = dto.BoardTypeId;
cmd.Parameters.Add("@DealTypeId", SqlDbType.VarChar).Value = dto.DealTypeId;
cmd.Parameters.Add("@Release", SqlDbType.VarChar).Value = dto.Release;
cmd.Parameters.Add("@Discount", SqlDbType.VarChar).Value = dto.Discount;
cmd.Parameters.Add("@FreeNights", SqlDbType.VarChar).Value = dto.FreeNights;
cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = dto.StartDate;
cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = dto.EndDate;


                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Updates the specified record.
        /// </summary>
        /// <param name="dto">The object to be modified</param>
        public void Update(Deals dto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_UPDATE_Deals", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = dto.Id;
cmd.Parameters.Add("@HotelRoomId", SqlDbType.VarChar).Value = dto.HotelRoomId;
cmd.Parameters.Add("@BoardTypeId", SqlDbType.VarChar).Value = dto.BoardTypeId;
cmd.Parameters.Add("@DealTypeId", SqlDbType.VarChar).Value = dto.DealTypeId;
cmd.Parameters.Add("@Release", SqlDbType.VarChar).Value = dto.Release;
cmd.Parameters.Add("@Discount", SqlDbType.VarChar).Value = dto.Discount;
cmd.Parameters.Add("@FreeNights", SqlDbType.VarChar).Value = dto.FreeNights;
cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = dto.StartDate;
cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = dto.EndDate;


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
                SqlCommand cmd = new SqlCommand("AG_DELETE_Deals", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;


                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Gets the List of Deals
        /// </summary>
        /// <returns>The List of Deals</returns>
        public List<Deals> Select()
        {
            List<Deals> dtos = new List<Deals>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_SELECT_Deals", conn);
                cmd.CommandType = CommandType.StoredProcedure;

				var dataReader = cmd.ExecuteReader();
				while (dataReader.Read())
				{
					Deals dto1 = new Deals();
					dto1.Id = (dataReader["Id"] == System.DBNull.Value) ? string.Empty : dataReader["Id"].ToString();
dto1.HotelRoomId = (dataReader["HotelRoomId"] == System.DBNull.Value) ? string.Empty : dataReader["HotelRoomId"].ToString();
dto1.BoardTypeId = (dataReader["BoardTypeId"] == System.DBNull.Value) ? string.Empty : dataReader["BoardTypeId"].ToString();
dto1.DealTypeId = (dataReader["DealTypeId"] == System.DBNull.Value) ? string.Empty : dataReader["DealTypeId"].ToString();
dto1.Release = (dataReader["Release"] == System.DBNull.Value) ? string.Empty : dataReader["Release"].ToString();
dto1.Discount = (dataReader["Discount"] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dataReader["Discount"].ToString());
dto1.FreeNights = (dataReader["FreeNights"] == System.DBNull.Value) ? string.Empty : dataReader["FreeNights"].ToString();
dto1.StartDate = (dataReader["StartDate"] == System.DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dataReader["StartDate"].ToString());
dto1.EndDate = (dataReader["EndDate"] == System.DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dataReader["EndDate"].ToString());

					dtos.Add(dto1);
				}
            }
			
            return dtos;
        }
		
		
		
		
		/// <summary>
        /// Gets the List of Deals
        /// </summary>
		/// <param name="id">The key to delete the record</param>
        /// <returns>The Deals</returns>
        public Deals SelectById(string id)
        {
            Deals dto1 = new Deals();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_SELECTBYID_Deals", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;

				
				var dataReader = cmd.ExecuteReader();
				while (dataReader.Read())
				{
					dto1.Id = (dataReader["Id"] == System.DBNull.Value) ? string.Empty : dataReader["Id"].ToString();
dto1.HotelRoomId = (dataReader["HotelRoomId"] == System.DBNull.Value) ? string.Empty : dataReader["HotelRoomId"].ToString();
dto1.BoardTypeId = (dataReader["BoardTypeId"] == System.DBNull.Value) ? string.Empty : dataReader["BoardTypeId"].ToString();
dto1.DealTypeId = (dataReader["DealTypeId"] == System.DBNull.Value) ? string.Empty : dataReader["DealTypeId"].ToString();
dto1.Release = (dataReader["Release"] == System.DBNull.Value) ? string.Empty : dataReader["Release"].ToString();
dto1.Discount = (dataReader["Discount"] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dataReader["Discount"].ToString());
dto1.FreeNights = (dataReader["FreeNights"] == System.DBNull.Value) ? string.Empty : dataReader["FreeNights"].ToString();
dto1.StartDate = (dataReader["StartDate"] == System.DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dataReader["StartDate"].ToString());
dto1.EndDate = (dataReader["EndDate"] == System.DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dataReader["EndDate"].ToString());

				}
            }
			
            return dto1;
        }
    }
}
