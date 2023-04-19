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
    public partial class ProjectPageComponentElementsGetByCustomCodesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentElementsGetByCustomCodesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentElementsGetByCustomCodesFunc(CustomCode={CustomCode})")]
        public IActionResult ProjectPageComponentElementsGetByCustomCodesFunc([FromODataUri] string CustomCode)
        {
            this.OnProjectPageComponentElementsGetByCustomCodesDefaultParams(ref CustomCode);

            var items = this.context.ProjectPageComponentElementsGetByCustomCodes.FromSqlRaw("EXEC [dbo].[ProjectPageComponentElementsGetByCustomCode] @CustomCode={0}", CustomCode).ToList().AsQueryable();

            this.OnProjectPageComponentElementsGetByCustomCodesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentElementsGetByCustomCodesDefaultParams(ref string CustomCode);

        partial void OnProjectPageComponentElementsGetByCustomCodesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByCustomCode> items);
    }
}
