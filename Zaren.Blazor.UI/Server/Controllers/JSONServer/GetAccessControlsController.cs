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
    public partial class GetAccessControlsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public GetAccessControlsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/GetAccessControlsFunc()")]
        public IActionResult GetAccessControlsFunc()
        {
            this.OnGetAccessControlsDefaultParams();

            var items = this.context.GetAccessControls.FromSqlRaw("EXEC [dbo].[GetAccessControl] ").ToList().AsQueryable();

            this.OnGetAccessControlsInvoke(ref items);

            return Ok(items);
        }

        partial void OnGetAccessControlsDefaultParams();

        partial void OnGetAccessControlsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.GetAccessControl> items);
    }
}
