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
    public class BuyRoomsDB
    {
        private string connectionString = "";
		
        /// <summary>
        /// The constructor for BuyRoomsDB
        /// </summary>
        /// <param name="connectionString">The database connection string</param>
        public BuyRoomsDB(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Inserts the given object
        /// </summary>
        /// <param name="dto">The object to be inserted</param>
        public void Insert(BuyRooms dto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_INSERT_BuyRooms", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = dto.Id;
cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = dto.Name;
cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = dto.Description;
cmd.Parameters.Add("@MaxAllotment", SqlDbType.VarChar).Value = dto.MaxAllotment;
cmd.Parameters.Add("@MaxAdults", SqlDbType.VarChar).Value = dto.MaxAdults;
cmd.Parameters.Add("@MaxChildren", SqlDbType.VarChar).Value = dto.MaxChildren;
cmd.Parameters.Add("@MaxInfants", SqlDbType.VarChar).Value = dto.MaxInfants;


                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Updates the specified record.
        /// </summary>
        /// <param name="dto">The object to be modified</param>
        public void Update(BuyRooms dto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_UPDATE_BuyRooms", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = dto.Id;
cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = dto.Name;
cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = dto.Description;
cmd.Parameters.Add("@MaxAllotment", SqlDbType.VarChar).Value = dto.MaxAllotment;
cmd.Parameters.Add("@MaxAdults", SqlDbType.VarChar).Value = dto.MaxAdults;
cmd.Parameters.Add("@MaxChildren", SqlDbType.VarChar).Value = dto.MaxChildren;
cmd.Parameters.Add("@MaxInfants", SqlDbType.VarChar).Value = dto.MaxInfants;


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
                SqlCommand cmd = new SqlCommand("AG_DELETE_BuyRooms", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;


                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Gets the List of BuyRooms
        /// </summary>
        /// <returns>The List of BuyRooms</returns>
        public List<BuyRooms> Select()
        {
            List<BuyRooms> dtos = new List<BuyRooms>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_SELECT_BuyRooms", conn);
                cmd.CommandType = CommandType.StoredProcedure;

				var dataReader = cmd.ExecuteReader();
				while (dataReader.Read())
				{
					BuyRooms dto1 = new BuyRooms();
					dto1.Id = (dataReader["Id"] == System.DBNull.Value) ? string.Empty : dataReader["Id"].ToString();
dto1.Name = (dataReader["Name"] == System.DBNull.Value) ? string.Empty : dataReader["Name"].ToString();
dto1.Description = (dataReader["Description"] == System.DBNull.Value) ? string.Empty : dataReader["Description"].ToString();
dto1.MaxAllotment = (dataReader["MaxAllotment"] == System.DBNull.Value) ? string.Empty : dataReader["MaxAllotment"].ToString();
dto1.MaxAdults = (dataReader["MaxAdults"] == System.DBNull.Value) ? string.Empty : dataReader["MaxAdults"].ToString();
dto1.MaxChildren = (dataReader["MaxChildren"] == System.DBNull.Value) ? string.Empty : dataReader["MaxChildren"].ToString();
dto1.MaxInfants = (dataReader["MaxInfants"] == System.DBNull.Value) ? string.Empty : dataReader["MaxInfants"].ToString();

					dtos.Add(dto1);
				}
            }
			
            return dtos;
        }
		
		
		
		
		/// <summary>
        /// Gets the List of BuyRooms
        /// </summary>
		/// <param name="id">The key to delete the record</param>
        /// <returns>The BuyRooms</returns>
        public BuyRooms SelectById(string id)
        {
            BuyRooms dto1 = new BuyRooms();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_SELECTBYID_BuyRooms", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;

				
				var dataReader = cmd.ExecuteReader();
				while (dataReader.Read())
				{
					dto1.Id = (dataReader["Id"] == System.DBNull.Value) ? string.Empty : dataReader["Id"].ToString();
dto1.Name = (dataReader["Name"] == System.DBNull.Value) ? string.Empty : dataReader["Name"].ToString();
dto1.Description = (dataReader["Description"] == System.DBNull.Value) ? string.Empty : dataReader["Description"].ToString();
dto1.MaxAllotment = (dataReader["MaxAllotment"] == System.DBNull.Value) ? string.Empty : dataReader["MaxAllotment"].ToString();
dto1.MaxAdults = (dataReader["MaxAdults"] == System.DBNull.Value) ? string.Empty : dataReader["MaxAdults"].ToString();
dto1.MaxChildren = (dataReader["MaxChildren"] == System.DBNull.Value) ? string.Empty : dataReader["MaxChildren"].ToString();
dto1.MaxInfants = (dataReader["MaxInfants"] == System.DBNull.Value) ? string.Empty : dataReader["MaxInfants"].ToString();

				}
            }
			
            return dto1;
        }
    }
}
