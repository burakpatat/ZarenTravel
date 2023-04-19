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
    public partial class ProjectFunctionsGetByCrudTypesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectFunctionsGetByCrudTypesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectFunctionsGetByCrudTypesFunc(CrudType={CrudType})")]
        public IActionResult ProjectFunctionsGetByCrudTypesFunc([FromODataUri] int? CrudType)
        {
            this.OnProjectFunctionsGetByCrudTypesDefaultParams(ref CrudType);

            var items = this.context.ProjectFunctionsGetByCrudTypes.FromSqlRaw("EXEC [dbo].[ProjectFunctionsGetByCrudType] @CrudType={0}", CrudType).ToList().AsQueryable();

            this.OnProjectFunctionsGetByCrudTypesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectFunctionsGetByCrudTypesDefaultParams(ref int? CrudType);

        partial void OnProjectFunctionsGetByCrudTypesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByCrudType> items);
    }
}
