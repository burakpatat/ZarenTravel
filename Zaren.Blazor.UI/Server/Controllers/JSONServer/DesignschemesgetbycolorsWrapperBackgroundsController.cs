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
    public partial class DesignschemesgetbycolorsWrapperBackgroundsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DesignschemesgetbycolorsWrapperBackgroundsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DesignschemesgetbycolorsWrapperBackgroundsFunc(colors_wrapper_background={colors_wrapper_background})")]
        public IActionResult DesignschemesgetbycolorsWrapperBackgroundsFunc([FromODataUri] string colors_wrapper_background)
        {
            this.OnDesignschemesgetbycolorsWrapperBackgroundsDefaultParams(ref colors_wrapper_background);

            var items = this.context.DesignschemesgetbycolorsWrapperBackgrounds.FromSqlRaw("EXEC [dbo].[DesignSchemesGetBycolors_wrapper_background] @colors_wrapper_background={0}", colors_wrapper_background).ToList().AsQueryable();

            this.OnDesignschemesgetbycolorsWrapperBackgroundsInvoke(ref items);

            return Ok(items);
        }

        partial void OnDesignschemesgetbycolorsWrapperBackgroundsDefaultParams(ref string colors_wrapper_background);

        partial void OnDesignschemesgetbycolorsWrapperBackgroundsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsWrapperBackground> items);
    }
}
