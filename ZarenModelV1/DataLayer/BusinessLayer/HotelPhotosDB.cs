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
    public class HotelPhotosDB
    {
        private string connectionString = "";
		
        /// <summary>
        /// The constructor for HotelPhotosDB
        /// </summary>
        /// <param name="connectionString">The database connection string</param>
        public HotelPhotosDB(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Inserts the given object
        /// </summary>
        /// <param name="dto">The object to be inserted</param>
        public void Insert(HotelPhotos dto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_INSERT_HotelPhotos", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = dto.Id;
cmd.Parameters.Add("@HotelId", SqlDbType.VarChar).Value = dto.HotelId;
cmd.Parameters.Add("@HotelRoomId", SqlDbType.VarChar).Value = dto.HotelRoomId;
cmd.Parameters.Add("@Path", SqlDbType.VarChar).Value = dto.Path;
cmd.Parameters.Add("@Order", SqlDbType.VarChar).Value = dto.Order;


                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Updates the specified record.
        /// </summary>
        /// <param name="dto">The object to be modified</param>
        public void Update(HotelPhotos dto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_UPDATE_HotelPhotos", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = dto.Id;
cmd.Parameters.Add("@HotelId", SqlDbType.VarChar).Value = dto.HotelId;
cmd.Parameters.Add("@HotelRoomId", SqlDbType.VarChar).Value = dto.HotelRoomId;
cmd.Parameters.Add("@Path", SqlDbType.VarChar).Value = dto.Path;
cmd.Parameters.Add("@Order", SqlDbType.VarChar).Value = dto.Order;


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
                SqlCommand cmd = new SqlCommand("AG_DELETE_HotelPhotos", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;


                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Gets the List of HotelPhotos
        /// </summary>
        /// <returns>The List of HotelPhotos</returns>
        public List<HotelPhotos> Select()
        {
            List<HotelPhotos> dtos = new List<HotelPhotos>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_SELECT_HotelPhotos", conn);
                cmd.CommandType = CommandType.StoredProcedure;

				var dataReader = cmd.ExecuteReader();
				while (dataReader.Read())
				{
					HotelPhotos dto1 = new HotelPhotos();
					dto1.Id = (dataReader["Id"] == System.DBNull.Value) ? string.Empty : dataReader["Id"].ToString();
dto1.HotelId = (dataReader["HotelId"] == System.DBNull.Value) ? string.Empty : dataReader["HotelId"].ToString();
dto1.HotelRoomId = (dataReader["HotelRoomId"] == System.DBNull.Value) ? string.Empty : dataReader["HotelRoomId"].ToString();
dto1.Path = (dataReader["Path"] == System.DBNull.Value) ? string.Empty : dataReader["Path"].ToString();
dto1.Order = (dataReader["Order"] == System.DBNull.Value) ? string.Empty : dataReader["Order"].ToString();

					dtos.Add(dto1);
				}
            }
			
            return dtos;
        }
		
		
		
		
		/// <summary>
        /// Gets the List of HotelPhotos
        /// </summary>
		/// <param name="id">The key to delete the record</param>
        /// <returns>The HotelPhotos</returns>
        public HotelPhotos SelectById(string id)
        {
            HotelPhotos dto1 = new HotelPhotos();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_SELECTBYID_HotelPhotos", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;

				
				var dataReader = cmd.ExecuteReader();
				while (dataReader.Read())
				{
					dto1.Id = (dataReader["Id"] == System.DBNull.Value) ? string.Empty : dataReader["Id"].ToString();
dto1.HotelId = (dataReader["HotelId"] == System.DBNull.Value) ? string.Empty : dataReader["HotelId"].ToString();
dto1.HotelRoomId = (dataReader["HotelRoomId"] == System.DBNull.Value) ? string.Empty : dataReader["HotelRoomId"].ToString();
dto1.Path = (dataReader["Path"] == System.DBNull.Value) ? string.Empty : dataReader["Path"].ToString();
dto1.Order = (dataReader["Order"] == System.DBNull.Value) ? string.Empty : dataReader["Order"].ToString();

				}
            }
			
            return dto1;
        }
    }
}
