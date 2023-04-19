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
    public class HotelTypeLanguagesDB
    {
        private string connectionString = "";
		
        /// <summary>
        /// The constructor for HotelTypeLanguagesDB
        /// </summary>
        /// <param name="connectionString">The database connection string</param>
        public HotelTypeLanguagesDB(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Inserts the given object
        /// </summary>
        /// <param name="dto">The object to be inserted</param>
        public void Insert(HotelTypeLanguages dto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_INSERT_HotelTypeLanguages", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = dto.Id;
cmd.Parameters.Add("@HotelTypeId", SqlDbType.VarChar).Value = dto.HotelTypeId;
cmd.Parameters.Add("@LanguageId", SqlDbType.VarChar).Value = dto.LanguageId;
cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = dto.Name;


                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Updates the specified record.
        /// </summary>
        /// <param name="dto">The object to be modified</param>
        public void Update(HotelTypeLanguages dto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_UPDATE_HotelTypeLanguages", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = dto.Id;
cmd.Parameters.Add("@HotelTypeId", SqlDbType.VarChar).Value = dto.HotelTypeId;
cmd.Parameters.Add("@LanguageId", SqlDbType.VarChar).Value = dto.LanguageId;
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
                SqlCommand cmd = new SqlCommand("AG_DELETE_HotelTypeLanguages", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;


                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Gets the List of HotelTypeLanguages
        /// </summary>
        /// <returns>The List of HotelTypeLanguages</returns>
        public List<HotelTypeLanguages> Select()
        {
            List<HotelTypeLanguages> dtos = new List<HotelTypeLanguages>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_SELECT_HotelTypeLanguages", conn);
                cmd.CommandType = CommandType.StoredProcedure;

				var dataReader = cmd.ExecuteReader();
				while (dataReader.Read())
				{
					HotelTypeLanguages dto1 = new HotelTypeLanguages();
					dto1.Id = (dataReader["Id"] == System.DBNull.Value) ? string.Empty : dataReader["Id"].ToString();
dto1.HotelTypeId = (dataReader["HotelTypeId"] == System.DBNull.Value) ? string.Empty : dataReader["HotelTypeId"].ToString();
dto1.LanguageId = (dataReader["LanguageId"] == System.DBNull.Value) ? string.Empty : dataReader["LanguageId"].ToString();
dto1.Name = (dataReader["Name"] == System.DBNull.Value) ? string.Empty : dataReader["Name"].ToString();

					dtos.Add(dto1);
				}
            }
			
            return dtos;
        }
		
		
		
		
		/// <summary>
        /// Gets the List of HotelTypeLanguages
        /// </summary>
		/// <param name="id">The key to delete the record</param>
        /// <returns>The HotelTypeLanguages</returns>
        public HotelTypeLanguages SelectById(string id)
        {
            HotelTypeLanguages dto1 = new HotelTypeLanguages();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_SELECTBYID_HotelTypeLanguages", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;

				
				var dataReader = cmd.ExecuteReader();
				while (dataReader.Read())
				{
					dto1.Id = (dataReader["Id"] == System.DBNull.Value) ? string.Empty : dataReader["Id"].ToString();
dto1.HotelTypeId = (dataReader["HotelTypeId"] == System.DBNull.Value) ? string.Empty : dataReader["HotelTypeId"].ToString();
dto1.LanguageId = (dataReader["LanguageId"] == System.DBNull.Value) ? string.Empty : dataReader["LanguageId"].ToString();
dto1.Name = (dataReader["Name"] == System.DBNull.Value) ? string.Empty : dataReader["Name"].ToString();

				}
            }
			
            return dto1;
        }
    }
}
