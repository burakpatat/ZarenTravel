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
    public class FacilityLanguagesDB
    {
        private string connectionString = "";
		
        /// <summary>
        /// The constructor for FacilityLanguagesDB
        /// </summary>
        /// <param name="connectionString">The database connection string</param>
        public FacilityLanguagesDB(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Inserts the given object
        /// </summary>
        /// <param name="dto">The object to be inserted</param>
        public void Insert(FacilityLanguages dto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_INSERT_FacilityLanguages", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = dto.Id;
cmd.Parameters.Add("@FacilityId", SqlDbType.VarChar).Value = dto.FacilityId;
cmd.Parameters.Add("@LanguageId", SqlDbType.VarChar).Value = dto.LanguageId;
cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = dto.Name;


                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Updates the specified record.
        /// </summary>
        /// <param name="dto">The object to be modified</param>
        public void Update(FacilityLanguages dto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_UPDATE_FacilityLanguages", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = dto.Id;
cmd.Parameters.Add("@FacilityId", SqlDbType.VarChar).Value = dto.FacilityId;
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
                SqlCommand cmd = new SqlCommand("AG_DELETE_FacilityLanguages", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;


                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Gets the List of FacilityLanguages
        /// </summary>
        /// <returns>The List of FacilityLanguages</returns>
        public List<FacilityLanguages> Select()
        {
            List<FacilityLanguages> dtos = new List<FacilityLanguages>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_SELECT_FacilityLanguages", conn);
                cmd.CommandType = CommandType.StoredProcedure;

				var dataReader = cmd.ExecuteReader();
				while (dataReader.Read())
				{
					FacilityLanguages dto1 = new FacilityLanguages();
					dto1.Id = (dataReader["Id"] == System.DBNull.Value) ? string.Empty : dataReader["Id"].ToString();
dto1.FacilityId = (dataReader["FacilityId"] == System.DBNull.Value) ? string.Empty : dataReader["FacilityId"].ToString();
dto1.LanguageId = (dataReader["LanguageId"] == System.DBNull.Value) ? string.Empty : dataReader["LanguageId"].ToString();
dto1.Name = (dataReader["Name"] == System.DBNull.Value) ? string.Empty : dataReader["Name"].ToString();

					dtos.Add(dto1);
				}
            }
			
            return dtos;
        }
		
		
		
		
		/// <summary>
        /// Gets the List of FacilityLanguages
        /// </summary>
		/// <param name="id">The key to delete the record</param>
        /// <returns>The FacilityLanguages</returns>
        public FacilityLanguages SelectById(string id)
        {
            FacilityLanguages dto1 = new FacilityLanguages();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_SELECTBYID_FacilityLanguages", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;

				
				var dataReader = cmd.ExecuteReader();
				while (dataReader.Read())
				{
					dto1.Id = (dataReader["Id"] == System.DBNull.Value) ? string.Empty : dataReader["Id"].ToString();
dto1.FacilityId = (dataReader["FacilityId"] == System.DBNull.Value) ? string.Empty : dataReader["FacilityId"].ToString();
dto1.LanguageId = (dataReader["LanguageId"] == System.DBNull.Value) ? string.Empty : dataReader["LanguageId"].ToString();
dto1.Name = (dataReader["Name"] == System.DBNull.Value) ? string.Empty : dataReader["Name"].ToString();

				}
            }
			
            return dto1;
        }
    }
}
