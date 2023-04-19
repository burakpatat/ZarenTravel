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
    public partial class ProjectFunctionsGetByLogCodeMergeDateDbTypesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectFunctionsGetByLogCodeMergeDateDbTypesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectFunctionsGetByLogCodeMergeDateDbTypesFunc(LogCodeMergeDateDBType={LogCodeMergeDateDBType})")]
        public IActionResult ProjectFunctionsGetByLogCodeMergeDateDbTypesFunc([FromODataUri] int? LogCodeMergeDateDBType)
        {
            this.OnProjectFunctionsGetByLogCodeMergeDateDbTypesDefaultParams(ref LogCodeMergeDateDBType);

            var items = this.context.ProjectFunctionsGetByLogCodeMergeDateDbTypes.FromSqlRaw("EXEC [dbo].[ProjectFunctionsGetByLogCodeMergeDateDBType] @LogCodeMergeDateDBType={0}", LogCodeMergeDateDBType).ToList().AsQueryable();

            this.OnProjectFunctionsGetByLogCodeMergeDateDbTypesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectFunctionsGetByLogCodeMergeDateDbTypesDefaultParams(ref int? LogCodeMergeDateDBType);

        partial void OnProjectFunctionsGetByLogCodeMergeDateDbTypesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByLogCodeMergeDateDbType> items);
    }
}
