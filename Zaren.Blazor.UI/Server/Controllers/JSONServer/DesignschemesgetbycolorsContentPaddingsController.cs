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
    public partial class DesignschemesgetbycolorsContentPaddingsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DesignschemesgetbycolorsContentPaddingsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DesignschemesgetbycolorsContentPaddingsFunc(colors_content_padding={colors_content_padding})")]
        public IActionResult DesignschemesgetbycolorsContentPaddingsFunc([FromODataUri] string colors_content_padding)
        {
            this.OnDesignschemesgetbycolorsContentPaddingsDefaultParams(ref colors_content_padding);

            var items = this.context.DesignschemesgetbycolorsContentPaddings.FromSqlRaw("EXEC [dbo].[DesignSchemesGetBycolors_content_padding] @colors_content_padding={0}", colors_content_padding).ToList().AsQueryable();

            this.OnDesignschemesgetbycolorsContentPaddingsInvoke(ref items);

            return Ok(items);
        }

        partial void OnDesignschemesgetbycolorsContentPaddingsDefaultParams(ref string colors_content_padding);

        partial void OnDesignschemesgetbycolorsContentPaddingsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsContentPadding> items);
    }
}
