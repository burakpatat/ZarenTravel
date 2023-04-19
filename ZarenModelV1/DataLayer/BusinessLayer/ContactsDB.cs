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
    public class ContactsDB
    {
        private string connectionString = "";
		
        /// <summary>
        /// The constructor for ContactsDB
        /// </summary>
        /// <param name="connectionString">The database connection string</param>
        public ContactsDB(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Inserts the given object
        /// </summary>
        /// <param name="dto">The object to be inserted</param>
        public void Insert(Contacts dto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_INSERT_Contacts", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = dto.Id;
cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = dto.Name;
cmd.Parameters.Add("@TelNumber", SqlDbType.VarChar).Value = dto.TelNumber;
cmd.Parameters.Add("@FaxNumber", SqlDbType.VarChar).Value = dto.FaxNumber;
cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = dto.Email;


                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Updates the specified record.
        /// </summary>
        /// <param name="dto">The object to be modified</param>
        public void Update(Contacts dto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_UPDATE_Contacts", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = dto.Id;
cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = dto.Name;
cmd.Parameters.Add("@TelNumber", SqlDbType.VarChar).Value = dto.TelNumber;
cmd.Parameters.Add("@FaxNumber", SqlDbType.VarChar).Value = dto.FaxNumber;
cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = dto.Email;


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
                SqlCommand cmd = new SqlCommand("AG_DELETE_Contacts", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;


                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Gets the List of Contacts
        /// </summary>
        /// <returns>The List of Contacts</returns>
        public List<Contacts> Select()
        {
            List<Contacts> dtos = new List<Contacts>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_SELECT_Contacts", conn);
                cmd.CommandType = CommandType.StoredProcedure;

				var dataReader = cmd.ExecuteReader();
				while (dataReader.Read())
				{
					Contacts dto1 = new Contacts();
					dto1.Id = (dataReader["Id"] == System.DBNull.Value) ? string.Empty : dataReader["Id"].ToString();
dto1.Name = (dataReader["Name"] == System.DBNull.Value) ? string.Empty : dataReader["Name"].ToString();
dto1.TelNumber = (dataReader["TelNumber"] == System.DBNull.Value) ? string.Empty : dataReader["TelNumber"].ToString();
dto1.FaxNumber = (dataReader["FaxNumber"] == System.DBNull.Value) ? string.Empty : dataReader["FaxNumber"].ToString();
dto1.Email = (dataReader["Email"] == System.DBNull.Value) ? string.Empty : dataReader["Email"].ToString();

					dtos.Add(dto1);
				}
            }
			
            return dtos;
        }
		
		
		
		
		/// <summary>
        /// Gets the List of Contacts
        /// </summary>
		/// <param name="id">The key to delete the record</param>
        /// <returns>The Contacts</returns>
        public Contacts SelectById(string id)
        {
            Contacts dto1 = new Contacts();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_SELECTBYID_Contacts", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;

				
				var dataReader = cmd.ExecuteReader();
				while (dataReader.Read())
				{
					dto1.Id = (dataReader["Id"] == System.DBNull.Value) ? string.Empty : dataReader["Id"].ToString();
dto1.Name = (dataReader["Name"] == System.DBNull.Value) ? string.Empty : dataReader["Name"].ToString();
dto1.TelNumber = (dataReader["TelNumber"] == System.DBNull.Value) ? string.Empty : dataReader["TelNumber"].ToString();
dto1.FaxNumber = (dataReader["FaxNumber"] == System.DBNull.Value) ? string.Empty : dataReader["FaxNumber"].ToString();
dto1.Email = (dataReader["Email"] == System.DBNull.Value) ? string.Empty : dataReader["Email"].ToString();

				}
            }
			
            return dto1;
        }
    }
}
