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
    public partial class ProjectPageComponentElementsGetByIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentElementsGetByIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentElementsGetByIdsFunc(Id={Id})")]
        public IActionResult ProjectPageComponentElementsGetByIdsFunc([FromODataUri] int? Id)
        {
            this.OnProjectPageComponentElementsGetByIdsDefaultParams(ref Id);

            var items = this.context.ProjectPageComponentElementsGetByIds.FromSqlRaw("EXEC [dbo].[ProjectPageComponentElementsGetByID] @Id={0}", Id).ToList().AsQueryable();

            this.OnProjectPageComponentElementsGetByIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentElementsGetByIdsDefaultParams(ref int? Id);

        partial void OnProjectPageComponentElementsGetByIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetById> items);
    }
}
