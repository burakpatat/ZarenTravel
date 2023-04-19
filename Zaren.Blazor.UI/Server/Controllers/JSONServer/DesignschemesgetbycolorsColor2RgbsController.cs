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
    public partial class DesignschemesgetbycolorsColor2RgbsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DesignschemesgetbycolorsColor2RgbsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DesignschemesgetbycolorsColor2RgbsFunc(colors_color2_rgb={colors_color2_rgb})")]
        public IActionResult DesignschemesgetbycolorsColor2RgbsFunc([FromODataUri] int? colors_color2_rgb)
        {
            this.OnDesignschemesgetbycolorsColor2RgbsDefaultParams(ref colors_color2_rgb);

            var items = this.context.DesignschemesgetbycolorsColor2Rgbs.FromSqlRaw("EXEC [dbo].[DesignSchemesGetBycolors_color2_rgb] @colors_color2_rgb={0}", colors_color2_rgb).ToList().AsQueryable();

            this.OnDesignschemesgetbycolorsColor2RgbsInvoke(ref items);

            return Ok(items);
        }

        partial void OnDesignschemesgetbycolorsColor2RgbsDefaultParams(ref int? colors_color2_rgb);

        partial void OnDesignschemesgetbycolorsColor2RgbsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsColor2Rgb> items);
    }
}
