using Model.Concrete;
using System.Text.Json.Serialization;


public class BasketDTO
{ 
    private string _Guid;
    [JsonPropertyName("guid")]
    public string Guid
    {
        get { return _Guid; }
        set { _Guid = value; }
    }
  
 
}


public class BasketDTOPost
{
    private int? _Id;
    [JsonPropertyName("id")]
    public int? Id
    {
        get { return _Id; }
        set { _Id = value; }
    }
    private string _Guid;
    [JsonPropertyName("guid")]
    public string Guid
    {
        get { return _Guid; }
        set { _Guid = value; }
    }


}
