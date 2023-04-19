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
    public partial class DynamicQueueListsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DynamicQueueListsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DynamicQueueListsFunc()")]
        public IActionResult DynamicQueueListsFunc()
        {
            this.OnDynamicQueueListsDefaultParams();

            var items = this.context.DynamicQueueLists.FromSqlRaw("EXEC [dbo].[DynamicQueueList] ").ToList().AsQueryable();

            this.OnDynamicQueueListsInvoke(ref items);

            return Ok(items);
        }

        partial void OnDynamicQueueListsDefaultParams();

        partial void OnDynamicQueueListsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DynamicQueueList> items);
    }
}
