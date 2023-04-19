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
    public partial class DesignschemesgetbycolorsColor1BrightnessesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DesignschemesgetbycolorsColor1BrightnessesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DesignschemesgetbycolorsColor1BrightnessesFunc(colors_color1_brightness={colors_color1_brightness})")]
        public IActionResult DesignschemesgetbycolorsColor1BrightnessesFunc([FromODataUri] decimal? colors_color1_brightness)
        {
            this.OnDesignschemesgetbycolorsColor1BrightnessesDefaultParams(ref colors_color1_brightness);

            var items = this.context.DesignschemesgetbycolorsColor1Brightnesses.FromSqlRaw("EXEC [dbo].[DesignSchemesGetBycolors_color1_brightness] @colors_color1_brightness={0}", colors_color1_brightness).ToList().AsQueryable();

            this.OnDesignschemesgetbycolorsColor1BrightnessesInvoke(ref items);

            return Ok(items);
        }

        partial void OnDesignschemesgetbycolorsColor1BrightnessesDefaultParams(ref decimal? colors_color1_brightness);

        partial void OnDesignschemesgetbycolorsColor1BrightnessesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsColor1Brightness> items);
    }
}
