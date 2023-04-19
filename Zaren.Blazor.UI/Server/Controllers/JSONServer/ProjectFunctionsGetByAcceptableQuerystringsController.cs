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
    public partial class ProjectFunctionsGetByAcceptableQuerystringsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectFunctionsGetByAcceptableQuerystringsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectFunctionsGetByAcceptableQuerystringsFunc(AcceptableQuerystrings={AcceptableQuerystrings})")]
        public IActionResult ProjectFunctionsGetByAcceptableQuerystringsFunc([FromODataUri] string AcceptableQuerystrings)
        {
            this.OnProjectFunctionsGetByAcceptableQuerystringsDefaultParams(ref AcceptableQuerystrings);

            var items = this.context.ProjectFunctionsGetByAcceptableQuerystrings.FromSqlRaw("EXEC [dbo].[ProjectFunctionsGetByAcceptableQuerystrings] @AcceptableQuerystrings={0}", AcceptableQuerystrings).ToList().AsQueryable();

            this.OnProjectFunctionsGetByAcceptableQuerystringsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectFunctionsGetByAcceptableQuerystringsDefaultParams(ref string AcceptableQuerystrings);

        partial void OnProjectFunctionsGetByAcceptableQuerystringsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByAcceptableQuerystring> items);
    }
}
