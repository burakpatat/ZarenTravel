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
    public partial class DesignschemesgetbycolorsWrapperMarginsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DesignschemesgetbycolorsWrapperMarginsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DesignschemesgetbycolorsWrapperMarginsFunc(colors_wrapper_margin={colors_wrapper_margin})")]
        public IActionResult DesignschemesgetbycolorsWrapperMarginsFunc([FromODataUri] string colors_wrapper_margin)
        {
            this.OnDesignschemesgetbycolorsWrapperMarginsDefaultParams(ref colors_wrapper_margin);

            var items = this.context.DesignschemesgetbycolorsWrapperMargins.FromSqlRaw("EXEC [dbo].[DesignSchemesGetBycolors_wrapper_margin] @colors_wrapper_margin={0}", colors_wrapper_margin).ToList().AsQueryable();

            this.OnDesignschemesgetbycolorsWrapperMarginsInvoke(ref items);

            return Ok(items);
        }

        partial void OnDesignschemesgetbycolorsWrapperMarginsDefaultParams(ref string colors_wrapper_margin);

        partial void OnDesignschemesgetbycolorsWrapperMarginsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsWrapperMargin> items);
    }
}
