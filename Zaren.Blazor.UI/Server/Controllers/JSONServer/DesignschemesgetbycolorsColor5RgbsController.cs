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
    public partial class DesignschemesgetbycolorsColor5RgbsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DesignschemesgetbycolorsColor5RgbsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DesignschemesgetbycolorsColor5RgbsFunc(colors_color5_rgb={colors_color5_rgb})")]
        public IActionResult DesignschemesgetbycolorsColor5RgbsFunc([FromODataUri] int? colors_color5_rgb)
        {
            this.OnDesignschemesgetbycolorsColor5RgbsDefaultParams(ref colors_color5_rgb);

            var items = this.context.DesignschemesgetbycolorsColor5Rgbs.FromSqlRaw("EXEC [dbo].[DesignSchemesGetBycolors_color5_rgb] @colors_color5_rgb={0}", colors_color5_rgb).ToList().AsQueryable();

            this.OnDesignschemesgetbycolorsColor5RgbsInvoke(ref items);

            return Ok(items);
        }

        partial void OnDesignschemesgetbycolorsColor5RgbsDefaultParams(ref int? colors_color5_rgb);

        partial void OnDesignschemesgetbycolorsColor5RgbsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsColor5Rgb> items);
    }
}
