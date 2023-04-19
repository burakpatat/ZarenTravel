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
    public partial class ProjectPageComponentElementsGetByStatusController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentElementsGetByStatusController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentElementsGetByStatusFunc(Statu={Statu})")]
        public IActionResult ProjectPageComponentElementsGetByStatusFunc([FromODataUri] int? Statu)
        {
            this.OnProjectPageComponentElementsGetByStatusDefaultParams(ref Statu);

            var items = this.context.ProjectPageComponentElementsGetByStatus.FromSqlRaw("EXEC [dbo].[ProjectPageComponentElementsGetByStatu] @Statu={0}", Statu).ToList().AsQueryable();

            this.OnProjectPageComponentElementsGetByStatusInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentElementsGetByStatusDefaultParams(ref int? Statu);

        partial void OnProjectPageComponentElementsGetByStatusInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByStatu> items);
    }
}
