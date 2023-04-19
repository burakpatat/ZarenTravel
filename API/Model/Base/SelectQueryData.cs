
using System.Collections.Generic;


public class SelectQueryData
{
    public List<ColumnModel> ColumnList { get; set; }

    public List<PrimaryKeyClass> PrimaryKeys { get; set; }

    public List<JoinColumnClass> JoinQueryData { get; set; }

    public List<FKColumnClass> FKColumnData { get; set; }

    public List<string> SelectColumnList { get; set; }
}
