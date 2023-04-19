using Dapper.Contrib.Extensions;
using System.Text.Json.Serialization;



[Table("Resources")]
public class Resources
{
    private int _Id;
    [Key]
    [JsonPropertyName("id")]
    public int Id
    {
        get { return _Id; }
        set { _Id = value; }
    }
    private string _KeyName;
    [JsonPropertyName("keyName")]
    public string KeyName
    {
        get { return _KeyName; }
        set { _KeyName = value; }
    }
    private int? _Language;
    [JsonPropertyName("language")]
    public int? Language
    {
        get { return _Language; }
        set { _Language = value; }
    }
    private bool? _IsRTL;
    [JsonPropertyName("isRTL")]
    public bool? IsRTL
    {
        get { return _IsRTL; }
        set { _IsRTL = value; }
    }
    private string _Translation;
    [JsonPropertyName("translation")]
    public string Translation
    {
        get { return _Translation; }
        set { _Translation = value; }
    }
    private string _Statu;
    [JsonPropertyName("statu")]
    public string Statu
    {
        get { return _Statu; }
        set { _Statu = value; }
    }
}