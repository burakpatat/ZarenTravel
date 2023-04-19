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
    public partial class GetParameterNamesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public GetParameterNamesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/GetParameterNamesFunc(Procedure={Procedure})")]
        public IActionResult GetParameterNamesFunc([FromODataUri] string Procedure)
        {
            this.OnGetParameterNamesDefaultParams(ref Procedure);

            var items = this.context.GetParameterNames.FromSqlRaw("EXEC [dbo].[GetParameterNames] @Procedure={0}", Procedure).ToList().AsQueryable();

            this.OnGetParameterNamesInvoke(ref items);

            return Ok(items);
        }

        partial void OnGetParameterNamesDefaultParams(ref string Procedure);

        partial void OnGetParameterNamesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.GetParameterName> items);
    }
}
