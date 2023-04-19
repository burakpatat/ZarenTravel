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
    public partial class ProjectPageComponentsGetByOnHoversController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentsGetByOnHoversController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentsGetByOnHoversFunc(OnHover={OnHover})")]
        public IActionResult ProjectPageComponentsGetByOnHoversFunc([FromODataUri] bool? OnHover)
        {
            this.OnProjectPageComponentsGetByOnHoversDefaultParams(ref OnHover);

            var items = this.context.ProjectPageComponentsGetByOnHovers.FromSqlRaw("EXEC [dbo].[ProjectPageComponentsGetByOnHover] @OnHover={0}", OnHover).ToList().AsQueryable();

            this.OnProjectPageComponentsGetByOnHoversInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentsGetByOnHoversDefaultParams(ref bool? OnHover);

        partial void OnProjectPageComponentsGetByOnHoversInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByOnHover> items);
    }
}
