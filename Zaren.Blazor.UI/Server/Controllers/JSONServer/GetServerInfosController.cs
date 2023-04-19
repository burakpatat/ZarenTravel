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
    public partial class GetServerInfosController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public GetServerInfosController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/GetServerInfosFunc()")]
        public IActionResult GetServerInfosFunc()
        {
            this.OnGetServerInfosDefaultParams();

            var items = this.context.GetServerInfos.FromSqlRaw("EXEC [dbo].[GetServerInfo] ").ToList().AsQueryable();

            this.OnGetServerInfosInvoke(ref items);

            return Ok(items);
        }

        partial void OnGetServerInfosDefaultParams();

        partial void OnGetServerInfosInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.GetServerInfo> items);
    }
}
