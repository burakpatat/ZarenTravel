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
    public partial class DesignschemesgetbycolorsGroupsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DesignschemesgetbycolorsGroupsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DesignschemesgetbycolorsGroupsFunc(colors_group={colors_group})")]
        public IActionResult DesignschemesgetbycolorsGroupsFunc([FromODataUri] string colors_group)
        {
            this.OnDesignschemesgetbycolorsGroupsDefaultParams(ref colors_group);

            var items = this.context.DesignschemesgetbycolorsGroups.FromSqlRaw("EXEC [dbo].[DesignSchemesGetBycolors_group] @colors_group={0}", colors_group).ToList().AsQueryable();

            this.OnDesignschemesgetbycolorsGroupsInvoke(ref items);

            return Ok(items);
        }

        partial void OnDesignschemesgetbycolorsGroupsDefaultParams(ref string colors_group);

        partial void OnDesignschemesgetbycolorsGroupsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsGroup> items);
    }
}
