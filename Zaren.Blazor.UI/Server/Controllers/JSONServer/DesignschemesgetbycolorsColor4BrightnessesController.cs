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
    public partial class DesignschemesgetbycolorsColor4BrightnessesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DesignschemesgetbycolorsColor4BrightnessesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DesignschemesgetbycolorsColor4BrightnessesFunc(colors_color4_brightness={colors_color4_brightness})")]
        public IActionResult DesignschemesgetbycolorsColor4BrightnessesFunc([FromODataUri] decimal? colors_color4_brightness)
        {
            this.OnDesignschemesgetbycolorsColor4BrightnessesDefaultParams(ref colors_color4_brightness);

            var items = this.context.DesignschemesgetbycolorsColor4Brightnesses.FromSqlRaw("EXEC [dbo].[DesignSchemesGetBycolors_color4_brightness] @colors_color4_brightness={0}", colors_color4_brightness).ToList().AsQueryable();

            this.OnDesignschemesgetbycolorsColor4BrightnessesInvoke(ref items);

            return Ok(items);
        }

        partial void OnDesignschemesgetbycolorsColor4BrightnessesDefaultParams(ref decimal? colors_color4_brightness);

        partial void OnDesignschemesgetbycolorsColor4BrightnessesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsColor4Brightness> items);
    }
}
