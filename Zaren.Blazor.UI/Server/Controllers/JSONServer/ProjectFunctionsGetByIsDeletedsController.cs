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
    public partial class ProjectFunctionsGetByIsDeletedsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectFunctionsGetByIsDeletedsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectFunctionsGetByIsDeletedsFunc(IsDeleted={IsDeleted})")]
        public IActionResult ProjectFunctionsGetByIsDeletedsFunc([FromODataUri] bool? IsDeleted)
        {
            this.OnProjectFunctionsGetByIsDeletedsDefaultParams(ref IsDeleted);

            var items = this.context.ProjectFunctionsGetByIsDeleteds.FromSqlRaw("EXEC [dbo].[ProjectFunctionsGetByIsDeleted] @IsDeleted={0}", IsDeleted).ToList().AsQueryable();

            this.OnProjectFunctionsGetByIsDeletedsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectFunctionsGetByIsDeletedsDefaultParams(ref bool? IsDeleted);

        partial void OnProjectFunctionsGetByIsDeletedsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByIsDeleted> items);
    }
}
