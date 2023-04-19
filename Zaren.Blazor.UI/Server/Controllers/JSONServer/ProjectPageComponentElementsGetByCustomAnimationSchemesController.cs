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
    public partial class ProjectPageComponentElementsGetByCustomAnimationSchemesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentElementsGetByCustomAnimationSchemesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentElementsGetByCustomAnimationSchemesFunc(CustomAnimationScheme={CustomAnimationScheme})")]
        public IActionResult ProjectPageComponentElementsGetByCustomAnimationSchemesFunc([FromODataUri] string CustomAnimationScheme)
        {
            this.OnProjectPageComponentElementsGetByCustomAnimationSchemesDefaultParams(ref CustomAnimationScheme);

            var items = this.context.ProjectPageComponentElementsGetByCustomAnimationSchemes.FromSqlRaw("EXEC [dbo].[ProjectPageComponentElementsGetByCustomAnimationScheme] @CustomAnimationScheme={0}", CustomAnimationScheme).ToList().AsQueryable();

            this.OnProjectPageComponentElementsGetByCustomAnimationSchemesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentElementsGetByCustomAnimationSchemesDefaultParams(ref string CustomAnimationScheme);

        partial void OnProjectPageComponentElementsGetByCustomAnimationSchemesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByCustomAnimationScheme> items);
    }
}
