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
    public partial class DesignschemesgetbycolorsMenuBackgroundsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DesignschemesgetbycolorsMenuBackgroundsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DesignschemesgetbycolorsMenuBackgroundsFunc(colors_menu_background={colors_menu_background})")]
        public IActionResult DesignschemesgetbycolorsMenuBackgroundsFunc([FromODataUri] string colors_menu_background)
        {
            this.OnDesignschemesgetbycolorsMenuBackgroundsDefaultParams(ref colors_menu_background);

            var items = this.context.DesignschemesgetbycolorsMenuBackgrounds.FromSqlRaw("EXEC [dbo].[DesignSchemesGetBycolors_menu_background] @colors_menu_background={0}", colors_menu_background).ToList().AsQueryable();

            this.OnDesignschemesgetbycolorsMenuBackgroundsInvoke(ref items);

            return Ok(items);
        }

        partial void OnDesignschemesgetbycolorsMenuBackgroundsDefaultParams(ref string colors_menu_background);

        partial void OnDesignschemesgetbycolorsMenuBackgroundsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsMenuBackground> items);
    }
}
