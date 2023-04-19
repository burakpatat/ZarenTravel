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
    public partial class DesignschemesgetbycolorsHeaderMarginsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DesignschemesgetbycolorsHeaderMarginsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DesignschemesgetbycolorsHeaderMarginsFunc(colors_header_margin={colors_header_margin})")]
        public IActionResult DesignschemesgetbycolorsHeaderMarginsFunc([FromODataUri] string colors_header_margin)
        {
            this.OnDesignschemesgetbycolorsHeaderMarginsDefaultParams(ref colors_header_margin);

            var items = this.context.DesignschemesgetbycolorsHeaderMargins.FromSqlRaw("EXEC [dbo].[DesignSchemesGetBycolors_header_margin] @colors_header_margin={0}", colors_header_margin).ToList().AsQueryable();

            this.OnDesignschemesgetbycolorsHeaderMarginsInvoke(ref items);

            return Ok(items);
        }

        partial void OnDesignschemesgetbycolorsHeaderMarginsDefaultParams(ref string colors_header_margin);

        partial void OnDesignschemesgetbycolorsHeaderMarginsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsHeaderMargin> items);
    }
}
