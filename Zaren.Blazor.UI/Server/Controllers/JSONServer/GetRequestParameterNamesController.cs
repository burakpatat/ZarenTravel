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
    public partial class GetRequestParameterNamesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public GetRequestParameterNamesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/GetRequestParameterNamesFunc()")]
        public IActionResult GetRequestParameterNamesFunc()
        {
            this.OnGetRequestParameterNamesDefaultParams();

            var items = this.context.GetRequestParameterNames.FromSqlRaw("EXEC [dbo].[GetRequestParameterNames] ").ToList().AsQueryable();

            this.OnGetRequestParameterNamesInvoke(ref items);

            return Ok(items);
        }

        partial void OnGetRequestParameterNamesDefaultParams();

        partial void OnGetRequestParameterNamesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.GetRequestParameterName> items);
    }
}
