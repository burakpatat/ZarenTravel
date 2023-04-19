using Dapper.Contrib.Extensions;

[Table("zaren.AspNetUserTokens")]
public class AspNetUserTokens
{
    public string UserId { get; internal set; }
    public string LoginProvider { get; internal set; }
    public string Name { get; internal set; }
    public string Value { get; internal set; }
}