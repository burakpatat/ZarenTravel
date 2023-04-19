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
    public partial class ProjectTablesGetByI18ConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectTablesGetByI18ConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectTablesGetByI18ConfigurationsFunc(I18Configuration={I18Configuration})")]
        public IActionResult ProjectTablesGetByI18ConfigurationsFunc([FromODataUri] string I18Configuration)
        {
            this.OnProjectTablesGetByI18ConfigurationsDefaultParams(ref I18Configuration);

            var items = this.context.ProjectTablesGetByI18Configurations.FromSqlRaw("EXEC [dbo].[ProjectTablesGetByI18Configuration] @I18Configuration={0}", I18Configuration).ToList().AsQueryable();

            this.OnProjectTablesGetByI18ConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectTablesGetByI18ConfigurationsDefaultParams(ref string I18Configuration);

        partial void OnProjectTablesGetByI18ConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByI18Configuration> items);
    }
}
