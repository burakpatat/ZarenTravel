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
    public partial class GetViewListsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public GetViewListsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/GetViewListsFunc()")]
        public IActionResult GetViewListsFunc()
        {
            this.OnGetViewListsDefaultParams();

            var items = this.context.GetViewLists.FromSqlRaw("EXEC [dbo].[GetViewList] ").ToList().AsQueryable();

            this.OnGetViewListsInvoke(ref items);

            return Ok(items);
        }

        partial void OnGetViewListsDefaultParams();

        partial void OnGetViewListsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.GetViewList> items);
    }
}
