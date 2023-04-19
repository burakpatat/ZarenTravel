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
    public partial class ProjectFunctionsGetByIfResponseIsSuccessCallThisFunctionIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectFunctionsGetByIfResponseIsSuccessCallThisFunctionIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectFunctionsGetByIfResponseIsSuccessCallThisFunctionIdsFunc(IfResponseIsSuccessCallThisFunctionId={IfResponseIsSuccessCallThisFunctionId})")]
        public IActionResult ProjectFunctionsGetByIfResponseIsSuccessCallThisFunctionIdsFunc([FromODataUri] int? IfResponseIsSuccessCallThisFunctionId)
        {
            this.OnProjectFunctionsGetByIfResponseIsSuccessCallThisFunctionIdsDefaultParams(ref IfResponseIsSuccessCallThisFunctionId);

            var items = this.context.ProjectFunctionsGetByIfResponseIsSuccessCallThisFunctionIds.FromSqlRaw("EXEC [dbo].[ProjectFunctionsGetByIfResponseIsSuccessCallThisFunctionId] @IfResponseIsSuccessCallThisFunctionId={0}", IfResponseIsSuccessCallThisFunctionId).ToList().AsQueryable();

            this.OnProjectFunctionsGetByIfResponseIsSuccessCallThisFunctionIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectFunctionsGetByIfResponseIsSuccessCallThisFunctionIdsDefaultParams(ref int? IfResponseIsSuccessCallThisFunctionId);

        partial void OnProjectFunctionsGetByIfResponseIsSuccessCallThisFunctionIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByIfResponseIsSuccessCallThisFunctionId> items);
    }
}
