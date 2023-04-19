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
    public partial class ProjectPageComponentsGetByHasFinishedSuccessfulliesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentsGetByHasFinishedSuccessfulliesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentsGetByHasFinishedSuccessfulliesFunc(HasFinishedSuccessfully={HasFinishedSuccessfully})")]
        public IActionResult ProjectPageComponentsGetByHasFinishedSuccessfulliesFunc([FromODataUri] bool? HasFinishedSuccessfully)
        {
            this.OnProjectPageComponentsGetByHasFinishedSuccessfulliesDefaultParams(ref HasFinishedSuccessfully);

            var items = this.context.ProjectPageComponentsGetByHasFinishedSuccessfullies.FromSqlRaw("EXEC [dbo].[ProjectPageComponentsGetByHasFinishedSuccessfully] @HasFinishedSuccessfully={0}", HasFinishedSuccessfully).ToList().AsQueryable();

            this.OnProjectPageComponentsGetByHasFinishedSuccessfulliesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentsGetByHasFinishedSuccessfulliesDefaultParams(ref bool? HasFinishedSuccessfully);

        partial void OnProjectPageComponentsGetByHasFinishedSuccessfulliesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByHasFinishedSuccessfully> items);
    }
}
