using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("__EFMigrationsHistory")]
public class __EFMigrationsHistory: IEntity
{
private string _MigrationId;
[Key]
[JsonPropertyName("migrationid")]
public string MigrationId
{
get { return _MigrationId; }
set { _MigrationId = value; }
}
private string _ProductVersion;
[Key]
[JsonPropertyName("productversion")]
public string ProductVersion
{
get { return _ProductVersion; }
set { _ProductVersion = value; }
}
}
}
