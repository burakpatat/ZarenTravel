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
    public partial class DesignschemesgetbycolorsContentBackgroundsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DesignschemesgetbycolorsContentBackgroundsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DesignschemesgetbycolorsContentBackgroundsFunc(colors_content_background={colors_content_background})")]
        public IActionResult DesignschemesgetbycolorsContentBackgroundsFunc([FromODataUri] string colors_content_background)
        {
            this.OnDesignschemesgetbycolorsContentBackgroundsDefaultParams(ref colors_content_background);

            var items = this.context.DesignschemesgetbycolorsContentBackgrounds.FromSqlRaw("EXEC [dbo].[DesignSchemesGetBycolors_content_background] @colors_content_background={0}", colors_content_background).ToList().AsQueryable();

            this.OnDesignschemesgetbycolorsContentBackgroundsInvoke(ref items);

            return Ok(items);
        }

        partial void OnDesignschemesgetbycolorsContentBackgroundsDefaultParams(ref string colors_content_background);

        partial void OnDesignschemesgetbycolorsContentBackgroundsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsContentBackground> items);
    }
}
