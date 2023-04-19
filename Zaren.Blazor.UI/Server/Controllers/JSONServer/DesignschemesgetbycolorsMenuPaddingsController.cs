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
    public partial class DesignschemesgetbycolorsMenuPaddingsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DesignschemesgetbycolorsMenuPaddingsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DesignschemesgetbycolorsMenuPaddingsFunc(colors_menu_padding={colors_menu_padding})")]
        public IActionResult DesignschemesgetbycolorsMenuPaddingsFunc([FromODataUri] string colors_menu_padding)
        {
            this.OnDesignschemesgetbycolorsMenuPaddingsDefaultParams(ref colors_menu_padding);

            var items = this.context.DesignschemesgetbycolorsMenuPaddings.FromSqlRaw("EXEC [dbo].[DesignSchemesGetBycolors_menu_padding] @colors_menu_padding={0}", colors_menu_padding).ToList().AsQueryable();

            this.OnDesignschemesgetbycolorsMenuPaddingsInvoke(ref items);

            return Ok(items);
        }

        partial void OnDesignschemesgetbycolorsMenuPaddingsDefaultParams(ref string colors_menu_padding);

        partial void OnDesignschemesgetbycolorsMenuPaddingsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsMenuPadding> items);
    }
}
