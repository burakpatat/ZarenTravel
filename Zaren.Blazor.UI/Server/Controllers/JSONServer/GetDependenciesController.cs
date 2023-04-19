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
    public partial class GetDependenciesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public GetDependenciesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/GetDependenciesFunc(Schema={Schema},Table={Table},Column={Column})")]
        public IActionResult GetDependenciesFunc([FromODataUri] string Schema, [FromODataUri] string Table, [FromODataUri] string Column)
        {
            this.OnGetDependenciesDefaultParams(ref Schema, ref Table, ref Column);

            var items = this.context.GetDependencies.FromSqlRaw("EXEC [dbo].[GetDependencies] @Schema={0}, @Table={1}, @Column={2}", Schema, Table, Column).ToList().AsQueryable();

            this.OnGetDependenciesInvoke(ref items);

            return Ok(items);
        }

        partial void OnGetDependenciesDefaultParams(ref string Schema, ref string Table, ref string Column);

        partial void OnGetDependenciesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.GetDependency> items);
    }
}
