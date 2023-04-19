using System;
using System.Net;
using System.Data;
using System.Linq;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Formatter;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ZarenUI.Server.Controllers.JSONServer
{
    public partial class SpHelpDatatypeMappingsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public SpHelpDatatypeMappingsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/SpHelpDatatypeMappingsFunc(dbms_name={dbms_name},dbms_version={dbms_version},sql_type={sql_type},source_prec={source_prec})")]
        public IActionResult SpHelpDatatypeMappingsFunc([FromODataUri] string dbms_name, [FromODataUri] string dbms_version, [FromODataUri] string sql_type, [FromODataUri] int? source_prec)
        {
            this.OnSpHelpDatatypeMappingsDefaultParams(ref dbms_name, ref dbms_version, ref sql_type, ref source_prec);

            var items = this.context.SpHelpDatatypeMappings.FromSqlRaw("EXEC [dbo].[sp_help_datatype_mapping] @dbms_name={0}, @dbms_version={1}, @sql_type={2}, @source_prec={3}", dbms_name, dbms_version, sql_type, source_prec).ToList().AsQueryable();

            this.OnSpHelpDatatypeMappingsInvoke(ref items);

            return Ok(items);
        }

        partial void OnSpHelpDatatypeMappingsDefaultParams(ref string dbms_name, ref string dbms_version, ref string sql_type, ref int? source_prec);

        partial void OnSpHelpDatatypeMappingsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.SpHelpDatatypeMapping> items);
    }
}
