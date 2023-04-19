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
    public partial class DesignschemesgetbycolorsHeaderBackgroundsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DesignschemesgetbycolorsHeaderBackgroundsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DesignschemesgetbycolorsHeaderBackgroundsFunc(colors_header_background={colors_header_background})")]
        public IActionResult DesignschemesgetbycolorsHeaderBackgroundsFunc([FromODataUri] string colors_header_background)
        {
            this.OnDesignschemesgetbycolorsHeaderBackgroundsDefaultParams(ref colors_header_background);

            var items = this.context.DesignschemesgetbycolorsHeaderBackgrounds.FromSqlRaw("EXEC [dbo].[DesignSchemesGetBycolors_header_background] @colors_header_background={0}", colors_header_background).ToList().AsQueryable();

            this.OnDesignschemesgetbycolorsHeaderBackgroundsInvoke(ref items);

            return Ok(items);
        }

        partial void OnDesignschemesgetbycolorsHeaderBackgroundsDefaultParams(ref string colors_header_background);

        partial void OnDesignschemesgetbycolorsHeaderBackgroundsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsHeaderBackground> items);
    }
}
