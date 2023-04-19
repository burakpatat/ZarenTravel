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
    public partial class DesignschemesgetbycolorsColor5HexesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DesignschemesgetbycolorsColor5HexesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DesignschemesgetbycolorsColor5HexesFunc(colors_color5_hex={colors_color5_hex})")]
        public IActionResult DesignschemesgetbycolorsColor5HexesFunc([FromODataUri] int? colors_color5_hex)
        {
            this.OnDesignschemesgetbycolorsColor5HexesDefaultParams(ref colors_color5_hex);

            var items = this.context.DesignschemesgetbycolorsColor5Hexes.FromSqlRaw("EXEC [dbo].[DesignSchemesGetBycolors_color5_hex] @colors_color5_hex={0}", colors_color5_hex).ToList().AsQueryable();

            this.OnDesignschemesgetbycolorsColor5HexesInvoke(ref items);

            return Ok(items);
        }

        partial void OnDesignschemesgetbycolorsColor5HexesDefaultParams(ref int? colors_color5_hex);

        partial void OnDesignschemesgetbycolorsColor5HexesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsColor5Hex> items);
    }
}
