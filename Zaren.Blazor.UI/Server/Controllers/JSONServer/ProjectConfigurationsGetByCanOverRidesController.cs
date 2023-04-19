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
    public partial class ProjectConfigurationsGetByCanOverRidesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByCanOverRidesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByCanOverRidesFunc(CanOverRide={CanOverRide})")]
        public IActionResult ProjectConfigurationsGetByCanOverRidesFunc([FromODataUri] bool? CanOverRide)
        {
            this.OnProjectConfigurationsGetByCanOverRidesDefaultParams(ref CanOverRide);

            var items = this.context.ProjectConfigurationsGetByCanOverRides.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByCanOverRide] @CanOverRide={0}", CanOverRide).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByCanOverRidesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByCanOverRidesDefaultParams(ref bool? CanOverRide);

        partial void OnProjectConfigurationsGetByCanOverRidesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByCanOverRide> items);
    }
}
