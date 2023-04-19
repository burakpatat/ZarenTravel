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
    public partial class ProjectFunctionsGetPublishedDateBetweensController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectFunctionsGetPublishedDateBetweensController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectFunctionsGetPublishedDateBetweensFunc(PublishedDateStart={PublishedDateStart},PublishedDateEnd={PublishedDateEnd})")]
        public IActionResult ProjectFunctionsGetPublishedDateBetweensFunc([FromODataUri] string PublishedDateStart, [FromODataUri] string PublishedDateEnd)
        {
            this.OnProjectFunctionsGetPublishedDateBetweensDefaultParams(ref PublishedDateStart, ref PublishedDateEnd);

            var items = this.context.ProjectFunctionsGetPublishedDateBetweens.FromSqlRaw("EXEC [dbo].[ProjectFunctionsGetPublishedDateBetween] @PublishedDateStart={0}, @PublishedDateEnd={1}", PublishedDateStart, PublishedDateEnd).ToList().AsQueryable();

            this.OnProjectFunctionsGetPublishedDateBetweensInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectFunctionsGetPublishedDateBetweensDefaultParams(ref string PublishedDateStart, ref string PublishedDateEnd);

        partial void OnProjectFunctionsGetPublishedDateBetweensInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetPublishedDateBetween> items);
    }
}
