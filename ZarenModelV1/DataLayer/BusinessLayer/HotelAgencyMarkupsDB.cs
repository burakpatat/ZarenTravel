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
    public class HotelAgencyMarkupsDB
    {
        private string connectionString = "";
		
        /// <summary>
        /// The constructor for HotelAgencyMarkupsDB
        /// </summary>
        /// <param name="connectionString">The database connection string</param>
        public HotelAgencyMarkupsDB(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Inserts the given object
        /// </summary>
        /// <param name="dto">The object to be inserted</param>
        public void Insert(HotelAgencyMarkups dto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_INSERT_HotelAgencyMarkups", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = dto.Id;
cmd.Parameters.Add("@AgencyId", SqlDbType.VarChar).Value = dto.AgencyId;
cmd.Parameters.Add("@HotelId", SqlDbType.VarChar).Value = dto.HotelId;
cmd.Parameters.Add("@MarkUp", SqlDbType.VarChar).Value = dto.MarkUp;
cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = dto.StartDate;
cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = dto.EndDate;


                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Updates the specified record.
        /// </summary>
        /// <param name="dto">The object to be modified</param>
        public void Update(HotelAgencyMarkups dto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_UPDATE_HotelAgencyMarkups", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = dto.Id;
cmd.Parameters.Add("@AgencyId", SqlDbType.VarChar).Value = dto.AgencyId;
cmd.Parameters.Add("@HotelId", SqlDbType.VarChar).Value = dto.HotelId;
cmd.Parameters.Add("@MarkUp", SqlDbType.VarChar).Value = dto.MarkUp;
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
                SqlCommand cmd = new SqlCommand("AG_DELETE_HotelAgencyMarkups", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;


                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Gets the List of HotelAgencyMarkups
        /// </summary>
        /// <returns>The List of HotelAgencyMarkups</returns>
        public List<HotelAgencyMarkups> Select()
        {
            List<HotelAgencyMarkups> dtos = new List<HotelAgencyMarkups>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_SELECT_HotelAgencyMarkups", conn);
                cmd.CommandType = CommandType.StoredProcedure;

				var dataReader = cmd.ExecuteReader();
				while (dataReader.Read())
				{
					HotelAgencyMarkups dto1 = new HotelAgencyMarkups();
					dto1.Id = (dataReader["Id"] == System.DBNull.Value) ? string.Empty : dataReader["Id"].ToString();
dto1.AgencyId = (dataReader["AgencyId"] == System.DBNull.Value) ? string.Empty : dataReader["AgencyId"].ToString();
dto1.HotelId = (dataReader["HotelId"] == System.DBNull.Value) ? string.Empty : dataReader["HotelId"].ToString();
dto1.MarkUp = (dataReader["MarkUp"] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dataReader["MarkUp"].ToString());
dto1.StartDate = (dataReader["StartDate"] == System.DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dataReader["StartDate"].ToString());
dto1.EndDate = (dataReader["EndDate"] == System.DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dataReader["EndDate"].ToString());

					dtos.Add(dto1);
				}
            }
			
            return dtos;
        }
		
		
		
		
		/// <summary>
        /// Gets the List of HotelAgencyMarkups
        /// </summary>
		/// <param name="id">The key to delete the record</param>
        /// <returns>The HotelAgencyMarkups</returns>
        public HotelAgencyMarkups SelectById(string id)
        {
            HotelAgencyMarkups dto1 = new HotelAgencyMarkups();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_SELECTBYID_HotelAgencyMarkups", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;

				
				var dataReader = cmd.ExecuteReader();
				while (dataReader.Read())
				{
					dto1.Id = (dataReader["Id"] == System.DBNull.Value) ? string.Empty : dataReader["Id"].ToString();
dto1.AgencyId = (dataReader["AgencyId"] == System.DBNull.Value) ? string.Empty : dataReader["AgencyId"].ToString();
dto1.HotelId = (dataReader["HotelId"] == System.DBNull.Value) ? string.Empty : dataReader["HotelId"].ToString();
dto1.MarkUp = (dataReader["MarkUp"] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dataReader["MarkUp"].ToString());
dto1.StartDate = (dataReader["StartDate"] == System.DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dataReader["StartDate"].ToString());
dto1.EndDate = (dataReader["EndDate"] == System.DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dataReader["EndDate"].ToString());

				}
            }
			
            return dto1;
        }
    }
}
