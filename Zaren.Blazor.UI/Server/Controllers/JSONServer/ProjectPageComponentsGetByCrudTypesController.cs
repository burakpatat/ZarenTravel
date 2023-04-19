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
    public partial class ProjectPageComponentsGetByCrudTypesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentsGetByCrudTypesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentsGetByCrudTypesFunc(CrudType={CrudType})")]
        public IActionResult ProjectPageComponentsGetByCrudTypesFunc([FromODataUri] int? CrudType)
        {
            this.OnProjectPageComponentsGetByCrudTypesDefaultParams(ref CrudType);

            var items = this.context.ProjectPageComponentsGetByCrudTypes.FromSqlRaw("EXEC [dbo].[ProjectPageComponentsGetByCrudType] @CrudType={0}", CrudType).ToList().AsQueryable();

            this.OnProjectPageComponentsGetByCrudTypesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentsGetByCrudTypesDefaultParams(ref int? CrudType);

        partial void OnProjectPageComponentsGetByCrudTypesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByCrudType> items);
    }
}
