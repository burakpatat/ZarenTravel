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
    public partial class ProjectPageComponentElementsGetByCrudTypesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentElementsGetByCrudTypesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentElementsGetByCrudTypesFunc(CrudType={CrudType})")]
        public IActionResult ProjectPageComponentElementsGetByCrudTypesFunc([FromODataUri] int? CrudType)
        {
            this.OnProjectPageComponentElementsGetByCrudTypesDefaultParams(ref CrudType);

            var items = this.context.ProjectPageComponentElementsGetByCrudTypes.FromSqlRaw("EXEC [dbo].[ProjectPageComponentElementsGetByCrudType] @CrudType={0}", CrudType).ToList().AsQueryable();

            this.OnProjectPageComponentElementsGetByCrudTypesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentElementsGetByCrudTypesDefaultParams(ref int? CrudType);

        partial void OnProjectPageComponentElementsGetByCrudTypesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByCrudType> items);
    }
}
