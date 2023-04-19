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
    public partial class ProjectPageComponentElementsGetByCustomCssesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentElementsGetByCustomCssesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentElementsGetByCustomCssesFunc(CustomCss={CustomCss})")]
        public IActionResult ProjectPageComponentElementsGetByCustomCssesFunc([FromODataUri] string CustomCss)
        {
            this.OnProjectPageComponentElementsGetByCustomCssesDefaultParams(ref CustomCss);

            var items = this.context.ProjectPageComponentElementsGetByCustomCsses.FromSqlRaw("EXEC [dbo].[ProjectPageComponentElementsGetByCustomCss] @CustomCss={0}", CustomCss).ToList().AsQueryable();

            this.OnProjectPageComponentElementsGetByCustomCssesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentElementsGetByCustomCssesDefaultParams(ref string CustomCss);

        partial void OnProjectPageComponentElementsGetByCustomCssesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByCustomCss> items);
    }
}
