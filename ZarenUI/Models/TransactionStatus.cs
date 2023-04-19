using ZarenUI.Pages;

namespace ZarenUI.Models
{
	public enum TransactionStatus
	{
		SetReservationInfo = 4,
		Committed = 1

	}

	public enum ReservationStatus
	{
		New = 0,
		Modified = 1,
		Cancel = 2,
		CancelX = 3,
		Draft = 9

	}

	public enum ConfirmationStatus
	{
		New = 9,
		Request = 0,
		Confirm = 1,
		NoConfirm = 2,
		NoShow = 3
	}
	public enum PaymentStatus
	{
		New=0,
		None = 1,
		UnPaid = 2,
		PartlyPaid = 3,
		Paid=4,
		Over=5
	}
 
}
