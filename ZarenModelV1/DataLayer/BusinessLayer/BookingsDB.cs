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
    public class BookingsDB
    {
        private string connectionString = "";
		
        /// <summary>
        /// The constructor for BookingsDB
        /// </summary>
        /// <param name="connectionString">The database connection string</param>
        public BookingsDB(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Inserts the given object
        /// </summary>
        /// <param name="dto">The object to be inserted</param>
        public void Insert(Bookings dto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_INSERT_Bookings", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = dto.Id;
cmd.Parameters.Add("@HotelId", SqlDbType.VarChar).Value = dto.HotelId;
cmd.Parameters.Add("@ProviderId", SqlDbType.VarChar).Value = dto.ProviderId;
cmd.Parameters.Add("@AgencyId", SqlDbType.VarChar).Value = dto.AgencyId;
cmd.Parameters.Add("@Reference", SqlDbType.VarChar).Value = dto.Reference;
cmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = dto.FromDate;
cmd.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = dto.ToDate;
cmd.Parameters.Add("@DateBooked", SqlDbType.DateTime).Value = dto.DateBooked;
cmd.Parameters.Add("@Nights", SqlDbType.VarChar).Value = dto.Nights;
cmd.Parameters.Add("@NumRooms", SqlDbType.VarChar).Value = dto.NumRooms;
cmd.Parameters.Add("@TotalCost", SqlDbType.VarChar).Value = dto.TotalCost;
cmd.Parameters.Add("@TotalPrice", SqlDbType.VarChar).Value = dto.TotalPrice;
cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = dto.Status;
cmd.Parameters.Add("@PaidStatus", SqlDbType.VarChar).Value = dto.PaidStatus;
cmd.Parameters.Add("@ClientTitle", SqlDbType.VarChar).Value = dto.ClientTitle;
cmd.Parameters.Add("@ClientName", SqlDbType.VarChar).Value = dto.ClientName;
cmd.Parameters.Add("@ClientSurname", SqlDbType.VarChar).Value = dto.ClientSurname;
cmd.Parameters.Add("@ClientEmail", SqlDbType.VarChar).Value = dto.ClientEmail;
cmd.Parameters.Add("@ClientNotes", SqlDbType.VarChar).Value = dto.ClientNotes;
cmd.Parameters.Add("@Client address", SqlDbType.VarChar).Value = dto.Clientaddress;
cmd.Parameters.Add("@ClientContact", SqlDbType.VarChar).Value = dto.ClientContact;
cmd.Parameters.Add("@Adults", SqlDbType.VarChar).Value = dto.Adults;
cmd.Parameters.Add("@Children", SqlDbType.VarChar).Value = dto.Children;
cmd.Parameters.Add("@Infants", SqlDbType.VarChar).Value = dto.Infants;
cmd.Parameters.Add("@ChildrenAges", SqlDbType.VarChar).Value = dto.ChildrenAges;


                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Updates the specified record.
        /// </summary>
        /// <param name="dto">The object to be modified</param>
        public void Update(Bookings dto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_UPDATE_Bookings", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = dto.Id;
cmd.Parameters.Add("@HotelId", SqlDbType.VarChar).Value = dto.HotelId;
cmd.Parameters.Add("@ProviderId", SqlDbType.VarChar).Value = dto.ProviderId;
cmd.Parameters.Add("@AgencyId", SqlDbType.VarChar).Value = dto.AgencyId;
cmd.Parameters.Add("@Reference", SqlDbType.VarChar).Value = dto.Reference;
cmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = dto.FromDate;
cmd.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = dto.ToDate;
cmd.Parameters.Add("@DateBooked", SqlDbType.DateTime).Value = dto.DateBooked;
cmd.Parameters.Add("@Nights", SqlDbType.VarChar).Value = dto.Nights;
cmd.Parameters.Add("@NumRooms", SqlDbType.VarChar).Value = dto.NumRooms;
cmd.Parameters.Add("@TotalCost", SqlDbType.VarChar).Value = dto.TotalCost;
cmd.Parameters.Add("@TotalPrice", SqlDbType.VarChar).Value = dto.TotalPrice;
cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = dto.Status;
cmd.Parameters.Add("@PaidStatus", SqlDbType.VarChar).Value = dto.PaidStatus;
cmd.Parameters.Add("@ClientTitle", SqlDbType.VarChar).Value = dto.ClientTitle;
cmd.Parameters.Add("@ClientName", SqlDbType.VarChar).Value = dto.ClientName;
cmd.Parameters.Add("@ClientSurname", SqlDbType.VarChar).Value = dto.ClientSurname;
cmd.Parameters.Add("@ClientEmail", SqlDbType.VarChar).Value = dto.ClientEmail;
cmd.Parameters.Add("@ClientNotes", SqlDbType.VarChar).Value = dto.ClientNotes;
cmd.Parameters.Add("@Client address", SqlDbType.VarChar).Value = dto.Clientaddress;
cmd.Parameters.Add("@ClientContact", SqlDbType.VarChar).Value = dto.ClientContact;
cmd.Parameters.Add("@Adults", SqlDbType.VarChar).Value = dto.Adults;
cmd.Parameters.Add("@Children", SqlDbType.VarChar).Value = dto.Children;
cmd.Parameters.Add("@Infants", SqlDbType.VarChar).Value = dto.Infants;
cmd.Parameters.Add("@ChildrenAges", SqlDbType.VarChar).Value = dto.ChildrenAges;


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
                SqlCommand cmd = new SqlCommand("AG_DELETE_Bookings", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;


                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Gets the List of Bookings
        /// </summary>
        /// <returns>The List of Bookings</returns>
        public List<Bookings> Select()
        {
            List<Bookings> dtos = new List<Bookings>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_SELECT_Bookings", conn);
                cmd.CommandType = CommandType.StoredProcedure;

				var dataReader = cmd.ExecuteReader();
				while (dataReader.Read())
				{
					Bookings dto1 = new Bookings();
					dto1.Id = (dataReader["Id"] == System.DBNull.Value) ? string.Empty : dataReader["Id"].ToString();
dto1.HotelId = (dataReader["HotelId"] == System.DBNull.Value) ? string.Empty : dataReader["HotelId"].ToString();
dto1.ProviderId = (dataReader["ProviderId"] == System.DBNull.Value) ? string.Empty : dataReader["ProviderId"].ToString();
dto1.AgencyId = (dataReader["AgencyId"] == System.DBNull.Value) ? string.Empty : dataReader["AgencyId"].ToString();
dto1.Reference = (dataReader["Reference"] == System.DBNull.Value) ? string.Empty : dataReader["Reference"].ToString();
dto1.FromDate = (dataReader["FromDate"] == System.DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dataReader["FromDate"].ToString());
dto1.ToDate = (dataReader["ToDate"] == System.DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dataReader["ToDate"].ToString());
dto1.DateBooked = (dataReader["DateBooked"] == System.DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dataReader["DateBooked"].ToString());
dto1.Nights = (dataReader["Nights"] == System.DBNull.Value) ? string.Empty : dataReader["Nights"].ToString();
dto1.NumRooms = (dataReader["NumRooms"] == System.DBNull.Value) ? string.Empty : dataReader["NumRooms"].ToString();
dto1.TotalCost = (dataReader["TotalCost"] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dataReader["TotalCost"].ToString());
dto1.TotalPrice = (dataReader["TotalPrice"] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dataReader["TotalPrice"].ToString());
dto1.Status = (dataReader["Status"] == System.DBNull.Value) ? string.Empty : dataReader["Status"].ToString();
dto1.PaidStatus = (dataReader["PaidStatus"] == System.DBNull.Value) ? string.Empty : dataReader["PaidStatus"].ToString();
dto1.ClientTitle = (dataReader["ClientTitle"] == System.DBNull.Value) ? string.Empty : dataReader["ClientTitle"].ToString();
dto1.ClientName = (dataReader["ClientName"] == System.DBNull.Value) ? string.Empty : dataReader["ClientName"].ToString();
dto1.ClientSurname = (dataReader["ClientSurname"] == System.DBNull.Value) ? string.Empty : dataReader["ClientSurname"].ToString();
dto1.ClientEmail = (dataReader["ClientEmail"] == System.DBNull.Value) ? string.Empty : dataReader["ClientEmail"].ToString();
dto1.ClientNotes = (dataReader["ClientNotes"] == System.DBNull.Value) ? string.Empty : dataReader["ClientNotes"].ToString();
dto1.Clientaddress = (dataReader["Client address"] == System.DBNull.Value) ? string.Empty : dataReader["Client address"].ToString();
dto1.ClientContact = (dataReader["ClientContact"] == System.DBNull.Value) ? string.Empty : dataReader["ClientContact"].ToString();
dto1.Adults = (dataReader["Adults"] == System.DBNull.Value) ? string.Empty : dataReader["Adults"].ToString();
dto1.Children = (dataReader["Children"] == System.DBNull.Value) ? string.Empty : dataReader["Children"].ToString();
dto1.Infants = (dataReader["Infants"] == System.DBNull.Value) ? string.Empty : dataReader["Infants"].ToString();
dto1.ChildrenAges = (dataReader["ChildrenAges"] == System.DBNull.Value) ? string.Empty : dataReader["ChildrenAges"].ToString();

					dtos.Add(dto1);
				}
            }
			
            return dtos;
        }
		
		
		
		
		/// <summary>
        /// Gets the List of Bookings
        /// </summary>
		/// <param name="id">The key to delete the record</param>
        /// <returns>The Bookings</returns>
        public Bookings SelectById(string id)
        {
            Bookings dto1 = new Bookings();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AG_SELECTBYID_Bookings", conn);
                cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;

				
				var dataReader = cmd.ExecuteReader();
				while (dataReader.Read())
				{
					dto1.Id = (dataReader["Id"] == System.DBNull.Value) ? string.Empty : dataReader["Id"].ToString();
dto1.HotelId = (dataReader["HotelId"] == System.DBNull.Value) ? string.Empty : dataReader["HotelId"].ToString();
dto1.ProviderId = (dataReader["ProviderId"] == System.DBNull.Value) ? string.Empty : dataReader["ProviderId"].ToString();
dto1.AgencyId = (dataReader["AgencyId"] == System.DBNull.Value) ? string.Empty : dataReader["AgencyId"].ToString();
dto1.Reference = (dataReader["Reference"] == System.DBNull.Value) ? string.Empty : dataReader["Reference"].ToString();
dto1.FromDate = (dataReader["FromDate"] == System.DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dataReader["FromDate"].ToString());
dto1.ToDate = (dataReader["ToDate"] == System.DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dataReader["ToDate"].ToString());
dto1.DateBooked = (dataReader["DateBooked"] == System.DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dataReader["DateBooked"].ToString());
dto1.Nights = (dataReader["Nights"] == System.DBNull.Value) ? string.Empty : dataReader["Nights"].ToString();
dto1.NumRooms = (dataReader["NumRooms"] == System.DBNull.Value) ? string.Empty : dataReader["NumRooms"].ToString();
dto1.TotalCost = (dataReader["TotalCost"] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dataReader["TotalCost"].ToString());
dto1.TotalPrice = (dataReader["TotalPrice"] == System.DBNull.Value) ? 0 : Convert.ToDecimal(dataReader["TotalPrice"].ToString());
dto1.Status = (dataReader["Status"] == System.DBNull.Value) ? string.Empty : dataReader["Status"].ToString();
dto1.PaidStatus = (dataReader["PaidStatus"] == System.DBNull.Value) ? string.Empty : dataReader["PaidStatus"].ToString();
dto1.ClientTitle = (dataReader["ClientTitle"] == System.DBNull.Value) ? string.Empty : dataReader["ClientTitle"].ToString();
dto1.ClientName = (dataReader["ClientName"] == System.DBNull.Value) ? string.Empty : dataReader["ClientName"].ToString();
dto1.ClientSurname = (dataReader["ClientSurname"] == System.DBNull.Value) ? string.Empty : dataReader["ClientSurname"].ToString();
dto1.ClientEmail = (dataReader["ClientEmail"] == System.DBNull.Value) ? string.Empty : dataReader["ClientEmail"].ToString();
dto1.ClientNotes = (dataReader["ClientNotes"] == System.DBNull.Value) ? string.Empty : dataReader["ClientNotes"].ToString();
dto1.Clientaddress = (dataReader["Client address"] == System.DBNull.Value) ? string.Empty : dataReader["Client address"].ToString();
dto1.ClientContact = (dataReader["ClientContact"] == System.DBNull.Value) ? string.Empty : dataReader["ClientContact"].ToString();
dto1.Adults = (dataReader["Adults"] == System.DBNull.Value) ? string.Empty : dataReader["Adults"].ToString();
dto1.Children = (dataReader["Children"] == System.DBNull.Value) ? string.Empty : dataReader["Children"].ToString();
dto1.Infants = (dataReader["Infants"] == System.DBNull.Value) ? string.Empty : dataReader["Infants"].ToString();
dto1.ChildrenAges = (dataReader["ChildrenAges"] == System.DBNull.Value) ? string.Empty : dataReader["ChildrenAges"].ToString();

				}
            }
			
            return dto1;
        }
    }
}
