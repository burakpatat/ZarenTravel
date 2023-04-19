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
    public partial class DesignschemesgetbycolorsBodyFontsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DesignschemesgetbycolorsBodyFontsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DesignschemesgetbycolorsBodyFontsFunc(colors_body_font={colors_body_font})")]
        public IActionResult DesignschemesgetbycolorsBodyFontsFunc([FromODataUri] string colors_body_font)
        {
            this.OnDesignschemesgetbycolorsBodyFontsDefaultParams(ref colors_body_font);

            var items = this.context.DesignschemesgetbycolorsBodyFonts.FromSqlRaw("EXEC [dbo].[DesignSchemesGetBycolors_body_font] @colors_body_font={0}", colors_body_font).ToList().AsQueryable();

            this.OnDesignschemesgetbycolorsBodyFontsInvoke(ref items);

            return Ok(items);
        }

        partial void OnDesignschemesgetbycolorsBodyFontsDefaultParams(ref string colors_body_font);

        partial void OnDesignschemesgetbycolorsBodyFontsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsBodyFont> items);
    }
}
