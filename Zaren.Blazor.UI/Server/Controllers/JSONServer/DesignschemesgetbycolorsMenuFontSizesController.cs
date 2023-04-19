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
    public partial class DesignschemesgetbycolorsMenuFontSizesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DesignschemesgetbycolorsMenuFontSizesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DesignschemesgetbycolorsMenuFontSizesFunc(colors_menu_font_size={colors_menu_font_size})")]
        public IActionResult DesignschemesgetbycolorsMenuFontSizesFunc([FromODataUri] int? colors_menu_font_size)
        {
            this.OnDesignschemesgetbycolorsMenuFontSizesDefaultParams(ref colors_menu_font_size);

            var items = this.context.DesignschemesgetbycolorsMenuFontSizes.FromSqlRaw("EXEC [dbo].[DesignSchemesGetBycolors_menu_font_size] @colors_menu_font_size={0}", colors_menu_font_size).ToList().AsQueryable();

            this.OnDesignschemesgetbycolorsMenuFontSizesInvoke(ref items);

            return Ok(items);
        }

        partial void OnDesignschemesgetbycolorsMenuFontSizesDefaultParams(ref int? colors_menu_font_size);

        partial void OnDesignschemesgetbycolorsMenuFontSizesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsMenuFontSize> items);
    }
}
