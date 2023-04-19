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
    public class BoardTypeLanguagesDB
    {
        private string connectionString = "";
		
        /// <summary>
        /// The constructor for BoardTypeLanguagesDB
        /// </summary>
        /// <param name="connectionString">The database connection string</param>
        public BoardTypeLanguagesDB(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Inserts the given object
        /// </summary>
        /// <param name="dto">The object to be inserted</param>
        public void Insert(BoardTypeLanguages dto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_INSERT_BoardTypeLanguages", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = dto.Id;
cmd.Parameters.Add("@LanguageId", SqlDbType.VarChar).Value = dto.LanguageId;
cmd.Parameters.Add("@BoardTypeId", SqlDbType.VarChar).Value = dto.BoardTypeId;
cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = dto.Name;


                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Updates the specified record.
        /// </summary>
        /// <param name="dto">The object to be modified</param>
        public void Update(BoardTypeLanguages dto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_UPDATE_BoardTypeLanguages", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = dto.Id;
cmd.Parameters.Add("@LanguageId", SqlDbType.VarChar).Value = dto.LanguageId;
cmd.Parameters.Add("@BoardTypeId", SqlDbType.VarChar).Value = dto.BoardTypeId;
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
                SqlCommand cmd = new SqlCommand("AG_DELETE_BoardTypeLanguages", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;


                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Gets the List of BoardTypeLanguages
        /// </summary>
        /// <returns>The List of BoardTypeLanguages</returns>
        public List<BoardTypeLanguages> Select()
        {
            List<BoardTypeLanguages> dtos = new List<BoardTypeLanguages>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_SELECT_BoardTypeLanguages", conn);
                cmd.CommandType = CommandType.StoredProcedure;

				var dataReader = cmd.ExecuteReader();
				while (dataReader.Read())
				{
					BoardTypeLanguages dto1 = new BoardTypeLanguages();
					dto1.Id = (dataReader["Id"] == System.DBNull.Value) ? string.Empty : dataReader["Id"].ToString();
dto1.LanguageId = (dataReader["LanguageId"] == System.DBNull.Value) ? string.Empty : dataReader["LanguageId"].ToString();
dto1.BoardTypeId = (dataReader["BoardTypeId"] == System.DBNull.Value) ? string.Empty : dataReader["BoardTypeId"].ToString();
dto1.Name = (dataReader["Name"] == System.DBNull.Value) ? string.Empty : dataReader["Name"].ToString();

					dtos.Add(dto1);
				}
            }
			
            return dtos;
        }
		
		
		
		
		/// <summary>
        /// Gets the List of BoardTypeLanguages
        /// </summary>
		/// <param name="id">The key to delete the record</param>
        /// <returns>The BoardTypeLanguages</returns>
        public BoardTypeLanguages SelectById(string id)
        {
            BoardTypeLanguages dto1 = new BoardTypeLanguages();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_SELECTBYID_BoardTypeLanguages", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;

				
				var dataReader = cmd.ExecuteReader();
				while (dataReader.Read())
				{
					dto1.Id = (dataReader["Id"] == System.DBNull.Value) ? string.Empty : dataReader["Id"].ToString();
dto1.LanguageId = (dataReader["LanguageId"] == System.DBNull.Value) ? string.Empty : dataReader["LanguageId"].ToString();
dto1.BoardTypeId = (dataReader["BoardTypeId"] == System.DBNull.Value) ? string.Empty : dataReader["BoardTypeId"].ToString();
dto1.Name = (dataReader["Name"] == System.DBNull.Value) ? string.Empty : dataReader["Name"].ToString();

				}
            }
			
            return dto1;
        }
    }
}
