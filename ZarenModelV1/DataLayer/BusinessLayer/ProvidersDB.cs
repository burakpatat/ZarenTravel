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
    public class ProvidersDB
    {
        private string connectionString = "";
		
        /// <summary>
        /// The constructor for ProvidersDB
        /// </summary>
        /// <param name="connectionString">The database connection string</param>
        public ProvidersDB(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Inserts the given object
        /// </summary>
        /// <param name="dto">The object to be inserted</param>
        public void Insert(Providers dto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_INSERT_Providers", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = dto.Id;
cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = dto.Name;
cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = dto.Address;
cmd.Parameters.Add("@Website", SqlDbType.VarChar).Value = dto.Website;
cmd.Parameters.Add("@ComercialContactId", SqlDbType.VarChar).Value = dto.ComercialContactId;
cmd.Parameters.Add("@ReservationContactId", SqlDbType.VarChar).Value = dto.ReservationContactId;
cmd.Parameters.Add("@FinanceContactId", SqlDbType.VarChar).Value = dto.FinanceContactId;


                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Updates the specified record.
        /// </summary>
        /// <param name="dto">The object to be modified</param>
        public void Update(Providers dto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_UPDATE_Providers", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = dto.Id;
cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = dto.Name;
cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = dto.Address;
cmd.Parameters.Add("@Website", SqlDbType.VarChar).Value = dto.Website;
cmd.Parameters.Add("@ComercialContactId", SqlDbType.VarChar).Value = dto.ComercialContactId;
cmd.Parameters.Add("@ReservationContactId", SqlDbType.VarChar).Value = dto.ReservationContactId;
cmd.Parameters.Add("@FinanceContactId", SqlDbType.VarChar).Value = dto.FinanceContactId;


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
                SqlCommand cmd = new SqlCommand("AG_DELETE_Providers", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;


                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Gets the List of Providers
        /// </summary>
        /// <returns>The List of Providers</returns>
        public List<Providers> Select()
        {
            List<Providers> dtos = new List<Providers>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_SELECT_Providers", conn);
                cmd.CommandType = CommandType.StoredProcedure;

				var dataReader = cmd.ExecuteReader();
				while (dataReader.Read())
				{
					Providers dto1 = new Providers();
					dto1.Id = (dataReader["Id"] == System.DBNull.Value) ? string.Empty : dataReader["Id"].ToString();
dto1.Name = (dataReader["Name"] == System.DBNull.Value) ? string.Empty : dataReader["Name"].ToString();
dto1.Address = (dataReader["Address"] == System.DBNull.Value) ? string.Empty : dataReader["Address"].ToString();
dto1.Website = (dataReader["Website"] == System.DBNull.Value) ? string.Empty : dataReader["Website"].ToString();
dto1.ComercialContactId = (dataReader["ComercialContactId"] == System.DBNull.Value) ? string.Empty : dataReader["ComercialContactId"].ToString();
dto1.ReservationContactId = (dataReader["ReservationContactId"] == System.DBNull.Value) ? string.Empty : dataReader["ReservationContactId"].ToString();
dto1.FinanceContactId = (dataReader["FinanceContactId"] == System.DBNull.Value) ? string.Empty : dataReader["FinanceContactId"].ToString();

					dtos.Add(dto1);
				}
            }
			
            return dtos;
        }
		
		
		
		
		/// <summary>
        /// Gets the List of Providers
        /// </summary>
		/// <param name="id">The key to delete the record</param>
        /// <returns>The Providers</returns>
        public Providers SelectById(string id)
        {
            Providers dto1 = new Providers();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_SELECTBYID_Providers", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;

				
				var dataReader = cmd.ExecuteReader();
				while (dataReader.Read())
				{
					dto1.Id = (dataReader["Id"] == System.DBNull.Value) ? string.Empty : dataReader["Id"].ToString();
dto1.Name = (dataReader["Name"] == System.DBNull.Value) ? string.Empty : dataReader["Name"].ToString();
dto1.Address = (dataReader["Address"] == System.DBNull.Value) ? string.Empty : dataReader["Address"].ToString();
dto1.Website = (dataReader["Website"] == System.DBNull.Value) ? string.Empty : dataReader["Website"].ToString();
dto1.ComercialContactId = (dataReader["ComercialContactId"] == System.DBNull.Value) ? string.Empty : dataReader["ComercialContactId"].ToString();
dto1.ReservationContactId = (dataReader["ReservationContactId"] == System.DBNull.Value) ? string.Empty : dataReader["ReservationContactId"].ToString();
dto1.FinanceContactId = (dataReader["FinanceContactId"] == System.DBNull.Value) ? string.Empty : dataReader["FinanceContactId"].ToString();

				}
            }
			
            return dto1;
        }
    }
}
