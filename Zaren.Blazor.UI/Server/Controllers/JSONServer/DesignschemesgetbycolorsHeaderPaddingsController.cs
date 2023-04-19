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
    public partial class DesignschemesgetbycolorsHeaderPaddingsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DesignschemesgetbycolorsHeaderPaddingsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DesignschemesgetbycolorsHeaderPaddingsFunc(colors_header_padding={colors_header_padding})")]
        public IActionResult DesignschemesgetbycolorsHeaderPaddingsFunc([FromODataUri] string colors_header_padding)
        {
            this.OnDesignschemesgetbycolorsHeaderPaddingsDefaultParams(ref colors_header_padding);

            var items = this.context.DesignschemesgetbycolorsHeaderPaddings.FromSqlRaw("EXEC [dbo].[DesignSchemesGetBycolors_header_padding] @colors_header_padding={0}", colors_header_padding).ToList().AsQueryable();

            this.OnDesignschemesgetbycolorsHeaderPaddingsInvoke(ref items);

            return Ok(items);
        }

        partial void OnDesignschemesgetbycolorsHeaderPaddingsDefaultParams(ref string colors_header_padding);

        partial void OnDesignschemesgetbycolorsHeaderPaddingsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsHeaderPadding> items);
    }
}
