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
    public partial class DesignschemesgetbycolorsHeaderFontSizesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DesignschemesgetbycolorsHeaderFontSizesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DesignschemesgetbycolorsHeaderFontSizesFunc(colors_header_font_size={colors_header_font_size})")]
        public IActionResult DesignschemesgetbycolorsHeaderFontSizesFunc([FromODataUri] int? colors_header_font_size)
        {
            this.OnDesignschemesgetbycolorsHeaderFontSizesDefaultParams(ref colors_header_font_size);

            var items = this.context.DesignschemesgetbycolorsHeaderFontSizes.FromSqlRaw("EXEC [dbo].[DesignSchemesGetBycolors_header_font_size] @colors_header_font_size={0}", colors_header_font_size).ToList().AsQueryable();

            this.OnDesignschemesgetbycolorsHeaderFontSizesInvoke(ref items);

            return Ok(items);
        }

        partial void OnDesignschemesgetbycolorsHeaderFontSizesDefaultParams(ref int? colors_header_font_size);

        partial void OnDesignschemesgetbycolorsHeaderFontSizesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsHeaderFontSize> items);
    }
}
