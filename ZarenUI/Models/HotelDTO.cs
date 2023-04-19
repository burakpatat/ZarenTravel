namespace ZarenUI.Models
{
	public class HotelDTO
	{
		public string SystemId { get; set; }
		public string Title { get; set; }
		public string Address { get; set; }
		public List<string> Facility { get; set; }
		public List<string> Images { get; set; }
		public string Price { get; set; }
		public string Currency { get; set; }
		public List<string> OffersId { get; set; }

		public string CancellationDate { get; set; }
		public string RoomType { get; set; }
	}
}

public class bodyData
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string GovernmentId { get; set; }
    public string BirthDate { get; set; }
    public string MobileNumber { get; set; } 
}