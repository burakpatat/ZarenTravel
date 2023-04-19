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
    public partial class DesignschemesgetbycolorsColor1RgbsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DesignschemesgetbycolorsColor1RgbsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DesignschemesgetbycolorsColor1RgbsFunc(colors_color1_rgb={colors_color1_rgb})")]
        public IActionResult DesignschemesgetbycolorsColor1RgbsFunc([FromODataUri] int? colors_color1_rgb)
        {
            this.OnDesignschemesgetbycolorsColor1RgbsDefaultParams(ref colors_color1_rgb);

            var items = this.context.DesignschemesgetbycolorsColor1Rgbs.FromSqlRaw("EXEC [dbo].[DesignSchemesGetBycolors_color1_rgb] @colors_color1_rgb={0}", colors_color1_rgb).ToList().AsQueryable();

            this.OnDesignschemesgetbycolorsColor1RgbsInvoke(ref items);

            return Ok(items);
        }

        partial void OnDesignschemesgetbycolorsColor1RgbsDefaultParams(ref int? colors_color1_rgb);

        partial void OnDesignschemesgetbycolorsColor1RgbsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsColor1Rgb> items);
    }
}
