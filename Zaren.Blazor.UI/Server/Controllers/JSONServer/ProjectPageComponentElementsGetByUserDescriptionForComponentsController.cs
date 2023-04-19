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
    public partial class ProjectPageComponentElementsGetByUserDescriptionForComponentsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentElementsGetByUserDescriptionForComponentsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentElementsGetByUserDescriptionForComponentsFunc(UserDescriptionForComponent={UserDescriptionForComponent})")]
        public IActionResult ProjectPageComponentElementsGetByUserDescriptionForComponentsFunc([FromODataUri] string UserDescriptionForComponent)
        {
            this.OnProjectPageComponentElementsGetByUserDescriptionForComponentsDefaultParams(ref UserDescriptionForComponent);

            var items = this.context.ProjectPageComponentElementsGetByUserDescriptionForComponents.FromSqlRaw("EXEC [dbo].[ProjectPageComponentElementsGetByUserDescriptionForComponent] @UserDescriptionForComponent={0}", UserDescriptionForComponent).ToList().AsQueryable();

            this.OnProjectPageComponentElementsGetByUserDescriptionForComponentsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentElementsGetByUserDescriptionForComponentsDefaultParams(ref string UserDescriptionForComponent);

        partial void OnProjectPageComponentElementsGetByUserDescriptionForComponentsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByUserDescriptionForComponent> items);
    }
}
