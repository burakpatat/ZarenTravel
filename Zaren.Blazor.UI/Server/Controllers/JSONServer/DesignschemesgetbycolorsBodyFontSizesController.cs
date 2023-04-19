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
    public partial class DesignschemesgetbycolorsBodyFontSizesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DesignschemesgetbycolorsBodyFontSizesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DesignschemesgetbycolorsBodyFontSizesFunc(colors_body_font_size={colors_body_font_size})")]
        public IActionResult DesignschemesgetbycolorsBodyFontSizesFunc([FromODataUri] int? colors_body_font_size)
        {
            this.OnDesignschemesgetbycolorsBodyFontSizesDefaultParams(ref colors_body_font_size);

            var items = this.context.DesignschemesgetbycolorsBodyFontSizes.FromSqlRaw("EXEC [dbo].[DesignSchemesGetBycolors_body_font_size] @colors_body_font_size={0}", colors_body_font_size).ToList().AsQueryable();

            this.OnDesignschemesgetbycolorsBodyFontSizesInvoke(ref items);

            return Ok(items);
        }

        partial void OnDesignschemesgetbycolorsBodyFontSizesDefaultParams(ref int? colors_body_font_size);

        partial void OnDesignschemesgetbycolorsBodyFontSizesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsBodyFontSize> items);
    }
}
