using System;

namespace Model.FlightModels.Concrete
{ 
public class Price
{
    public int Id { get; set; }

    public int? CurrencyId { get; set; }

    public decimal Amount { get; set; }

    public Offers Offers { get; set; }

    public int SystemId { get; set; }

    public int ApiId { get; set; }

    public int AgencyId { get; set; }

    public int MicroSiteId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }

    public int CreatedBy { get; set; }

    public int UpdatedBy { get; set; }

    public int LanguageId { get; set; }
}
}