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
    public partial class GetProcedureNamesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public GetProcedureNamesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/GetProcedureNamesFunc()")]
        public IActionResult GetProcedureNamesFunc()
        {
            this.OnGetProcedureNamesDefaultParams();

            var items = this.context.GetProcedureNames.FromSqlRaw("EXEC [dbo].[GetProcedureNames] ").ToList().AsQueryable();

            this.OnGetProcedureNamesInvoke(ref items);

            return Ok(items);
        }

        partial void OnGetProcedureNamesDefaultParams();

        partial void OnGetProcedureNamesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.GetProcedureName> items);
    }
}
