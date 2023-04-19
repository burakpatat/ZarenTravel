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
    public partial class ProjectFunctionsGetBySoftwareLanguageIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectFunctionsGetBySoftwareLanguageIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectFunctionsGetBySoftwareLanguageIdsFunc(SoftwareLanguageId={SoftwareLanguageId})")]
        public IActionResult ProjectFunctionsGetBySoftwareLanguageIdsFunc([FromODataUri] int? SoftwareLanguageId)
        {
            this.OnProjectFunctionsGetBySoftwareLanguageIdsDefaultParams(ref SoftwareLanguageId);

            var items = this.context.ProjectFunctionsGetBySoftwareLanguageIds.FromSqlRaw("EXEC [dbo].[ProjectFunctionsGetBySoftwareLanguageId] @SoftwareLanguageId={0}", SoftwareLanguageId).ToList().AsQueryable();

            this.OnProjectFunctionsGetBySoftwareLanguageIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectFunctionsGetBySoftwareLanguageIdsDefaultParams(ref int? SoftwareLanguageId);

        partial void OnProjectFunctionsGetBySoftwareLanguageIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetBySoftwareLanguageId> items);
    }
}
