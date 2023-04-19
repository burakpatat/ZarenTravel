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
    public partial class ProjectFunctionsGetByi18JsonsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectFunctionsGetByi18JsonsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectFunctionsGetByi18JsonsFunc(i18Json={i18Json})")]
        public IActionResult ProjectFunctionsGetByi18JsonsFunc([FromODataUri] string i18Json)
        {
            this.OnProjectFunctionsGetByi18JsonsDefaultParams(ref i18Json);

            var items = this.context.ProjectFunctionsGetByi18Jsons.FromSqlRaw("EXEC [dbo].[ProjectFunctionsGetByi18Json] @i18Json={0}", i18Json).ToList().AsQueryable();

            this.OnProjectFunctionsGetByi18JsonsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectFunctionsGetByi18JsonsDefaultParams(ref string i18Json);

        partial void OnProjectFunctionsGetByi18JsonsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByi18Json> items);
    }
}
