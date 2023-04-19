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
    public partial class ForeignKeyRulesGetByReferencedTableNamesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ForeignKeyRulesGetByReferencedTableNamesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ForeignKeyRulesGetByReferencedTableNamesFunc(ReferencedTableName={ReferencedTableName})")]
        public IActionResult ForeignKeyRulesGetByReferencedTableNamesFunc([FromODataUri] string ReferencedTableName)
        {
            this.OnForeignKeyRulesGetByReferencedTableNamesDefaultParams(ref ReferencedTableName);

            var items = this.context.ForeignKeyRulesGetByReferencedTableNames.FromSqlRaw("EXEC [dbo].[ForeignKeyRulesGetByReferencedTableName] @ReferencedTableName={0}", ReferencedTableName).ToList().AsQueryable();

            this.OnForeignKeyRulesGetByReferencedTableNamesInvoke(ref items);

            return Ok(items);
        }

        partial void OnForeignKeyRulesGetByReferencedTableNamesDefaultParams(ref string ReferencedTableName);

        partial void OnForeignKeyRulesGetByReferencedTableNamesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ForeignKeyRulesGetByReferencedTableName> items);
    }
}
