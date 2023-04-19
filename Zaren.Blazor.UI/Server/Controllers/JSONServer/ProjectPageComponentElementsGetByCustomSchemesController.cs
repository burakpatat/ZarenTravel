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
    public partial class ProjectPageComponentElementsGetByCustomSchemesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentElementsGetByCustomSchemesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentElementsGetByCustomSchemesFunc(CustomScheme={CustomScheme})")]
        public IActionResult ProjectPageComponentElementsGetByCustomSchemesFunc([FromODataUri] string CustomScheme)
        {
            this.OnProjectPageComponentElementsGetByCustomSchemesDefaultParams(ref CustomScheme);

            var items = this.context.ProjectPageComponentElementsGetByCustomSchemes.FromSqlRaw("EXEC [dbo].[ProjectPageComponentElementsGetByCustomScheme] @CustomScheme={0}", CustomScheme).ToList().AsQueryable();

            this.OnProjectPageComponentElementsGetByCustomSchemesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentElementsGetByCustomSchemesDefaultParams(ref string CustomScheme);

        partial void OnProjectPageComponentElementsGetByCustomSchemesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByCustomScheme> items);
    }
}
