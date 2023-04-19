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
    public partial class ProjectPageComponentsGetByRequestSchemesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentsGetByRequestSchemesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentsGetByRequestSchemesFunc(RequestScheme={RequestScheme})")]
        public IActionResult ProjectPageComponentsGetByRequestSchemesFunc([FromODataUri] string RequestScheme)
        {
            this.OnProjectPageComponentsGetByRequestSchemesDefaultParams(ref RequestScheme);

            var items = this.context.ProjectPageComponentsGetByRequestSchemes.FromSqlRaw("EXEC [dbo].[ProjectPageComponentsGetByRequestScheme] @RequestScheme={0}", RequestScheme).ToList().AsQueryable();

            this.OnProjectPageComponentsGetByRequestSchemesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentsGetByRequestSchemesDefaultParams(ref string RequestScheme);

        partial void OnProjectPageComponentsGetByRequestSchemesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByRequestScheme> items);
    }
}
