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
    public partial class ProjectConfigurationsGetCreatedDateBetweensController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetCreatedDateBetweensController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetCreatedDateBetweensFunc(CreatedDateStart={CreatedDateStart},CreatedDateEnd={CreatedDateEnd})")]
        public IActionResult ProjectConfigurationsGetCreatedDateBetweensFunc([FromODataUri] string CreatedDateStart, [FromODataUri] string CreatedDateEnd)
        {
            this.OnProjectConfigurationsGetCreatedDateBetweensDefaultParams(ref CreatedDateStart, ref CreatedDateEnd);

            var items = this.context.ProjectConfigurationsGetCreatedDateBetweens.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetCreatedDateBetween] @CreatedDateStart={0}, @CreatedDateEnd={1}", CreatedDateStart, CreatedDateEnd).ToList().AsQueryable();

            this.OnProjectConfigurationsGetCreatedDateBetweensInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetCreatedDateBetweensDefaultParams(ref string CreatedDateStart, ref string CreatedDateEnd);

        partial void OnProjectConfigurationsGetCreatedDateBetweensInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetCreatedDateBetween> items);
    }
}
