

public class ColumnModel
{
    public string Field { get; set; }

    public string TypeName { get; set; }

    public string IsNull { get; set; }

    public bool IsPrimary { get; set; }

    public string Key { get; set; }

    public string DefaultValue { get; set; }

    public string Extra { get; set; }

    public FKDetails FKDetails { get; set; }

    public ColumnModel()
    {
        FKDetails = null;
    }

    public ColumnModel(string field, string typename, string isnull, string key, string defaultValue, string extra)
    {
        Field = field;
        TypeName = typename;
        IsNull = isnull;
        Key = key;
        DefaultValue = defaultValue;
        Extra = extra;
    }
}
