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
    public partial class DesignschemesgetbycolorsContentTextColorsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DesignschemesgetbycolorsContentTextColorsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DesignschemesgetbycolorsContentTextColorsFunc(colors_content_text_color={colors_content_text_color})")]
        public IActionResult DesignschemesgetbycolorsContentTextColorsFunc([FromODataUri] string colors_content_text_color)
        {
            this.OnDesignschemesgetbycolorsContentTextColorsDefaultParams(ref colors_content_text_color);

            var items = this.context.DesignschemesgetbycolorsContentTextColors.FromSqlRaw("EXEC [dbo].[DesignSchemesGetBycolors_content_text_color] @colors_content_text_color={0}", colors_content_text_color).ToList().AsQueryable();

            this.OnDesignschemesgetbycolorsContentTextColorsInvoke(ref items);

            return Ok(items);
        }

        partial void OnDesignschemesgetbycolorsContentTextColorsDefaultParams(ref string colors_content_text_color);

        partial void OnDesignschemesgetbycolorsContentTextColorsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsContentTextColor> items);
    }
}
