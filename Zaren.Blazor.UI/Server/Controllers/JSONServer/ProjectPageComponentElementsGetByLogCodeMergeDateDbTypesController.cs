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
    public partial class ProjectPageComponentElementsGetByLogCodeMergeDateDbTypesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentElementsGetByLogCodeMergeDateDbTypesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentElementsGetByLogCodeMergeDateDbTypesFunc(LogCodeMergeDateDBType={LogCodeMergeDateDBType})")]
        public IActionResult ProjectPageComponentElementsGetByLogCodeMergeDateDbTypesFunc([FromODataUri] int? LogCodeMergeDateDBType)
        {
            this.OnProjectPageComponentElementsGetByLogCodeMergeDateDbTypesDefaultParams(ref LogCodeMergeDateDBType);

            var items = this.context.ProjectPageComponentElementsGetByLogCodeMergeDateDbTypes.FromSqlRaw("EXEC [dbo].[ProjectPageComponentElementsGetByLogCodeMergeDateDBType] @LogCodeMergeDateDBType={0}", LogCodeMergeDateDBType).ToList().AsQueryable();

            this.OnProjectPageComponentElementsGetByLogCodeMergeDateDbTypesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentElementsGetByLogCodeMergeDateDbTypesDefaultParams(ref int? LogCodeMergeDateDBType);

        partial void OnProjectPageComponentElementsGetByLogCodeMergeDateDbTypesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByLogCodeMergeDateDbType> items);
    }
}
