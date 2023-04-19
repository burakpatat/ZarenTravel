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
    public class CancellationRulesDB
    {
        private string connectionString = "";
		
        /// <summary>
        /// The constructor for CancellationRulesDB
        /// </summary>
        /// <param name="connectionString">The database connection string</param>
        public CancellationRulesDB(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Inserts the given object
        /// </summary>
        /// <param name="dto">The object to be inserted</param>
        public void Insert(CancellationRules dto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_INSERT_CancellationRules", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = dto.Id;
cmd.Parameters.Add("@CancellationSeasonId", SqlDbType.VarChar).Value = dto.CancellationSeasonId;
cmd.Parameters.Add("@Cost", SqlDbType.VarChar).Value = dto.Cost;
cmd.Parameters.Add("@CostType", SqlDbType.VarChar).Value = dto.CostType;
cmd.Parameters.Add("@FromDays", SqlDbType.VarChar).Value = dto.FromDays;
cmd.Parameters.Add("@ToDays", SqlDbType.VarChar).Value = dto.ToDays;


                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Updates the specified record.
        /// </summary>
        /// <param name="dto">The object to be modified</param>
        public void Update(CancellationRules dto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_UPDATE_CancellationRules", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = dto.Id;
cmd.Parameters.Add("@CancellationSeasonId", SqlDbType.VarChar).Value = dto.CancellationSeasonId;
cmd.Parameters.Add("@Cost", SqlDbType.VarChar).Value = dto.Cost;
cmd.Parameters.Add("@CostType", SqlDbType.VarChar).Value = dto.CostType;
cmd.Parameters.Add("@FromDays", SqlDbType.VarChar).Value = dto.FromDays;
cmd.Parameters.Add("@ToDays", SqlDbType.VarChar).Value = dto.ToDays;


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
                SqlCommand cmd = new SqlCommand("AG_DELETE_CancellationRules", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;


                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Gets the List of CancellationRules
        /// </summary>
        /// <returns>The List of CancellationRules</returns>
        public List<CancellationRules> Select()
        {
            List<CancellationRules> dtos = new List<CancellationRules>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_SELECT_CancellationRules", conn);
                cmd.CommandType = CommandType.StoredProcedure;

				var dataReader = cmd.ExecuteReader();
				while (dataReader.Read())
				{
					CancellationRules dto1 = new CancellationRules();
					dto1.Id = (dataReader["Id"] == System.DBNull.Value) ? string.Empty : dataReader["Id"].ToString();
dto1.CancellationSeasonId = (dataReader["CancellationSeasonId"] == System.DBNull.Value) ? string.Empty : dataReader["CancellationSeasonId"].ToString();
dto1.Cost = (dataReader["Cost"] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dataReader["Cost"].ToString());
dto1.CostType = (dataReader["CostType"] == System.DBNull.Value) ? string.Empty : dataReader["CostType"].ToString();
dto1.FromDays = (dataReader["FromDays"] == System.DBNull.Value) ? string.Empty : dataReader["FromDays"].ToString();
dto1.ToDays = (dataReader["ToDays"] == System.DBNull.Value) ? string.Empty : dataReader["ToDays"].ToString();

					dtos.Add(dto1);
				}
            }
			
            return dtos;
        }
		
		
		
		
		/// <summary>
        /// Gets the List of CancellationRules
        /// </summary>
		/// <param name="id">The key to delete the record</param>
        /// <returns>The CancellationRules</returns>
        public CancellationRules SelectById(string id)
        {
            CancellationRules dto1 = new CancellationRules();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_SELECTBYID_CancellationRules", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;

				
				var dataReader = cmd.ExecuteReader();
				while (dataReader.Read())
				{
					dto1.Id = (dataReader["Id"] == System.DBNull.Value) ? string.Empty : dataReader["Id"].ToString();
dto1.CancellationSeasonId = (dataReader["CancellationSeasonId"] == System.DBNull.Value) ? string.Empty : dataReader["CancellationSeasonId"].ToString();
dto1.Cost = (dataReader["Cost"] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dataReader["Cost"].ToString());
dto1.CostType = (dataReader["CostType"] == System.DBNull.Value) ? string.Empty : dataReader["CostType"].ToString();
dto1.FromDays = (dataReader["FromDays"] == System.DBNull.Value) ? string.Empty : dataReader["FromDays"].ToString();
dto1.ToDays = (dataReader["ToDays"] == System.DBNull.Value) ? string.Empty : dataReader["ToDays"].ToString();

				}
            }
			
            return dto1;
        }
    }
}
