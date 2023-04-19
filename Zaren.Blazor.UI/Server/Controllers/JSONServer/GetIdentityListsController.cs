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
    public partial class GetIdentityListsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public GetIdentityListsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/GetIdentityListsFunc()")]
        public IActionResult GetIdentityListsFunc()
        {
            this.OnGetIdentityListsDefaultParams();

            var items = this.context.GetIdentityLists.FromSqlRaw("EXEC [dbo].[GetIdentityList] ").ToList().AsQueryable();

            this.OnGetIdentityListsInvoke(ref items);

            return Ok(items);
        }

        partial void OnGetIdentityListsDefaultParams();

        partial void OnGetIdentityListsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.GetIdentityList> items);
    }
}
