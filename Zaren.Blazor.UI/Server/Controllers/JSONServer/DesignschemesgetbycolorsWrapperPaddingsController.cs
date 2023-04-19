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
    public partial class DesignschemesgetbycolorsWrapperPaddingsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DesignschemesgetbycolorsWrapperPaddingsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DesignschemesgetbycolorsWrapperPaddingsFunc(colors_wrapper_padding={colors_wrapper_padding})")]
        public IActionResult DesignschemesgetbycolorsWrapperPaddingsFunc([FromODataUri] string colors_wrapper_padding)
        {
            this.OnDesignschemesgetbycolorsWrapperPaddingsDefaultParams(ref colors_wrapper_padding);

            var items = this.context.DesignschemesgetbycolorsWrapperPaddings.FromSqlRaw("EXEC [dbo].[DesignSchemesGetBycolors_wrapper_padding] @colors_wrapper_padding={0}", colors_wrapper_padding).ToList().AsQueryable();

            this.OnDesignschemesgetbycolorsWrapperPaddingsInvoke(ref items);

            return Ok(items);
        }

        partial void OnDesignschemesgetbycolorsWrapperPaddingsDefaultParams(ref string colors_wrapper_padding);

        partial void OnDesignschemesgetbycolorsWrapperPaddingsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsWrapperPadding> items);
    }
}
