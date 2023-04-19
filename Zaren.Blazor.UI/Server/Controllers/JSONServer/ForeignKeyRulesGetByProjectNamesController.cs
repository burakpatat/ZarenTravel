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
    public partial class ForeignKeyRulesGetByProjectNamesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ForeignKeyRulesGetByProjectNamesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ForeignKeyRulesGetByProjectNamesFunc(ProjectName={ProjectName})")]
        public IActionResult ForeignKeyRulesGetByProjectNamesFunc([FromODataUri] string ProjectName)
        {
            this.OnForeignKeyRulesGetByProjectNamesDefaultParams(ref ProjectName);

            var items = this.context.ForeignKeyRulesGetByProjectNames.FromSqlRaw("EXEC [dbo].[ForeignKeyRulesGetByProjectName] @ProjectName={0}", ProjectName).ToList().AsQueryable();

            this.OnForeignKeyRulesGetByProjectNamesInvoke(ref items);

            return Ok(items);
        }

        partial void OnForeignKeyRulesGetByProjectNamesDefaultParams(ref string ProjectName);

        partial void OnForeignKeyRulesGetByProjectNamesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ForeignKeyRulesGetByProjectName> items);
    }
}
