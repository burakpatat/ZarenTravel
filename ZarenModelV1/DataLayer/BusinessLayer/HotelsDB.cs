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
    public class HotelsDB
    {
        private string connectionString = "";
		
        /// <summary>
        /// The constructor for HotelsDB
        /// </summary>
        /// <param name="connectionString">The database connection string</param>
        public HotelsDB(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Inserts the given object
        /// </summary>
        /// <param name="dto">The object to be inserted</param>
        public void Insert(Hotels dto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_INSERT_Hotels", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = dto.Id;
cmd.Parameters.Add("@HotelChainId", SqlDbType.VarChar).Value = dto.HotelChainId;
cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = dto.Name;
cmd.Parameters.Add("@HotelTypeId", SqlDbType.VarChar).Value = dto.HotelTypeId;
cmd.Parameters.Add("@CountryId", SqlDbType.VarChar).Value = dto.CountryId;
cmd.Parameters.Add("@RegionId", SqlDbType.VarChar).Value = dto.RegionId;
cmd.Parameters.Add("@ZoneId", SqlDbType.VarChar).Value = dto.ZoneId;
cmd.Parameters.Add("@CityId", SqlDbType.VarChar).Value = dto.CityId;
cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = dto.Address;
cmd.Parameters.Add("@ZipCode", SqlDbType.VarChar).Value = dto.ZipCode;
cmd.Parameters.Add("@Latitude", SqlDbType.VarChar).Value = dto.Latitude;
cmd.Parameters.Add("@Longitude", SqlDbType.VarChar).Value = dto.Longitude;
cmd.Parameters.Add("@CommercialContactId", SqlDbType.VarChar).Value = dto.CommercialContactId;
cmd.Parameters.Add("@ReservationContactId", SqlDbType.VarChar).Value = dto.ReservationContactId;
cmd.Parameters.Add("@FinanceContactId", SqlDbType.VarChar).Value = dto.FinanceContactId;
cmd.Parameters.Add("@Release", SqlDbType.VarChar).Value = dto.Release;
cmd.Parameters.Add("@NumberRooms", SqlDbType.VarChar).Value = dto.NumberRooms;


                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Updates the specified record.
        /// </summary>
        /// <param name="dto">The object to be modified</param>
        public void Update(Hotels dto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_UPDATE_Hotels", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = dto.Id;
cmd.Parameters.Add("@HotelChainId", SqlDbType.VarChar).Value = dto.HotelChainId;
cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = dto.Name;
cmd.Parameters.Add("@HotelTypeId", SqlDbType.VarChar).Value = dto.HotelTypeId;
cmd.Parameters.Add("@CountryId", SqlDbType.VarChar).Value = dto.CountryId;
cmd.Parameters.Add("@RegionId", SqlDbType.VarChar).Value = dto.RegionId;
cmd.Parameters.Add("@ZoneId", SqlDbType.VarChar).Value = dto.ZoneId;
cmd.Parameters.Add("@CityId", SqlDbType.VarChar).Value = dto.CityId;
cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = dto.Address;
cmd.Parameters.Add("@ZipCode", SqlDbType.VarChar).Value = dto.ZipCode;
cmd.Parameters.Add("@Latitude", SqlDbType.VarChar).Value = dto.Latitude;
cmd.Parameters.Add("@Longitude", SqlDbType.VarChar).Value = dto.Longitude;
cmd.Parameters.Add("@CommercialContactId", SqlDbType.VarChar).Value = dto.CommercialContactId;
cmd.Parameters.Add("@ReservationContactId", SqlDbType.VarChar).Value = dto.ReservationContactId;
cmd.Parameters.Add("@FinanceContactId", SqlDbType.VarChar).Value = dto.FinanceContactId;
cmd.Parameters.Add("@Release", SqlDbType.VarChar).Value = dto.Release;
cmd.Parameters.Add("@NumberRooms", SqlDbType.VarChar).Value = dto.NumberRooms;


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
                SqlCommand cmd = new SqlCommand("AG_DELETE_Hotels", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;


                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Gets the List of Hotels
        /// </summary>
        /// <returns>The List of Hotels</returns>
        public List<Hotels> Select()
        {
            List<Hotels> dtos = new List<Hotels>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_SELECT_Hotels", conn);
                cmd.CommandType = CommandType.StoredProcedure;

				var dataReader = cmd.ExecuteReader();
				while (dataReader.Read())
				{
					Hotels dto1 = new Hotels();
					dto1.Id = (dataReader["Id"] == System.DBNull.Value) ? string.Empty : dataReader["Id"].ToString();
dto1.HotelChainId = (dataReader["HotelChainId"] == System.DBNull.Value) ? string.Empty : dataReader["HotelChainId"].ToString();
dto1.Name = (dataReader["Name"] == System.DBNull.Value) ? string.Empty : dataReader["Name"].ToString();
dto1.HotelTypeId = (dataReader["HotelTypeId"] == System.DBNull.Value) ? string.Empty : dataReader["HotelTypeId"].ToString();
dto1.CountryId = (dataReader["CountryId"] == System.DBNull.Value) ? string.Empty : dataReader["CountryId"].ToString();
dto1.RegionId = (dataReader["RegionId"] == System.DBNull.Value) ? string.Empty : dataReader["RegionId"].ToString();
dto1.ZoneId = (dataReader["ZoneId"] == System.DBNull.Value) ? string.Empty : dataReader["ZoneId"].ToString();
dto1.CityId = (dataReader["CityId"] == System.DBNull.Value) ? string.Empty : dataReader["CityId"].ToString();
dto1.Address = (dataReader["Address"] == System.DBNull.Value) ? string.Empty : dataReader["Address"].ToString();
dto1.ZipCode = (dataReader["ZipCode"] == System.DBNull.Value) ? string.Empty : dataReader["ZipCode"].ToString();
dto1.Latitude = (dataReader["Latitude"] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dataReader["Latitude"].ToString());
dto1.Longitude = (dataReader["Longitude"] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dataReader["Longitude"].ToString());
dto1.CommercialContactId = (dataReader["CommercialContactId"] == System.DBNull.Value) ? string.Empty : dataReader["CommercialContactId"].ToString();
dto1.ReservationContactId = (dataReader["ReservationContactId"] == System.DBNull.Value) ? string.Empty : dataReader["ReservationContactId"].ToString();
dto1.FinanceContactId = (dataReader["FinanceContactId"] == System.DBNull.Value) ? string.Empty : dataReader["FinanceContactId"].ToString();
dto1.Release = (dataReader["Release"] == System.DBNull.Value) ? string.Empty : dataReader["Release"].ToString();
dto1.NumberRooms = (dataReader["NumberRooms"] == System.DBNull.Value) ? string.Empty : dataReader["NumberRooms"].ToString();

					dtos.Add(dto1);
				}
            }
			
            return dtos;
        }
		
		
		
		
		/// <summary>
        /// Gets the List of Hotels
        /// </summary>
		/// <param name="id">The key to delete the record</param>
        /// <returns>The Hotels</returns>
        public Hotels SelectById(string id)
        {
            Hotels dto1 = new Hotels();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_SELECTBYID_Hotels", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;

				
				var dataReader = cmd.ExecuteReader();
				while (dataReader.Read())
				{
					dto1.Id = (dataReader["Id"] == System.DBNull.Value) ? string.Empty : dataReader["Id"].ToString();
dto1.HotelChainId = (dataReader["HotelChainId"] == System.DBNull.Value) ? string.Empty : dataReader["HotelChainId"].ToString();
dto1.Name = (dataReader["Name"] == System.DBNull.Value) ? string.Empty : dataReader["Name"].ToString();
dto1.HotelTypeId = (dataReader["HotelTypeId"] == System.DBNull.Value) ? string.Empty : dataReader["HotelTypeId"].ToString();
dto1.CountryId = (dataReader["CountryId"] == System.DBNull.Value) ? string.Empty : dataReader["CountryId"].ToString();
dto1.RegionId = (dataReader["RegionId"] == System.DBNull.Value) ? string.Empty : dataReader["RegionId"].ToString();
dto1.ZoneId = (dataReader["ZoneId"] == System.DBNull.Value) ? string.Empty : dataReader["ZoneId"].ToString();
dto1.CityId = (dataReader["CityId"] == System.DBNull.Value) ? string.Empty : dataReader["CityId"].ToString();
dto1.Address = (dataReader["Address"] == System.DBNull.Value) ? string.Empty : dataReader["Address"].ToString();
dto1.ZipCode = (dataReader["ZipCode"] == System.DBNull.Value) ? string.Empty : dataReader["ZipCode"].ToString();
dto1.Latitude = (dataReader["Latitude"] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dataReader["Latitude"].ToString());
dto1.Longitude = (dataReader["Longitude"] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dataReader["Longitude"].ToString());
dto1.CommercialContactId = (dataReader["CommercialContactId"] == System.DBNull.Value) ? string.Empty : dataReader["CommercialContactId"].ToString();
dto1.ReservationContactId = (dataReader["ReservationContactId"] == System.DBNull.Value) ? string.Empty : dataReader["ReservationContactId"].ToString();
dto1.FinanceContactId = (dataReader["FinanceContactId"] == System.DBNull.Value) ? string.Empty : dataReader["FinanceContactId"].ToString();
dto1.Release = (dataReader["Release"] == System.DBNull.Value) ? string.Empty : dataReader["Release"].ToString();
dto1.NumberRooms = (dataReader["NumberRooms"] == System.DBNull.Value) ? string.Empty : dataReader["NumberRooms"].ToString();

				}
            }
			
            return dto1;
        }
    }
}
