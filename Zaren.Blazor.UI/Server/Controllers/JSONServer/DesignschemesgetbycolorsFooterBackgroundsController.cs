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
    public partial class DesignschemesgetbycolorsFooterBackgroundsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DesignschemesgetbycolorsFooterBackgroundsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DesignschemesgetbycolorsFooterBackgroundsFunc(colors_footer_background={colors_footer_background})")]
        public IActionResult DesignschemesgetbycolorsFooterBackgroundsFunc([FromODataUri] string colors_footer_background)
        {
            this.OnDesignschemesgetbycolorsFooterBackgroundsDefaultParams(ref colors_footer_background);

            var items = this.context.DesignschemesgetbycolorsFooterBackgrounds.FromSqlRaw("EXEC [dbo].[DesignSchemesGetBycolors_footer_background] @colors_footer_background={0}", colors_footer_background).ToList().AsQueryable();

            this.OnDesignschemesgetbycolorsFooterBackgroundsInvoke(ref items);

            return Ok(items);
        }

        partial void OnDesignschemesgetbycolorsFooterBackgroundsDefaultParams(ref string colors_footer_background);

        partial void OnDesignschemesgetbycolorsFooterBackgroundsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsFooterBackground> items);
    }
}
