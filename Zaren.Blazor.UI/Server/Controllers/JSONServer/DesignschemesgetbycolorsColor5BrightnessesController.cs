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
    public partial class DesignschemesgetbycolorsColor5BrightnessesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DesignschemesgetbycolorsColor5BrightnessesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DesignschemesgetbycolorsColor5BrightnessesFunc(colors_color5_brightness={colors_color5_brightness})")]
        public IActionResult DesignschemesgetbycolorsColor5BrightnessesFunc([FromODataUri] decimal? colors_color5_brightness)
        {
            this.OnDesignschemesgetbycolorsColor5BrightnessesDefaultParams(ref colors_color5_brightness);

            var items = this.context.DesignschemesgetbycolorsColor5Brightnesses.FromSqlRaw("EXEC [dbo].[DesignSchemesGetBycolors_color5_brightness] @colors_color5_brightness={0}", colors_color5_brightness).ToList().AsQueryable();

            this.OnDesignschemesgetbycolorsColor5BrightnessesInvoke(ref items);

            return Ok(items);
        }

        partial void OnDesignschemesgetbycolorsColor5BrightnessesDefaultParams(ref decimal? colors_color5_brightness);

        partial void OnDesignschemesgetbycolorsColor5BrightnessesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsColor5Brightness> items);
    }
}
