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
    public partial class DesignschemesgetbycolorsColor3BrightnessesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DesignschemesgetbycolorsColor3BrightnessesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DesignschemesgetbycolorsColor3BrightnessesFunc(colors_color3_brightness={colors_color3_brightness})")]
        public IActionResult DesignschemesgetbycolorsColor3BrightnessesFunc([FromODataUri] decimal? colors_color3_brightness)
        {
            this.OnDesignschemesgetbycolorsColor3BrightnessesDefaultParams(ref colors_color3_brightness);

            var items = this.context.DesignschemesgetbycolorsColor3Brightnesses.FromSqlRaw("EXEC [dbo].[DesignSchemesGetBycolors_color3_brightness] @colors_color3_brightness={0}", colors_color3_brightness).ToList().AsQueryable();

            this.OnDesignschemesgetbycolorsColor3BrightnessesInvoke(ref items);

            return Ok(items);
        }

        partial void OnDesignschemesgetbycolorsColor3BrightnessesDefaultParams(ref decimal? colors_color3_brightness);

        partial void OnDesignschemesgetbycolorsColor3BrightnessesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsColor3Brightness> items);
    }
}
