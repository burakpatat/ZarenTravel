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
    public partial class DesignschemesgetbycolorsWrapperFontSizesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DesignschemesgetbycolorsWrapperFontSizesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DesignschemesgetbycolorsWrapperFontSizesFunc(colors_wrapper_font_size={colors_wrapper_font_size})")]
        public IActionResult DesignschemesgetbycolorsWrapperFontSizesFunc([FromODataUri] int? colors_wrapper_font_size)
        {
            this.OnDesignschemesgetbycolorsWrapperFontSizesDefaultParams(ref colors_wrapper_font_size);

            var items = this.context.DesignschemesgetbycolorsWrapperFontSizes.FromSqlRaw("EXEC [dbo].[DesignSchemesGetBycolors_wrapper_font_size] @colors_wrapper_font_size={0}", colors_wrapper_font_size).ToList().AsQueryable();

            this.OnDesignschemesgetbycolorsWrapperFontSizesInvoke(ref items);

            return Ok(items);
        }

        partial void OnDesignschemesgetbycolorsWrapperFontSizesDefaultParams(ref int? colors_wrapper_font_size);

        partial void OnDesignschemesgetbycolorsWrapperFontSizesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsWrapperFontSize> items);
    }
}
