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
    public partial class GetReturnParameterNamesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public GetReturnParameterNamesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/GetReturnParameterNamesFunc(ProcedureName={ProcedureName})")]
        public IActionResult GetReturnParameterNamesFunc([FromODataUri] string ProcedureName)
        {
            this.OnGetReturnParameterNamesDefaultParams(ref ProcedureName);

            var items = this.context.GetReturnParameterNames.FromSqlRaw("EXEC [dbo].[GetReturnParameterNames] @ProcedureName={0}", ProcedureName).ToList().AsQueryable();

            this.OnGetReturnParameterNamesInvoke(ref items);

            return Ok(items);
        }

        partial void OnGetReturnParameterNamesDefaultParams(ref string ProcedureName);

        partial void OnGetReturnParameterNamesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.GetReturnParameterName> items);
    }
}
