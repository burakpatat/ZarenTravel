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
    public partial class ProjectConfigurationsGetLastValidDateBetweensController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetLastValidDateBetweensController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetLastValidDateBetweensFunc(LastValidDateStart={LastValidDateStart},LastValidDateEnd={LastValidDateEnd})")]
        public IActionResult ProjectConfigurationsGetLastValidDateBetweensFunc([FromODataUri] string LastValidDateStart, [FromODataUri] string LastValidDateEnd)
        {
            this.OnProjectConfigurationsGetLastValidDateBetweensDefaultParams(ref LastValidDateStart, ref LastValidDateEnd);

            var items = this.context.ProjectConfigurationsGetLastValidDateBetweens.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetLastValidDateBetween] @LastValidDateStart={0}, @LastValidDateEnd={1}", LastValidDateStart, LastValidDateEnd).ToList().AsQueryable();

            this.OnProjectConfigurationsGetLastValidDateBetweensInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetLastValidDateBetweensDefaultParams(ref string LastValidDateStart, ref string LastValidDateEnd);

        partial void OnProjectConfigurationsGetLastValidDateBetweensInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetLastValidDateBetween> items);
    }
}
