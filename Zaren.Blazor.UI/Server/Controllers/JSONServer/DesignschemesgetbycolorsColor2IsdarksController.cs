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
    public partial class DesignschemesgetbycolorsColor2IsdarksController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DesignschemesgetbycolorsColor2IsdarksController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DesignschemesgetbycolorsColor2IsdarksFunc(colors_color2_isDark={colors_color2_isDark})")]
        public IActionResult DesignschemesgetbycolorsColor2IsdarksFunc([FromODataUri] string colors_color2_isDark)
        {
            this.OnDesignschemesgetbycolorsColor2IsdarksDefaultParams(ref colors_color2_isDark);

            var items = this.context.DesignschemesgetbycolorsColor2Isdarks.FromSqlRaw("EXEC [dbo].[DesignSchemesGetBycolors_color2_isDark] @colors_color2_isDark={0}", colors_color2_isDark).ToList().AsQueryable();

            this.OnDesignschemesgetbycolorsColor2IsdarksInvoke(ref items);

            return Ok(items);
        }

        partial void OnDesignschemesgetbycolorsColor2IsdarksDefaultParams(ref string colors_color2_isDark);

        partial void OnDesignschemesgetbycolorsColor2IsdarksInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsColor2Isdark> items);
    }
}
