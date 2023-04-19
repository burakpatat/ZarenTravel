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
    public partial class ProjectPagesGetByHasFinishedSuccessfulliesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPagesGetByHasFinishedSuccessfulliesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPagesGetByHasFinishedSuccessfulliesFunc(HasFinishedSuccessfully={HasFinishedSuccessfully})")]
        public IActionResult ProjectPagesGetByHasFinishedSuccessfulliesFunc([FromODataUri] bool? HasFinishedSuccessfully)
        {
            this.OnProjectPagesGetByHasFinishedSuccessfulliesDefaultParams(ref HasFinishedSuccessfully);

            var items = this.context.ProjectPagesGetByHasFinishedSuccessfullies.FromSqlRaw("EXEC [dbo].[ProjectPagesGetByHasFinishedSuccessfully] @HasFinishedSuccessfully={0}", HasFinishedSuccessfully).ToList().AsQueryable();

            this.OnProjectPagesGetByHasFinishedSuccessfulliesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPagesGetByHasFinishedSuccessfulliesDefaultParams(ref bool? HasFinishedSuccessfully);

        partial void OnProjectPagesGetByHasFinishedSuccessfulliesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByHasFinishedSuccessfully> items);
    }
}
