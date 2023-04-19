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
    public partial class ProjectPageComponentElementsGetPublishedDateBetweensController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentElementsGetPublishedDateBetweensController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentElementsGetPublishedDateBetweensFunc(PublishedDateStart={PublishedDateStart},PublishedDateEnd={PublishedDateEnd})")]
        public IActionResult ProjectPageComponentElementsGetPublishedDateBetweensFunc([FromODataUri] string PublishedDateStart, [FromODataUri] string PublishedDateEnd)
        {
            this.OnProjectPageComponentElementsGetPublishedDateBetweensDefaultParams(ref PublishedDateStart, ref PublishedDateEnd);

            var items = this.context.ProjectPageComponentElementsGetPublishedDateBetweens.FromSqlRaw("EXEC [dbo].[ProjectPageComponentElementsGetPublishedDateBetween] @PublishedDateStart={0}, @PublishedDateEnd={1}", PublishedDateStart, PublishedDateEnd).ToList().AsQueryable();

            this.OnProjectPageComponentElementsGetPublishedDateBetweensInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentElementsGetPublishedDateBetweensDefaultParams(ref string PublishedDateStart, ref string PublishedDateEnd);

        partial void OnProjectPageComponentElementsGetPublishedDateBetweensInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetPublishedDateBetween> items);
    }
}
