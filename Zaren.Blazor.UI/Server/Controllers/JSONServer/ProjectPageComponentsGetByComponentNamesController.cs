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
    public partial class ProjectPageComponentsGetByComponentNamesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentsGetByComponentNamesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentsGetByComponentNamesFunc(ComponentName={ComponentName})")]
        public IActionResult ProjectPageComponentsGetByComponentNamesFunc([FromODataUri] string ComponentName)
        {
            this.OnProjectPageComponentsGetByComponentNamesDefaultParams(ref ComponentName);

            var items = this.context.ProjectPageComponentsGetByComponentNames.FromSqlRaw("EXEC [dbo].[ProjectPageComponentsGetByComponentName] @ComponentName={0}", ComponentName).ToList().AsQueryable();

            this.OnProjectPageComponentsGetByComponentNamesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentsGetByComponentNamesDefaultParams(ref string ComponentName);

        partial void OnProjectPageComponentsGetByComponentNamesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByComponentName> items);
    }
}
