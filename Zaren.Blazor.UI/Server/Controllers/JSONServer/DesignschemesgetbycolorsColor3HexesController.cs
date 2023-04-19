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
    public partial class DesignschemesgetbycolorsColor3HexesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DesignschemesgetbycolorsColor3HexesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DesignschemesgetbycolorsColor3HexesFunc(colors_color3_hex={colors_color3_hex})")]
        public IActionResult DesignschemesgetbycolorsColor3HexesFunc([FromODataUri] int? colors_color3_hex)
        {
            this.OnDesignschemesgetbycolorsColor3HexesDefaultParams(ref colors_color3_hex);

            var items = this.context.DesignschemesgetbycolorsColor3Hexes.FromSqlRaw("EXEC [dbo].[DesignSchemesGetBycolors_color3_hex] @colors_color3_hex={0}", colors_color3_hex).ToList().AsQueryable();

            this.OnDesignschemesgetbycolorsColor3HexesInvoke(ref items);

            return Ok(items);
        }

        partial void OnDesignschemesgetbycolorsColor3HexesDefaultParams(ref int? colors_color3_hex);

        partial void OnDesignschemesgetbycolorsColor3HexesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsColor3Hex> items);
    }
}
