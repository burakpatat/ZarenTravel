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
    public partial class DesignschemesgetbycolorsColor4HexesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DesignschemesgetbycolorsColor4HexesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DesignschemesgetbycolorsColor4HexesFunc(colors_color4_hex={colors_color4_hex})")]
        public IActionResult DesignschemesgetbycolorsColor4HexesFunc([FromODataUri] int? colors_color4_hex)
        {
            this.OnDesignschemesgetbycolorsColor4HexesDefaultParams(ref colors_color4_hex);

            var items = this.context.DesignschemesgetbycolorsColor4Hexes.FromSqlRaw("EXEC [dbo].[DesignSchemesGetBycolors_color4_hex] @colors_color4_hex={0}", colors_color4_hex).ToList().AsQueryable();

            this.OnDesignschemesgetbycolorsColor4HexesInvoke(ref items);

            return Ok(items);
        }

        partial void OnDesignschemesgetbycolorsColor4HexesDefaultParams(ref int? colors_color4_hex);

        partial void OnDesignschemesgetbycolorsColor4HexesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsColor4Hex> items);
    }
}
