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
    public partial class ProjectFunctionsGetByStatusController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectFunctionsGetByStatusController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectFunctionsGetByStatusFunc(Statu={Statu})")]
        public IActionResult ProjectFunctionsGetByStatusFunc([FromODataUri] int? Statu)
        {
            this.OnProjectFunctionsGetByStatusDefaultParams(ref Statu);

            var items = this.context.ProjectFunctionsGetByStatus.FromSqlRaw("EXEC [dbo].[ProjectFunctionsGetByStatu] @Statu={0}", Statu).ToList().AsQueryable();

            this.OnProjectFunctionsGetByStatusInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectFunctionsGetByStatusDefaultParams(ref int? Statu);

        partial void OnProjectFunctionsGetByStatusInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByStatu> items);
    }
}
