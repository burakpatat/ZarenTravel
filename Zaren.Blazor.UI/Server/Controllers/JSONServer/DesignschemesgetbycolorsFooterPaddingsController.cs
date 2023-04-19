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
    public partial class DesignschemesgetbycolorsFooterPaddingsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DesignschemesgetbycolorsFooterPaddingsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DesignschemesgetbycolorsFooterPaddingsFunc(colors_footer_padding={colors_footer_padding})")]
        public IActionResult DesignschemesgetbycolorsFooterPaddingsFunc([FromODataUri] string colors_footer_padding)
        {
            this.OnDesignschemesgetbycolorsFooterPaddingsDefaultParams(ref colors_footer_padding);

            var items = this.context.DesignschemesgetbycolorsFooterPaddings.FromSqlRaw("EXEC [dbo].[DesignSchemesGetBycolors_footer_padding] @colors_footer_padding={0}", colors_footer_padding).ToList().AsQueryable();

            this.OnDesignschemesgetbycolorsFooterPaddingsInvoke(ref items);

            return Ok(items);
        }

        partial void OnDesignschemesgetbycolorsFooterPaddingsDefaultParams(ref string colors_footer_padding);

        partial void OnDesignschemesgetbycolorsFooterPaddingsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsFooterPadding> items);
    }
}
