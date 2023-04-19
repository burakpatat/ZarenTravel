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
    public partial class ProjectPageComponentsGetByResponseSchemesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentsGetByResponseSchemesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentsGetByResponseSchemesFunc(ResponseScheme={ResponseScheme})")]
        public IActionResult ProjectPageComponentsGetByResponseSchemesFunc([FromODataUri] string ResponseScheme)
        {
            this.OnProjectPageComponentsGetByResponseSchemesDefaultParams(ref ResponseScheme);

            var items = this.context.ProjectPageComponentsGetByResponseSchemes.FromSqlRaw("EXEC [dbo].[ProjectPageComponentsGetByResponseScheme] @ResponseScheme={0}", ResponseScheme).ToList().AsQueryable();

            this.OnProjectPageComponentsGetByResponseSchemesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentsGetByResponseSchemesDefaultParams(ref string ResponseScheme);

        partial void OnProjectPageComponentsGetByResponseSchemesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByResponseScheme> items);
    }
}
