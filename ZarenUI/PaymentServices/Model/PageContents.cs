using System.Text.Json.Serialization;
using Core.Entities;
using Dapper.Contrib.Extensions;

namespace Model.Concrete;

[Table("PageContents")]
public class PageContents : IEntity
{
	private int _Id;

	private string _ContentTitle;

	private string _Contents;

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

	[JsonPropertyName("contenttitle")]
	public string ContentTitle
	{
		get
		{
			return _ContentTitle;
		}
		set
		{
			_ContentTitle = value;
		}
	}

	[JsonPropertyName("contents")]
	public string Contents
	{
		get
		{
			return _Contents;
		}
		set
		{
			_Contents = value;
		}
	}
}
