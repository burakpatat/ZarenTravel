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
    public partial class DesignschemesgetbycolorsColor3RgbsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DesignschemesgetbycolorsColor3RgbsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DesignschemesgetbycolorsColor3RgbsFunc(colors_color3_rgb={colors_color3_rgb})")]
        public IActionResult DesignschemesgetbycolorsColor3RgbsFunc([FromODataUri] int? colors_color3_rgb)
        {
            this.OnDesignschemesgetbycolorsColor3RgbsDefaultParams(ref colors_color3_rgb);

            var items = this.context.DesignschemesgetbycolorsColor3Rgbs.FromSqlRaw("EXEC [dbo].[DesignSchemesGetBycolors_color3_rgb] @colors_color3_rgb={0}", colors_color3_rgb).ToList().AsQueryable();

            this.OnDesignschemesgetbycolorsColor3RgbsInvoke(ref items);

            return Ok(items);
        }

        partial void OnDesignschemesgetbycolorsColor3RgbsDefaultParams(ref int? colors_color3_rgb);

        partial void OnDesignschemesgetbycolorsColor3RgbsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsColor3Rgb> items);
    }
}
