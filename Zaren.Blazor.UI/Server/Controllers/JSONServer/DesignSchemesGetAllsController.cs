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
    public partial class DesignSchemesGetAllsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DesignSchemesGetAllsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DesignSchemesGetAllsFunc()")]
        public IActionResult DesignSchemesGetAllsFunc()
        {
            this.OnDesignSchemesGetAllsDefaultParams();

            var items = this.context.DesignSchemesGetAlls.FromSqlRaw("EXEC [dbo].[DesignSchemesGetAll] ").ToList().AsQueryable();

            this.OnDesignSchemesGetAllsInvoke(ref items);

            return Ok(items);
        }

        partial void OnDesignSchemesGetAllsDefaultParams();

        partial void OnDesignSchemesGetAllsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DesignSchemesGetAll> items);
    }
}
