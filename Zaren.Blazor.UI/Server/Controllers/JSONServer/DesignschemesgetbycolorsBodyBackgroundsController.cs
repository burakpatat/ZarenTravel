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
    public partial class DesignschemesgetbycolorsBodyBackgroundsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DesignschemesgetbycolorsBodyBackgroundsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DesignschemesgetbycolorsBodyBackgroundsFunc(colors_body_background={colors_body_background})")]
        public IActionResult DesignschemesgetbycolorsBodyBackgroundsFunc([FromODataUri] string colors_body_background)
        {
            this.OnDesignschemesgetbycolorsBodyBackgroundsDefaultParams(ref colors_body_background);

            var items = this.context.DesignschemesgetbycolorsBodyBackgrounds.FromSqlRaw("EXEC [dbo].[DesignSchemesGetBycolors_body_background] @colors_body_background={0}", colors_body_background).ToList().AsQueryable();

            this.OnDesignschemesgetbycolorsBodyBackgroundsInvoke(ref items);

            return Ok(items);
        }

        partial void OnDesignschemesgetbycolorsBodyBackgroundsDefaultParams(ref string colors_body_background);

        partial void OnDesignschemesgetbycolorsBodyBackgroundsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsBodyBackground> items);
    }
}
