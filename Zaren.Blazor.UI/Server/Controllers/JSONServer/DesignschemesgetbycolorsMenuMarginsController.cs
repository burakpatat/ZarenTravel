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
    public partial class DesignschemesgetbycolorsMenuMarginsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DesignschemesgetbycolorsMenuMarginsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DesignschemesgetbycolorsMenuMarginsFunc(colors_menu_margin={colors_menu_margin})")]
        public IActionResult DesignschemesgetbycolorsMenuMarginsFunc([FromODataUri] string colors_menu_margin)
        {
            this.OnDesignschemesgetbycolorsMenuMarginsDefaultParams(ref colors_menu_margin);

            var items = this.context.DesignschemesgetbycolorsMenuMargins.FromSqlRaw("EXEC [dbo].[DesignSchemesGetBycolors_menu_margin] @colors_menu_margin={0}", colors_menu_margin).ToList().AsQueryable();

            this.OnDesignschemesgetbycolorsMenuMarginsInvoke(ref items);

            return Ok(items);
        }

        partial void OnDesignschemesgetbycolorsMenuMarginsDefaultParams(ref string colors_menu_margin);

        partial void OnDesignschemesgetbycolorsMenuMarginsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsMenuMargin> items);
    }
}
