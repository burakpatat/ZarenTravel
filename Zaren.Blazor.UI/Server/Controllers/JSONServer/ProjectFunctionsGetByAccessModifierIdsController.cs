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
    public partial class ProjectFunctionsGetByAccessModifierIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectFunctionsGetByAccessModifierIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectFunctionsGetByAccessModifierIdsFunc(AccessModifierId={AccessModifierId})")]
        public IActionResult ProjectFunctionsGetByAccessModifierIdsFunc([FromODataUri] int? AccessModifierId)
        {
            this.OnProjectFunctionsGetByAccessModifierIdsDefaultParams(ref AccessModifierId);

            var items = this.context.ProjectFunctionsGetByAccessModifierIds.FromSqlRaw("EXEC [dbo].[ProjectFunctionsGetByAccessModifierId] @AccessModifierId={0}", AccessModifierId).ToList().AsQueryable();

            this.OnProjectFunctionsGetByAccessModifierIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectFunctionsGetByAccessModifierIdsDefaultParams(ref int? AccessModifierId);

        partial void OnProjectFunctionsGetByAccessModifierIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByAccessModifierId> items);
    }
}
