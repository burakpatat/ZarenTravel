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
    public partial class DesignschemesgetbycolorsFooterMarginsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DesignschemesgetbycolorsFooterMarginsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DesignschemesgetbycolorsFooterMarginsFunc(colors_footer_margin={colors_footer_margin})")]
        public IActionResult DesignschemesgetbycolorsFooterMarginsFunc([FromODataUri] string colors_footer_margin)
        {
            this.OnDesignschemesgetbycolorsFooterMarginsDefaultParams(ref colors_footer_margin);

            var items = this.context.DesignschemesgetbycolorsFooterMargins.FromSqlRaw("EXEC [dbo].[DesignSchemesGetBycolors_footer_margin] @colors_footer_margin={0}", colors_footer_margin).ToList().AsQueryable();

            this.OnDesignschemesgetbycolorsFooterMarginsInvoke(ref items);

            return Ok(items);
        }

        partial void OnDesignschemesgetbycolorsFooterMarginsDefaultParams(ref string colors_footer_margin);

        partial void OnDesignschemesgetbycolorsFooterMarginsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsFooterMargin> items);
    }
}
