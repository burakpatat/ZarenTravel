using System.Text.Json.Serialization;
using Core.Entities;
using Dapper.Contrib.Extensions;

namespace Model.Concrete;

[Table("Languages")]
public class Languages : IEntity
{
	private int _Id;

	private string _LanguageName;

	private string _LanguageCode;

	[Key]
	[JsonPropertyName("id")]
	public int Id
	{
		get
		{
			return _Id;
		}
		set
		{
			_Id = value;
		}
	}

	[JsonPropertyName("languagename")]
	public string LanguageName
	{
		get
		{
			return _LanguageName;
		}
		set
		{
			_LanguageName = value;
		}
	}

	[JsonPropertyName("languagecode")]
	public string LanguageCode
	{
		get
		{
			return _LanguageCode;
		}
		set
		{
			_LanguageCode = value;
		}
	}
	public string CultureInfo { get; set; }

	public string Icon { get; set; }
    public bool IsDefault { get; set; }
    public bool IsRTL { get; set; }
}
