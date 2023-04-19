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
    public partial class DesignschemesgetbycolorsColor1IsdarksController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DesignschemesgetbycolorsColor1IsdarksController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DesignschemesgetbycolorsColor1IsdarksFunc(colors_color1_isDark={colors_color1_isDark})")]
        public IActionResult DesignschemesgetbycolorsColor1IsdarksFunc([FromODataUri] string colors_color1_isDark)
        {
            this.OnDesignschemesgetbycolorsColor1IsdarksDefaultParams(ref colors_color1_isDark);

            var items = this.context.DesignschemesgetbycolorsColor1Isdarks.FromSqlRaw("EXEC [dbo].[DesignSchemesGetBycolors_color1_isDark] @colors_color1_isDark={0}", colors_color1_isDark).ToList().AsQueryable();

            this.OnDesignschemesgetbycolorsColor1IsdarksInvoke(ref items);

            return Ok(items);
        }

        partial void OnDesignschemesgetbycolorsColor1IsdarksDefaultParams(ref string colors_color1_isDark);

        partial void OnDesignschemesgetbycolorsColor1IsdarksInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsColor1Isdark> items);
    }
}
