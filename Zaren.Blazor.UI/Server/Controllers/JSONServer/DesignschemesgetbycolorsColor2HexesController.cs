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
    public partial class DesignschemesgetbycolorsColor2HexesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DesignschemesgetbycolorsColor2HexesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DesignschemesgetbycolorsColor2HexesFunc(colors_color2_hex={colors_color2_hex})")]
        public IActionResult DesignschemesgetbycolorsColor2HexesFunc([FromODataUri] int? colors_color2_hex)
        {
            this.OnDesignschemesgetbycolorsColor2HexesDefaultParams(ref colors_color2_hex);

            var items = this.context.DesignschemesgetbycolorsColor2Hexes.FromSqlRaw("EXEC [dbo].[DesignSchemesGetBycolors_color2_hex] @colors_color2_hex={0}", colors_color2_hex).ToList().AsQueryable();

            this.OnDesignschemesgetbycolorsColor2HexesInvoke(ref items);

            return Ok(items);
        }

        partial void OnDesignschemesgetbycolorsColor2HexesDefaultParams(ref int? colors_color2_hex);

        partial void OnDesignschemesgetbycolorsColor2HexesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsColor2Hex> items);
    }
}
