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
    public class AgenciesDB
    {
        private string connectionString = "";
		
        /// <summary>
        /// The constructor for AgenciesDB
        /// </summary>
        /// <param name="connectionString">The database connection string</param>
        public AgenciesDB(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Inserts the given object
        /// </summary>
        /// <param name="dto">The object to be inserted</param>
        public void Insert(Agencies dto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_INSERT_Agencies", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = dto.Id;
cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = dto.Name;
cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = dto.Address;
cmd.Parameters.Add("@PaymentPolitics", SqlDbType.VarChar).Value = dto.PaymentPolitics;
cmd.Parameters.Add("@MarkUp", SqlDbType.VarChar).Value = dto.MarkUp;
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
        public void Update(Agencies dto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_UPDATE_Agencies", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = dto.Id;
cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = dto.Name;
cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = dto.Address;
cmd.Parameters.Add("@PaymentPolitics", SqlDbType.VarChar).Value = dto.PaymentPolitics;
cmd.Parameters.Add("@MarkUp", SqlDbType.VarChar).Value = dto.MarkUp;
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
                SqlCommand cmd = new SqlCommand("AG_DELETE_Agencies", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;


                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Gets the List of Agencies
        /// </summary>
        /// <returns>The List of Agencies</returns>
        public List<Agencies> Select()
        {
            List<Agencies> dtos = new List<Agencies>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_SELECT_Agencies", conn);
                cmd.CommandType = CommandType.StoredProcedure;

				var dataReader = cmd.ExecuteReader();
				while (dataReader.Read())
				{
					Agencies dto1 = new Agencies();
					dto1.Id = (dataReader["Id"] == System.DBNull.Value) ? string.Empty : dataReader["Id"].ToString();
dto1.Name = (dataReader["Name"] == System.DBNull.Value) ? string.Empty : dataReader["Name"].ToString();
dto1.Address = (dataReader["Address"] == System.DBNull.Value) ? string.Empty : dataReader["Address"].ToString();
dto1.PaymentPolitics = (dataReader["PaymentPolitics"] == System.DBNull.Value) ? string.Empty : dataReader["PaymentPolitics"].ToString();
dto1.MarkUp = (dataReader["MarkUp"] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dataReader["MarkUp"].ToString());
dto1.ComercialContactId = (dataReader["ComercialContactId"] == System.DBNull.Value) ? string.Empty : dataReader["ComercialContactId"].ToString();
dto1.ReservationContactId = (dataReader["ReservationContactId"] == System.DBNull.Value) ? string.Empty : dataReader["ReservationContactId"].ToString();
dto1.FinanceContactId = (dataReader["FinanceContactId"] == System.DBNull.Value) ? string.Empty : dataReader["FinanceContactId"].ToString();

					dtos.Add(dto1);
				}
            }
			
            return dtos;
        }
		
		
		
		
		/// <summary>
        /// Gets the List of Agencies
        /// </summary>
		/// <param name="id">The key to delete the record</param>
        /// <returns>The Agencies</returns>
        public Agencies SelectById(string id)
        {
            Agencies dto1 = new Agencies();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_SELECTBYID_Agencies", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;

				
				var dataReader = cmd.ExecuteReader();
				while (dataReader.Read())
				{
					dto1.Id = (dataReader["Id"] == System.DBNull.Value) ? string.Empty : dataReader["Id"].ToString();
dto1.Name = (dataReader["Name"] == System.DBNull.Value) ? string.Empty : dataReader["Name"].ToString();
dto1.Address = (dataReader["Address"] == System.DBNull.Value) ? string.Empty : dataReader["Address"].ToString();
dto1.PaymentPolitics = (dataReader["PaymentPolitics"] == System.DBNull.Value) ? string.Empty : dataReader["PaymentPolitics"].ToString();
dto1.MarkUp = (dataReader["MarkUp"] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dataReader["MarkUp"].ToString());
dto1.ComercialContactId = (dataReader["ComercialContactId"] == System.DBNull.Value) ? string.Empty : dataReader["ComercialContactId"].ToString();
dto1.ReservationContactId = (dataReader["ReservationContactId"] == System.DBNull.Value) ? string.Empty : dataReader["ReservationContactId"].ToString();
dto1.FinanceContactId = (dataReader["FinanceContactId"] == System.DBNull.Value) ? string.Empty : dataReader["FinanceContactId"].ToString();

				}
            }
			
            return dto1;
        }
    }
}
