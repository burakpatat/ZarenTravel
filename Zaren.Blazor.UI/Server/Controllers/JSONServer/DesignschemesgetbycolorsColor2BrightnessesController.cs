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
    public partial class DesignschemesgetbycolorsColor2BrightnessesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DesignschemesgetbycolorsColor2BrightnessesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DesignschemesgetbycolorsColor2BrightnessesFunc(colors_color2_brightness={colors_color2_brightness})")]
        public IActionResult DesignschemesgetbycolorsColor2BrightnessesFunc([FromODataUri] decimal? colors_color2_brightness)
        {
            this.OnDesignschemesgetbycolorsColor2BrightnessesDefaultParams(ref colors_color2_brightness);

            var items = this.context.DesignschemesgetbycolorsColor2Brightnesses.FromSqlRaw("EXEC [dbo].[DesignSchemesGetBycolors_color2_brightness] @colors_color2_brightness={0}", colors_color2_brightness).ToList().AsQueryable();

            this.OnDesignschemesgetbycolorsColor2BrightnessesInvoke(ref items);

            return Ok(items);
        }

        partial void OnDesignschemesgetbycolorsColor2BrightnessesDefaultParams(ref decimal? colors_color2_brightness);

        partial void OnDesignschemesgetbycolorsColor2BrightnessesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsColor2Brightness> items);
    }
}
