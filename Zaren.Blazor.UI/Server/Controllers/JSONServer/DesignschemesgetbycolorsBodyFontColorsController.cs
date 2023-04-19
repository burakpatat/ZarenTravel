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
    public partial class DesignschemesgetbycolorsBodyFontColorsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DesignschemesgetbycolorsBodyFontColorsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DesignschemesgetbycolorsBodyFontColorsFunc(colors_body_font_color={colors_body_font_color})")]
        public IActionResult DesignschemesgetbycolorsBodyFontColorsFunc([FromODataUri] string colors_body_font_color)
        {
            this.OnDesignschemesgetbycolorsBodyFontColorsDefaultParams(ref colors_body_font_color);

            var items = this.context.DesignschemesgetbycolorsBodyFontColors.FromSqlRaw("EXEC [dbo].[DesignSchemesGetBycolors_body_font_color] @colors_body_font_color={0}", colors_body_font_color).ToList().AsQueryable();

            this.OnDesignschemesgetbycolorsBodyFontColorsInvoke(ref items);

            return Ok(items);
        }

        partial void OnDesignschemesgetbycolorsBodyFontColorsDefaultParams(ref string colors_body_font_color);

        partial void OnDesignschemesgetbycolorsBodyFontColorsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsBodyFontColor> items);
    }
}
