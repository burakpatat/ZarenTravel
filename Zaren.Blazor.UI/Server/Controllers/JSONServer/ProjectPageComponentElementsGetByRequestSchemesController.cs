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
    public partial class ProjectPageComponentElementsGetByRequestSchemesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentElementsGetByRequestSchemesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentElementsGetByRequestSchemesFunc(RequestScheme={RequestScheme})")]
        public IActionResult ProjectPageComponentElementsGetByRequestSchemesFunc([FromODataUri] string RequestScheme)
        {
            this.OnProjectPageComponentElementsGetByRequestSchemesDefaultParams(ref RequestScheme);

            var items = this.context.ProjectPageComponentElementsGetByRequestSchemes.FromSqlRaw("EXEC [dbo].[ProjectPageComponentElementsGetByRequestScheme] @RequestScheme={0}", RequestScheme).ToList().AsQueryable();

            this.OnProjectPageComponentElementsGetByRequestSchemesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentElementsGetByRequestSchemesDefaultParams(ref string RequestScheme);

        partial void OnProjectPageComponentElementsGetByRequestSchemesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByRequestScheme> items);
    }
}
