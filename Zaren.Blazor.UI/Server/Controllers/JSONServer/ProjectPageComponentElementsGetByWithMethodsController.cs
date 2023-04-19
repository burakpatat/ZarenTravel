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
    public partial class ProjectPageComponentElementsGetByWithMethodsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentElementsGetByWithMethodsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentElementsGetByWithMethodsFunc(WithMethods={WithMethods})")]
        public IActionResult ProjectPageComponentElementsGetByWithMethodsFunc([FromODataUri] string WithMethods)
        {
            this.OnProjectPageComponentElementsGetByWithMethodsDefaultParams(ref WithMethods);

            var items = this.context.ProjectPageComponentElementsGetByWithMethods.FromSqlRaw("EXEC [dbo].[ProjectPageComponentElementsGetByWithMethods] @WithMethods={0}", WithMethods).ToList().AsQueryable();

            this.OnProjectPageComponentElementsGetByWithMethodsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentElementsGetByWithMethodsDefaultParams(ref string WithMethods);

        partial void OnProjectPageComponentElementsGetByWithMethodsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByWithMethod> items);
    }
}
