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
    public partial class ForeignKeyRulesGetByReferencedColumnDbTypeComparesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ForeignKeyRulesGetByReferencedColumnDbTypeComparesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ForeignKeyRulesGetByReferencedColumnDbTypeComparesFunc(ReferencedColumnDbTypeCompare={ReferencedColumnDbTypeCompare})")]
        public IActionResult ForeignKeyRulesGetByReferencedColumnDbTypeComparesFunc([FromODataUri] string ReferencedColumnDbTypeCompare)
        {
            this.OnForeignKeyRulesGetByReferencedColumnDbTypeComparesDefaultParams(ref ReferencedColumnDbTypeCompare);

            var items = this.context.ForeignKeyRulesGetByReferencedColumnDbTypeCompares.FromSqlRaw("EXEC [dbo].[ForeignKeyRulesGetByReferencedColumnDbTypeCompare] @ReferencedColumnDbTypeCompare={0}", ReferencedColumnDbTypeCompare).ToList().AsQueryable();

            this.OnForeignKeyRulesGetByReferencedColumnDbTypeComparesInvoke(ref items);

            return Ok(items);
        }

        partial void OnForeignKeyRulesGetByReferencedColumnDbTypeComparesDefaultParams(ref string ReferencedColumnDbTypeCompare);

        partial void OnForeignKeyRulesGetByReferencedColumnDbTypeComparesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ForeignKeyRulesGetByReferencedColumnDbTypeCompare> items);
    }
}
