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
    public partial class DesignschemesgetbycolorsColor4RgbsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DesignschemesgetbycolorsColor4RgbsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DesignschemesgetbycolorsColor4RgbsFunc(colors_color4_rgb={colors_color4_rgb})")]
        public IActionResult DesignschemesgetbycolorsColor4RgbsFunc([FromODataUri] int? colors_color4_rgb)
        {
            this.OnDesignschemesgetbycolorsColor4RgbsDefaultParams(ref colors_color4_rgb);

            var items = this.context.DesignschemesgetbycolorsColor4Rgbs.FromSqlRaw("EXEC [dbo].[DesignSchemesGetBycolors_color4_rgb] @colors_color4_rgb={0}", colors_color4_rgb).ToList().AsQueryable();

            this.OnDesignschemesgetbycolorsColor4RgbsInvoke(ref items);

            return Ok(items);
        }

        partial void OnDesignschemesgetbycolorsColor4RgbsDefaultParams(ref int? colors_color4_rgb);

        partial void OnDesignschemesgetbycolorsColor4RgbsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsColor4Rgb> items);
    }
}
