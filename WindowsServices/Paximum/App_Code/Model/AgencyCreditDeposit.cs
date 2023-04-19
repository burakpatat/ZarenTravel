using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("AgencyCreditDeposit")]
public class AgencyCreditDeposit: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private int? _AgencyId;
[JsonPropertyName("agencyid")]
public int? AgencyId
{
get { return _AgencyId; }
set { _AgencyId = value; }
}
private int? _BalanceCurrencyId;
[JsonPropertyName("balancecurrencyid")]
public int? BalanceCurrencyId
{
get { return _BalanceCurrencyId; }
set { _BalanceCurrencyId = value; }
}
private decimal? _BalanceAmount;
[JsonPropertyName("balanceamount")]
public decimal? BalanceAmount
{
get { return _BalanceAmount; }
set { _BalanceAmount = value; }
}
private bool? _SendBalanceWarning;
[JsonPropertyName("sendbalancewarning")]
public bool? SendBalanceWarning
{
get { return _SendBalanceWarning; }
set { _SendBalanceWarning = value; }
}
private decimal? _AgencyBalanceWarningAmount;
[JsonPropertyName("agencybalancewarningamount")]
public decimal? AgencyBalanceWarningAmount
{
get { return _AgencyBalanceWarningAmount; }
set { _AgencyBalanceWarningAmount = value; }
}
private int? _AgencyBalanceWarningIsByPercentage;
[JsonPropertyName("agencybalancewarningisbypercentage")]
public int? AgencyBalanceWarningIsByPercentage
{
get { return _AgencyBalanceWarningIsByPercentage; }
set { _AgencyBalanceWarningIsByPercentage = value; }
}
private int? _AgencyBalanceWarningCurrencyId;
[JsonPropertyName("agencybalancewarningcurrencyid")]
public int? AgencyBalanceWarningCurrencyId
{
get { return _AgencyBalanceWarningCurrencyId; }
set { _AgencyBalanceWarningCurrencyId = value; }
}
}
}
