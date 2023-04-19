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
    public partial class ProjectConfigurationsGetByHasNeedCompileOnChangesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByHasNeedCompileOnChangesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByHasNeedCompileOnChangesFunc(HasNeedCompileOnChange={HasNeedCompileOnChange})")]
        public IActionResult ProjectConfigurationsGetByHasNeedCompileOnChangesFunc([FromODataUri] string HasNeedCompileOnChange)
        {
            this.OnProjectConfigurationsGetByHasNeedCompileOnChangesDefaultParams(ref HasNeedCompileOnChange);

            var items = this.context.ProjectConfigurationsGetByHasNeedCompileOnChanges.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByHasNeedCompileOnChange] @HasNeedCompileOnChange={0}", HasNeedCompileOnChange).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByHasNeedCompileOnChangesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByHasNeedCompileOnChangesDefaultParams(ref string HasNeedCompileOnChange);

        partial void OnProjectConfigurationsGetByHasNeedCompileOnChangesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByHasNeedCompileOnChange> items);
    }
}
