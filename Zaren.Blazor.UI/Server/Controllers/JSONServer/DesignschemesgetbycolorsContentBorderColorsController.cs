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
    public partial class DesignschemesgetbycolorsContentBorderColorsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DesignschemesgetbycolorsContentBorderColorsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DesignschemesgetbycolorsContentBorderColorsFunc(colors_content_border_color={colors_content_border_color})")]
        public IActionResult DesignschemesgetbycolorsContentBorderColorsFunc([FromODataUri] string colors_content_border_color)
        {
            this.OnDesignschemesgetbycolorsContentBorderColorsDefaultParams(ref colors_content_border_color);

            var items = this.context.DesignschemesgetbycolorsContentBorderColors.FromSqlRaw("EXEC [dbo].[DesignSchemesGetBycolors_content_border_color] @colors_content_border_color={0}", colors_content_border_color).ToList().AsQueryable();

            this.OnDesignschemesgetbycolorsContentBorderColorsInvoke(ref items);

            return Ok(items);
        }

        partial void OnDesignschemesgetbycolorsContentBorderColorsDefaultParams(ref string colors_content_border_color);

        partial void OnDesignschemesgetbycolorsContentBorderColorsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsContentBorderColor> items);
    }
}
