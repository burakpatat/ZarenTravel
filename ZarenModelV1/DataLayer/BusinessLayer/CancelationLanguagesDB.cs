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
    public class CancelationLanguagesDB
    {
        private string connectionString = "";
		
        /// <summary>
        /// The constructor for CancelationLanguagesDB
        /// </summary>
        /// <param name="connectionString">The database connection string</param>
        public CancelationLanguagesDB(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Inserts the given object
        /// </summary>
        /// <param name="dto">The object to be inserted</param>
        public void Insert(CancelationLanguages dto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_INSERT_CancelationLanguages", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = dto.Id;
cmd.Parameters.Add("@CancelationRulesId", SqlDbType.VarChar).Value = dto.CancelationRulesId;
cmd.Parameters.Add("@LanguageId", SqlDbType.VarChar).Value = dto.LanguageId;
cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = dto.Name;
cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = dto.Description;


                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Updates the specified record.
        /// </summary>
        /// <param name="dto">The object to be modified</param>
        public void Update(CancelationLanguages dto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_UPDATE_CancelationLanguages", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = dto.Id;
cmd.Parameters.Add("@CancelationRulesId", SqlDbType.VarChar).Value = dto.CancelationRulesId;
cmd.Parameters.Add("@LanguageId", SqlDbType.VarChar).Value = dto.LanguageId;
cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = dto.Name;
cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = dto.Description;


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
                SqlCommand cmd = new SqlCommand("AG_DELETE_CancelationLanguages", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;


                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Gets the List of CancelationLanguages
        /// </summary>
        /// <returns>The List of CancelationLanguages</returns>
        public List<CancelationLanguages> Select()
        {
            List<CancelationLanguages> dtos = new List<CancelationLanguages>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_SELECT_CancelationLanguages", conn);
                cmd.CommandType = CommandType.StoredProcedure;

				var dataReader = cmd.ExecuteReader();
				while (dataReader.Read())
				{
					CancelationLanguages dto1 = new CancelationLanguages();
					dto1.Id = (dataReader["Id"] == System.DBNull.Value) ? string.Empty : dataReader["Id"].ToString();
dto1.CancelationRulesId = (dataReader["CancelationRulesId"] == System.DBNull.Value) ? string.Empty : dataReader["CancelationRulesId"].ToString();
dto1.LanguageId = (dataReader["LanguageId"] == System.DBNull.Value) ? string.Empty : dataReader["LanguageId"].ToString();
dto1.Name = (dataReader["Name"] == System.DBNull.Value) ? string.Empty : dataReader["Name"].ToString();
dto1.Description = (dataReader["Description"] == System.DBNull.Value) ? string.Empty : dataReader["Description"].ToString();

					dtos.Add(dto1);
				}
            }
			
            return dtos;
        }
		
		
		
		
		/// <summary>
        /// Gets the List of CancelationLanguages
        /// </summary>
		/// <param name="id">The key to delete the record</param>
        /// <returns>The CancelationLanguages</returns>
        public CancelationLanguages SelectById(string id)
        {
            CancelationLanguages dto1 = new CancelationLanguages();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_SELECTBYID_CancelationLanguages", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;

				
				var dataReader = cmd.ExecuteReader();
				while (dataReader.Read())
				{
					dto1.Id = (dataReader["Id"] == System.DBNull.Value) ? string.Empty : dataReader["Id"].ToString();
dto1.CancelationRulesId = (dataReader["CancelationRulesId"] == System.DBNull.Value) ? string.Empty : dataReader["CancelationRulesId"].ToString();
dto1.LanguageId = (dataReader["LanguageId"] == System.DBNull.Value) ? string.Empty : dataReader["LanguageId"].ToString();
dto1.Name = (dataReader["Name"] == System.DBNull.Value) ? string.Empty : dataReader["Name"].ToString();
dto1.Description = (dataReader["Description"] == System.DBNull.Value) ? string.Empty : dataReader["Description"].ToString();

				}
            }
			
            return dto1;
        }
    }
}
