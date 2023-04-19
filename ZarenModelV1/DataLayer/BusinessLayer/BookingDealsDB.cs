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
    public class BookingDealsDB
    {
        private string connectionString = "";
		
        /// <summary>
        /// The constructor for BookingDealsDB
        /// </summary>
        /// <param name="connectionString">The database connection string</param>
        public BookingDealsDB(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Inserts the given object
        /// </summary>
        /// <param name="dto">The object to be inserted</param>
        public void Insert(BookingDeals dto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_INSERT_BookingDeals", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = dto.Id;
cmd.Parameters.Add("@BookingId", SqlDbType.VarChar).Value = dto.BookingId;
cmd.Parameters.Add("@DealId", SqlDbType.VarChar).Value = dto.DealId;


                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Updates the specified record.
        /// </summary>
        /// <param name="dto">The object to be modified</param>
        public void Update(BookingDeals dto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_UPDATE_BookingDeals", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = dto.Id;
cmd.Parameters.Add("@BookingId", SqlDbType.VarChar).Value = dto.BookingId;
cmd.Parameters.Add("@DealId", SqlDbType.VarChar).Value = dto.DealId;


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
                SqlCommand cmd = new SqlCommand("AG_DELETE_BookingDeals", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;


                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Gets the List of BookingDeals
        /// </summary>
        /// <returns>The List of BookingDeals</returns>
        public List<BookingDeals> Select()
        {
            List<BookingDeals> dtos = new List<BookingDeals>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_SELECT_BookingDeals", conn);
                cmd.CommandType = CommandType.StoredProcedure;

				var dataReader = cmd.ExecuteReader();
				while (dataReader.Read())
				{
					BookingDeals dto1 = new BookingDeals();
					dto1.Id = (dataReader["Id"] == System.DBNull.Value) ? string.Empty : dataReader["Id"].ToString();
dto1.BookingId = (dataReader["BookingId"] == System.DBNull.Value) ? string.Empty : dataReader["BookingId"].ToString();
dto1.DealId = (dataReader["DealId"] == System.DBNull.Value) ? string.Empty : dataReader["DealId"].ToString();

					dtos.Add(dto1);
				}
            }
			
            return dtos;
        }
		
		
		
		
		/// <summary>
        /// Gets the List of BookingDeals
        /// </summary>
		/// <param name="id">The key to delete the record</param>
        /// <returns>The BookingDeals</returns>
        public BookingDeals SelectById(string id)
        {
            BookingDeals dto1 = new BookingDeals();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_SELECTBYID_BookingDeals", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;

				
				var dataReader = cmd.ExecuteReader();
				while (dataReader.Read())
				{
					dto1.Id = (dataReader["Id"] == System.DBNull.Value) ? string.Empty : dataReader["Id"].ToString();
dto1.BookingId = (dataReader["BookingId"] == System.DBNull.Value) ? string.Empty : dataReader["BookingId"].ToString();
dto1.DealId = (dataReader["DealId"] == System.DBNull.Value) ? string.Empty : dataReader["DealId"].ToString();

				}
            }
			
            return dto1;
        }
    }
}
