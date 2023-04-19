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
    public partial class ProjectPageComponentElementsGetByExampleHtmlCodesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentElementsGetByExampleHtmlCodesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentElementsGetByExampleHtmlCodesFunc(ExampleHtmlCode={ExampleHtmlCode})")]
        public IActionResult ProjectPageComponentElementsGetByExampleHtmlCodesFunc([FromODataUri] string ExampleHtmlCode)
        {
            this.OnProjectPageComponentElementsGetByExampleHtmlCodesDefaultParams(ref ExampleHtmlCode);

            var items = this.context.ProjectPageComponentElementsGetByExampleHtmlCodes.FromSqlRaw("EXEC [dbo].[ProjectPageComponentElementsGetByExampleHtmlCode] @ExampleHtmlCode={0}", ExampleHtmlCode).ToList().AsQueryable();

            this.OnProjectPageComponentElementsGetByExampleHtmlCodesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentElementsGetByExampleHtmlCodesDefaultParams(ref string ExampleHtmlCode);

        partial void OnProjectPageComponentElementsGetByExampleHtmlCodesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByExampleHtmlCode> items);
    }
}
